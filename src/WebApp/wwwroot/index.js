sap.ui.define([
	"sap/ui/core/ComponentContainer"
], function (ComponentContainer) {
	"use strict";

	new ComponentContainer({
		name: "controleDeFuncionarios",
		settings : {
			id : "app"
		},
		async: true
	}).placeAt("content");
});