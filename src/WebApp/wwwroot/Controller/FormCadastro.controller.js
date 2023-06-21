sap.ui.define(
  [
    "sap/ui/core/mvc/Controller",
    "sap/ui/core/routing/History",
    "sap/ui/model/json/JSONModel",
    "sap/m/MessageBox",
    "../servicos/Validacoes",
  ],
  function (Controller, History, JSONModel, MessageBox) {
    "use strict";

    return Controller.extend("controleDeFuncionarios.Controller.FormCadastro", {
      onInit: function () {
        var oRouter = sap.ui.core.UIComponent.getRouterFor(this);
        oRouter.attachRoutePatternMatched(this.rotaCorrespondida, this);
      },

      rotaCorrespondida: function () {
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
        // Chamar validações
        let errosNome = Validacoes.validarCampoNome(funcionario.nome);
        let errosEmail = Validacoes.validarCampoEmail(funcionario.email);
        let errosCpf = Validacoes.validarCampoCpf(funcionario.cpf);
        let errosDataNascimento = Validacoes.validarCampoDataNascimento(
          funcionario.dataNascimento
        );

        if (
          errosNome.length > 0 ||
          errosEmail.length > 0 ||
          errosCpf.length > 0 ||
          errosDataNascimento.length > 0
        ) {
          this.exibirMensagensErro(
            errosNome,
            errosEmail,
            errosCpf,
            errosDataNascimento
          );
          return;
        }

        // let cpf = this.byId("inputCPF").getValue();
        // funcionario.cpf = cpf.replaceAll(".", "").replace("-", "");

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
                    this.limparFormulario();
                    this.navegarParaDetalhes(res);
                  }
                },
              });
            }
          })
          .catch(() => {
            MessageBox.error(`OPS! Erro ao cadastrar Funcionário`);
          });
      },

      navegarParaDetalhes: function (id) {
        let rota = this.getOwnerComponent().getRouter();
        rota.navTo("details", { id: id });
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
        errosEmail,
        errosCpf,
        errosDataNascimento
      ) {
        // Exibir erros no campo de nome
        let campoNome = this.getView().byId("inputNome");
        Validacoes.mensagensErro(campoNome, errosNome);

        // Exibir erros no campo de email
        let campoEmail = this.getView().byId("inputEmail");
        Validacoes.mensagensErro(campoEmail, errosEmail);

        // Exibir erros no campo de CPF
        let campoCpf = this.getView().byId("inputCPF");
        Validacoes.mensagensErro(campoCpf, errosCpf);

        // Exibir erros no campo de data de nascimento
        let campoDataNascimento = this.getView().byId("inputDataNascimento");
        Validacoes.mensagensErro(campoDataNascimento, errosDataNascimento);
      },

      voltarTela: function () {
        let historico = History.getInstance();
        let paginaAnterior = historico.getPreviousHash();

        if (paginaAnterior !== undefined) {
          window.history.go(-1);
        } else {
          let rota = this.getOwnerComponent().getRouter();
          rota.navTo("listView");
        }
      },
    });
  }
);
