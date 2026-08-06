using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace backend.Controllers
{
    [Route("api/aula8")] 
    [ApiController]
    public class aula8Controller : ControllerBase
    {
        [Route("olaMundo")] 
        [HttpGet]
        public string OlaMundo()
        {
            var mensagem = "Ola mundo API";
            
            return mensagem;
        }

        [Route("OlaMundoPersonalizado")]
        [HttpGet]
        public string OlaMundoPerso(string nome)
        {
            var mensagem = "Ola mundo via API " + nome;

            return mensagem;
        }
        

        [Route("Adicao")]
        [HttpGet]
        public int somar(int num1, int num2)
        {
            var soma = num1 + num2;

            var mensagem = soma;

            return mensagem;
        }
    }
}