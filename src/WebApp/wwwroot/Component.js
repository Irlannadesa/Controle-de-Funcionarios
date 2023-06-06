sap.ui.define([
  "sap/ui/core/UIComponent",
  "sap/ui/model/json/JSONModel",
  "sap/ui/model/resource/ResourceModel"
], function (UIComponent, JSONModel, ResourceModel) {
  "use strict";
  return UIComponent.extend("controleDeFuncionarios.Component", {
     metadata : {
        "interfaces": ["sap.ui.core.IAsyncContentCreation"],
        "rootView": {
           "viewName": "controleDeFuncionarios.view.App",
           "type": "XML",
           "async": true,
           "id": "app"
        }
     },
     init : function () {        
        UIComponent.prototype.init.apply(this, arguments);       
        
        
        
        let i18nModel = new ResourceModel({
           bundleName: "controleDeFuncionarios.i18n.i18n"
        });
        this.setModel(i18nModel, "i18n");
     }
  });
});
