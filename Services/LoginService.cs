using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyNetAPI.Context;
using MyNetAPI.Models;
using MyNetAPI.Models.DTO;
using MyNetAPI.Models.DTO.Login;

namespace MyNetAPI.Services
{
    public class LoginService
    {

        private readonly MyApiContext _context;

        public LoginService(MyApiContext context){
            _context = context;
        }


        public Login CriarLogin(UsuarioCriacaoDTO usuarioDTO){
            return new Login(usuarioDTO);
        }

        public Login ObterLoginPorUsuario(Usuario usuario){
            return _context.Logins.Where(l => l.Usuario == usuario).FirstOrDefault();
        }

        public Usuario RealizarLogin(LoginDTO dto){
            return _context.Usuarios.Where(l => l.Email == dto.Email && l.Senha == dto.Senha && l.Ativo == true).Include(u => u.Perfil).FirstOrDefault();
        }
    }
}