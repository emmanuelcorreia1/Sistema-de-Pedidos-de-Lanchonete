namespace SistemaPedidosLanchonete.Domain.Entities;

public class Pedido
{
    public int Id { get; private set; }
    public DateTime DataHora { get; private set; }
    public List<ItemPedido> Itens { get; private set; }
    public Cliente Cliente { get; private set; }
    public bool Cancelado { get; private set; }

    public Pedido(int id, DateTime dataHora, List<ItemPedido> itens, Cliente cliente)
    {
        Id = id;
        DataHora = dataHora;
        Itens = itens ?? new List<ItemPedido>();
        Cliente = cliente;
        Cancelado = false;
    }

    public void AdicionarItem(ItemPedido item)
    {
        if (Cancelado)
        {
            Console.WriteLine("Não é possível adicionar itens a um pedido cancelado.");
            return;
        }

        if (item == null)
        {
            Console.WriteLine("Item inválido.");
            return;
        }

        Itens.Add(item);
        Console.WriteLine("Item adicionado ao pedido com sucesso.");
    }

    public void RemoverItem(ItemPedido item)
    {
        if (Cancelado)
        {
            Console.WriteLine("Não é possível remover itens de um pedido cancelado.");
            return;
        }

        if (item == null || !Itens.Contains(item))
        {
            Console.WriteLine("Item não encontrado no pedido.");
            return;
        }

        Itens.Remove(item);
        Console.WriteLine("Item removido do pedido com sucesso.");
    }

    public void Cancelar()
    {
        if (Cancelado)
        {
            Console.WriteLine("Este pedido já estava cancelado.");
            return;
        }

        Cancelado = true;
        Console.WriteLine($"Pedido número {Id} cancelado com sucesso.");
    }

    public decimal CalcularTotal()
    {
        decimal total = 0m;
        foreach (ItemPedido item in Itens)
        {
            total += item.CalcularSubTotal();
        }
        return total;
    }

    public void ExibirPedido()
    {
        Console.WriteLine($"Pedido numero: {Id}");
        Console.WriteLine($"Data e hora: {DataHora:dd/MM/yyyy HH:mm}");

        if (Cliente != null)
        {
            Console.Write("Cliente: ");
            Cliente.ExibirDados();
        }
        else
        {
            Console.WriteLine("Cliente: (não informado)");
        }

        if (Cancelado)
        {
            Console.WriteLine("====PEDIDO CANCELADO====");
        }

        Console.WriteLine("Itens:");
        if (Itens.Count == 0)
        {
            Console.WriteLine("  (nenhum item)");
        }
        else
        {
            foreach (ItemPedido item in Itens)
            {
                Console.WriteLine($"  - {item.Produto.Nome} | Qtd: {item.Quantidade} | " +
                                  $"Preço Unit.: {item.PrecoUnitario:C} | " +
                                  $"Subtotal: {item.CalcularSubTotal():C}");
            }
        }

        Console.WriteLine($"TOTAL DO PEDIDO: {CalcularTotal():C}");
    }

}