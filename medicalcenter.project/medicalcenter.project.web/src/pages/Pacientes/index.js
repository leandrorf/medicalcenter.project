import React, {useState, useEffect} from 'react';
import { Link, useHistory } from 'react-router-dom';
import './styles.css';
import api from '../../services/api';

import { FiEdit, FiUserX, FiHome, FiChevronRight, FiActivity } from 'react-icons/fi';

export default function Pacientes() {

  const [pacientes, setPacientes] = useState([]);
  
  const history = useHistory();

  useEffect( ()=> {
    api.get('api/pacientes').then(
      response=> {setPacientes(response.data);
     })
  })

  async function editPaciente(id){
    try{
      history.push(`paciente/novo/${id}`);
    }catch(error){
     alert('Não foi possível editar o paciente')
    }
  }

  async function deletepaciente(id){
    try{
       if(window.confirm('Deseja deletar o paciente de id = ' + id + ' ?'))
       {
             await api.delete(`api/pacientes/${id}`);
             setPacientes(pacientes.filter(x => x.id !== id));
       }
    }catch(error){
     alert('Não foi possível excluir o aluno')
    }
  }

  return (
    <div className="pacienetes-container">
      <header>
        <FiActivity size={50} color='#0099ff' />
        <span><strong>Atendimento Hospitalar</strong></span>
        <Link className="button" to="paciente/novo/0">Novo Paciente</Link>
      </header>

      <h1>
        <FiHome size="25" color="#17202a" /> &nbsp;
        <Link className="back-link" to="/">Home</Link>
        <FiChevronRight size={20} /> Relação de Pacientes
      </h1>

      <ul>
        {pacientes.map(x=>(
          <li key={x.id}>
            <b>Nome:</b> {x.nome}<br/><br/>
            <b>Sexo:</b> {x.sexo == 1 ? "Masculino" : "Feminino"}<br/><br/>
            <b>Email:</b> {x.email}<br/><br/>
            <b>Telefone:</b> {x.telefone}<br/><br/>

            <button onClick={()=> editPaciente(x.id)} type="button">
                <FiEdit size="25" color="#17202a" />
            </button>

            <button type="button" onClick= {()=> deletepaciente(x.id)}>
              <FiUserX size="25" color="#FF0000" />
            </button>
          </li>
        ))}
      </ul>
    </div>
  );
}