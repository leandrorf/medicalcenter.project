import React , {useEffect, useState} from 'react';
import './styles.css';
import {Link,useHistory , useParams} from 'react-router-dom';
import {FiCornerDownLeft, FiUserPlus } from 'react-icons/fi';
import api from '../../../services/api';

import Select from 'react-select'

export default function PacienteDetails(){

   const [id,setId]= useState('');
   const [nome, setNome] = useState('');
   const [email, setEmail] = useState('');
   const [telefone, setTelefone] = useState('');
   const [sexo, setSexo] = useState();
   const [errors, setErrors] = useState({});

    const {pacienteId} = useParams();
    const history = useHistory();

    const handleValidation = () => {
      const formErrors = {};
      let formIsValid = true;
  
      //Name
      if(!nome){
        formIsValid = false;
        formErrors.nome = "O nome é obrigatório";
      }

      //Sexo
      if(!sexo){
         formIsValid = false;
         formErrors.sexo = "O sexo é obrigatório";
       }
  
      //Email
      if(!email){
        formIsValid = false;
        formErrors.email = "O E-mail é obrigatório";
      }
      else{
         if(typeof email !== "undefined"){
            let lastAtPos = email.lastIndexOf('@');
            let lastDotPos = email.lastIndexOf('.');
      
            if (!(lastAtPos < lastDotPos && lastAtPos > 0 && email.indexOf('@@') == -1 
                && lastDotPos > 2 && (email.length - lastDotPos) > 2)) {
              formIsValid = false;
              formErrors.email = "O E-mail é inválido";
            }
          }
      }
  
      //Telefone
      if(!telefone){
         formIsValid = false;
         formErrors.telefone = "O telefone é obrigatório";
      }

      setErrors(formErrors)
      return formIsValid;
    }

    useEffect(()=>{
       if(pacienteId === '0')
       {
         return;
       }         
       else
       {
         loadPaciente();
       }
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

         if(handleValidation()){
            alert("Paciente cadastrado com sucesso!");
          }else{
            alert("Um ou mais campos não foram preenchidos.")
            return;
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

    const genderOptions = [
      { value: 0, label: "" },
      { value: 1, label: "Masculino" },
      { value: 2, label: "Feminino" }
    ]

    const handleSexoChange = (e) => {
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
               <span className="error">{errors.nome}</span>
               <input placeholder="Nome"
                  value={nome}
                  onChange= {e => setNome(e.target.value)} />

               <br /> &nbsp;
               <span className="error">{errors.sexo}</span>
               <Select placeholder="Sexo"
                  options={genderOptions}
                  defaultValue={genderOptions[sexo]}
                  onChange={handleSexoChange} />

               <span className="error">{errors["email"]}</span>
               <input placeholder="Email" 
                value={email}
                onChange={e => setEmail(e.target.value)} />

               <span className="error">{errors.telefone}</span>
               <input placeholder="Telefone" 
                  value={telefone}
                  onChange={e => setTelefone(e.target.value)} />               

               <button className="button" type="submit">{pacienteId === '0'? 'Incluir ' : 'Atualizar '}</button>
            </form>

           </div>
        </div>
    );
}
