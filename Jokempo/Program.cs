// See https://aka.ms/new-console-template for more information
using System;


Dictionary<String, (int vitorias, int empates, int derrotas)> jogadores = new Dictionary<string, (int, int, int)>();

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("😀 Olá! Vamos jogar Jokempo?");
Console.WriteLine("1 - Sim | 2 - Não | 3 - Sair");

int escolhaInicioJogo = Console.ReadKey().KeyChar;

while (escolhaInicioJogo != "0" && escolhaInicioJogo != "1")
{
    Console.WriteLine("\nOpção inválida. Escolha entre 1 e 2")
    escolhaInicioJogo = Console.ReadKey().KeyChar;
}

while (escolhaInicioJogo != 0)
{
    Console.WriteLine("\nQual seu nome?");
    String nomeJogador = Console.ReadLine();

    while (string.IsNullOrEmpty(nomeJogador))
    {
        Console.WriteLine("Você precisa digitar o seu nome");
        nomeJogador = Console.ReadLine();
    }
    Console.WriteLine("Escolha uma opção: 0 - Pedra ✊, 1 - Papel ✋ ou 2 - Tesoura ✌");
    char opcao = Console.ReadKey().KeyChar;
    Random pc = new Random();
    
    int opcaoEscolhidaPc = pc.Next(0, 3);
    string opcaoEscolhidaPcStr = "";

    switch (opcao)
    {
        case '0':
            opcaoEscolhidaUser = "Pedra ✊";
            break;
        case '1':
            opcaoEscolhidaUser = "Papel ✋";
            break;
        case '2':
            opcaoEscolhidaUser = "tesoura ✌";
            break;

        default: Console.WriteLine("Opção Inválida"); break;
    }

    switch (opcaoEscolhidaPc)
    {
        case 0:
            opcaoEscolhidaPcStr = "Pedra ✊";
            break;
        case 1:
            opcaoEscolhidaPcStr = "Papel ✋";
            break;
        case 2:
            opcaoEscolhidaPcStr = "Tesoura ✌";
            break;
        default: Console.WriteLine("Opção Inválida"); break;
    }


    Console.WriteLine($"Você escolheu: {opcaoEscolhidaUser}");
    Console.WriteLine($"Computador escolheu: {opcaoEscolhidaPcStr}");

    //Empates
    if (opcaoEscolhidaUser == opcaoEscolhidaPcStr)
    {
        Console.WriteLine("Empatou");
    }
    else if ((opcaoEscolhidaUser == "Pedra ✊" && opcaoEscolhidaPcStr == "Tesoura ✌") ||
                     (opcaoEscolhidaUser == "Papel ✋" && opcaoEscolhidaPcStr == "Pedra ✊") ||
                     (opcaoEscolhidaUser == "Tesoura ✌" && opcaoEscolhidaPcStr == "Papel ✋"))
    {
        Console.WriteLine("Você venceu! 🎉");
    }
    else
    {
        Console.WriteLine("Você perdeu! 😢");
    }

}
