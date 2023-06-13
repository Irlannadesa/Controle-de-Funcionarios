sap.ui.define(
  [
    "sap/ui/core/mvc/Controller",
    "sap/ui/model/json/JSONModel",
    "sap/ui/core/routing/History"
  ],
  function (Controller, JSONModel, History) {
    "use strict";

    return Controller.extend("controleDeFuncionarios.Controller.DetalhesLista", {
      onInit: function () {
        let Rota = this.getOwnerComponent().getRouter();
        Rota.getRoute("details").attachPatternMatched(this.aoCoincidirRota, this);
      },

      aoCoincidirRota: function (oEvento) {
        let id = oEvento.getParameter("arguments").id;
        this.ObterFuncionario(id);
      },
      
      ObterFuncionario: function (id) {
        let jsonFuncionario = new JSONModel();

        fetch("/api/Funcionario/" + id)
          .then((res) => res.json())
          .then((res) => jsonFuncionario.setData({ funcionario: res }));

        this.getView().setModel(jsonFuncionario);
      },

      clicarEmVoltar: function () {
        let historico = History.getInstance();
        let paginaAnterior = historico.getPreviousHash();

        if (paginaAnterior !== undefined) {
          window.history.go(-1);
        } else {
          let rota = this.getOwnerComponent().getRouter();
          rota.navTo("listView", {}, true);
        }
      }
    });
  }
);
