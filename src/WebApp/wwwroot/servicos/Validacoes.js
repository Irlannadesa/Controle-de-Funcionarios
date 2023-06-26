sap.ui.define([], function () {
  "use strict";

  return {

    validarCampoNome: function (nomeFuncionario) {
      const formatoNomeFuncionario = /^[a-zA-ZÀ-ÖØ-öø-ÿ ]*$/;
      const erros = [];

      nomeFuncionario = nomeFuncionario.trim();

      if (nomeFuncionario.length < 1) {
        erros.push("Nome do funcionário deve ter no mínimo 1 caractere");
      }

      if (!formatoNomeFuncionario.test(nomeFuncionario)) {
        erros.push(
          "O nome do funcionário não pode conter caracteres especiais ou números"
        );
      }

      return erros;
    },

		validarCampoEndereco: function (enderecoFuncionario) {
      const erros = [];
      if (enderecoFuncionario.trim().length === 0) {
        erros.push("O campo endereço é obrigatório");
      }
      return erros;
    },

		validarCampoDataNascimento: function (dataNascimentoFuncionario) {
      const erros = [];
      const dataValidar = new Date(dataNascimentoFuncionario);
      const dataHoje = new Date();

      if (!dataNascimentoFuncionario) {
        erros.push("O campo de data de nascimento é obrigatório");
      } else {
        if (dataHoje.getFullYear() - dataValidar.getFullYear() > 70) {
          erros.push("A idade máxima é 70 anos!");
        }

        if (dataHoje.getFullYear() - dataValidar.getFullYear() < 18) {
          erros.push("A idade mínima é 18 anos!");
        }
      }

      return erros;
    },
   

    validarCampoCpf: function (cpfFuncionario) {
      const maximoTamanhoCaracteresRepetidos = 11;
      const quantidadeNulaCaracteres = 0;

      let strCPF = cpfFuncionario
        .replaceAll(".", "")
        .replace("-", "")
        .replace(" ", "");
      const erros = [];
      const expressaoRegular = new RegExp(`${strCPF[0]}`, "g");
      let Soma;
      let Resto;
      const tamanhoCaracteresRepetidos = (strCPF.match(expressaoRegular) || [])
        .length;

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

  

    validarCampoTelefone: function (telefoneFuncionario) {
      const erros = [];
      const formato = /^\(\d{2}\)\s\d{4,5}-\d{4}$/;

      if (typeof telefoneFuncionario === "string") {
        telefoneFuncionario = telefoneFuncionario.trim();

        if (!formato.test(telefoneFuncionario)) {
          erros.push(
            "Esse formato de telefone não é válido! O formato deve ser (XX) XXXX-XXXX ou (XX) XXXXX-XXXX"
          );
        }

        if (telefoneFuncionario.length === 0) {
          erros.push("Esse campo não pode ser vazio");
        }
      } else {
        erros.push("Telefone inválido");
      }

      return erros;
    },



    validarCampoDataAdmissao: function (dataAdmissao) {
      const erros = [];
      const dataAtual = new Date();
      const umMesAntes = new Date(
        dataAtual.getFullYear(),
        dataAtual.getMonth() - 1,
        dataAtual.getDate()
      );

      if (!dataAdmissao) {
        erros.push("A data de admissão é obrigatória");
      }
      return erros;
    },

		mensagensErro: function (item, erros) {
			const quantidadeNulaDeErros = 0;
			if (erros.length > quantidadeNulaDeErros) {
				let estadosErro = '';
				if (item && item.setValueState) {
					item.setValueState("Error");
					erros.forEach(erro => {
						estadosErro = estadosErro + "\n" + erro;
					});
					item.setValueStateText(estadosErro);
				}
			} else {
				if (item && item.setValueState) {
					item.setValueState("Success");
				}
			}
		}
		
	
		
			
  };
});
