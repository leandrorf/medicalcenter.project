using AutoMapper;
using medicalcenter.project.api.Domain.Dto.Triagem;
using medicalcenter.project.api.Domain.Entities;
using medicalcenter.project.api.Domain.Interfaces.Repositories;
using medicalcenter.project.api.Domain.Interfaces.Services;
using medicalcenter.project.api.Domain.Model;

namespace medicalcenter.project.api.Services
{
    public class TriagemService : ITriagemService
    {
        private readonly IMapper _Mapper;
        private readonly ITriagemRepository _Repository;

        public TriagemService( IMapper mapper, ITriagemRepository repository )
        {
            _Mapper = mapper;
            _Repository = repository;
        }

        public async Task<IEnumerable<TriagemDtoResponse>> GetAsync( )
        {
            var entity = await _Repository.GetAsync( );

            return _Mapper.Map<IEnumerable<TriagemDtoResponse>>( entity );
        }

        public async Task<TriagemDtoResponse> GetByIdAsync( Guid id )
        {
            var entity = await _Repository.GetByIdAsync( id );

            return _Mapper.Map<TriagemDtoResponse>( entity );
        }

        public async Task<TriagemDtoResponse> PostAsync( TriagemDtoRequest TriagemDto )
        {
            var model = _Mapper.Map<TriagemModel>( TriagemDto );
            var entity = _Mapper.Map<TriagemEntity>( model );

            var result = await _Repository.PostAsync( entity );

            return _Mapper.Map<TriagemDtoResponse>( result );
        }

        public async Task<TriagemDtoResponse> PutAsync( Guid id, TriagemDtoRequest TriagemDto )
        {
            if ( await _Repository.CheckExists( id ) == false )
            {
                throw new Exception( "Triagem não existe no sistema" );
            }

            var model = _Mapper.Map<TriagemModel>( TriagemDto );

            model.Id = id;

            var entity = _Mapper.Map<TriagemEntity>( model );

            var result = await _Repository.PutAsync( entity );

            return _Mapper.Map<TriagemDtoResponse>( result );
        }

        public async Task<bool> DeleteAsync( Guid id )
        {
            return await _Repository.DeleteAsync( id );
        }
    }
}