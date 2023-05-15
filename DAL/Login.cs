using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DAL
{
    public class Login : ControllerBase
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Local"].ConnectionString);

        public TokenModel GerarToken(string login, string senha)
        {           

            TokenModel _token = new TokenModel();
            if (String.IsNullOrEmpty(login) || String.IsNullOrEmpty(senha))
            {
                _token.status = 0;
                _token.mensagem = "Nome de Usuário e/ou Senha Não Informado(s)!";
                _token.cliente = null;
                _token.token = null;
                return _token;
            }

            ClienteModel _cliente = new ClienteModel();
            SqlCommand cmd = new SqlCommand("LogarCliente", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LOGIN", SqlDbType.VarChar).Value = login;
            cmd.Parameters.AddWithValue("@SENHA", SqlDbType.VarChar).Value = senha;

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                _cliente.CPF = reader["CPF"].ToString();
                _cliente.Nome = reader["Nome"].ToString();
                _cliente.RG = reader["RG"].ToString();
                _cliente.DataExpedicao = Convert.ToDateTime(reader["DataExpedicao"]);
                _cliente.OrgaoExpedicao = reader["OrgaoExpedicao"].ToString();
                _cliente.UF = reader["UF"].ToString();
                _cliente.DataNascimento = Convert.ToDateTime(reader["DataNascimento"]);
                _cliente.Sexo = reader["Sexo"].ToString();
                _cliente.EstadoCivil = reader["EstadoCivil"].ToString();

                Endereco _endereco = new Endereco();
                _cliente.Endereco = _endereco.Buscar(_cliente.ID);

                string chave = "dfusa7f9090dfsiaisfdasfiuasjasdfa90cvzxxzcvasf998dfspd";

                _token.status = 1;
                _token.mensagem = "";
                _token.cliente = _cliente;

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(chave);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim("Nome", _cliente.Nome.ToString()),
                    new Claim(ClaimTypes.Role, "CLI")
                    }),
                    Expires = DateTime.UtcNow.AddHours(2),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                //return tokenHandler.WriteToken(token);
                _token.token = tokenHandler.WriteToken(token);

                HttpContext.Session.SetInt32("id", _cliente.ID);
                HttpContext.Session.SetString("nomeusuario", _cliente.login);
                HttpContext.Session.SetString("perfil", "cli");
                HttpContext.Session.SetString("cpf", _cliente.CPF);
            }
            else
            {
                cmd.Dispose();
                con.Close();

                _token.status = 0;
                _token.mensagem = "Nome de Usuário e/ou Senha Inválido(s)!";
                _token.cliente = null;
                _token.token = null;
                return _token;
            }

            cmd.Dispose();
            con.Close();

            return _token;
        }

    }
}
