import React , {useEffect, useState} from 'react';
import './styles.css';
import {Link,useHistory , useParams} from 'react-router-dom';
import {FiCornerDownLeft, FiUserPlus } from 'react-icons/fi';
import api from '../../services/api';

import Select from 'react-select'

export default function NovoPaciente(){

   const [id,setId]= useState('');
   const [nome, setNome] = useState('');
   const [email, setEmail] = useState('');
   const [telefone, setTelefone] = useState('');
   const [sexo, setSexo] = useState('');

    const {pacienteId} = useParams();
    const history = useHistory();

    useEffect(()=>{
       if(pacienteId === '0')
         return;
       else
         loadPaciente();
    }, pacienteId)

    async function loadPaciente(){
       try{
         const response = await api.get(`api/pacientes/${pacienteId}`);

         setId(response.data.id);
         setNome(response.data.nome);
         setEmail(response.data.email);
         setTelefone(response.data.telefone);
         setSexo(response.data.sexo);
       }catch(error){
         alert('Erro ao recuperar o paciente ' + error);
         history.push('/pacientes');
       }
    }

    async function saveOrUpdate(event) {
         event.preventDefault();

         const data = {
            nome,
            email,
            telefone,
            sexo
         }

         try{
           if(pacienteId==='0')
           {
              await api.post('api/pacientes', data);
           }
           else
           {
              data.id= id;
              await api.put(`api/pacientes/${id}`, data)
           }
         }catch(error){
            alert('Erro ao gravar paciente ' + error);
            return;
         }
         history.push('/pacientes');
    }

    const options = [
      { value: 1, label: "Masculino" },
      { value: 2, label: "Feminino" }
    ]

    const handleChange = (e) => {
      setSexo(e.value);
    };

    return(
        <div className="novo-paciente-container">
           <div className="content">
           <section className="form"><FiUserPlus size="105" color="#17202a"/>
             <h1>{pacienteId === '0'? 'Incluir Novo Paciente' : 'Atualizar Paciente'}</h1>
               <Link className="back-link" to="/pacientes">
                    <FiCornerDownLeft size="25" color="#17202a"/> Retornar
               </Link>
            </section>
            
            <form onSubmit={saveOrUpdate}>
               <input  placeholder="Nome" 
                  value={nome}
                  onChange= {e=> setNome(e.target.value)}
               />

               <br /> &nbsp;
               <Select options={options} onChange={handleChange} />

               <input  placeholder="Email" 
                value={email}
                onChange={e => setEmail(e.target.value)}
               />
               <input  placeholder="Telefone" 
                  value={telefone}
                  onChange={e => setTelefone(e.target.value)}
               />
                  <button className="button" type="submit">{pacienteId === '0'? 'Incluir ' : 'Atualizar '}</button>
            </form>

           </div>
        </div>
    );
}
