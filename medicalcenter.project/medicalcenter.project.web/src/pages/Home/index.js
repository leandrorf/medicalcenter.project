import React, {useState, useEffect} from 'react';
import { Link, useHistory } from 'react-router-dom';
import './styles.css';
import api from '../../services/api';

import { FiUser, FiPlusSquare, FiLayers, FiGrid, FiActivity, FiList } from 'react-icons/fi';

export default function Atendimentos() {

  return (
    <div className="home-container">
      <header>
        <FiActivity size={50} color='#0099ff' />
        <span><strong>Atendimento Hospitalar</strong></span>
      </header>
      <h1>Serviços do sistema</h1>

      <ul>
        <li>
            <Link className="button" to="pacientes">
                <FiUser size="100" color="#17202a" /> 
                <br />
                Pacientes
            </Link>
        </li>
        <li>
            <Link className="button" to="atendimentos">
                <FiPlusSquare size="100" color="#17202a" /> 
                <br />
                Atendimentos
            </Link>
        </li>
        <li>
            <Link className="button" to="especialidades">
                <FiGrid size="100" color="#17202a" /> 
                <br />
                Especialidades
            </Link>
        </li>
        <li>
            <Link className="button" to="triagens">
                <FiLayers size="100" color="#17202a" /> 
                <br />
                Triagens
            </Link>
        </li>
        <li>
            <Link className="button" to="espera">
                <FiList size="100" color="#17202a" /> 
                <br />
                Aguardando atendimento
            </Link>
        </li>
      </ul>
    </div>
  );
}