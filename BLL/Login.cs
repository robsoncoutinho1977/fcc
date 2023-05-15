using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class Login
    {
        public TokenModel Gerar(string login, string senha)
        {
            DAL.Login dalLogin = new DAL.Login();
            return dalLogin.GerarToken(login, senha);
        }
    }
}
