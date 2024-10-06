using AutoMapper;
using medicalcenter.project.api.Domain.Dto.Atendimento;
using medicalcenter.project.api.Domain.Entities;
using medicalcenter.project.api.Domain.Enums;
using medicalcenter.project.api.Domain.Interfaces.Repositories;
using medicalcenter.project.api.Domain.Interfaces.Services;
using medicalcenter.project.api.Domain.Model;

namespace medicalcenter.project.api.Services
{
    public class AtendimentoService : IAtendimentoService
    {
        private readonly IMapper _Mapper;
        private readonly IAtendimentoRepository _Repository;

        public AtendimentoService( IMapper mapper, IAtendimentoRepository repository )
        {
            _Mapper = mapper;
            _Repository = repository;
        }

        public async Task<IEnumerable<AtendimentoDtoResponse>> GetAsync( )
        {
            var entity = await _Repository.GetAsync( );

            return _Mapper.Map<IEnumerable<AtendimentoDtoResponse>>( entity );
        }

        public async Task<AtendimentoDtoResponse> GetByIdAsync( Guid id )
        {
            var entity = await _Repository.GetByIdAsync( id );

            return _Mapper.Map<AtendimentoDtoResponse>( entity );
        }

        public async Task<AtendimentoDtoResponse> PostAsync( AtendimentoDtoRequest atendimentoDto )
        {
            var model = _Mapper.Map<AtendimentoModel>( atendimentoDto );
            var entity = _Mapper.Map<AtendimentoEntity>( model );

            var result = await _Repository.PostAsync( entity );

            return _Mapper.Map<AtendimentoDtoResponse>( result );
        }

        public async Task<AtendimentoDtoResponse> PutAsync( Guid id, AtendimentoDtoRequest AtendimentoDto )
        {
            if ( await _Repository.CheckExists( id ) == false )
            {
                throw new Exception( "Atendimento não existe no sistema" );
            }

            var entity = await _Repository.GetByIdAsync( id );

            var result = await _Repository.PutAsync( entity );

            return _Mapper.Map<AtendimentoDtoResponse>( result );
        }

        public async Task<bool> DeleteAsync( Guid id )
        {
            return await _Repository.DeleteAsync( id );
        }

        public async Task<AtendimentoDtoResponse> GetNextPatient( EAreasAtendimento service )
        {
            var entity = await _Repository.GetNextPatient( service );

            return _Mapper.Map<AtendimentoDtoResponse>( entity );
        }

        public async Task<IEnumerable<AtendimentoDtoResponse>> GetQueueForService( EAreasAtendimento service )
        {
            var entities = await _Repository.GetQueueForService( service );

            return _Mapper.Map<IEnumerable<AtendimentoDtoResponse>>( entities );
        }
    }
}