namespace SistemaPedidosLanchonete.Domain.Entities;

public class Cliente
{
    public int Id { get; private set; }
    public string Nome { get; private set; }
    public string Telefone { get; private set; }

    public Cliente(int id, string nome, string telefone)
    {
        Id = id;
        Nome = nome;
        Telefone = nome;
    }

    public void ExibirDados()
    {
        Console.WriteLine($"Id: {Id}");
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Telefone: {Telefone}");
    }
}
