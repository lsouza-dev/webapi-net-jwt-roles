using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MyNetAPI.Context;
using MyNetAPI.Models;
using MyNetAPI.Models.DTO;

namespace MyNetAPI.Services
{
    public class UsuarioServices
    {
        private readonly MyApiContext _context;
        private LoginService _loginService;

        public UsuarioServices(MyApiContext context, LoginService loginService)
        {
            _context = context;
            _loginService = loginService;
        }

        public Usuario CriarUsuario(UsuarioCriacaoDTO usuarioDTO)
        {
            var usuario = new Usuario(usuarioDTO);
            var login = new Login(usuarioDTO);
            var perfil = _context.Perfis.Where(p => p.Id == usuarioDTO.Perfil).FirstOrDefault();

            usuario.Login = login;
            usuario.Perfil = perfil;
            login.Usuario = usuario;

            _context.Usuarios.Add(usuario);
            _context.Logins.Add(login);
            _context.SaveChanges();

            return usuario;
        }

        public List<UsuarioExibicaoDTO> ListarUsuarios()
        {
            var usuariosDb = _context.Usuarios.Where(u => u.Ativo == true).Include(u => u.Perfil);
            var dtos = usuariosDb.Select(u => new UsuarioExibicaoDTO(u)).ToList();
            return dtos;
        }

        public Usuario ObterPorId(int id)
        {
            return _context.Usuarios.Where(u => u.Id == id).Include(u => u.Perfil).FirstOrDefault();
        }

        public Usuario AtualizarUsuario(int id, UsuarioEdicaoDTO dto)
        {
            var usuarioDb = ObterPorId(id);
            if(usuarioDb == null) return null;

            var login = _loginService.ObterLoginPorUsuario(usuarioDb);

            usuarioDb.Atualizar(dto);
            login.Atualizar(dto);

            _context.Usuarios.Update(usuarioDb);
            _context.Logins.Update(login);
            _context.SaveChanges();

            return usuarioDb;
        }

        public bool DesativarUsuario(int id)
        {
            var usuario = ObterPorId(id);
            if(usuario == null) return false;

            usuario.Desativar();
            _context.SaveChanges();
            return true;
        }
    }
}