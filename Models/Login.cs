using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MyNetAPI.Models.DTO;

namespace MyNetAPI.Models
{
    public class Login
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email{ get; set; }
        [Required]
        [MinLength(6)]
        public string Senha { get; set; }

        [Required]
        public Usuario Usuario {get; set;}
        
        
        
        public Login(){}

        public Login(UsuarioCriacaoDTO usuarioDTO){
            Email = usuarioDTO.Email;
            Senha = usuarioDTO.Senha;
        }

        public Login Atualizar(UsuarioEdicaoDTO dTO){
            if(dTO.Email != null) this.Email = dTO.Email;
            if(dTO.Senha != null) this.Senha = dTO.Senha;
            
            return this;
        }
    }

}