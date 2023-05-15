using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CepController : Controller
    {
        [HttpGet]
        public ActionResult<CepModel> Busca(string cep)
        {
            try
            {
                CepModel _cep = new CepModel();
                BLL.CEP bllCliente = new BLL.CEP();
                _cep = bllCliente.Buscar(cep);
                return _cep;
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
