using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Models;

namespace Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        [HttpGet("{id}")]
        public ActionResult<ClienteModel> GetCliente(int id)
        {
            try
            {
                ClienteModel _cliente = new ClienteModel();
                BLL.Cliente bllCliente = new BLL.Cliente();
                _cliente = bllCliente.Buscar(id);
                return _cliente;
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<ClienteModel>> GetClientes()
        {
            List<ClienteModel> _clientes = new List<ClienteModel>();
            try
            {
                BLL.Cliente bllCliente = new BLL.Cliente();
                _clientes = bllCliente.Buscar().ToList();
                return _clientes;
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public ActionResult PostCliente(IFormCollection obj)
        {
            try
            {
                string CPF              = obj["CPF "].ToString();
                string Nome             = obj["Nome"].ToString();
                string RG               = obj["RG"].ToString();
                DateTime DataExpedicao  = Convert.ToDateTime(obj["DataExpedicao"]);
                string OrgaoExpedicao   = obj["OrgaoExpedicao"].ToString();
                string UF               = obj["UF"].ToString();
                DateTime DataNascimento = Convert.ToDateTime(obj["DataNascimento"]);
                string Sexo             = obj["Sexo"].ToString();
                string EstadoCivil      = obj["EstadoCivil"].ToString();
                string CEP              = obj["CEP"].ToString();
                string Logradouro       = obj["Logradouro"].ToString();
                string Numero           = obj["Numero"].ToString();
                string Complemento      = obj["Complemento"].ToString();
                string Bairro           = obj["Bairro"].ToString();
                string Cidade           = obj["Cidade"].ToString();
                string Estado           = obj["Estado"].ToString();
                string Login            = obj["Login"].ToString();
                string Senha            = obj["Senha"].ToString();

                BLL.Cliente bllCliente = new BLL.Cliente();
                bllCliente.Salvar(CPF, Nome, RG, DataExpedicao, OrgaoExpedicao, UF, DataNascimento, Sexo, EstadoCivil, CEP, Logradouro, Numero, Complemento, Bairro, Cidade, Estado, Login, Senha);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public ActionResult PutCliente(IFormCollection obj)
        {
            try
            {
                int IdCliente           = Convert.ToInt32(obj["IdCliente "]);
                string CPF              = obj["CPF "].ToString();
                string Nome             = obj["Nome"].ToString();
                string RG               = obj["RG"].ToString();
                DateTime DataExpedicao  = Convert.ToDateTime(obj["DataExpedicao"]);
                string OrgaoExpedicao   = obj["OrgaoExpedicao"].ToString();
                string UF               = obj["UF"].ToString();
                DateTime DataNascimento = Convert.ToDateTime(obj["DataNascimento"]);
                string Sexo             = obj["Sexo"].ToString();
                string EstadoCivil      = obj["EstadoCivil"].ToString();
                string CEP              = obj["CEP"].ToString();
                string Logradouro       = obj["Logradouro"].ToString();
                string Numero           = obj["Numero"].ToString();
                string Complemento      = obj["Complemento"].ToString();
                string Bairro           = obj["Bairro"].ToString();
                string Cidade           = obj["Cidade"].ToString();
                string Estado           = obj["Estado"].ToString();
                string Login            = obj["Login"].ToString();
                string Senha            = obj["Senha"].ToString();

                BLL.Cliente bllCliente = new BLL.Cliente();
                bllCliente.Atualizar(IdCliente, CPF, Nome, RG, DataExpedicao, OrgaoExpedicao, UF, DataNascimento, Sexo, EstadoCivil, CEP, Logradouro, Numero, Complemento, Bairro, Cidade, Estado, Login, Senha);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult ApagaCliente(int id)
        {
            try
            {
                ClienteModel _cliente = new ClienteModel();
                BLL.Cliente bllCliente = new BLL.Cliente();
                bllCliente.Excluir(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
