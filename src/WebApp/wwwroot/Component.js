sap.ui.define([
  "sap/ui/core/UIComponent",
  "sap/ui/model/json/JSONModel",
  "sap/ui/model/resource/ResourceModel"
], function (UIComponent, JSONModel, ResourceModel) {
  "use strict";
  return UIComponent.extend("controleDeFuncionarios.Component", {
     metadata : {
      interfaces: ["sap.ui.core.IAsyncContentCreation"],
      manifest: "json"      
     },
     init : function () {        
        UIComponent.prototype.init.apply(this, arguments);       
        
        var oData = {
         recipient: {
            name: ""
         }
      };
      let oModel = new JSONModel(oData);
      this.setModel(oModel);

      
      this.getRouter().initialize();
     }
  });
});
