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
        //private ValidacoesFuncionario<Funcionario> _validacao;

        public FuncionarioController(IFuncionarios funcionario)
        {
            _funcionario = funcionario;
            //_validacao = validacao;
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
            if (novoFuncionario == null)
            {
                return BadRequest("mensagem de erro - teste");
            }
            try
            {
                ValidacoesFuncionarios.ValidarCampos(novoFuncionario);
                _funcionario.Criar(novoFuncionario);

                return Created($"{novoFuncionario.Id}", novoFuncionario);
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

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Atualizar([FromRoute] int id, [FromBody] Funcionario funcionario)
        {
            try
            {
                ValidacoesFuncionarios.ValidarCampos(funcionario);
                _funcionario.Atualizar(funcionario);

                return Ok(funcionario.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
