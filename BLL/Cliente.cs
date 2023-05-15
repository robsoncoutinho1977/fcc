using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class Cliente
    {
        public bool Salvar(string CPF, string Nome, string RG, DateTime DataExpedicao, string OrgaoExpedicao, string OrgaoExpedicaoUF, DateTime DataNascimento, string Sexo, string EstadoCivil,
            string CEP, string Logradouro, string Numero, string Complemento, string Bairro, string Cidade, string Estado, string Login, string Senha)
        {
            try
            {
                DAL.Cliente dalCliente = new DAL.Cliente();
                dalCliente.Salvar(CPF, Nome, RG, DataExpedicao, OrgaoExpedicao, OrgaoExpedicaoUF, DataNascimento, Sexo, EstadoCivil, CEP, Logradouro, Numero, Complemento, Bairro, Cidade, Estado, Login, Senha);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Atualizar(int IdCliente, string CPF, string Nome, string RG, DateTime DataExpedicao, string OrgaoExpedicao, string OrgaoExpedicaoUF, DateTime DataNascimento, string Sexo, string EstadoCivil,
            string CEP, string Logradouro, string Numero, string Complemento, string Bairro, string Cidade, string Estado, string Login, string Senha)
        {
            DAL.Cliente dalCliente = new DAL.Cliente();
            dalCliente.Atualizar(IdCliente,CPF, Nome, RG, DataExpedicao, OrgaoExpedicao, OrgaoExpedicaoUF, DataNascimento, Sexo, EstadoCivil, CEP, Logradouro, Numero, Complemento, Bairro, Cidade, Estado, Login, Senha);
        }

        public void Excluir(int IdCliente)
        {
            DAL.Cliente dalCliente = new DAL.Cliente();
            dalCliente.Excluir(IdCliente);
        }

        public ICollection<ClienteModel> Buscar()
        {
            //List<ClienteModel> _clientes = new List<ClienteModel>();

            DAL.Cliente dalCliente = new DAL.Cliente();
            return dalCliente.BuscarClientes();
        }

        public ClienteModel Buscar(int ID)
        {
            DAL.Cliente dalCliente = new DAL.Cliente();
            return dalCliente.BuscarCliente(ID);
        }
    }
}
