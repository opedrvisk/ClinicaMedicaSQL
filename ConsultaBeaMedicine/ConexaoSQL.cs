using MySql.Data.MySqlClient;

public static class Conexao
{
    private const string connectionString = "server=localhost;user=root;password=;database=ClinicaMedicaDB;";

    public static MySqlConnection ObterConexao()
    {
        var conexao = new MySqlConnection(connectionString);
        conexao.Open();
        return conexao;
    }
}
