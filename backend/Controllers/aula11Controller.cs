using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/aula11")]
    [ApiController]
    public class aula11Controller : ControllerBase
    {
        [Route("obterveiculo")]
        [HttpGet]
        public Veiculo obterVeiculo()
        {
            var meuVeiculo = new Veiculo();

            meuVeiculo.Cor = "Preto";
            meuVeiculo.Marca = "Nissan";
            meuVeiculo.Modelo = "Kicks";
            meuVeiculo.Placa = "DEX-1234";

            meuVeiculo.Acelerar();
            meuVeiculo.Acelerar(); 

            return meuVeiculo;
        }

        [Route("obtercarro")]
        [HttpGet]
        public Carro obtercarro()
        {
            var meucarro = new Carro();

            meucarro.Marca = "Honda";
            meucarro.Modelo = "Fit";
            meucarro.Placa = "abc-1234";
            meucarro.Cor = "preto";

            meucarro.Acelerar();

            return meucarro;
        }
        [Route("obtermoto")]
        [HttpGet]
        public Moto obtermoto()
        {
            var minhamoto = new Moto();

            minhamoto.Marca = "honda";
            minhamoto.Modelo = "Biz";
            minhamoto.Placa = "abc-1234";
            minhamoto.Cor = "azul";

            minhamoto.Acelerar();

            return minhamoto;
        }
    }
}