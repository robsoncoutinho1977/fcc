using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using System.Linq;
using DAL.Models;

namespace DAL
{
    public class Cliente
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Local"].ConnectionString);

        public void Salvar(string CPF, string Nome, string RG, DateTime DataExpedicao, string OrgaoExpedicao, string OrgaoExpedicaoUF, DateTime DataNascimento, string Sexo, string EstadoCivil,
            string CEP, string Logradouro, string Numero, string Complemento, string Bairro, string Cidade, string Estado, string Login, string Senha)
        {
            #region Cliente
            SqlCommand cmd = new SqlCommand("SalvarCliente", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CPF", SqlDbType.VarChar).Value = CPF;
            cmd.Parameters.AddWithValue("@Nome", SqlDbType.VarChar).Value = Nome;
            cmd.Parameters.AddWithValue("@RG", SqlDbType.VarChar).Value = RG;
            cmd.Parameters.AddWithValue("@DATAEXPEDCAO", SqlDbType.DateTime).Value = DataExpedicao;
            cmd.Parameters.AddWithValue("@ORGAOEXPEDICAO", SqlDbType.VarChar).Value = OrgaoExpedicao;
            cmd.Parameters.AddWithValue("@UF", SqlDbType.VarChar).Value = OrgaoExpedicaoUF;
            cmd.Parameters.AddWithValue("@DATANASCIMENTO", SqlDbType.DateTime).Value = DataNascimento;
            cmd.Parameters.AddWithValue("@SEXO", SqlDbType.VarChar).Value = Sexo;
            cmd.Parameters.AddWithValue("@ESTADOCIVIL", SqlDbType.VarChar).Value = EstadoCivil;
            cmd.Parameters.AddWithValue("@LOGIN", SqlDbType.VarChar).Value = Login;
            cmd.Parameters.AddWithValue("@SENHA", SqlDbType.VarChar).Value = Senha;
            cmd.Parameters.Add("@NewId", SqlDbType.Int).Direction = ParameterDirection.Output;

            con.Open();
            cmd.ExecuteNonQuery();
            int ClienteId = Convert.ToInt32(cmd.Parameters["@NewId"].Value);
            cmd.Dispose();
            con.Close();
            #endregion Cliente

            #region Endereco
            Endereco _endereco = new Endereco();
            _endereco.Salvar(ClienteId, CEP, Logradouro, Numero, Complemento, Bairro, Cidade, Estado);

            #endregion Endereco
        }

        public void Atualizar(int IdCliente, string CPF, string Nome, string RG, DateTime DataExpedicao, string OrgaoExpedicao, string OrgaoExpedicaoUF, DateTime DataNascimento, string Sexo, string EstadoCivil,
            string CEP, string Logradouro, string Numero, string Complemento, string Bairro, string Cidade, string Estado, string Login, string Senha)
        {
            #region Cliente
            SqlCommand cmd = new SqlCommand("AtualizarCliente", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@IDCLIENTE", SqlDbType.Int).Value = IdCliente;
            cmd.Parameters.AddWithValue("@CPF", SqlDbType.VarChar).Value = CPF;
            cmd.Parameters.AddWithValue("@Nome", SqlDbType.VarChar).Value = Nome;
            cmd.Parameters.AddWithValue("@RG", SqlDbType.VarChar).Value = RG;
            cmd.Parameters.AddWithValue("@DATAEXPEDCAO", SqlDbType.DateTime).Value = DataExpedicao;
            cmd.Parameters.AddWithValue("@ORGAOEXPEDICAO", SqlDbType.VarChar).Value = OrgaoExpedicao;
            cmd.Parameters.AddWithValue("@UF", SqlDbType.VarChar).Value = OrgaoExpedicaoUF;
            cmd.Parameters.AddWithValue("@DATANASCIMENTO", SqlDbType.DateTime).Value = DataNascimento;
            cmd.Parameters.AddWithValue("@SEXO", SqlDbType.VarChar).Value = Sexo;
            cmd.Parameters.AddWithValue("@ESTADOCIVIL", SqlDbType.VarChar).Value = EstadoCivil;
            cmd.Parameters.AddWithValue("@LOGIN", SqlDbType.VarChar).Value = Login;
            cmd.Parameters.AddWithValue("@SENHA", SqlDbType.VarChar).Value = Senha;
            cmd.Parameters.Add("@NewId", SqlDbType.Int).Direction = ParameterDirection.Output;

            con.Open();
            cmd.ExecuteNonQuery();
            int ClienteId = Convert.ToInt32(cmd.Parameters["@NewId"].Value);
            cmd.Dispose();
            con.Close();
            #endregion Cliente

            #region Endereco
            Endereco _endereco = new Endereco();
            _endereco.Salvar(ClienteId, CEP, Logradouro, Numero, Complemento, Bairro, Cidade, Estado);

            #endregion Endereco
        }

        public void Excluir(int IdCliente)
        {
            #region Cliente
            SqlCommand cmd = new SqlCommand("ExcluirCliente", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDCLIENTE", SqlDbType.Int).Value = IdCliente;

            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            #endregion Cliente

            #region Endereco
            Endereco _endereco = new Endereco();
            _endereco.Excluir(IdCliente);

            #endregion Endereco
        }


        public ICollection<ClienteModel> BuscarClientes()
        {

            List<ClienteModel> _clientes = new List<ClienteModel>();

            SqlCommand cmd = new SqlCommand("BuscarCliente", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", SqlDbType.VarChar).Value = 0;

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ClienteModel _cliente = new ClienteModel();
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
                    _clientes.Add(_cliente);
                }
            }

            cmd.Dispose();
            con.Close();

            return _clientes;
        }

        public ClienteModel BuscarCliente(int ID)
        {
            if (ID == null)
            {
                ID = 0;
            }

            ClienteModel _cliente = new ClienteModel();

            SqlCommand cmd = new SqlCommand("BuscarCliente", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", SqlDbType.VarChar).Value = ID;

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
                _cliente.login = reader["Login"].ToString();
                _cliente.senha = reader["Senha"].ToString();

                Endereco _endereco = new Endereco();
                _cliente.Endereco = _endereco.Buscar(_cliente.ID);
            }

            cmd.Dispose();
            con.Close();

            return _cliente;
        }
    }
}
