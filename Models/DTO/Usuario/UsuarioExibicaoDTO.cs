using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MyNetAPI.Models.DTO
{
   public record UsuarioExibicaoDTO
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int Idade { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
        public string Perfil { get; set; }


        public UsuarioExibicaoDTO(Usuario u){
            Nome = u.Nome;
            Cpf = u.Cpf;
            Idade = u.Idade;
            Email = u.Email;
            Ativo = u.Ativo;
            Perfil = u.Perfil.Nome;
        }
    }
}