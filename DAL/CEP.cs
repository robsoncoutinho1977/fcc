using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class CEP
    {
        public CepModel Buscar(string cep)
        {
            CepModel _cep = new CepModel();

            var _correios = new Correios.NET.CorreiosService().GetAddresses(cep).First();
            if (_correios != null)
            {
                _cep.Logradouro = _correios.Street;
                _cep.Bairro = _correios.District;
                _cep.Cidade = _correios.City;
                _cep.Estado = _correios.State;
            }

            return _cep;
        }
    }
}
