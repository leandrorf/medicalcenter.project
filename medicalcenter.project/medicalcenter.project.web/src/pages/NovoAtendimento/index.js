import React , {useEffect, useState} from 'react';
import './styles.css';
import {Link,useHistory , useParams} from 'react-router-dom';
import {FiCornerDownLeft, FiUserPlus } from 'react-icons/fi';
import api from '../../services/api';

import Select from 'react-select'

export default function NovoPaciente(){

   const [id,setId]= useState('');
   const [pacienteId, setPacienteId] = useState('');
   const [pacientes, setPacientes] = useState([]);
   const [errors, setErrors] = useState({});
   
    const {atendimentoId} = useParams();
    const history = useHistory();

    const handleValidation = () => {
      const formErrors = {};
      let formIsValid = true;
  
      if(!pacienteId){
        formIsValid = false;
        formErrors.paciente = "O paciente é obrigatório";
      }

      setErrors(formErrors)
      return formIsValid;
    }

    useEffect( ()=> {
      const interval = setInterval(() => {
         loadPacientes();
      
         if(atendimentoId === '0')
            return;
         else
            loadAtendimento();         
      }, 1000);
  
      return () => clearInterval(interval);
    }, []);

    async function loadPacientes(){
      const pacientesResponse = await api.get('api/pacientes');

      var options = [];

      pacientesResponse.data.map((x) => {
         options.push({ value: x.id, label: x.nome });
      });

      setPacientes(options);
    }

    async function loadAtendimento(){
       try{
         const response = await api.get(`api/atendimentos/${atendimentoId}`);

         setId(response.data.id);
         setPacienteId(response.data.pacienteId);
       }catch(error){
         alert('Erro ao recuperar o atendimento ' + error);
         history.push('/atendimentos');
       }
    }

    async function saveOrUpdate(event) {
         event.preventDefault();

         const data = {
            pacienteId,
         }

         if(handleValidation()){
            alert("Atendimento cadastrado com sucesso!");
          }else{
            alert("Um ou mais campos não foram preenchidos.")
            return;
          }

         try{
           if(atendimentoId==='0')
           {
              await api.post('api/atendimentos', data);
           }
           else
           {
              data.id= id;
              await api.put(`api/atendimentos/${id}`, data)
           }
         }catch(error){
            alert('Erro ao gravar paciente ' + error);
         }
         history.push('/atendimentos');
    }

    const handleChange = (e) => {
      setPacienteId(e.value);
    };

    return(
        <div className="novo-atendimento-container">
           <div className="content">
           <section className="form"><FiUserPlus size="105" color="#17202a"/>
             <h1>{atendimentoId === '0'? 'Incluir Novo Atendimento' : 'Atualizar Atendimento'}</h1>
               <Link className="back-link" to="/atendimentos">
                    <FiCornerDownLeft size="25" color="#17202a"/> Retornar
               </Link>
            </section>
            
            <form onSubmit={saveOrUpdate}>

            <span className="error">{errors.paciente}</span>
               <Select options={pacientes} 
                  onChange={handleChange} />
               
               <button className="button" type="submit">{atendimentoId === '0'? 'Incluir ' : 'Atualizar '}</button>
            </form>
           </div>
        </div>
    );
}
