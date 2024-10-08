import React , {useEffect, useState} from 'react';
import './styles.css';
import {Link,useHistory , useParams} from 'react-router-dom';
import {FiCornerDownLeft, FiUserPlus } from 'react-icons/fi';
import api from '../../services/api';

export default function NovoEspecialidade(){

   const [id,setId]= useState('');
   const [nome, setNome] = useState('');
   const [descricao, setDescricao] = useState('');

    const {especialidadeId} = useParams();
    const history = useHistory();

    useEffect(()=>{
       if(especialidadeId === '0')
         return;
       else
         loadEspecialidade();
    }, especialidadeId)

    async function loadEspecialidade(){
       try{
         const response = await api.get(`api/especialidades/${especialidadeId}`);

         setId(response.data.id);
         setNome(response.data.nome);
         setDescricao(response.data.descricao);
       }catch(error){
         alert('Erro ao recuperar o especialidade ' + error);
         history.push('/especialidades');
       }
    }

    async function saveOrUpdate(event) {
         event.preventDefault();

         const data = {
            nome,
            descricao,
         }

         try{
           if(especialidadeId==='0')
           {
              await api.post('api/especialidades', data);
           }
           else
           {
              data.id= id;
              await api.put(`api/especialidades/${id}`, data)
           }
         }catch(error){
            alert('Erro ao gravar especialidade ' + error);
         }
         history.push('/especialidades');
    }

    return(
        <div className="novo-especialidade-container">
           <div className="content">
           <section className="form"><FiUserPlus size="105" color="#17202a"/>
             <h1>{especialidadeId === '0'? 'Incluir Novo Especialidade' : 'Atualizar Especialidade'}</h1>
               <Link className="back-link" to="/especialidades">
                    <FiCornerDownLeft size="25" color="#17202a"/> Retornar
               </Link>
            </section>
            
            <form onSubmit={saveOrUpdate}>
               <input  placeholder="Nome" 
                value={nome}
                onChange={e => setNome(e.target.value)}
               />
               <input  placeholder="Descrição" 
                  value={descricao}
                  onChange={e => setDescricao(e.target.value)}
               />
               
               <button className="button" type="submit">{especialidadeId === '0'? 'Incluir ' : 'Atualizar '}</button>
            </form>

           </div>
        </div>
    );
}
