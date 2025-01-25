using System.ComponentModel.DataAnnotations;
using MyNetAPI.Models.DTO;

namespace MyNetAPI.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        [MaxLength(11)]
        public string Cpf { get; set; }
        [Required]
        public int Idade { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
         [Required]
        [MinLength(6)]
        public string Senha { get; set; }

        public Login Login {get; set;}
        
        public bool Ativo {get; set;} = true;
        public int? PerfilId {get; set;} // FK
        public Perfil Perfil {get; set;}

        public Usuario(){}

        public Usuario(UsuarioCriacaoDTO u){
            Nome = u.Nome;
            Cpf = u.Cpf;
            Idade = u.Idade;
            Email = u.Email;
            Senha = u.Senha;
            Ativo = true;
            PerfilId = u.Perfil;
        }

        public Usuario Atualizar(UsuarioEdicaoDTO dto){
            if(dto.Nome != null) this.Nome = dto.Nome;
            
            return this;
        }

        public void Desativar()
        {   
            this.Ativo = false;
        }
    }
}
