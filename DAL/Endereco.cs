using DAL.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class Endereco
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Local"].ConnectionString);

        public EnderecoModel Buscar(int? idcliente)
        {         
            EnderecoModel _endereco = new EnderecoModel();

            SqlCommand cmd = new SqlCommand("BuscarEndereco", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDCLIENTE", SqlDbType.Int).Value = idcliente;

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();

                _endereco.CEP         = reader["CEP"].ToString();
                _endereco.Logradouro  = reader["Logradouro"].ToString();
                _endereco.Numero      = reader["Numero"].ToString();
                _endereco.Complemento = reader["Complemento"].ToString();
                _endereco.Bairro      = reader["Bairro"].ToString();
                _endereco.Cidade      = reader["Cidade"].ToString();
                _endereco.UF          = reader["UF"].ToString();
            }
            else
            {
                _endereco.CEP         = "";
                _endereco.Logradouro  = "";
                _endereco.Numero      = "";
                _endereco.Complemento = "";
                _endereco.Bairro      = "";
                _endereco.Cidade      = "";
                _endereco.UF          = "";
            }

            cmd.Dispose();
            con.Close();

            return _endereco;
        }

        public void Salvar(int IdCliente, string CEP, string Logradouro, string Numero, string Complemento, string Bairro, string Cidade, string Estado)
        {
            SqlCommand cmd2 = new SqlCommand("SalvarEndereco", con);
            cmd2.CommandType = CommandType.StoredProcedure;

            cmd2.Parameters.AddWithValue("@IDCLIENTE", SqlDbType.Int).Value = IdCliente;
            cmd2.Parameters.AddWithValue("@CEP", SqlDbType.VarChar).Value = CEP;
            cmd2.Parameters.AddWithValue("@LOGRADOURO", SqlDbType.VarChar).Value = Logradouro;
            cmd2.Parameters.AddWithValue("@NUMERO", SqlDbType.VarChar).Value = Numero;
            cmd2.Parameters.AddWithValue("@COMPLEMENTO", SqlDbType.VarChar).Value = Complemento;
            cmd2.Parameters.AddWithValue("@BAIRRO", SqlDbType.VarChar).Value = Bairro;
            cmd2.Parameters.AddWithValue("@CIDADE", SqlDbType.VarChar).Value = Cidade;
            cmd2.Parameters.AddWithValue("@UF", SqlDbType.VarChar).Value = Estado;

            con.Open();
            cmd2.ExecuteNonQuery();
            cmd2.Dispose();
            con.Close();
        }

        public void Excluir(int IdCliente)
        {
            SqlCommand cmd2 = new SqlCommand("ExcluirEndereco", con);
            cmd2.CommandType = CommandType.StoredProcedure;

            cmd2.Parameters.AddWithValue("@IDCLIENTE", SqlDbType.Int).Value = IdCliente;

            con.Open();
            cmd2.ExecuteNonQuery();
            cmd2.Dispose();
            con.Close();
        }
    }
}
