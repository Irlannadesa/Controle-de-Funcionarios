sap.ui.define([], function() {
	"use strict";

	return {
		  validarNomeFuncionario: function(nomeFuncionario) {
      const formatoNomeFuncionario = /^[a-zA-ZÀ-ÖØ-öø-ÿ ]*$/;
      const quantidadeMinimadeLetras = 1;
      const erros = [];
    
      nomeFuncionario = nomeFuncionario.trim();
    
      if (nomeFuncionario.length < quantidadeMinimadeLetras) {
        erros.push("Nome do funcionário deve ter no mínimo 1 caractere");
      }
    
      if (!formatoNomeFuncionario.test(nomeFuncionario)) {
        erros.push("O nome do funcionário não pode conter caracteres especiais ou números");
      }
    
      return erros;
    },

		_validarEmail: function(email) {
			const erros = [];
			const formato = /^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$/;

			email = email.trim();

			if (!formato.test(email)) {
				erros.push("Esse formato de email não é válido!");
			}

			if (email.length === 0) {
				erros.push("Esse campo não pode ser vazio");
			}

			return erros;
		},

		_validarCpf: function(cpf) {
			const maximoTamanhoCaracteresRepetidos = 11;
			const quantidadeNulaCaracteres = 0;

			let strCPF = cpf.replaceAll(".", "").replace("-", "").replace(" ", "");
			const erros = [];
			const expressaoRegular = new RegExp(`${strCPF[0]}`, 'g');
			let Soma;
			let Resto;
			const tamanhoCaracteresRepetidos = (strCPF.match(expressaoRegular) || []).length;

			if (strCPF.length === quantidadeNulaCaracteres) {
				erros.push("Esse campo não pode ser vazio");
			}

			if (tamanhoCaracteresRepetidos === maximoTamanhoCaracteresRepetidos) {
				erros.push("Esse formato de CPF não é válido!");
			}

			Soma = 0;
			for (let i = 1; i <= 9; i++) {
				Soma += parseInt(strCPF.substring(i - 1, i)) * (11 - i);
			}
			Resto = (Soma * 10) % 11;

			if (Resto === 10 || Resto === 11) {
				Resto = 0;
			}
			if (Resto !== parseInt(strCPF.substring(9, 10))) {
				erros.push("Esse formato de CPF não é válido!");
			}

			Soma = 0;
			for (let i = 1; i <= 10; i++) {
				Soma += parseInt(strCPF.substring(i - 1, i)) * (12 - i);
			}
			Resto = (Soma * 10) % 11;

			if (Resto === 10 || Resto === 11) {
				Resto = 0;
			}
			if (Resto !== parseInt(strCPF.substring(10, 11))) {
				erros.push("Esse formato de CPF não é válido!");
			}

			return erros;
		},

		_validarDataNascimento: function(dataNascimento) {
			const quantidadeNulaCaracteres = 0;
			const erros = [];
			const dataValidar = new Date(dataNascimento);
			const dataHoje = new Date();

			if (dataHoje.getFullYear() - dataValidar.getFullYear() > 120) {
        erros.push("A idade máxima é 120 anos!");
      }
  
      if (dataHoje.getFullYear() - dataValidar.getFullYear() < 18) {
        erros.push("A idade mínima é 18 anos!");
      }
  
      return erros;
    },
  
    _addMensagensErro: function(oItem, erros) {
      const quantidadeNulaDeErros = 0;
  
      if (erros.length > quantidadeNulaDeErros) {
        let estadosErro = '';
        oItem.setValueState("Error");
  
        erros.forEach(erro => {
          estadosErro += "\n" + erro;
        });
  
        oItem.setValueStateText(estadosErro);
      } else {
        oItem.setValueState("Success");
      }
    }
  };
  });
