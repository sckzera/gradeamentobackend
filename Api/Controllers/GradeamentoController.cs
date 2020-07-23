using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using gradeamento_backend.Api.Entities;
using gradeamento_backend.Api.Models;
using gradeamento_backend.Api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace gradeamento_backend.Api.Controllers
{
    [ApiController]
    [Route("gradeamentos")]
    public class GradeamentoController : ControllerBase
    {
          private const string _mensagemErroExcecao = "Ocorreu um erro inesperado";
        private readonly ILogger<GradeamentoController> _logger;
        private readonly IMapper _mapper;
        private readonly IGradeamentoRepository _repository;

        public GradeamentoController(ILogger<GradeamentoController> logger
           , IGradeamentoRepository repository
           , IMapper mapper)
        {
            _logger = logger;

            _repository = repository ??
                throw new ArgumentNullException(nameof(repository));

            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));

        }

          /// <summary>
        /// Cria um novo dado de Gradeamento
        /// </summary>
        /// <response code="201">Retorna quando um recurso foi criado com sucesso</response>
        /// <response code="400">Retorna quando houve uma requisição mal formada</response>
        /// <response code="409">Retorna quando o recurso ja existe</response>
        /// <response code="500">Retorna quando houve um erro interno do serviço</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErroRetorno))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(ErroRetorno))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErroRetorno))]
        [Produces("application/json")]
        public IActionResult Create([FromBody]GradeamentoInclusao gradeamento)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return new BadRequestObjectResult(new ErroRetorno(string.Join(", ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage))));
                }

                var gradeamentoEntity = _mapper.Map<Gradeamento>(gradeamento);

                _repository.Cadastrar(gradeamentoEntity);


                if (_repository.Salvar())
                {
                    return CreatedAtRoute(null, null);
                }

                return new JsonResult(500, new ErroRetorno(_mensagemErroExcecao));
            }
            catch (Exception ex)
            {
                _logger.LogError(_mensagemErroExcecao, ex);
                return new JsonResult(500, new ErroRetorno(_mensagemErroExcecao));
            }
        }

        /// <summary>
        /// Consultar Gradeamento
        /// </summary>
        /// <response code="201">Retorna quando um recurso foi criado com sucesso</response>
        /// <response code="400">Retorna quando houve uma requisição mal formada</response>
        /// <response code="409">Retorna quando o recurso ja existe</response>
        /// <response code="500">Retorna quando houve um erro interno do serviço</response>
        [HttpGet]
         [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GradeamentoListaRetorno))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErroRetorno))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErroRetorno))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(ErroRetorno))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErroRetorno))]
        public IActionResult GetGradeamento()
        {
            try
            {
                if (!ModelState.IsValid)
                    return new BadRequestObjectResult(new ErroRetorno(string.Join(", ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage))));

                var gradeamento = _repository.Obter();

                if (gradeamento.Count <= 0)
                    return new NoContentResult();

                return Ok(_mapper.Map<List<Gradeamento>>(gradeamento));
            }
            catch (Exception ex)
            {
                _logger.LogError(_mensagemErroExcecao, ex);
                return new JsonResult(500, new ErroRetorno(_mensagemErroExcecao));
            }
        }

    }
}