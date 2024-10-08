import React, {useState, useEffect} from 'react';
import { Link, useHistory } from 'react-router-dom';
import './styles.css';
import api from '../../services/api';

import { FiEdit, FiUserX, FiHome, FiChevronRight, FiActivity } from 'react-icons/fi';

export default function Especialidades() {

  const [especialidades, setEspecialidades] = useState([]);
  
  const history = useHistory();

  useEffect( ()=> {
    api.get('api/especialidades').then(
      response=> {setEspecialidades(response.data);
     })
  })

  async function editEspecialidade(id){
    try{
      history.push(`especialidade/novo/${id}`);
    }catch(error){
     alert('Não foi possível editar o especialidade')
    }
  }

  async function deleteEspecialidade(id){
    try{
       if(window.confirm('Deseja deletar o especialidade de id = ' + id + ' ?'))
       {
             await api.delete(`api/especialidades/${id}`);
             setEspecialidades(especialidades.filter(x => x.id !== id));
       }
    }catch(error){
     alert('Não foi possível excluir o aluno')
    }
  }

  return (
    <div className="especialidades-container">
      <header>
        <FiActivity size={50} color='#0099ff' />
        <span><strong>Atendimento Hospitalar</strong></span>
        <Link className="button" to="especialidade/novo/0">Nova Especialidade</Link>
      </header>

      <h1>
        <FiHome size="25" color="#17202a" /> &nbsp;
        <Link className="back-link" to="/">Home</Link>
        <FiChevronRight size={20} /> Relação de Especialidades
      </h1>

      <ul>
        {especialidades.map(x=>(
          <li key={x.id}>
            <b>Nome:</b> {x.nome}<br/><br/>
            <b>Descrição:</b> {x.descricao}<br/><br/>

            <button onClick={()=> editEspecialidade(x.id)} type="button">
                <FiEdit size="25" color="#17202a" />
            </button>

            <button type="button" onClick= {()=> deleteEspecialidade(x.id)}>
              <FiUserX size="25" color="#FF0000" />
            </button>
          </li>
        ))}
      </ul>
    </div>
  );
}