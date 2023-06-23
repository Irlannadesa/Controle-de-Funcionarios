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
          rota.attachRoutePatternMatched(this._rotaCorrespondida, this);
        },

        _rotaCorrespondida: function (oEvent) {
          let id = oEvent.getParameter("arguments").id;
          this._obterFuncionario(id);
        },

        _obterFuncionario: function (id) {
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

        _atualizarFuncionario: function (id) {
          let funcionario = this.getView()
            .getModel("dadosFormularioCriar")
            .getData();

          return fetch(`/api/Funcionario/${id}`, {
            method: "PUT",
            body: JSON.stringify(funcionario),
            headers: { "Content-type": "application/json; charset=UTF-8" },
          });
        },

        _editarFuncionario: function () {
          let dadosFormularioCriar =
            this.getView().getModel("funcionarios");
          var idFucionario = dadosFormularioCriar.getProperty("/id");
          let rota = this.getOwnerComponent().getRouter();

          rota.navTo("formCadastro", {
            clienteCaminho: window.encodeURIComponent(idFucionario),
          });
        },

        _clicarEmVoltar: function () {
          let historico = History.getInstance();
          let paginaAnterior = historico.getPreviousHash();

          if (paginaAnterior !== undefined) {
            window.history.go(-1);
          } else {
            let rota = this.getOwnerComponent().getRouter();
            rota.navTo("listaTelaInicial");
          }
        },
      }
    );
  }
);
