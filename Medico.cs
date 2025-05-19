using MySql.Data.MySqlClient;
using System;

public class Medico : Pessoa
{
    public string Especialidade { get; set; }

    public Medico(string nome, string cpf, string especialidade)
        : base(nome, cpf)
    {
        Especialidade = especialidade;
    }

    public override void Salvar()
    {
        using (MySqlConnection con = Conexao.ObterConexao())
        {
            MySqlCommand cmd = new MySqlCommand("INSERT INTO Medico (nome, cpf, especialidade) VALUES (@nome, @cpf, @especialidade)", con);
            cmd.Parameters.AddWithValue("@nome", Nome);
            cmd.Parameters.AddWithValue("@cpf", CPF);
            cmd.Parameters.AddWithValue("@especialidade", Especialidade);
            cmd.ExecuteNonQuery();
        }
    }

    public override void MostrarInfo()
    {
        Console.WriteLine($"Dr. {Nome}, Especialidade: {Especialidade}");
    }

    public static void ListarTodos()
    {
        using (MySqlConnection con = Conexao.ObterConexao())
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM Medico", con);
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                Console.WriteLine("\n--- Lista de Médicos ---");
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["id"]}, Nome: {reader["nome"]}, CPF: {reader["cpf"]}, Especialidade: {reader["especialidade"]}");
                }
            }
        }
    }
    public static void ConsultarPorId(int id)
    {
        using (MySqlConnection con = Conexao.ObterConexao())
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM Medico WHERE id = @id", con);
            cmd.Parameters.AddWithValue("@id", id);
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["id"]}, Nome: {reader["nome"]}, CPF: {reader["cpf"]}, Especialidade: {reader["especialidade"]} ");
                }
                else
                {
                    Console.WriteLine("Medico não encontrado.");
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
                MySqlCommand deletarCmd = new MySqlCommand("DELETE FROM Medico WHERE id = @id", con);
                deletarCmd.Parameters.AddWithValue("@id", id);
                int linhasAfetadas = deletarCmd.ExecuteNonQuery();

                if (linhasAfetadas > 0)
                {
                    Console.WriteLine("Médico deletado com sucesso.");
                }
                else
                {
                    Console.WriteLine("Médico não encontrado.");
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1451) // erro de chave estrangeira
                {
                    Console.WriteLine("Não é possível deletar o médico porque ele possui consultas associadas.");
                }
                else
                {
                    Console.WriteLine($"Erro ao tentar deletar o médico: {ex.Message}");
                }
            }
        }
    }
}
