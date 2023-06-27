sap.ui.define([
  "sap/ui/core/mvc/Controller",
  "sap/ui/model/json/JSONModel",
  "sap/ui/core/routing/History"
], function (Controller, JSONModel, History) {
  "use strict";

  return Controller.extend("controleDeFuncionarios.Controller.DetalhesFuncionario", {
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
      rota.navTo("listaTelaInicial");
    },

    // _clicarEmVoltar: function () {
    //   let historico = History.getInstance();
    //   let paginaAnterior = historico.getPreviousHash();

    //   if (paginaAnterior !== undefined) {
    //     window.history.go(-1);
    //   } else {
    //     let rota = this.getOwnerComponent().getRouter();
    //     let model = this.getView().getModel("funcionario");
    //     let id = model.getProperty("/id");
    //     rota.navTo("listaTelaInicial", {
    //       id: id
    //     });
    //   }
    // },
  });
});
