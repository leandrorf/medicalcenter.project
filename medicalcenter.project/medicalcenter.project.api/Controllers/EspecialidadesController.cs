using FluentValidation;
using medicalcenter.project.api.Domain.Dto.Especialidade;
using medicalcenter.project.api.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace medicalcenter.project.api.Controllers
{
    [ApiController]
    [Route( "api/[controller]" )]
    public class EspecialidadesController : ControllerBase
    {
        private readonly IEspecialidadeService _Service;
        private readonly IValidator<EspecialidadeDtoRequest> _Validator;

        public EspecialidadesController( IEspecialidadeService service, IValidator<EspecialidadeDtoRequest> validator )
        {
            _Service = service;
            _Validator = validator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EspecialidadeDtoResponse>>> Get( )
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
        public async Task<ActionResult> Post( [FromBody] EspecialidadeDtoRequest dto )
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
        public async Task<ActionResult<EspecialidadeDtoResponse>> Put( Guid id, [FromBody] EspecialidadeDtoRequest dto )
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