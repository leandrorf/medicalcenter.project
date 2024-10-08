import React, {useState, useEffect} from 'react';
import { Link, useHistory } from 'react-router-dom';
import './styles.css';
import api from '../../services/api';

import { FiEdit, FiUserX, FiHome, FiChevronRight, FiActivity } from 'react-icons/fi';

export default function Espera() {

  const [espera, setEspera] = useState([]);
  const [atentdimentoAtual, setAtentdimentoAtual] = useState('');

  useEffect( ()=> {
    api.get('api/Atendimentos/VisualizarFila', {
      params: {
        service: 2
      }
    }).then(
      response=> {setEspera(response.data);

      });
      
    getNextPatient();
  })

  async function getNextPatient(){
    const response = await api.get('api/Atendimentos/ChamarPaciente',{
      params: {
         service: 2
      }
   });

   if (response.data.status === 2){
    setAtentdimentoAtual(response.data);
   }   
  }

  return (
    <div className="espera-container">
      <header>
        <FiActivity size={50} color='#0099ff' />
        <span><strong>Atendimento Hospitalar</strong></span>
        <Link className={atentdimentoAtual =='' ? 'buttonAtendimentoDisable' : 'buttonAtendimento' } color="#ff0000">Próximo atendimento: {atentdimentoAtual == '' ? '?' : atentdimentoAtual.numeroSequencial}</Link>
      </header>

      <h1>
        <FiHome size="25" color="#17202a" /> &nbsp;
        <Link className="back-link" to="/">Home</Link>
        <FiChevronRight size={20} /> Aguardando atentimento
      </h1>

      <ul>
        {espera.map(x=>(
          <li key={x.id}>
            <b>Paciente:</b> {x.pacienteNome}<br/><br/>
            <b>Número do Atendimento:</b> {x.numeroSequencial}<br/><br/>
            <b>Hora de Chegada:</b> {x.dataHoraChegada}<br/><br/>
            <b>Status:</b> {x.status}<br/><br/>
          </li>
        ))}
      </ul>
    </div>
  );
}