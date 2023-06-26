sap.ui.define(
  [
    "sap/ui/core/mvc/Controller",
    "sap/ui/core/routing/History",
    "sap/ui/model/json/JSONModel",
    "sap/m/MessageBox",
    "../servicos/Validacoes",
  ],
  function (Controller, History, JSONModel, MessageBox, Validacoes) {
    "use strict";

    return Controller.extend(
      "controleDeFuncionarios.Controller.CadastroDeFuncionarios",
      {
        onInit: function () {
          let rota = this.getOwnerComponent().getRouter();
          rota
            .getRoute("cadastroDeFuncionarios")
            .attachPatternMatched(
              this._rotaCorrespondidaCadastroFuncionario,
              this
            );
          rota
            .getRoute("edicao")
            .attachPatternMatched(this._rotaCorrespondidaEdicao, this);
        },

        _rotaCorrespondidaCadastroFuncionario: function () {
          let dadosFuncionario = {
            nome: "",
            endereco: "",
            cpf: "",
            telefone: "",
            dataNascimento: "",
            dataAdmissao: "",
          };

          let jsonFuncionario = new JSONModel(dadosFuncionario);
          this.getView().setModel(jsonFuncionario, "funcionario");

          this._limparFormulario();
        },

        _rotaCorrespondidaEdicao: function (Evento) {
          let camposFormulario = [
            "inputNome",
            "inputEndereco",
            "inputCPF",
            "inputCPF",
            "inputTelefone",
            "inputDataNascimento",
            "inputDataAdmissao",
          ];

          camposFormulario.forEach((res) => {
            let campo = this.getView().byId(res);
            campo.setValueState("Success");
          });

          let id = Evento.getParameter("arguments").id;
          this._obterFuncionarioPorId(id);
        },

        _obterFuncionarioPorId: function (id) {
          let funcionario = this.getView();

          fetch(`/api/Funcionario/${id}`)
            .then((response) => response.json())
            .then((data) => {
              data.dataNascimento = new Date(data.dataNascimento);
              data.dataAdmissao = new Date(data.dataAdmissao);
              funcionario.setModel(new JSONModel(data), "funcionario");
            })
            .catch((error) => {
              console.error(error);
            });
        },

        _cadastrarNovoFuncionario: function () {
          let funcionario = this.getView().getModel("funcionario").getData();

          return fetch("/api/Funcionario", {
            method: "POST",
            headers: {
              "Content-type": "application/json",
            },

            body: JSON.stringify(funcionario),
          });
        },

        _editarFuncionario: function (id) {
          let funcionario = this.getView().getModel("funcionario").getData();
          id = funcionario.id;

          return fetch(`/api/Funcionario/${id}`, {
            method: "PUT",
            headers: {
              "Content-type": "application/json",
            },

            body: JSON.stringify(funcionario),
          });
        },

        _clicarEmSalvar: function () {
          let funcionario = this.getView().getModel("funcionario").getData();
          let id = funcionario.id;

          if (id) {
            this._editarFuncionario(id)
              .then((res) => {
                if (res.status !== 200) {
                  return res.text();
                }
                return res.json();
              })
              .then((res) => {
                if (typeof res === "string") {
                  MessageBox.error(`${res}`, {
                    emphasizedAction: MessageBox.Action.CLOSE,
                  });
                } else {
                  MessageBox.success(
                    `Funcionario ${funcionario.nome} atualizado com sucesso !`,
                    {
                      emphasizedAction: MessageBox.Action.OK,
                      title: "Sucesso",
                      actions: [MessageBox.Action.OK],
                      onClose: (acao) => {
                        if (acao === MessageBox.Action.OK) {
                          this._limparFormulario();
                          this._navegarParaDetalhes(res);
                        }
                      },
                    }
                  );
                }
              });
          } else {
            this._cadastrarNovoFuncionario()
              .then((res) => {
                if (res.status !== 200) {
                  return res.text();
                }
                return res.json();
              })
              .then((res) => {
                if (typeof res === "string") {
                  MessageBox.error(`Erro ao cadastrar Funcionário`, {
                    emphasizedAction: MessageBox.Action.CLOSE,
                  });
                } else {
                  MessageBox.success(`Funcionario ${funcionario.nome} cadastrado com sucesso !`, {
                    emphasizedAction: MessageBox.Action.OK,
                    title: "Sucesso",
                    actions: [MessageBox.Action.OK],
                    onClose: (acao) => {
                      if (acao === MessageBox.Action.OK) {
                        this._limparFormulario();
                        this._navegarParaDetalhes(res);
                      }
                    },
                  });
                }
              });
          }
        },

        _navegarParaDetalhes: function (id) {
          let rota = this.getOwnerComponent().getRouter();
          rota.navTo("detalhes", { id: id });
        },
        _obterControle: function (id) {
          return this.getView().byId(id);
        },

        _limparFormulario: function () {
          let nome = this._obterControle("inputNome");
          let endereco = this._obterControle("inputEndereco");
          let cpf = this._obterControle("inputCPF");
          let telefone = this._obterControle("inputTelefone");
          let dataNascimento = this._obterControle("inputDataNascimento");
          let dataAdmissao = this._obterControle("inputDataAdmissao");

          nome.setValue("");
          endereco.setValue("");
          cpf.setValue("");
          telefone.setValue("");
          dataNascimento.setValue("");
          dataAdmissao.setValue("");
        },

        _clicarEmCancelar: function () {
          MessageBox.alert("Deseja cancelar o cadastro ?", {
            icon: MessageBox.Icon.WARNING,
            actions: [MessageBox.Action.YES, MessageBox.Action.NO],
            onClose: (seOk) => {
              if (seOk == MessageBox.Action.YES) {
                this._voltarTela();
                this._limparFormulario();
              }
            },
          });
        },

        _exibirMensagensErro: function (
          errosNome,
          errosEndereco,
          errosDataNascimento,
          errosCpf,
          errosTelefone,
          errosDataAdmissao
        ) {
          let campoNome = this._obterControle("inputNome");
          Validacoes.mensagensErro(campoNome, errosNome);

          let campoEndereco = this._obterControle("inputEndereco");
          Validacoes.mensagensErro(campoEndereco, errosEndereco);

          let campoDataNascimento = this._obterControle("inputDataNascimento");
          Validacoes.mensagensErro(campoDataNascimento, errosDataNascimento);

          let campoCpf = this._obterControle("inputCPF");
          Validacoes.mensagensErro(campoCpf, errosCpf);

          let campoTelefone = this._obterControle("inputTelefone");
          Validacoes.mensagensErro(campoTelefone, errosTelefone);

          let campoDataAdmissao = this._obterControle("inputDataAdmissao");
          Validacoes.mensagensErro(campoDataAdmissao, errosDataAdmissao);
        },

        _alterarEstadoCampos: function (estado) {
          let campoNome = this.byId("inputNome");
          let campoEndereco = this.byId("inputEndereco");
          let campoCpf = this.byId("inputCPF");
          let campoTelefone = this.byId("inputTelefone");
          let campoDataNascimento = this.byId("inputDataNascimento");
          let campoDataAdmissao = this.byId("inputDataAdmissao");
          let campos = [
            campoNome,
            campoEndereco,
            campoCpf,
            campoDataNascimento,
            campoDataAdmissao,
            campoTelefone,
          ];

          campos.forEach((campo) => {
            campo.setValueState(estado);

            if (estado === "None") campo.setValue("");

            if (estado === "Error" && campo !== campoDataNascimento)
              campo.setValueStateText("Esse campo não pode ser vazio");
          });
        },
        _funcionarioEhValido() {
          let funcionario = this.getView().getModel("funcionario").getData();

          let errosNome = Validacoes.validarCampoNome(funcionario.nome);
          let errosEndereco = Validacoes.validarCampoEndereco(
            funcionario.endereco
          );
          let errosDataNascimento = Validacoes.validarCampoDataNascimento(
            funcionario.dataNascimento
          );
          let errosCpf = Validacoes.validarCampoCpf(funcionario.cpf);
          let errosTelefone = Validacoes.validarCampoTelefone(
            funcionario.telefone
          );
          let errosDataAdmissao = Validacoes.validarCampoDataAdmissao(
            funcionario.dataAdmissao
          );

          if (
            errosNome.length > 0 ||
            errosCpf.length > 0 ||
            errosDataNascimento.length > 0 ||
            errosEndereco.length > 0 ||
            errosTelefone.length > 0 ||
            errosDataAdmissao.length > 0
          ) {
            this._exibirMensagensErro(
              errosNome,
              errosEndereco,
              errosDataNascimento,
              errosCpf,
              errosTelefone,
              errosDataAdmissao
            );
            return false;
          }

          return true;
        },

        _voltarTela: function () {
          let historico = History.getInstance();
          let paginaAnterior = historico.getPreviousHash();

          this._alterarEstadoCampos("None");
          if (paginaAnterior !== undefined) {
            window.history.go(-1);
          } else {
            let rota = this.getOwnerComponent().getRouter();
            rota.navTo("listaTelaInicial");
          }
        },
      }
    );
  }
);
