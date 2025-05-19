using MySql.Data.MySqlClient;
using System;

public class Paciente : Pessoa
{
    public string Convenio { get; set; }

    public Paciente(string nome, string cpf, string convenio)
        : base(nome, cpf)
    {
        Convenio = convenio;
    }

    public override void Salvar()
    {
        using (MySqlConnection con = Conexao.ObterConexao())
        {
            MySqlCommand cmd = new MySqlCommand("INSERT INTO Paciente (nome, cpf, convenio) VALUES (@nome, @cpf, @convenio)", con);
            cmd.Parameters.AddWithValue("@nome", Nome);
            cmd.Parameters.AddWithValue("@cpf", CPF);
            cmd.Parameters.AddWithValue("@convenio", Convenio);
            cmd.ExecuteNonQuery();
        }
    }

    public override void MostrarInfo()
    {
        Console.WriteLine($"Paciente: {Nome}, Convênio: {Convenio}");
    }

    public static void ListarTodos()
    {
        using (MySqlConnection con = Conexao.ObterConexao())
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM Paciente", con);
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                Console.WriteLine("\n--- Lista de Pacientes ---");
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["id"]}, Nome: {reader["nome"]}, CPF: {reader["cpf"]}, Convênio: {reader["convenio"]}");
                }
            }
        }
    }

    public static void ConsultarPorId(int id)
    {
        using (MySqlConnection con = Conexao.ObterConexao())
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM Paciente WHERE id = @id", con);
            cmd.Parameters.AddWithValue("@id", id);
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["id"]}, Nome: {reader["nome"]}, CPF: {reader["cpf"]}, Convênio: {reader["convenio"]}");
                }
                else
                {
                    Console.WriteLine("Paciente não encontrado.");
                }
            }
        }
    }

    public static void Deletar(int id)
    {
        using (MySqlConnection con = Conexao.ObterConexao())
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("DELETE FROM Paciente WHERE id = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
                int linhasAfetadas = cmd.ExecuteNonQuery();

                if (linhasAfetadas > 0)
                {
                    Console.WriteLine("Paciente deletado com sucesso.");
                }
                else
                {
                    Console.WriteLine("Paciente não encontrado.");
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1451) // erro de chave estrangeira
                {
                    Console.WriteLine("Não é possível deletar o paciente porque ele possui consultas associadas.");
                }
                else
                {
                    Console.WriteLine($"Erro ao tentar deletar o paciente: {ex.Message}");
                }
            }
        }
    }
}
