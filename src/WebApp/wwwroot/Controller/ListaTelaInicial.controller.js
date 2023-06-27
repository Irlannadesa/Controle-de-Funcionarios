sap.ui.define([
  "sap/ui/core/mvc/Controller",
  "sap/ui/model/json/JSONModel",
  "sap/ui/model/Filter",
  "sap/ui/model/FilterOperator",
  "sap/ui/core/routing/Router"
], function (Controller, JSONModel, Filter, FilterOperator) {
  "use strict";

  return Controller.extend("controleDeFuncionarios.Controller.ListaTelaInicial", {
    onInit: function () {
      this._carregarLista(); 
    },

    _carregarLista: async function () {
      let tela = this.getView();
      let model = new JSONModel({
        listaCarregando: true
      });
      tela.setModel(model, "funcionarios");

      try {
        const response = await fetch("/api/Funcionario");
        const data = await response.json();
        tela.getModel("funcionarios").setData(data);
        model.setProperty("/listaCarregando", false);
      } catch (error) {
        console.error(error);
        model.setProperty("/listaCarregando", false);
      }
    },

    barraPesquisa: function (oEvent) {
      let filtro = [];
      let buscar = oEvent.getParameter("query");
      if (buscar) {
        filtro.push(new Filter("nome", FilterOperator.Contains, buscar));
      }
      let lista = this.getView().byId("minhaLista");
      let items = lista.getBinding("items");
      items.filter(filtro);
    },

    _detalhesFuncionarios: function (oEvent) {
      let itemSelecionado = oEvent.getSource();
      let rota = this.getOwnerComponent().getRouter();
      let lista = itemSelecionado.getBindingContext("funcionarios");
      let idDaLinhaSelecionada = lista.getProperty("id");

      rota.navTo("detalhesFuncionario", {
        id: idDaLinhaSelecionada
      });
    },

    _aoClicarEmCadastrar: function () {
      let rota = this.getOwnerComponent().getRouter();
      rota.navTo("cadastroDeFuncionarios");
    }
  });
});
