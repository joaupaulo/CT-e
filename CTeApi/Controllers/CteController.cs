using CTe.Application.Command;
using CTe.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Controlador responsável pelo gerenciamento do Conhecimento de Transporte Eletrônico (CT-e).
/// </summary>
[ApiController]
[Route("api/cte")]
public class CteController : ControllerBase
{
    private readonly IMediator _mediator;

    public CteController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Cria um novo CT-e no sistema.
    /// </summary>
    /// <param name="command">Dados do CT-e a ser criado.</param>
    /// <returns>Retorna o ID do CT-e criado.</returns>
    /// <response code="201">CT-e criado com sucesso.</response>
    /// <response code="400">Erro de validação nos dados enviados.</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Criar([FromBody] CriarCteCommand command)
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

            return CreatedAtAction(nameof(ObterPorId), new { id }, new { Mensagem = "CT-e criado com sucesso.", Id = id });
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
    /// Obtém um CT-e pelo ID.
    /// </summary>
    /// <param name="id">Identificador do CT-e.</param>
    /// <returns>Retorna os detalhes do CT-e.</returns>
    /// <response code="200">Retorna o CT-e encontrado.</response>
    /// <response code="404">CT-e não encontrado.</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ObterPorId(int id)
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
            var cte = await _mediator.Send(new ObterCtePorIdQuery(id));

            return Ok(new { Mensagem = "CT-e encontrado com sucesso.", Dados = cte });
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
