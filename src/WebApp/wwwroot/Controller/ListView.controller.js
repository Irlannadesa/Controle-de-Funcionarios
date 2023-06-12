sap.ui.define([
  "sap/ui/core/mvc/Controller",
  "sap/ui/model/json/JSONModel"
], function(Controller, JSONModel) {
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

        
    }
  });
});
