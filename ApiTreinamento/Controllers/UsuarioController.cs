using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using ApiTreinamento.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTreinamento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public static List<UsuarioViewModel> users = new List<UsuarioViewModel>();

        public UsuarioController()
        {
            
        }

        [HttpGet]
        public ActionResult Get()
        {
            if (users.Count == 0)
            {
                users.Add(new UsuarioViewModel(1, "Wes Um", "wes@testeum.com"));
                users.Add(new UsuarioViewModel(2, "Wes Dois", "wes@testedois.com"));
                users.Add(new UsuarioViewModel(3, "Wes Tres", "wes@testetres.com"));
            }              

            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            UsuarioViewModel usuario = users.FirstOrDefault(x => x.Id == id);

            return Ok(usuario);
        }

        [HttpPost]
        public ActionResult Post([FromBody] UsuarioViewModel usuario) 
        {
            users.Add(usuario);

            return Ok("Cadastrado realizado com sucesso!");
        }

        [HttpPut]
        public ActionResult Put([FromBody] UsuarioViewModel usuario)
        {
            var usuarioModel = users.Where(x => x.Id != usuario.Id).ToList();

            users = usuarioModel;
            users.Add(usuario);

            return Ok("Alteração realizada com sucesso!");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var usuarioModel = users.Where(x => x.Id != id).ToList();

            users = usuarioModel;

            return Ok("Alteração realizada com sucesso!");
        }

    }
}
