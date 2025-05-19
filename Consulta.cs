using MySql.Data.MySqlClient;
using System;
public class Consulta
{
    public int PacienteId { get; set; }
    public int MedicoId { get; set; }
    public DateTime DataHora { get; set; }
    public Consulta(int pacienteId, int medicoId, DateTime dataHora)
    {
    PacienteId = pacienteId;
    MedicoId = medicoId;
    DataHora = dataHora;
}
public void Salvar()
{
    using (MySqlConnection con = Conexao.ObterConexao())
    {
        MySqlCommand cmd = new MySqlCommand("INSERT INTO Consulta (paciente_id, medico_id, data_hora) VALUES (@pid, @mid, @data)", con);
        cmd.Parameters.AddWithValue("@pid", PacienteId);
        cmd.Parameters.AddWithValue("@mid", MedicoId);
        cmd.Parameters.AddWithValue("@data", DataHora);
        cmd.ExecuteNonQuery();
    }
}
    public static void ListarTodas()
    {
        using (MySqlConnection con = Conexao.ObterConexao())
        {
            MySqlCommand cmd = new MySqlCommand(@"
            SELECT c.id, p.nome AS paciente, m.nome AS medico, c.data_hora
            FROM Consulta c
            JOIN Paciente p ON c.paciente_id = p.id
            JOIN Medico m ON c.medico_id = m.id
            ORDER BY c.data_hora", con);
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                Console.WriteLine("\n--- Lista de Consultas ---");
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["id"]}, Paciente: {reader["paciente"]}, Médico: {reader["medico"]}, Data: {reader["data_hora"]}");
                }
            }
        }
    }
     public static void ConsultarPorId(int id)
     {
        using (MySqlConnection con = Conexao.ObterConexao())
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM Consulta WHERE id = @id", con);
            cmd.Parameters.AddWithValue("@id", id);
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["id"]}, PacienteID: {reader["paciente_id"]}, MedicoID: {reader["medico_id"]}, DataHora: {reader["data_hora"]}");
                }
                else
                {
                    Console.WriteLine("Consulta não encontrada.");
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
                MySqlCommand deletarCmd = new MySqlCommand("DELETE FROM Consulta WHERE id = @id", con);
                deletarCmd.Parameters.AddWithValue("@id", id);
                int linhasAfetadas = deletarCmd.ExecuteNonQuery();

                if (linhasAfetadas > 0)
                {
                    Console.WriteLine("Consulta deletada com sucesso.");
                }
                else
                {
                    Console.WriteLine("Consulta não encontrada.");
                }
            }
            catch (MySqlException ex)
            {              
                    Console.WriteLine($"Erro ao tentar deletar a consulta: {ex.Message}");
                }
            }
        }
     }
