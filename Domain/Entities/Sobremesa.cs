namespace SistemaPedidosLanchonete.Domain.Entities;

public class Sobremesa: Produto, IPromocao
{
    public int Calorias { get; private set; }

    public Sobremesa(int codigo, string nome, decimal precoBase, int calorias)
        : base(codigo, nome, precoBase)
    {
        Calorias = calorias < 0 ? 0 : calorias;
    }

    public override decimal CalcularPreco()
    {
        return AplicarPromocao();
    }

    public override void ExibirInformacoes()
    {
        Console.WriteLine("=====SOBREMESA=====");
        base.ExibirInformacoes();
        Console.WriteLine($"  Calorias: {Calorias}");
        Console.WriteLine($"  Em promoção: {(EstaEmPromocao() ? "Sim (15% off)" : "Não")}");
    }

    public bool EstaEmPromocao()
    {
        return Calorias > 300;
    }

    public decimal AplicarPromocao()
    {
        return EstaEmPromocao() ? PrecoBase * 0.85m : PrecoBase;
    }
}