using Dominio.Modelo;
using Dominio.Validacoes;
using Infraestrutura.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IRepositorioFuncionario _repositorioFuncionario;

        public FuncionarioController(IRepositorioFuncionario repositorioFuncionario)
        {
            _repositorioFuncionario = repositorioFuncionario;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult ObterTodos()
        {
            try
            {
                List<Funcionario> funcionarios = _repositorioFuncionario.ObterTodos();
                return Ok(funcionarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Criar([FromBody] Funcionario novoFuncionario)
        {
            if (novoFuncionario == null)
            {
                return BadRequest();
            }

            try
            {
                ValidacoesFuncionarios.ValidarCampos(novoFuncionario);
                _repositorioFuncionario.Criar(novoFuncionario);
                var funcionarioNovo = _repositorioFuncionario.ObterPorCpf(novoFuncionario.CPF);
                return Ok(funcionarioNovo.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Atualizar([FromRoute] int id, [FromBody] Funcionario funcionario)
        {
            try
            {
                ValidacoesFuncionarios.ValidarCampos(funcionario);
                _repositorioFuncionario.Atualizar(funcionario);
                return Ok(funcionario.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult ObterPorId([FromRoute] int id)
        {
            try
            {
                Funcionario funcionario = _repositorioFuncionario.ObterPorId(id);
                return Ok(funcionario);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message + ", \n" + ex.InnerException);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Remover([FromRoute] int Id)
        {
            try
            {
                if (_repositorioFuncionario.ObterPorId(Id) != null)
                    _repositorioFuncionario.Remover(Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(Id);
        }
       
    }
}
