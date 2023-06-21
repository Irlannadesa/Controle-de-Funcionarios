sap.ui.define([], function() {
	"use strict";

	return {
		  validarCampoNome: function(nomeFuncionario) {
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

		validarCampoEmail: function(emailFuncionario) {
			const erros = [];
			const formato = /^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$/;

			emailFuncionario = emailFuncionario.trim();

			if (!formato.test(emailFuncionario)) {
				erros.push("Esse formato de email não é válido!");
			}

			if (emailFuncionario.length === 0) {
				erros.push("Esse campo não pode ser vazio");
			}

			return erros;
		},

		validarCampoCpf: function(cpfFuncionario) {
			const maximoTamanhoCaracteresRepetidos = 11;
			const quantidadeNulaCaracteres = 0;

			let strCPF = cpfFuncionario.replaceAll(".", "").replace("-", "").replace(" ", "");
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

		validarCampoDataNascimento: function(dataNascimentoFuncionario) {		
			const erros = [];
			const dataValidar = new Date(dataNascimentoFuncionario);
			const dataHoje = new Date();

			if (dataHoje.getFullYear() - dataValidar.getFullYear() > 70) {
        erros.push("A idade máxima é 70 anos!");
      }
  
      if (dataHoje.getFullYear() - dataValidar.getFullYear() < 18) {
        erros.push("A idade mínima é 18 anos!");
      }
  
      return erros;
    },
  
    mensagensErro: function(oItem, erros) {
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
