namespace SistemaPedidosLanchonete.Domain.Entities;

public class Bebida : Produto, IPromocao
{
    public int Volume { get; private set; }
    public string Tipo { get; private set; }

    public Bebida(int codigo, string nome, decimal precoBase, int volume, string tipo)
        : base(codigo, nome, precoBase)
    {
        Volume = volume;
        Tipo = tipo;
    }

    public override decimal CalcularPreco()
    {
        return AplicarPromocao();
    }

    public override void ExibirInformacoes()
    {
        Console.WriteLine("=====BEBIDA=====");
        base.ExibirInformacoes();
        Console.WriteLine($"Volume: {Volume} ml - Tipo: {Tipo}");
        Console.WriteLine($"Em promoção: {(EstaEmPromocao() ? "Sim (5% off)" : "Não")}");
    }

    public bool EstaEmPromocao()
    {
        return Tipo.Equals("Refrigerante", StringComparison.OrdinalIgnoreCase);
    }

    public decimal AplicarPromocao()
    {
        return EstaEmPromocao() ? PrecoBase * 0.95m : PrecoBase;
    }
}