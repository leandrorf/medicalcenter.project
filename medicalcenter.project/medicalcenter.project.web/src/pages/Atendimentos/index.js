import React, {useState, useEffect} from 'react';
import { Link, useHistory } from 'react-router-dom';
import './styles.css';
import api from '../../services/api';

import { FiEdit, FiUserX, FiHome, FiChevronRight, FiActivity } from 'react-icons/fi';

export default function Atendimentos() {

  const [atendimento, setAtendimentos] = useState([]);
  const history = useHistory();

  useEffect( ()=> {
    api.get('api/atendimentos').then(
      response=> {setAtendimentos(response.data);
     })
  })

  async function editAtendimento(id){
    try{
      history.push(`atendimento/novo/${id}`);
    }catch(error){
     alert('Não foi possível editar o atendimento')
    }
  }

  async function deleteAtendimento(id){
    try{
       if(window.confirm('Deseja deletar o atendimento de id = ' + id + ' ?'))
       {
             await api.delete(`api/atendimentos/${id}`);
             setAtendimentos(atendimento.filter(x => x.id !== id));
       }
    }catch(error){
     alert('Não foi possível excluir o aluno')
    }
  }

  return (
    <div className="atendimentos-container">
      <header>
        <FiActivity size={50} color='#0099ff' />
        <span><strong>Atendimento Hospitalar</strong></span>
        <Link className="button" to="atendimento/novo/0">Novo Atendimento</Link>
      </header>

      <h1>
        <FiHome size="25" color="#17202a" /> &nbsp;
        <Link className="back-link" to="/">Home</Link>
        <FiChevronRight size={20} /> Relação de Atendimentos
      </h1>

      <ul>
        {atendimento.map(x=>(
          <li key={x.id}>
            <b>Paciente:</b> {x.pacienteNome}<br/><br/>
            <b>Número do Atendimento:</b> {x.numeroSequencial}<br/><br/>
            <b>Hora de Chegada:</b> {x.dataHoraChegada}<br/><br/>
            <b>Status:</b> {x.status}<br/><br/>

            <button onClick={()=> editAtendimento(x.id)} type="button">
                <FiEdit size="25" color="#17202a" />
            </button>

            <button type="button" onClick= {()=> deleteAtendimento(x.id)}>
              <FiUserX size="25" color="#FF0000" />
            </button>
          </li>
        ))}
      </ul>
    </div>
  );
}