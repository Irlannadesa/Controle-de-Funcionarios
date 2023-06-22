sap.ui.define(
  [
    "sap/ui/core/mvc/Controller",
    "sap/ui/model/json/JSONModel",
    "sap/ui/core/routing/History",
  ],
  function (Controller, JSONModel, History) {
    "use strict";

    return Controller.extend(
      "controleDeFuncionarios.Controller.DetalhesLista",
      {
        onInit: function () {
          let rota = sap.ui.core.UIComponent.getRouterFor(this);
          rota.attachRoutePatternMatched(this.rotaCorrespondida, this);
        },

        rotaCorrespondida: function (oEvent) {
          let id = oEvent.getParameter("arguments").id;
          this.ObterFuncionario(id);
        },

        ObterFuncionario: function (id) {
          let funcionario = this.getView();

          fetch(`/api/Funcionario/${id}`)
            .then((response) => response.json())
            .then((data) => {              
              funcionario.setModel(new JSONModel(data), "funcionario");
            })
            .catch((error) => {
              console.error(error);
            });
        },
        
        clicarEmVoltar: function () {
          let historico = History.getInstance();
          let paginaAnterior = historico.getPreviousHash();

          if (paginaAnterior !== undefined) {
            window.history.go(-1);
          } else {
            let rota = this.getOwnerComponent().getRouter();
            rota.navTo("listaTelaInicial");
          }
        },

        EditarFuncionario: function () {},

        ExcluirFuncionario: function () {},
      }
    );
  }
);
