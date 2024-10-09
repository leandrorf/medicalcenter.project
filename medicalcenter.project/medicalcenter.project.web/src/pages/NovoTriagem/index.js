import React , {useEffect, useState} from 'react';
import './styles.css';
import {Link,useHistory , useParams} from 'react-router-dom';
import {FiCornerDownLeft, FiUserPlus } from 'react-icons/fi';
import api from '../../services/api';

import Select from 'react-select'

export default function NovoTriagem(){

   const [id,setId]= useState('');
   const [atendimentoId, setAtendimentoId] = useState('');
   const [especialidadeId, setEspecialidadeId] = useState('');
   const [sintomas, setSintomas] = useState('');
   const [pressaoArterial, setPressaoArterial] = useState('');
   const [peso, setPeso] = useState('');
   const [altura, setAltura] = useState('');
   const [especialidades, setEspecialidades] = useState('');
   const [errors, setErrors] = useState({});

    const {triagemId} = useParams();
    const history = useHistory();

    const handleValidation = () => {
      const formErrors = {};
      let formIsValid = true;
  
      if(!especialidadeId){
        formIsValid = false;
        formErrors.especialidadeId = "A especialidade é obrigatório";
      }

      if(!sintomas){
         formIsValid = false;
         formErrors.sintomas = "Os sintomas são obrigatórios";
       }
  
      if(!pressaoArterial){
        formIsValid = false;
        formErrors.pressaoArterial = "A pressão arterial é obrigatório";
      }
  
      if(!peso){
         formIsValid = false;
         formErrors.peso = "O peso é obrigatório";
      }

      if(!altura){
         formIsValid = false;
         formErrors.altura = "A altura é obrigatório";
      }

      setErrors(formErrors)
      return formIsValid;
    }

    useEffect( ()=> {
      const interval = setInterval(() => {
         getNextPatient();
         loadEspecialidades();
         
         if(triagemId === '0')
         {
            return;
         }
         else
         {
            loadTriagem();
         }
      }, 1000);
  
      return () => clearInterval(interval);
    }, []);

    async function getNextPatient(){
      try{
         const response = await api.get('api/Atendimentos/ChamarPaciente',{
            params: {
               service: 2
            }
         });
      
         const data = {
            pacienteId: response.data.pacienteId,
            status: 2
         };

         await api.put(`api/atendimentos/${response.data.id}`, data);

         setAtendimentoId(response.data.id);
      }
      catch(error){
         console.log("Erro na triagem");
         console.log(error);
         history.push('/triagens');
      }
    }
   
    async function loadEspecialidades(){
      const especialidadesResponse = await api.get('api/Especialidades');

      var options = [];

      especialidadesResponse.data.map((x) => {
         options.push({ value: x.id, label: x.nome });
      });

      setEspecialidades(options);
    }

    async function loadTriagem(){
       try{
         const response = await api.get(`api/triagens/${triagemId}`);

         setId(response.data.id);
         setAtendimentoId(response.data.atendimentoID);
         setEspecialidadeId(response.data.especialidadeId);
         setSintomas(response.data.sintomas);
         setPressaoArterial(response.data.pressaoArterial);
         setPeso(response.data.peso);
         setAltura(response.data.altura);
       }catch(error){
         alert('Erro ao recuperar o triagem ' + error);
         history.push('/triagens');
       }
    }

    async function saveOrUpdate(event) {
         event.preventDefault();

         const data = {
            atendimentoId,
            especialidadeId,
            sintomas,
            pressaoArterial,
            peso,
            altura
         }

         if(handleValidation()){
            alert("Triagem cadastrada com sucesso!");
          }
          else{
            alert("Um ou mais campos não foram preenchidos.")
            return;
          }   

         try{
           if(triagemId==='0')
           {
              await api.post('api/triagens', data);
           }
           else
           {
              data.id= id;
              await api.put(`api/triagens/${id}`, data)
           }
         }catch(error){
            alert('Erro ao gravar triagem ' + error);
            return;
         }
         history.push('/triagens');
    }

    const handleChange = (e) => {
      setEspecialidadeId(e.value);
    };

    return(
        <div className="novo-triagem-container">
           <div className="content">
           <section className="form"><FiUserPlus size="105" color="#17202a"/>
             <h1>{triagemId === '0'? 'Incluir Novo Triagem' : 'Atualizar Triagem'}</h1>
               <Link className="back-link" to="/triagens">
                    <FiCornerDownLeft size="25" color="#17202a"/> Retornar
               </Link>
            </section>
            
            <form onSubmit={saveOrUpdate}>
               <input  placeholder="AtendimentoId" 
                  value={atendimentoId}
                  onChange= {e=> setAtendimentoId(e.target.value)}
               />

               <br />&nbsp;
               <span className="error">{errors.especialidadeId}</span>
               <Select placeholder="Selecione a especialidade"
                  options={especialidades}
                  onChange={handleChange} />
               
               <span className="error">{errors.sintomas}</span>
               <input  placeholder="Sintomas" 
                value={sintomas}
                onChange={e => setSintomas(e.target.value)} />

               <span className="error">{errors.pressaoArterial}</span>
               <input  placeholder="Pressao Arterial" 
                  value={pressaoArterial}
                  onChange={e => setPressaoArterial(e.target.value)} />
               
               <span className="error">{errors.peso}</span>
               <input  placeholder="Peso" 
                  value={peso}
                  onChange={e => setPeso(e.target.value)} />

               <span className="error">{errors.altura}</span>
               <input  placeholder="Altura" 
                  value={altura}
                  onChange={e => setAltura(e.target.value)}
               />
               
               <button className="button" type="submit">{triagemId === '0'? 'Incluir ' : 'Atualizar '}</button>
            </form>
           </div>
        </div>
    );
}
