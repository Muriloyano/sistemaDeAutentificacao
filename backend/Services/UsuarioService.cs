using backend.Repositories;
using backend.Models;
using backend.Entities;
using backend.Common;
using System.Runtime.Serialization;

namespace backend.Services
{
    public class UsuarioService
    {
        private string _connectionString;
        public UsuarioService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public LoginResult Login(string email, string senha)
        {
            var result = new LoginResult();

            var usuarioRepository = new UsuarioRepository(_connectionString);

            var usuario = usuarioRepository.ObterUsuarioPorEmail(email);

            if (usuario != null)
            {
                if (usuario.senha == senha)
                {
                    result.sucesso = true;
                    result.usuarioGuid = usuario.usuarioGuid;
                }
                else
                {
                    result.sucesso = false;
                    result.Mensagem = "Usuario ou senha invalidos";
                }
            }

            else
            {
                result.sucesso = false;
                result.Mensagem = "Usuario ou senha invalidos.";
            }

            return result;
        }

        public CadastroResult Cadastro(string nome, string sobrenome, string telefone, string email, string genero, string senha)
        {
            var result = new CadastroResult();

            var usuarioRepository = new UsuarioRepository(_connectionString);

            var usuario = usuarioRepository.ObterUsuarioPorEmail(email);

            if (usuario != null)
            {
                result.sucesso = false;
                result.Mensagem = "Usuario ja existente no sistema";
            }
            else
            {
                usuario = new Usuario();
                usuario.nome = nome;
                usuario.sobrenome = sobrenome;
                usuario.telefone = telefone;
                usuario.email = email;
                usuario.genero = genero;
                usuario.senha = senha;
                usuario.usuarioGuid = Guid.NewGuid();

                var insertResult = usuarioRepository.Inserir(usuario);

                if (insertResult > 0)
                {
                    result.sucesso = true;
                    result.usuarioGuid = usuario.usuarioGuid;
                }
                else
                {
                    result.sucesso = false;
                    result.Mensagem = "Erro ao inserir ususrio.";
                }
            }

            return result;
        }

        public  EsqueceuSenhaResult EsqueceuSenha(string email)
        {
            var result = new EsqueceuSenhaResult();

            var usuarioRepository = new UsuarioRepository(_connectionString);

            var usuario = usuarioRepository.ObterUsuarioPorEmail(email);

            if (usuario == null)
            {
                result.sucesso = false;
                result.Mensagem = "Usuario nao existe.";
            }
            else
            {
                var emailSender = new EmailSender();

                var assunto = "Recuperacao de senha";
                var corpo = "sua senha é" + usuario.senha;

                emailSender.Enviar(assunto, corpo, usuario.email);
            }

            return result;
        }

        public Usuario ObterUsuario(Guid usuarioGuig)
        {
            var usuario = new UsuarioRepository(_connectionString).ObterPorGuid(usuarioGuig);

            return usuario; 
        }
    }
}