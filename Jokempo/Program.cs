// See https://aka.ms/new-console-template for more information
using System;
using System.Globalization;


Dictionary<String, (int vitorias, int empates, int derrotas)> jogadores = new Dictionary<string, (int, int, int)>();
Console.OutputEncoding = System.Text.Encoding.UTF8;

//Loop que deixa o jogo rodando até acionar um break
while (true)
{
    //Exibir menu
    Console.WriteLine("\nOlá! Vamos jogar?");
    Console.WriteLine("1 - Jogar | 2 - Ver resultados | 3 - Sair");

    //Iniciando váriavel para armazenar a escolha do jogador
    int escolhaInicioJogo;
    char input = Console.ReadKey().KeyChar;
    Console.WriteLine();
    //Validando se a opção digitada consegue ser transformada para int e se está entre 1 a 3
    while (!char.IsDigit(input) || !int.TryParse(input.ToString(), out escolhaInicioJogo) || (escolhaInicioJogo < 1 || escolhaInicioJogo > 3))
    {
        Console.WriteLine("Opção inválida. Escolha entre 1, 2 ou 3.");
        input = Console.ReadKey().KeyChar;
        Console.WriteLine();
    }

    // Se o jogador escolheu 3, encerra o jogo
    if (escolhaInicioJogo == 3)
    {
        Console.WriteLine("\nObrigado por jogar! Até mais! 👋");
        break;
    }

    // Se o jogador escolheu 2, exibe as estatísticas e volta ao menu
    if (escolhaInicioJogo == 2)
    {
        ExibirResultados(jogadores);
        continue;
    }

    Console.WriteLine("Qual seu nome?");
    string nomeJogador = Console.ReadLine();


    while (string.IsNullOrWhiteSpace(nomeJogador))
    {
        Console.WriteLine("Você precisa digitar o seu nome:");
        nomeJogador = Console.ReadLine();
    }


    Console.WriteLine("Escolha uma opção: 0 - Pedra ✊, 1 - Papel ✋ ou 2 - Tesoura ✌");
    char opcao = Console.ReadKey().KeyChar;
    Console.WriteLine();
    string opcaoEscolhidaUser = "";

    // Converte a opção escolhida pelo usuário para texto
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
        default:
            // Se a opção for inválida, exibe um erro e reinicia o loop do jogo
            Console.WriteLine("\nOpção Inválida, tente novamente.");
            continue;
    }

    // Gera uma jogada aleatória para o computador
    Random pc = new Random();
    int opcaoEscolhidaPc = pc.Next(0, 3);

    string opcaoEscolhidaPcStr = opcaoEscolhidaPc switch
    {
        0 => "Pedra ✊",
        1 => "Papel ✋",
        2 => "Tesoura ✌",
        _ => "Erro"
    };

    Console.WriteLine($"\nVocê escolheu: {opcaoEscolhidaUser}");
    Console.WriteLine($"Computador escolheu {opcaoEscolhidaPcStr}");

    // Verifica o resultado do jogo
    if (opcaoEscolhidaUser == opcaoEscolhidaPcStr)
    {
        Console.WriteLine("Empate! 😐");
        AtualizaResultados(nomeJogador, jogadores, "empate");
    }
    else if ((opcaoEscolhidaUser == "Pedra ✊" && opcaoEscolhidaPcStr == "Tesoura ✌") ||
             (opcaoEscolhidaUser == "Papel ✋" && opcaoEscolhidaPcStr == "Pedra ✊") ||
             (opcaoEscolhidaUser == "Tesoura ✌" && opcaoEscolhidaPcStr == "Papel ✋"))
    {
        Console.WriteLine("Você venceu! 🎉");
        AtualizaResultados(nomeJogador, jogadores, "vitoria");
    }
    else
    {
        Console.WriteLine("Você perdeu! 😢");
        AtualizaResultados(nomeJogador, jogadores, "derrota");
    }
}

static void AtualizaResultados(string nome, Dictionary<string, (int vitorias, int empates, int derrotas)> jogadores, string resultado)
{
    if (!jogadores.ContainsKey(nome))
    {
        jogadores[nome] = (0, 0, 0);
    }

    var stats = jogadores[nome];


    switch (resultado)
    {
        case "vitoria":
            jogadores[nome] = (stats.vitorias + 1, stats.empates, stats.derrotas);
            break;
        case "empate":
            jogadores[nome] = (stats.vitorias, stats.empates + 1, stats.derrotas);
            break;
        case "derrota":
            jogadores[nome] = (stats.vitorias, stats.empates, stats.derrotas + 1);
            break;

    }


    Console.WriteLine($"\n Resultados de {nome}: {jogadores[nome].vitorias} Vitórias, {jogadores[nome].empates} Empates, {jogadores[nome].derrotas} Derrotas");
}

static void ExibirResultados(Dictionary<string, (int vitorias, int empates, int derrotas)> jogadores)
{
    if(jogadores.Count == 0)
    {
        Console.WriteLine("Nenhum jogo foi registrado");
        return;
    }

    Console.WriteLine("\n Resultado dos jogadores:");
    foreach(var jogador in jogadores)
    {
        Console.WriteLine($"{jogador.Key}: {jogador.Value.vitorias} Vitórias, {jogador.Value.empates} Empates, {jogador.Value.derrotas} Derrotas");
    }
}