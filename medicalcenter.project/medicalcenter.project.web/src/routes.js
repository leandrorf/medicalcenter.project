import React from 'react';
import { BrowserRouter, Route, Switch } from 'react-router-dom';
import Pacientes from './pages/Pacientes';
import NovoPaciente from './pages/NovoPaciente';
import Atendimentos from './pages/Atendimentos';
import NovoAtendimento from './pages/NovoAtendimento';
import Triagens from './pages/Triagens';
import NovoTriagem from './pages/NovoTriagem';
import Especialidades from './pages/Especialidades';
import NovoEspecialidade from './pages/NovoEspecialidade';
import Espera from './pages/Espera';

import Home from './pages/Home'

export default function Routes(){
    return (
        <BrowserRouter>
           <Switch>
               <Route path="/" exact component={Home} />
               <Route path="/pacientes" component={Pacientes}/>
               <Route path="/paciente/novo/:pacienteId" component={NovoPaciente}/>
               <Route path="/atendimentos" component={Atendimentos}/>
               <Route path="/atendimento/novo/:atendimentoId" component={NovoAtendimento}/>
               <Route path="/triagens" component={Triagens} />
               <Route path="/triagem/novo/:triagemId" component={NovoTriagem} />
               <Route path="/especialidades" component={Especialidades} />
               <Route path="/especialidade/novo/:especialidadeId" component={NovoEspecialidade} />
               <Route path="/espera" component={Espera} />
            </Switch>
        </BrowserRouter>    
    );
}