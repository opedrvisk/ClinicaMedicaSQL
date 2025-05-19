using System;

public class Pessoa
{
    public string Nome { get; set; }
    public string CPF { get; set; }

    public Pessoa(string nome, string cpf)
    {
        Nome = nome;
        CPF = cpf;
    }

    public virtual void Salvar()
    {
    }

    public virtual void MostrarInfo()
    {
        Console.WriteLine($"Nome: {Nome}, CPF: {CPF}");
    }
}
