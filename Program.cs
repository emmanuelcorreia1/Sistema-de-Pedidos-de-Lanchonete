using SistemaPedidosLanchonete.Domain.Entities;

// Criando os ingredientes
Ingrediente pao = new Ingrediente(1, "Pão", "un", 100, 0.50m);
Ingrediente carne = new Ingrediente(2, "Carne Bovina", "g", 5000, 0.04m);
Ingrediente queijo = new Ingrediente(3, "Queijo", "g", 2000, 0.03m);

// Criando os produtos e adicionando os ingredientes
Lanche xBurguer = new Lanche(1, "X-Burguer", 22.00m, "Batata Frita");
xBurguer.AdicionarIngrediente(pao);
xBurguer.AdicionarIngrediente(carne);
xBurguer.AdicionarIngrediente(queijo);

Lanche xEspecial = new Lanche(2, "X-Especial", 32.00m, "Batata Frita + Onion Rings");
xEspecial.AdicionarIngrediente(pao);
xEspecial.AdicionarIngrediente(carne);

Bebida coca = new Bebida(3, "Coca-Cola", 8.00m, 350, "Refrigerante");
Bebida suco = new Bebida(4, "Suco de Laranja", 9.00m, 400, "Suco Natural");

Sobremesa sorvete = new Sobremesa(5, "Sorvete de Chocolate", 14.00m, 420);
Sobremesa mousse = new Sobremesa(6, "Mousse de Maracujá", 12.00m, 210);

// Criando os clientes
Cliente cliente1 = new Cliente(1, "João Silva", "11999990001");
Cliente cliente2 = new Cliente(2, "Maria Souza", "11999990002");

// Criando os pedidos
Pedido pedido1 = new Pedido(1, DateTime.Now, new List<ItemPedido>(), cliente1);
pedido1.AdicionarItem(new ItemPedido(xBurguer, 2, xBurguer.CalcularPreco()));
pedido1.AdicionarItem(new ItemPedido(coca, 2, coca.CalcularPreco()));
pedido1.AdicionarItem(new ItemPedido(sorvete, 1, sorvete.CalcularPreco()));

Pedido pedido2 = new Pedido(2, DateTime.Now, new List<ItemPedido>(), cliente2);
pedido2.AdicionarItem(new ItemPedido(xEspecial, 1, xEspecial.CalcularPreco()));
pedido2.AdicionarItem(new ItemPedido(suco, 1, suco.CalcularPreco()));
pedido2.AdicionarItem(new ItemPedido(mousse, 1, mousse.CalcularPreco()));

// Menu
string opcao = "";

while (opcao != "0")
{
    Console.WriteLine("======SISTEMA DE PEDIDOS DE LANCHONETE======");
    Console.WriteLine("1 - Exibir cardápio");
    Console.WriteLine("2 - Exibir Pedido 1 (João Silva)");
    Console.WriteLine("3 - Exibir Pedido 2 (Maria Souza)");
    Console.WriteLine("4 - Cancelar Pedido 2");
    Console.WriteLine("5 - Atualizar estoque de carne");
    Console.WriteLine("0 - Sair");
    Console.Write("\nEscolha uma opção: ");
    opcao = Console.ReadLine() ?? "";
    Console.WriteLine();

    switch (opcao)
    {
        case "1":
            Console.WriteLine("======CARDÁPIO======\n");
            xBurguer.ExibirInformacoes();
            Console.WriteLine();
            xEspecial.ExibirInformacoes();
            Console.WriteLine();
            coca.ExibirInformacoes();
            Console.WriteLine();
            suco.ExibirInformacoes();
            Console.WriteLine();
            sorvete.ExibirInformacoes();
            Console.WriteLine();
            mousse.ExibirInformacoes();
            break;

        case "2":
            Console.WriteLine("======PEDIDO 1======\n");
            pedido1.ExibirPedido();
            break;

        case "3":
            Console.WriteLine("======PEDIDO 2======\n");
            pedido2.ExibirPedido();
            break;

        case "4":
            Console.WriteLine("======CANCELAMENTO======\n");
            pedido2.Cancelar();
            pedido2.AdicionarItem(new ItemPedido(coca, 1, coca.CalcularPreco()));
            break;

        case "5":
            Console.WriteLine("======ESTOQUE======\n");
            carne.DiminuirEstoque(300);
            carne.DiminuirEstoque(9999);
            break;

        case "0":
            Console.WriteLine("Encerrando o sistema. Até logo!");
            break;

        default:
            Console.WriteLine("Opção inválida.");
            break;
    }

    Console.WriteLine();
}
