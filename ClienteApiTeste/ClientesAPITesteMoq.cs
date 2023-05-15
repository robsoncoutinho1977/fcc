using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using BLL;

namespace ClienteApiTeste
{
    [TestClass]
    public class ClientesAPITesteMoq
    {
        private Cliente _target;
        private Mock<ICliente> _mock;

        [TestMethod]
        public void ClienteSalvaTeste()
        {
            _mock = new Mock<ICliente>();

            string CPF = "25485848584";
            string Nome = "Teste";
            string RG = "254858585";
            DateTime DataExpedicao = System.DateTime.Now;
            string OrgaoExpedicao = "SSP";
            string OrgaoExpedicaoUF = "SP";
            DateTime DataNascimento = System.DateTime.Now;
            string Sexo = "Masculino";
            string EstadoCivil = "Casado";
            string CEP = "05772090";
            string Logradouro = "Rua Teste";
            string Numero = "10";
            string Complemento = "";
            string Bairro = "Campo Limpo";
            string Cidade = "São Paulo";
            string Estado = "SP";
            string Login = "teste";
            string Senha = "teste";

            bool esperado = true;
            bool obtido = _target.Salvar(CPF, Nome, RG, DataExpedicao, OrgaoExpedicao, OrgaoExpedicaoUF, DataNascimento, Sexo, EstadoCivil, CEP, Logradouro, Numero, Complemento, Bairro, Cidade, Estado, Login, Senha);

            Assert.AreEqual(esperado, obtido);
        }
    }
}
