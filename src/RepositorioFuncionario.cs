﻿using ListaDePessoas.Modelo;
using System.Security.Cryptography;

namespace ListaDePessoas
{
    internal class RepositorioFuncionario : IFuncionarios
    {
        public List<Funcionario> ObterTodos()
        {
            return SingletonFuncionarios.ObterInstancia();
        }

        public Funcionario ObterPorId(int id)
        {


            foreach (Funcionario funcionario in SingletonFuncionarios.ObterInstancia())
            {
                if (funcionario.Id == id)
                {
                    return funcionario;
                }
            }

            return null;

        }

        public void Criar(Funcionario novoFuncionario)
        {
            SingletonFuncionarios.ObterInstancia().Add(novoFuncionario);
        }



        public void Remover(int id)
        {
            var animalARemover = ObterPorId(id);
            SingletonFuncionarios.ObterInstancia().Remove(animalARemover);
        }

        public void Atualizar(Funcionario funcionarioASerAtualizado)
        {
            foreach (Funcionario funcionario in SingletonFuncionarios.ObterInstancia())
            {
                if (funcionario.Id == funcionarioASerAtualizado.Id)
                {
                    funcionario.Nome = funcionarioASerAtualizado.Nome;
                    funcionario.CPF = funcionarioASerAtualizado.CPF;
                    funcionario.Endereco = funcionarioASerAtualizado.Endereco;
                    funcionario.Telefone = funcionarioASerAtualizado.Telefone;
                    funcionario.DataNascimento = funcionarioASerAtualizado.DataNascimento;
                    funcionario.DataAdmissao = funcionarioASerAtualizado.DataAdmissao;
                }
            }
        }
    }
}