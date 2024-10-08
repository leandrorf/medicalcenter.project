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
        private readonly IAtendimentoRepository _AtendimentoRepository;
        private readonly IPacienteRepository _PacienteRepository;

        public AtendimentoService( IMapper mapper, IAtendimentoRepository atendimentoRepository, IPacienteRepository pacienteRepository )
        {
            _Mapper = mapper;
            _AtendimentoRepository = atendimentoRepository;
            _PacienteRepository = pacienteRepository;
        }

        public async Task<IEnumerable<AtendimentoDtoResponse>> GetAsync( )
        {
            try
            {
                var entity = await _AtendimentoRepository.GetAsync( );
                var dtp = _Mapper.Map<IEnumerable<AtendimentoDtoResponse>>( entity );

                var listPacientes = dtp.ToList( );

                for ( int idx = 0; idx < listPacientes.Count( ); idx++ )
                {
                    listPacientes[ idx ].PacienteNome = _PacienteRepository.GetByIdAsync( listPacientes[ idx ].PacienteId ).Result.Nome;
                }

                return _Mapper.Map<IEnumerable<AtendimentoDtoResponse>>( listPacientes );
            }
            catch ( Exception ex )
            {
                throw new Exception( ex.Message );
            }
        }

        public async Task<AtendimentoDtoResponse> GetByIdAsync( Guid id )
        {
            try
            {
                var entity = await _AtendimentoRepository.GetByIdAsync( id );

                return _Mapper.Map<AtendimentoDtoResponse>( entity );
            }
            catch ( Exception ex )
            {
                throw new Exception( ex.Message );
            }
        }

        public async Task<AtendimentoDtoResponse> PostAsync( AtendimentoDtoRequest atendimentoDto )
        {
            try
            {
                var model = _Mapper.Map<AtendimentoModel>( atendimentoDto );
                var entity = _Mapper.Map<AtendimentoEntity>( model );
                var result = await _AtendimentoRepository.PostAsync( entity );

                return _Mapper.Map<AtendimentoDtoResponse>( result );
            }
            catch ( Exception ex )
            {
                throw new Exception( ex.Message );
            }
        }

        public async Task<AtendimentoDtoResponse> PutAsync( Guid id, AtendimentoDtoRequest atendimentoDto )
        {
            try
            {
                if ( await _AtendimentoRepository.CheckExists( id ) == false )
                {
                    throw new Exception( "Atendimento não existe no sistema" );
                }

                var model = _Mapper.Map<AtendimentoModel>( atendimentoDto );
                var entity = _Mapper.Map<AtendimentoEntity>( model );

                entity.Id = id;

                var result = await _AtendimentoRepository.PutAsync( entity );

                return _Mapper.Map<AtendimentoDtoResponse>( result );
            }
            catch ( Exception ex )
            {
                throw new Exception( ex.Message );
            }
        }

        public async Task<bool> DeleteAsync( Guid id )
        {
            try
            {
                return await _AtendimentoRepository.DeleteAsync( id );
            }
            catch ( Exception ex )
            {
                throw new Exception( ex.Message );
            }
        }

        public async Task<AtendimentoDtoResponse> GetNextPatient( EAreasAtendimento service )
        {
            try
            {
                var entity = await _AtendimentoRepository.GetNextPatient( service );
                var dto = _Mapper.Map<AtendimentoDtoResponse>( entity );
                dto.PacienteNome = _PacienteRepository.GetByIdAsync( dto.PacienteId ).Result.Nome;

                return dto;
            }
            catch ( Exception ex )
            {
                throw new Exception( ex.Message );
            }
        }

        public async Task<IEnumerable<AtendimentoDtoResponse>> GetQueueForService( EAreasAtendimento service )
        {
            try
            {
                var entities = await _AtendimentoRepository.GetQueueForService( service );
                var dto = _Mapper.Map<IEnumerable<AtendimentoDtoResponse>>( entities );
                var listPacientes = dto.ToList( );

                for ( int idx = 0; idx < dto.Count( ); idx++ )
                {
                    listPacientes[ idx ].PacienteNome = _PacienteRepository.GetByIdAsync( listPacientes[ idx ].PacienteId ).Result.Nome;
                }

                return dto;
            }
            catch ( Exception ex )
            {
                throw new Exception( ex.Message );
            }
        }
    }
}