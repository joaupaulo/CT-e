using CTe.Application.Command;
using CTe.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CTeApi.Controllers
{
    /// <summary>
    /// Controlador responsável pelo gerenciamento das transportadoras
    /// </summary>
    [ApiController]
    [Route("api/transportadoras")]
    public class TransportadoraController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransportadoraController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Cria uma nova transportadora.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CriarTransportadora([FromBody] CriarTransportadoraCommand command)
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
                var id = await _mediator.Send(command);

                return CreatedAtAction(nameof(ObterTransportadoraPorId), new { Mensagem = "Transportadora criada com sucesso.", Id = id });
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

        /// <summary>
        /// Obtém uma transportadora pelo ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> ObterTransportadoraPorId(int id)
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
                var transportadora = await _mediator.Send(new ObterTransportadoraPorIdQuery(id));

                return Ok(new { Mensagem = "Transportadora encontrada com sucesso.", Transportadora = transportadora });
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
