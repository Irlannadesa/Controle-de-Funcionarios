sap.ui.define([
  "sap/ui/core/mvc/Controller",
  "sap/ui/model/json/JSONModel",
  "sap/ui/model/Filter",
  "sap/ui/model/FilterOperator",
  "sap/ui/core/routing/Router",
], function(Controller, JSONModel, Filter, FilterOperator, Router) {
  "use strict";
  return Controller.extend("controleDeFuncionarios.Controller.ListView", {
    onInit: function() {
      var oView = this.getView();

      fetch("/api/Funcionario")
        .then((response) => response.json())
        .then((data) => {
          oView.setModel(new JSONModel(data), "funcionarios");
        })
        .catch((error) => {
          console.error(error);
        });        
        
    },


    barraPesquisa: function (oEvent) {
      let filtro = [];
      let buscar = oEvent.getParameter("query");
      if (buscar) {
        filtro.push(new Filter("nome", FilterOperator.Contains, buscar));
      }
    
      let lista = this.getView().byId("myList");
      let items = lista.getBinding("items");
      items.filter(filtro);
    },

    aoClicarNaLinha: function (oEvent) {
      var oItem = oEvent.getSource();
      let rota = this.getOwnerComponent().getRouter();
      let idDaLinhaSelecionada = oEvent.getSource().getBindingContext().getProperty("id")
      rota.navTo("details", { id: idDaLinhaSelecionada })
  }   
  
  });
});
