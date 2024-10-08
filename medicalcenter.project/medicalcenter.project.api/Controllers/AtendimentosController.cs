using FluentValidation;
using medicalcenter.project.api.Domain.Dto.Atendimento;
using medicalcenter.project.api.Domain.Enums;
using medicalcenter.project.api.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace medicalcenter.project.api.Controllers
{
    [ApiController]
    [Route( "api/[controller]" )]
    public class AtendimentosController : ControllerBase
    {
        private readonly IAtendimentoService _Service;
        private readonly IValidator<AtendimentoDtoRequest> _Validator;

        public AtendimentosController( IAtendimentoService service, IValidator<AtendimentoDtoRequest> validator )
        {
            _Service = service;
            _Validator = validator;
        }

        [HttpGet( "StatusAtentimento" )]
        public async Task<ActionResult> GetStatus( )
        {
            try
            {
                return Ok( Enum.GetNames( typeof( EStatusAtendimento ) ) );
            }
            catch ( Exception ex )
            {
                return StatusCode( ( int )StatusCodes.Status500InternalServerError, ex );
            }
        }

        [HttpGet( "AreasAtentimento" )]
        public async Task<ActionResult> GetAreasAtentimentos( )
        {
            return Ok( Enum.GetNames( typeof( EAreasAtendimento ) ) );
        }

        [HttpGet( "ChamarPaciente" )]
        public async Task<ActionResult> GetPaciente( [FromQuery] EAreasAtendimento service )
        {
            try
            {
                return Ok( await _Service.GetNextPatient( service ) );
            }
            catch ( Exception ex )
            {
                return StatusCode( ( int )HttpStatusCode.InternalServerError, ex.Message );
            }
        }

        [HttpGet( "VisualizarFila" )]
        public async Task<ActionResult> GetQueueForService( [FromQuery] EAreasAtendimento service )
        {
            try
            {
                return Ok( await _Service.GetQueueForService( service ) );
            }
            catch ( Exception ex )
            {
                return StatusCode( ( int )StatusCodes.Status500InternalServerError, ex );
                throw;
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AtendimentoDtoResponse>>> Get( )
        {
            try
            {
                return Ok( await _Service.GetAsync( ) );
            }
            catch ( Exception ex )
            {
                return StatusCode( ( int )HttpStatusCode.InternalServerError, ex.Message );
            }
        }

        [HttpGet( "{id}" )]
        public async Task<ActionResult> GetById( Guid id )
        {
            try
            {
                return Ok( await _Service.GetByIdAsync( id ) );
            }
            catch ( Exception ex )
            {
                return StatusCode( ( int )HttpStatusCode.InternalServerError, ex.Message );
            }
        }

        [HttpPost]
        public async Task<ActionResult<AtendimentoDtoResponse>> Post( [FromBody] AtendimentoDtoRequest dto )
        {
            try
            {
                var validateResult = await _Validator.ValidateAsync( dto );

                if ( !validateResult.IsValid )
                {
                    return BadRequest( validateResult.Errors );
                }

                var result = await _Service.PostAsync( dto );

                return Created( Url.Action( nameof( GetById ), new { id = result.Id } ), result );
            }
            catch ( Exception ex )
            {
                return StatusCode( ( int )HttpStatusCode.InternalServerError, ex.Message );
            }
        }

        [HttpPut( "{id}" )]
        public async Task<ActionResult<AtendimentoDtoResponse>> Put( Guid id, [FromBody] AtendimentoDtoRequest dto )
        {
            try
            {
                var validateResult = await _Validator.ValidateAsync( dto );

                if ( !validateResult.IsValid )
                {
                    return BadRequest( validateResult.Errors );
                }

                var result = await _Service.PutAsync( id, dto );

                return Ok( result );
            }
            catch ( Exception ex )
            {
                return StatusCode( ( int )HttpStatusCode.InternalServerError, ex.Message );
            }
        }

        [HttpDelete( "{id}" )]
        public async Task<IActionResult> Delete( Guid id )
        {
            try
            {
                var result = await _Service.DeleteAsync( id );

                return Ok( result );
            }
            catch ( Exception ex )
            {
                return StatusCode( ( int )HttpStatusCode.InternalServerError, ex.Message );
            }
        }
    }
}