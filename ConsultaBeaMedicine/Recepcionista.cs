using MySql.Data.MySqlClient;
using System;

public class Recepcionista : Pessoa
{
    public string Turno { get; set; }

    public Recepcionista(string nome, string cpf, string turno)
        : base(nome, cpf)
    {
        Turno = turno;
    }

    public override void Salvar()
    {
        using (MySqlConnection con = Conexao.ObterConexao())
        {
            MySqlCommand cmd = new MySqlCommand("INSERT INTO Recepcionista (nome, cpf, turno) VALUES (@nome, @cpf, @turno)", con);
            cmd.Parameters.AddWithValue("@nome", Nome);
            cmd.Parameters.AddWithValue("@cpf", CPF);
            cmd.Parameters.AddWithValue("@turno", Turno);
            cmd.ExecuteNonQuery();
        }
    }

    public override void MostrarInfo()
    {
        Console.WriteLine($"Recepcionista: {Nome}, Turno: {Turno}");
    }

    public static void ListarTodos()
    {
        using (MySqlConnection con = Conexao.ObterConexao())
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM Recepcionista", con);
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                Console.WriteLine("\n--- Lista de Recepcionistas ---");
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["id"]}, Nome: {reader["nome"]}, CPF: {reader["cpf"]}, Turno: {reader["turno"]}");
                }
            }
        }
    }
    public static void ConsultarPorId(int id)
    {
        using (MySqlConnection con = Conexao.ObterConexao())
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM Recepcionista WHERE id = @id", con);
            cmd.Parameters.AddWithValue("@id", id);
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["id"]}, Nome: {reader["nome"]}, CPF: {reader["cpf"]}, Turno: {reader["turno"]} ");
                }
                else
                {
                    Console.WriteLine("Recepcionista não encontrada.");
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
                MySqlCommand deletarCmd = new MySqlCommand("DELETE FROM Recepcionista WHERE id = @id", con);
                deletarCmd.Parameters.AddWithValue("@id", id);
                int linhasAfetadas = deletarCmd.ExecuteNonQuery();

                if (linhasAfetadas > 0)
                {
                    Console.WriteLine("Recepcionista deletada com sucesso.");
                }
                else
                {
                    Console.WriteLine("Recepcionista não encontrada.");
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro ao tentar deletar a recepcionista: {ex.Message}");
            }
        }
    }
}
