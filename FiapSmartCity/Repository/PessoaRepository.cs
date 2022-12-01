using FiapSmartCity.Models;
using System.Data;
using System.Data.SqlClient;


namespace FiapSmartCity.Repository
{
    public class PessoaRepository
    {
        public IList<Pessoa> Listar()
        {
            IList<Pessoa> listaPessoa = new List<Pessoa>();
            // STRING DE CONEXAO
            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("FiapSmartCityConnection");
            // CONEXAO COM O BANCO DE DADOS
            SqlConnection Connection = new SqlConnection(connectionString);
            Connection.Open();
            // EXECUTANDO A QUERY
            SqlCommand Command = new SqlCommand("SELECT *  FROM PESSOA", Connection);
            SqlDataReader Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                //recuperar os dados da tabela pessoa
                Pessoa pessoa = new Pessoa();
                pessoa.IdPessoa = Convert.ToInt32(Reader["IDPESSOA"]);
                pessoa.Nome = Reader["NOME"].ToString();
                pessoa.Telefone = Reader["PHONE"].ToString();

                listaPessoa.Add(pessoa);

            }
            // Fechando as Conexões
            Reader.Close();

            return listaPessoa;
        }

        public void Inserir(Pessoa pessoa)
        {
            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("FiapSmartCityConnection");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                    "INSERT INTO PESSOA ( NOME, PHONE ) VALUES ( @NOME, @PHONE ) ";
                SqlCommand command = new SqlCommand(query, connection);
                // Adicionando o valor ao comando
                command.Parameters.Add("@NOME", SqlDbType.Text);
                command.Parameters["@NOME"].Value = pessoa.Nome;
                command.Parameters.Add("@PHONE", SqlDbType.Text);
                command.Parameters["@PHONE"].Value = pessoa.Telefone;
                // Abrindo a conexão com  o Banco
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public Pessoa Consultar(int id)
        {
            Pessoa pessoa = new Pessoa();
            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("FiapSmartCityConnection");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                    "SELECT IDPESSOA, NOME, PHONE FROM PESSOA WHERE IDPESSOA = @ID ";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@ID", SqlDbType.Int);
                command.Parameters["@ID"].Value = id;
                connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    // Recupera os dados
                    pessoa.IdPessoa = Convert.ToInt32(dataReader["IDPESSOA"]);
                    pessoa.Nome = dataReader["NOME"].ToString();
                    pessoa.Telefone = dataReader["PHONE"].ToString();
                }
                connection.Close();
            } // Finaliza o objeto connection
            // Retorna a lista
            return pessoa;
        }

        public void Alterar(Pessoa pessoa)
        {
            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("FiapSmartCityConnection");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                    "UPDATE PESSOA SET NOME = @NOME , PHONE = @PHONE WHERE IDPESSOA = @ID  ";
                SqlCommand command = new SqlCommand(query, connection);
                // Adicionando o valor ao comando
                command.Parameters.Add("@NOME", SqlDbType.Text);
                command.Parameters.Add("@PHONE", SqlDbType.Text);
                command.Parameters.Add("@ID", SqlDbType.Int);
                command.Parameters["@NOME"].Value = pessoa.Nome;
                command.Parameters["@PHONE"].Value = pessoa.Telefone;
                command.Parameters["@ID"].Value = pessoa.IdPessoa;
                // Abrindo a conexão com  o Banco
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Excluir(int id)
        {
            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("FiapSmartCityConnection");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                    "DELETE PESSOA WHERE IDPESSOA = @id  ";
                SqlCommand command = new SqlCommand(query, connection);
                // Adicionando o valor ao comando
                command.Parameters.Add("@id", SqlDbType.Int);
                command.Parameters["@id"].Value = id;
                // Abrindo a conexão com  o Banco
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
        
        
}
