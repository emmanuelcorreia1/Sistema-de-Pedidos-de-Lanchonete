namespace SistemaPedidosLanchonete.Domain.Entities;

public class Lanche: Produto, IPromocao
{
    public string Acompanhamento { get; private set; }

    public Lanche(int codigo, string nome, decimal precoBase, string acompanhamento)
        : base(codigo, nome, precoBase)
    {
        Acompanhamento = acompanhamento;
    }

    public override decimal CalcularPreco()
    {
        return AplicarPromocao();
    }

    public override void ExibirInformacoes()
    {
        Console.WriteLine("=====LANCHE=====");
        base.ExibirInformacoes();
        Console.WriteLine($"  Acompanhamento: {Acompanhamento}");
        Console.WriteLine($"  Em promoção: {(EstaEmPromocao() ? "Sim (10% off)" : "Não")}");
    }

    public bool EstaEmPromocao()
    {
        return PrecoBase >= 25m;
    }

    public decimal AplicarPromocao()
    {
        return EstaEmPromocao() ? PrecoBase * 0.90m : PrecoBase;
    }
}
