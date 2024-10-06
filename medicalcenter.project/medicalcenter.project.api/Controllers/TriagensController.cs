using FluentValidation;
using medicalcenter.project.api.Domain.Dto.Triagem;
using medicalcenter.project.api.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace medicalcenter.project.api.Controllers
{
    [ApiController]
    [Route( "api/[controller]" )]
    public class TriagensController : ControllerBase
    {
        private readonly ITriagemService _Service;
        private readonly IValidator<TriagemDtoRequest> _Validator;

        public TriagensController( ITriagemService service, IValidator<TriagemDtoRequest> validator )
        {
            _Service = service;
            _Validator = validator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TriagemDtoResponse>>> Get( )
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
        public async Task<ActionResult> Post( [FromBody] TriagemDtoRequest dto )
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
        public async Task<ActionResult<TriagemDtoResponse>> Put( Guid id, [FromBody] TriagemDtoRequest dto )
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