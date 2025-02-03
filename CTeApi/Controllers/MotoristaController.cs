using CTe.Application.Command;
using CTe.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CTeApi.Controllers
{
    /// <summary>
    /// Controlador responsável pelo gerenciamento dos motoristas
    /// </summary>
    [ApiController]
    [Route("api/motoristas")]
    public class MotoristaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MotoristaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CriarMotorista([FromBody] CriarMotoristaCommand command)
        {

            if (command == null)
            {
                return BadRequest(new
                {
                    Mensagem = "Os dados enviados são inválidos.",
                    Erros = new[] { "O corpo da requisição não pode estar vazio." }
                });
            }

            try
            {
                var motoristaId = await _mediator.Send(command);

                return CreatedAtAction(nameof(ObterMotoristaPorId), new { Messagem = "Motorista criado com sucesso", id = motoristaId }, motoristaId);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Mensagem = "Ocorreu um erro inesperado.",
                    Detalhes = ex.Message
                });
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterMotoristaPorId(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new
                {
                    Mensagem = "O ID fornecido é inválido.",
                    Erros = new[] { "O ID deve ser um número maior que zero." }
                });
            }
            try
            {
                var motorista = await _mediator.Send(new ObterMotoristaPorIdQuery(id));

                return Ok(new { Mensagem = "Motorista encontrado com sucesso", Motorista = motorista });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Mensagem = "Ocorreu um erro inesperado.",
                    Detalhes = ex.Message
                });
            }
        }
    }

}
