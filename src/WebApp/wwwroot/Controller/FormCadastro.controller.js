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

    return Controller.extend("controleDeFuncionarios.Controller.FormCadastro", {
      onInit: function () {
        var rota = sap.ui.core.UIComponent.getRouterFor(this);
        rota.attachRoutePatternMatched(this._rotaCorrespondida, this);
      },

      _rotaCorrespondida: function () {
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

        this.limparFormulario();
      },

      limparFormulario: function () {
        let Nome = this.getView().byId("inputNome");
        let Endereco = this.getView().byId("inputEndereco");
        let Cpf = this.getView().byId("inputCPF");
        let Telefone = this.getView().byId("inputTelefone");
        let DataNascimento = this.getView().byId("inputDataNascimento");
        let DataAdmissao = this.getView().byId("inputDataAdmissao");

        Nome.setValue("");
        Endereco.setValue("");
        Cpf.setValue("");
        Telefone.setValue("");
        DataNascimento.setValue("");
        DataAdmissao.setValue("");
      },

      clicarEmSalvar: function () {
        let funcionario = this.getView().getModel("funcionario").getData();

        let erros = {};
        erros.nome = Validacoes.validarCampoNome(funcionario.nome);
        erros.endereco = Validacoes.validarCampoEndereco(funcionario.endereco);
        erros.dataNascimento = Validacoes.validarCampoDataNascimento(
          funcionario.dataNascimento
        );
        erros.cpf = Validacoes.validarCampoCpf(funcionario.cpf);
        erros.telefone = Validacoes.validarCampoTelefone(funcionario.telefone);
        erros.dataAdmissao = Validacoes.validarCampoDataAdmissao(
          funcionario.dataAdmissao
        );

        let errors = false;
        for (let campo in erros) {
          if (erros[campo].length > 0) {
            errors = true;
            break;
          }
        }

        if (errors) {
          this.exibirMensagensErro(
            erros.nome,
            erros.endereco,
            erros.dataNascimento,
            erros.cpf,
            erros.telefone,
            erros.dataAdmissao
          );
          return;
        }

        fetch("/api/Funcionario", {
          method: "POST",
          headers: {
            "Content-type": "application/json",
          },
          body: JSON.stringify(funcionario),
        })
          .then(function (res) {
            return res.json();
          })
          .then(function (res) {
            if (res.status == 400) {
              MessageBox.error("OPS! Erro ao cadastrar Funcionário");
            } else {
              MessageBox.success("Funcionário cadastrado com sucesso!", {
                title: "Sucesso",
                actions: [MessageBox.Action.OK],
                onClose: function (seOk) {
                  if (seOk == MessageBox.Action.OK) {
                    this.limparFormulario();
                    this.navegarParaDetalhes(res);
                  }
                },
              });
            }
          })
          .catch(function () {
            MessageBox.error("OPS! Erro ao cadastrar Funcionário");
          });
      },

      navegarParaDetalhes: function (id) {
        let rota = this.getOwnerComponent().getRouter();
        rota.navTo("detalhes", { id: id });
      },

      clicarEmCancelar: function () {
        MessageBox.alert("Deseja cancelar o cadastro ?", {
          icon: MessageBox.Icon.WARNING,
          actions: [MessageBox.Action.YES, MessageBox.Action.NO],
          onClose: (seOk) => {
            if (seOk == MessageBox.Action.YES) {
              this.voltarTela();
              this.limparFormulario();
            }
          },
        });
      },

      exibirMensagensErro: function (
        errosNome,
        errosEndereco,
        errosDataNascimento,
        errosCpf,
        errosTelefone,
        errosDataAdmissao
      ) {
        let campoNome = this.getView().byId("inputNome");
        Validacoes.mensagensErro(campoNome, errosNome);

        let campoEndereco = this.getView().byId("inputEndereco");
        Validacoes.mensagensErro(campoEndereco, errosEndereco);

        let campoDataNascimento = this.getView().byId("inputDataNascimento");
        Validacoes.mensagensErro(campoDataNascimento, errosDataNascimento);

        let campoCpf = this.getView().byId("inputCPF");
        Validacoes.mensagensErro(campoCpf, errosCpf);

        let campoTelefone = this.getView().byId("inputTelefone");
        Validacoes.mensagensErro(campoTelefone, errosTelefone);

        let campoDataAdmissao = this.getView().byId("inputDataAdmissao");
        Validacoes.mensagensErro(campoDataAdmissao, errosDataAdmissao);
      },

      alterarEstadoCampos: function (estado) {
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

      voltarTela: function () {
        let historico = History.getInstance();
        let paginaAnterior = historico.getPreviousHash();

        this.alterarEstadoCampos("None");
        if (paginaAnterior !== undefined) {
          window.history.go(-1);
        } else {
          let rota = this.getOwnerComponent().getRouter();
          rota.navTo("listaTelaInicial");
        }
      },
    });
  }
);
