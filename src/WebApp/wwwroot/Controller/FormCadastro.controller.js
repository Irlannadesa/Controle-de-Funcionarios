sap.ui.define(
  [
    "sap/ui/core/mvc/Controller",
    "sap/ui/core/routing/History",
    "sap/ui/model/json/JSONModel",
    "sap/m/MessageBox",
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
        console.log(funcionario)
      
        let cpf = this.byId("inputCPF").getValue();
        funcionario.cpf = cpf.replaceAll(".", "").replace("-", "");
      
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
              MessageBox.error("OPS! Erro ao cadastrar Funcionário");
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
          .catch((error) => {
            MessageBox.error("OPS! Erro ao cadastrar Funcionário: "); 
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
