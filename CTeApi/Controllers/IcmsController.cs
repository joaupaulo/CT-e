using Microsoft.AspNetCore.Mvc;

namespace CTeApi.Controllers
{
    using CTe.Application.Command;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Controlador responsável pelo gerenciamento de ICMS Alíquota
    /// </summary>
    [ApiController]
    [Route("api/icms")]
    public class IcmsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IcmsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Insere uma nova alíquota de ICMS no banco de dados.
        /// </summary>
        /// <param name="command">Objeto contendo os dados da alíquota a ser cadastrada.</param>
        /// <returns>Retorna 200 OK se o ICMS for cadastrado com sucesso.</returns>
        /// <response code="200">ICMS inserido com sucesso.</response>
        /// <response code="400">Requisição inválida. Verifique os dados enviados.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPost("inserir")]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> InserirIcms([FromBody] CriarIcmsCommand command)
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
                await _mediator.Send(command);

                return Ok(new { Message = "ICMS inserido com sucesso!", IcmsAliquota = command });
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
