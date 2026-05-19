namespace SistemaPedidosLanchonete.Domain.Entities;

public class ItemPedido
{
    public Produto Produto { get; private set; }
    public int Quantidade { get; private set; }
    public decimal PrecoUnitario { get; private set; }

    public ItemPedido(Produto produto, int quantidade, decimal precoUnitario)
    {
        Produto = produto;
        Quantidade = quantidade;
        PrecoUnitario = precoUnitario;
    }

    public decimal CalcularSubTotal()
    {
        return Quantidade * PrecoUnitario;
    }
}