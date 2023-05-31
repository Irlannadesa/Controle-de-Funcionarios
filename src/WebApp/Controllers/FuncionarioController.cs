using Dominio.Modelo;
using Dominio.Validacoes;
using Infraestrutura.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private IFuncionarios _funcionario;


        public FuncionarioController(IFuncionarios funcionario)
        {
            _funcionario = funcionario;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult ObterTodos()
        {
            try
            {
                List<Funcionario> funcionario = _funcionario.ObterTodos();

                return Ok(funcionario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Criar(Funcionario novoFuncionario)
        {

            try
            {
                if (!ValidacoesFuncionarios.ValidarCPF(novoFuncionario.CPF))
                {
                    throw new Exception("Campo CPF é inválido.");
                }
                if (!ValidacoesFuncionarios.ValidarTelefone(novoFuncionario.Telefone))
                {
                    throw new Exception("Campo Telefone é inválido.");
                }

                if (!ValidacoesFuncionarios.ValidarDataNascimento(novoFuncionario.DataNascimento))
                {
                    throw new Exception("Campo Data de Nascimento é inválido.");
                }

                ValidacoesFuncionarios.ValidarCampos(novoFuncionario);
                _funcionario.Criar(novoFuncionario);

                return Created($"{novoFuncionario.Id}", novoFuncionario);
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

                if (!ValidacoesFuncionarios.ValidarCPF(funcionario.CPF))
                {
                    throw new Exception("Campo CPF é inválido.");
                }
                if (!ValidacoesFuncionarios.ValidarTelefone(funcionario.Telefone))
                {
                    throw new Exception("Campo Telefone é inválido.");
                }

                if (!ValidacoesFuncionarios.ValidarDataNascimento(funcionario.DataNascimento))
                {
                    throw new Exception("Campo Data de Nascimento é inválido.");
                }

                _funcionario.Atualizar(funcionario);

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
                Funcionario funcionario = _funcionario.ObterPorId(id);

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
        public IActionResult Remover([FromRoute] int id)
        {
            try
            {
                var funcionario = _funcionario.ObterPorId(id);

                _funcionario.Remover(funcionario.Id);

                return Ok(funcionario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ", \n" + ex.InnerException);
            }
        }
    }

     
}
