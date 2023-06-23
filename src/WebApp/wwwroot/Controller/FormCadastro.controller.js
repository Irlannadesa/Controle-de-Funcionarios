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

        this._limparFormulario();
      },

      _obterControle: function (id) {
        return this.getView().byId(id);
      },

      _limparFormulario: function () {
        let nome = this._obterControle("inputNome");
        let endereco =this._obterControle("inputEndereco");
        let cpf = this._obterControle("inputCPF");
        let telefone = this._obterControle("inputTelefone");
        let dataNascimento =this._obterControle("inputDataNascimento");
        let dataAdmissao = this._obterControle("inputDataAdmissao");

        nome.setValue("");
        endereco.setValue("");
        cpf.setValue("");
        telefone.setValue("");
        dataNascimento.setValue("");
        dataAdmissao.setValue("");
      },

      _funcionarioEhValido() {
        let funcionario = this.getView().getModel("funcionario").getData();
      
        let errosNome = Validacoes.validarCampoNome(funcionario.nome);
        let errosEndereco = Validacoes.validarCampoEndereco(funcionario.endereco);
        let errosDataNascimento = Validacoes.validarCampoDataNascimento(funcionario.dataNascimento);
        let errosCpf = Validacoes.validarCampoCpf(funcionario.cpf);
        let errosTelefone = Validacoes.validarCampoTelefone(funcionario.telefone);
        let errosDataAdmissao = Validacoes.validarCampoDataAdmissao(funcionario.dataAdmissao);
      
        if (
          errosNome.length > 0 ||
          errosCpf.length > 0 ||
          errosDataNascimento.length > 0 ||
          errosEndereco.length > 0 ||
          errosTelefone.length > 0 ||
          errosDataAdmissao.length > 0
        ) {
          this.exibirMensagensErro(
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
      

      _clicarEmSalvar: function() {
        if (!this._funcionarioEhValido()) {
          return;
        }
      
        let funcionario = this.getView().getModel("funcionario").getData();
      
        fetch("/api/Funcionario", {
          method: "POST",
          headers: {
            "Content-type": "application/json",
          },
          body: JSON.stringify(funcionario),
        })
          .then((res) => res.json())
          .then((res) => {
            if (res.status == 400) {
              MessageBox.error(`OPS! Erro ao cadastrar Funcionário `);
            } else {
              MessageBox.success("Funcionário cadastrado com sucesso!", {
                title: "Sucesso",
                actions: [MessageBox.Action.OK],
                onClose: (seOk) => {
                  if (seOk == MessageBox.Action.OK) {
                    this._limparFormulario();
                    this._navegarParaDetalhes(res);
                  }
                },
              });
            }
          })
          .catch(() => {
            MessageBox.error(`OPS! Erro ao cadastrar Funcionário`);
          });
      },
      
      _navegarParaDetalhes: function (id) {
        let rota = this.getOwnerComponent().getRouter();
        rota.navTo("detalhes", { id: id });
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

      exibirMensagensErro: function (
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
    });
  }
);
