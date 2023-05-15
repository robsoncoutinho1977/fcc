using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class Endereco
    {
        public void Salvar(int IdCliente, string CEP, string Logradouro, string Numero, string Complemento, string Bairro, string Cidade, string Estado)
        {
            DAL.Endereco dalCliente = new DAL.Endereco();
            dalCliente.Salvar(IdCliente, CEP, Logradouro, Numero, Complemento, Bairro, Cidade, Estado);
        }
    }
}
