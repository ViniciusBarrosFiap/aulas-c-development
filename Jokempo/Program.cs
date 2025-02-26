// See https://aka.ms/new-console-template for more information
using System;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("😀 Olá! Vamos jogar Jokempo?");
Console.WriteLine("1 - Sim ou 0 - Não");
if(Console.ReadKey().KeyChar == '1')
{
    Console.WriteLine("Então vamos começar...");
    Console.WriteLine("Escolha uma opção: 0 - Pedra ✊, 1 - Papel ✋ ou 2 - Tesoura ✌");
    char opcao = Console.ReadKey().KeyChar;
    Random pc = new Random();
    string opcaoEscolhidaUser = "";
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
            opcaoEscolhidaUser = "Tesoura ✌";
            break;
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
else
{
    Console.WriteLine("👋 Tchau! Até a próxima");

}