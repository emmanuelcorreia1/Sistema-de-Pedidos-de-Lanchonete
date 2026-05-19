namespace SistemaPedidosLanchonete.Domain.Entities;

public abstract class Produto
{
    public int Codigo { get; protected set; }
    public string Nome { get; protected set; }
    public decimal PrecoBase { get; protected set; }
    public List<Ingrediente> Ingredientes { get; private set; }

    protected Produto(int codigo, string nome, decimal precoBase)
    {
        Codigo = codigo;
        Nome = nome;
        PrecoBase = precoBase;
        Ingredientes = new List<Ingrediente>();
    }
    public abstract decimal CalcularPreco();

    public virtual void ExibirInformacoes()
    {
        Console.WriteLine($"Código: {Codigo}");
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Preço Base: {PrecoBase:C}");
        Console.WriteLine($"Preço Final: {CalcularPreco():C}");

        if (Ingredientes.Count == 0)
        {
            Console.WriteLine("  Ingredientes: (nenhum)");
        }
        else
        {
            Console.WriteLine("  Ingredientes:");
            foreach (Ingrediente ingrediente in Ingredientes)
            {
                Console.Write("   - ");
                ingrediente.ExibirIngrediente();
            }
        }
    }

    public void AdicionarIngrediente(Ingrediente ingrediente)
    {
        if (ingrediente == null)
        {
            Console.WriteLine("Ingrediente inválido.");
            return;
        }

        Ingredientes.Add(ingrediente);
    }

    public void RemoverIngrediente(Ingrediente ingrediente)
    {
        if (ingrediente == null || !Ingredientes.Contains(ingrediente))
        {
            Console.WriteLine("Ingrediente não encontrado neste produto.");
            return;
        }

        Ingredientes.Remove(ingrediente);
    }
}