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
        private readonly ITriagemRepository _TriagemRepository;
        private readonly IEspecialidadeRepository _EspecialidadeRepository;
        private readonly IAtendimentoRepository _AtendimentoRepository;
        private readonly IPacienteRepository _PacienteRepository;

        public TriagemService( IMapper mapper,
            ITriagemRepository triagemRepository,
            IEspecialidadeRepository especialidadeRepository,
            IAtendimentoRepository atendimentoRepository,
            IPacienteRepository pacienteRepository )
        {
            _Mapper = mapper;
            _TriagemRepository = triagemRepository;
            _EspecialidadeRepository = especialidadeRepository;
            _AtendimentoRepository = atendimentoRepository;
            _PacienteRepository = pacienteRepository;
        }

        public async Task<IEnumerable<TriagemDtoResponse>> GetAsync( )
        {
            try
            {
                var entity = await _TriagemRepository.GetAsync( );
                var dto = _Mapper.Map<IEnumerable<TriagemDtoResponse>>( entity );
                var list = dto.ToList( );

                for ( int idx = 0; idx < list.Count( ); idx++ )
                {
                    list[ idx ].EspecialidadeNome = _EspecialidadeRepository.GetByIdAsync( list[ idx ].EspecialidadeId ).Result.Nome;

                    var pacienteId = _AtendimentoRepository.GetByIdAsync( list[ idx ].AtendimentoId ).Result.PacienteId;

                    list[ idx ].PacienteNome = _PacienteRepository.GetByIdAsync( pacienteId ).Result.Nome;
                }

                return _Mapper.Map<IEnumerable<TriagemDtoResponse>>( list );
            }
            catch ( Exception ex )
            {
                throw new Exception( ex.Message );
            }
        }

        public async Task<TriagemDtoResponse> GetByIdAsync( Guid id )
        {
            try
            {
                var entity = await _TriagemRepository.GetByIdAsync( id );

                return _Mapper.Map<TriagemDtoResponse>( entity );
            }
            catch ( Exception ex )
            {
                throw new Exception( ex.Message );
            }
        }

        public async Task<TriagemDtoResponse> PostAsync( TriagemDtoRequest TriagemDto )
        {
            try
            {
                var model = _Mapper.Map<TriagemModel>( TriagemDto );
                var entity = _Mapper.Map<TriagemEntity>( model );

                var result = await _TriagemRepository.PostAsync( entity );

                var atendimento = await _AtendimentoRepository.GetByIdAsync( result.AtendimentoId );
                atendimento.Status = Domain.Enums.EStatusAtendimento.AguardandoEspecialista;

                await _AtendimentoRepository.PutAsync( atendimento );

                return _Mapper.Map<TriagemDtoResponse>( result );
            }
            catch ( Exception ex )
            {
                throw new Exception( ex.Message );
            }
        }

        public async Task<TriagemDtoResponse> PutAsync( Guid id, TriagemDtoRequest TriagemDto )
        {
            try
            {
                if ( await _TriagemRepository.CheckExists( id ) == false )
                {
                    throw new Exception( "Triagem não existe no sistema" );
                }

                var model = _Mapper.Map<TriagemModel>( TriagemDto );

                model.Id = id;

                var entity = _Mapper.Map<TriagemEntity>( model );

                var result = await _TriagemRepository.PutAsync( entity );

                return _Mapper.Map<TriagemDtoResponse>( result );
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
                return await _TriagemRepository.DeleteAsync( id );
            }
            catch ( Exception ex )
            {
                throw new Exception( ex.Message );
            }
        }
    }
}