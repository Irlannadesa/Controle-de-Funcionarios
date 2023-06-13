sap.ui.define([
  "sap/ui/core/mvc/Controller",
  "sap/ui/model/json/JSONModel",
  "sap/ui/model/Filter",
  "sap/ui/model/FilterOperator",
  "sap/ui/core/routing/Router",
], function(Controller, JSONModel, Filter, FilterOperator, ) {
  "use strict";
  return Controller.extend("controleDeFuncionarios.Controller.ListView", {
    onInit: function() {
      let oView = this.getView();

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

    detalhesFuncionarios: function (oEvent) {
      let itemSelecionado = oEvent.getSource();
      let rota = this.getOwnerComponent().getRouter();
      let lista = itemSelecionado.getBindingContext("funcionarios");
      let idDaLinhaSelecionada = lista.getProperty("id");
    
      rota.navTo("details", {
        id: idDaLinhaSelecionada
      });
    },
    aoClicarEmCadastrar: function () {      
      let rota = this.getOwnerComponent().getRouter();       
      rota.navTo("formCadastro");
    },
       
  
  });
});
