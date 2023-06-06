sap.ui.define(
  [
    "sap/ui/core/mvc/Controller",
    "sap/m/MessageToast",
    "sap/ui/model/json/JSONModel"
  ],
  function (Controller, MessageToast, JSONModel) {
    "use strict";
    return Controller.extend("controleDeFuncionarios.Controller.App", {
      onInit: function () {       
      
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
  }
);
