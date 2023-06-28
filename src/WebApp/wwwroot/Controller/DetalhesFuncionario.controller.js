sap.ui.define(
  [
    "sap/ui/core/mvc/Controller",
    "sap/ui/model/json/JSONModel",
    "sap/ui/core/routing/History",
    "sap/m/MessageToast",
    "sap/m/MessageBox",
  ],
  function (Controller, JSONModel, History, MessageToast, MessageBox) {
    "use strict";
    const ROTA_LISTA = "listaFuncionario";

    return Controller.extend(
      "controleDeFuncionarios.Controller.DetalhesFuncionario",
      {
        onInit: function () {
          let rota = sap.ui.core.UIComponent.getRouterFor(this);
          rota.attachRoutePatternMatched(this._rotaCorrespondida, this);
        },

        _rotaCorrespondida: function (oEvent) {
          let id = oEvent.getParameter("arguments").id;
          this._obterFuncionario(id);
        },
        

        _obterFuncionario: async function (id) {
          try {
            let funcionario = this.getView();

            const response = await fetch(`/api/Funcionario/${id}`);
            const data = await response.json();

            funcionario.setModel(new JSONModel(data), "funcionario");
          } catch (error) {
            console.error(error);
          }
        },

        _editarFuncionario: function () {
          let funcionario = this.getView().getModel("funcionario").getData();
          let id = funcionario.id;

          let rota = this.getOwnerComponent().getRouter();
          rota.navTo("edicao", { id: id });
        },

        _voltaParaInicio: function () {
          let rota = this.getOwnerComponent().getRouter();
          rota.navTo("listaFuncionario");
        },

        _excluirFuncionario: function (id) {
          fetch(`/api/Funcionario/${id}`, {
            method: "DELETE",
            headers: { "Content-type": "application/json; charset=UTF-8" },
          })
            .then(() => {
              this._voltaParaInicio();
            })
            .catch((error) => {
              console.log(error);
            });
        },

        _aoClicarEmExcluirFuncionario: function () {
          let funcionarioSelecionado = this.getView().getModel("funcionario");
          let idFuncionario = funcionarioSelecionado.getProperty("/id");

          if (idFuncionario) {
            MessageBox.alert(`Deseja mesmo exlcuir este funcionário ?`, {
              emphasizedAction: MessageBox.Action.YES,
              initialFocus: MessageBox.Action.NO,
              icon: MessageBox.Icon.WARNING,
              actions: [MessageBox.Action.YES, MessageBox.Action.NO],
              onClose: (acao) => {
                if (acao == MessageBox.Action.YES) {
                  this._excluirFuncionario(idFuncionario);
                }
              },
            });
          } else {
            MessageToast.show("Erro ao encontrar o id do usuário!");
            this._voltaParaInicio();
          }
        },
      }
    );
  }
);
