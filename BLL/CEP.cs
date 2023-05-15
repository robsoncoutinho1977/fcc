using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class CEP
    {
        public CepModel Buscar(string cep)
        {
            CepModel _cepModel = new CepModel();

            DAL.CEP dalCep = new DAL.CEP();
            _cepModel = dalCep.Buscar(cep);

            return _cepModel;
        }
    }
}
