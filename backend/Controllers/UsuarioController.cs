using Microsoft.AspNetCore.Mvc;
using backend.Models;
using backend.Services;
using backend.Api.Models;
using backend.Entities;

namespace backend.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IConfiguration _configuration;
        public UsuarioController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [Route("login")]
        [HttpPost]
        public LoginResult Login(LoginRequest request)
        {
            var result = new LoginResult();

            if (request == null)
            {
                result.sucesso = false;
                result.Mensagem = "paremetro request veio nulo";
            }
            else if (request.email == null)
            {
                result.sucesso = false;
                result.Mensagem = "Email obrigatorio";
            }
            else if (request.senha == null)
            {
                result.sucesso = false;
                result.Mensagem = "senha obrigatoria";
            }
            else
            {
                var connectionString = _configuration.GetConnectionString("backendDb");

                var usuarioService = new UsuarioService(connectionString);

                result = usuarioService.Login(request.email, request.senha);
            }

            return result;
        }


        [Route("cadastro")]
        [HttpPost]
        public CadastroResult Cadastro(CadastroRequest request)
        {
            var result = new CadastroResult();

            if (request == null ||
                string.IsNullOrEmpty(request.nome) ||
                string.IsNullOrEmpty(request.sobrenome) ||
                string.IsNullOrEmpty(request.telefone) ||
                string.IsNullOrEmpty(request.email) ||
                string.IsNullOrEmpty(request.genero) ||
                string.IsNullOrEmpty(request.senha))
            {
                result.sucesso = false;
                result.Mensagem = "Todos os campos sao Obrigatorios.";
            }

            else
            {
                var connectionString = _configuration.GetConnectionString("backendDb");

                var usuarioService = new UsuarioService(connectionString);

                result = usuarioService.Cadastro(request.nome, request.sobrenome, request.telefone, request.email, request.genero, request.senha);
            }
            return result;
        }

        [Route("esqueceuSenha")]
        [HttpPost]
        public EsqueceuSenhaResult EsqueceuSenha(EsqueceuSenhaRequest request)
        {
            var result = new EsqueceuSenhaResult();

            if (request.email == null)
            {
                result.sucesso = false;
                result.Mensagem = "E-mail obrigatorio.";
            }

            else
            {
                var connectionString = _configuration.GetConnectionString("backendDb");

                var usuarioService = new UsuarioService(connectionString);

                result = usuarioService.EsqueceuSenha(request.email);
            }
            
            return result;
        }

        [HttpGet]
        [Route("ObterUsuario")]
        public ObterUsuarioResult ObterUsuario(Guid usuarioGuid)
        {
            var result = new ObterUsuarioResult();

            if (usuarioGuid == null)
            {
                result.Mensagem = "Guid vazio";
            }
            else
            {
                var connectionString = _configuration.GetConnectionString("backendDb");

                var usuario = new UsuarioService(connectionString).ObterUsuario(usuarioGuid);

                if (usuario == null)
                {
                    result.Mensagem = "Usuario nao existe";
                }
                else
                {
                    result.sucesso = true;
                    result.nome = usuario.nome;
                }
            }

            return result;
        }
    } 
        
}