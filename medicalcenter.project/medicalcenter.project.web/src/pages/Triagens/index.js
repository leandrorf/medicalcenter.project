import React, {useState, useEffect} from 'react';
import { Link, useHistory } from 'react-router-dom';
import './styles.css';
import api from '../../services/api';

import Select from 'react-select';

import { FiEdit, FiUserX, FiHome, FiChevronRight, FiActivity } from 'react-icons/fi';

export default function Triagens() {

  const [triagens, setTriagens] = useState([]);
  
  const history = useHistory();

  useEffect( ()=> {
    api.get('api/triagens').then(
      response=> {setTriagens(response.data);
     })
  })

  async function editTriagem(id){
    try{
      history.push(`triagem/novo/${id}`);
    }catch(error){
     alert('Não foi possível editar o triagem')
    }
  }

  async function deleteTriagem(id){
    try{
       if(window.confirm('Deseja deletar o triagem de id = ' + id + ' ?'))
       {
             await api.delete(`api/triagens/${id}`);
             setTriagens(triagens.filter(x => x.id !== id));
       }
    }catch(error){
     alert('Não foi possível excluir o aluno')
    }
  }

  return (
    <div className="triagens-container">
      <header>
        <FiActivity size={50} color='#0099ff' />
        <span><strong>Atendimento Hospitalar</strong></span>
        <Link className="button" to="triagem/novo/0">Próximo paciente</Link>
      </header>
      
      <h1>
        <FiHome size="25" color="#17202a" /> &nbsp;
        <Link className="back-link" to="/">Home</Link>
        <FiChevronRight size={20} /> Triagens Processadas
      </h1>
      <ul>
        {triagens.map(x=>(
          <li key={x.id}>
            <b>AtendimentoId:</b> {x.atendimentoId}<br/><br/>
            <b>Nome do Paciente:</b> {x.pacienteNome}<br/><br/>
            <b>EspecialidadeId:</b> {x.especialidadeNome}<br/><br/>
            <b>Sintomas:</b> {x.sintomas}<br/><br/>
            <b>Pressao Arterial:</b> {x.pressaoArterial}<br/><br/>
            <b>Peso:</b> {x.peso}<br/><br/>
            <b>Altura:</b> {x.altura}<br/><br/>

            <button onClick={()=> editTriagem(x.id)} type="button">
              <FiEdit size="25" color="#17202a" />
            </button>

            <button type="button" onClick= {()=> deleteTriagem(x.id)}>
              <FiUserX size="25" color="#FF0000" />
            </button>
          </li>
        ))}
      </ul>
    </div>
  );
}