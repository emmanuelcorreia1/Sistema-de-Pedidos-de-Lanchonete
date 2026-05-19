namespace SistemaPedidosLanchonete.Domain.Entities;

public class Ingrediente
{
    public int Id { get; private set; }
    public string Nome { get; private set; }
    public string UnidadeMedida { get; private set; }
    public decimal QuantidadeEstoque { get; private set; }
    public decimal CustoUnitario { get; private set; }

    public Ingrediente(int id, string nome, string unidadeMedida, decimal quantidadeEstoque, decimal custoUnitario)
    {
        Id = id;
        Nome = nome;
        UnidadeMedida = unidadeMedida;
        QuantidadeEstoque = quantidadeEstoque;
        CustoUnitario = custoUnitario;
    }
    public void DiminuirEstoque(decimal quantidade)
    {
        if (quantidade <= 0)
        {
            Console.WriteLine("A quantidade a diminuir deve ser maior que zero.");
            return;
        }
        if (quantidade > QuantidadeEstoque)
        {
            Console.WriteLine($"Estoque insuficiente. Disponível: {QuantidadeEstoque} {UnidadeMedida}.");
            return;
        }
        QuantidadeEstoque -= quantidade;
        if (QuantidadeEstoque < 0)
        {
            QuantidadeEstoque = 0;
        }
        Console.WriteLine($"Estoque de {Nome} atualizado para {QuantidadeEstoque} {UnidadeMedida}.");
    }

    public void ExibirIngrediente()
    {
        Console.WriteLine($"Id: {Id}");
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Unidade: {UnidadeMedida}");
        Console.WriteLine($"Estoque: {QuantidadeEstoque}");
        Console.WriteLine($"Custo Unitário: {CustoUnitario:C}");
    }
}