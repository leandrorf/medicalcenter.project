using AutoMapper;
using medicalcenter.project.api.Domain.Dto.Paciente;
using medicalcenter.project.api.Domain.Entities;
using medicalcenter.project.api.Domain.Interfaces.Repositories;
using medicalcenter.project.api.Domain.Interfaces.Services;
using medicalcenter.project.api.Domain.Model;

namespace medicalcenter.project.api.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly IMapper _Mapper;
        private readonly IPacienteRepository _Repository;

        public PacienteService( IMapper mapper, IPacienteRepository repository )
        {
            _Mapper = mapper;
            _Repository = repository;
        }

        public async Task<IEnumerable<PacienteDtoResponse>> GetAsync( )
        {
            var entity = await _Repository.GetAsync( );

            return _Mapper.Map<IEnumerable<PacienteDtoResponse>>( entity );
        }

        public async Task<PacienteDtoResponse> GetByIdAsync( Guid id )
        {
            var entity = await _Repository.GetByIdAsync( id );

            return _Mapper.Map<PacienteDtoResponse>( entity );
        }

        public async Task<PacienteDtoResponse> PostAsync( PacienteDtoRequest pacienteDto )
        {
            var model = _Mapper.Map<PacienteModel>( pacienteDto );
            var entity = _Mapper.Map<PacienteEntity>( model );

            var result = await _Repository.PostAsync( entity );

            return _Mapper.Map<PacienteDtoResponse>( result );
        }

        public async Task<PacienteDtoResponse> PutAsync( Guid id, PacienteDtoRequest pacienteDto )
        {
            if ( await _Repository.CheckExists( id ) == false )
            {
                throw new Exception( "Usuário não existe no sistema" );
            }

            var model = _Mapper.Map<PacienteModel>( pacienteDto );

            model.Id = id;

            var entity = _Mapper.Map<PacienteEntity>( model );

            var result = await _Repository.PutAsync( entity );

            return _Mapper.Map<PacienteDtoResponse>( result );
        }

        public async Task<bool> DeleteAsync( Guid id )
        {
            return await _Repository.DeleteAsync( id );
        }
    }
}