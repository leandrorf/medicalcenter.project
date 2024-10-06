using AutoMapper;
using medicalcenter.project.api.Domain.Dto.Especialidade;
using medicalcenter.project.api.Domain.Entities;
using medicalcenter.project.api.Domain.Interfaces.Repositories;
using medicalcenter.project.api.Domain.Interfaces.Services;
using medicalcenter.project.api.Domain.Model;

namespace medicalcenter.project.api.Services
{
    public class EspecialidadeService : IEspecialidadeService
    {
        private readonly IMapper _Mapper;
        private readonly IEspecialidadeRepository _Repository;

        public EspecialidadeService( IMapper mapper, IEspecialidadeRepository repository )
        {
            _Mapper = mapper;
            _Repository = repository;
        }

        public async Task<IEnumerable<EspecialidadeDtoResponse>> GetAsync( )
        {
            var entity = await _Repository.GetAsync( );

            return _Mapper.Map<IEnumerable<EspecialidadeDtoResponse>>( entity );
        }

        public async Task<EspecialidadeDtoResponse> GetByIdAsync( Guid id )
        {
            var entity = await _Repository.GetByIdAsync( id );

            return _Mapper.Map<EspecialidadeDtoResponse>( entity );
        }

        public async Task<EspecialidadeDtoResponse> PostAsync( EspecialidadeDtoRequest EspecialidadeDto )
        {
            var model = _Mapper.Map<EspecialidadeModel>( EspecialidadeDto );
            var entity = _Mapper.Map<EspecialidadeEntity>( model );

            var result = await _Repository.PostAsync( entity );

            return _Mapper.Map<EspecialidadeDtoResponse>( result );
        }

        public async Task<EspecialidadeDtoResponse> PutAsync( Guid id, EspecialidadeDtoRequest EspecialidadeDto )
        {
            if ( await _Repository.CheckExists( id ) == false )
            {
                throw new Exception( "Especialidade não existe no sistema" );
            }

            var model = _Mapper.Map<EspecialidadeModel>( EspecialidadeDto );

            model.Id = id;

            var entity = _Mapper.Map<EspecialidadeEntity>( model );

            var result = await _Repository.PutAsync( entity );

            return _Mapper.Map<EspecialidadeDtoResponse>( result );
        }

        public async Task<bool> DeleteAsync( Guid id )
        {
            return await _Repository.DeleteAsync( id );
        }
    }
}