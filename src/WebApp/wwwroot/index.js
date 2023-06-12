sap.ui.define([
	"sap/ui/core/ComponentContainer"
], function (ComponentContainer) {
	"use strict";

	new ComponentContainer({
		name: "controleDeFuncionarios",
		settings : {
			id : "controleDeFuncionarios"
		},
		async: true
	}).placeAt("content");
});