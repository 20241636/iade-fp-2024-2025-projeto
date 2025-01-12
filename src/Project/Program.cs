using System;
using System.Collections;
using System.Dynamic;
using System.Net;
using System.Net.Mail;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Globalization;
using System.Collections.Immutable;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using System.Text.Json;
using System.Text.Json.Serialization;



class Program
{
    static void Main(string[] args)
    {
        Xadrez jogoXadrez = new Xadrez();
        jogoXadrez.executaJogo();
    }

}


class Xadrez
{

    public List<Jogador> jogadores {get; set;}
    public Jogo jogoEmCurso {get; set;}


    List<(int, int)> movPeao = new List<(int, int)> { (0, 1) };
    List<(int, int)> movTorre = new List<(int, int)> { (0, -1), (0, -2), (0, -3), (0, -4), (0, -5), (0, -6), (0, -7), (0, -8), (0, 1), (0, 2), (0, 3), (0, 4), (0, 5), (0, 6), (0, 7), (0, 8), (-1, 0), (-2, 0), (-3, 0), (-4, 0), (-5, 0), (-6, 0), (-7, 0), (-8, 0), (1, 0), (2, 0), (3, 0), (4, 0), (5, 0), (6, 0), (7, 0), (8, 0) };
    List<(int, int)> movCavalo = new List<(int, int)> { (1, 2), (1, -2), (-1, 2), (-1, -2), (2, 1), (2, -1), (-2, 1) };
    List<(int, int)> movBispo = new List<(int, int)> { (1, 1), (2, 2), (3, 3), (4, 4), (5, 5), (6, 6), (7, 7), (8, 8), (1, -1), (2, -2), (3, -3), (4, -4), (5, -5), (6, -6), (7, -7), (8, -8), (-1, 1), (-2, 2), (-3, 3), (-4, 4), (-5, 5), (-6, 6), (-7, 7), (-8, 8), (-1, -1), (-2, -2), (-3, 3), (-4, -4), (-5, -5), (-6, -6), (-7, -7), (-8, -8) };
    List<(int, int)> movRainha = new List<(int, int)> { (0, -1), (0, -2), (0, -3), (0, -4), (0, -5), (0, -6), (0, -7), (0, -8), (0, 1), (0, 2), (0, 3), (0, 4), (0, 5), (0, 6), (0, 7), (0, 8), (-1, 0), (-2, 0), (-3, 0), (-4, 0), (-5, 0), (-6, 0), (-7, 0), (-8, 0), (1, 0), (2, 0), (3, 0), (4, 0), (5, 0), (6, 0), (7, 0), (8, 0), (1, 1), (2, 2), (3, 3), (4, 4), (5, 5), (6, 6), (7, 7), (8, 8), (1, -1), (2, -2), (3, -3), (4, -4), (5, -5), (6, -6), (7, -7), (8, -8), (-1, 1), (-2, 2), (-3, 3), (-4, 4), (-5, 5), (-6, 6), (-7, 7), (-8, 8), (-1, -1), (-2, -2), (-3, 3), (-4, -4), (-5, -5), (-6, -6), (-7, -7), (-8, -8) };
    List<(int, int)> movRei = new List<(int, int)> { (-1, -1), (-1, 0), (-1, 1), (0, 1), (1, 1), (1, 0), (1, -1), (0, -1) };
    List<(int, int)> capturaPeao = new List<(int, int)> { (1, 1), (-1, 1) };
    List<(int, int)> capturaTorre = new List<(int, int)> { (0, -1), (0, -2), (0, -3), (0, -4), (0, -5), (0, -6), (0, -7), (0, -8), (0, 1), (0, 2), (0, 3), (0, 4), (0, 5), (0, 6), (0, 7), (0, 8), (-1, 0), (-2, 0), (-3, 0), (-4, 0), (-5, 0), (-6, 0), (-7, 0), (-8, 0), (1, 0), (2, 0), (3, 0), (4, 0), (5, 0), (6, 0), (7, 0), (8, 0) };
    List<(int, int)> capturaCavalo = new List<(int, int)> { (1, 2), (1, -2), (-1, 2), (-1, -2), (2, 1), (2, -1), (-2, 1) };
    List<(int, int)> capturaBispo = new List<(int, int)> { (1, 1), (2, 2), (3, 3), (4, 4), (5, 5), (6, 6), (7, 7), (8, 8), (1, -1), (2, -2), (3, -3), (4, -4), (5, -5), (6, -6), (7, -7), (8, -8), (-1, 1), (-2, 2), (-3, 3), (-4, 4), (-5, 5), (-6, 6), (-7, 7), (-8, 8), (-1, -1), (-2, -2), (-3, 3), (-4, -4), (-5, -5), (-6, -6), (-7, -7), (-8, -8) };
    List<(int, int)> capturaRainha = new List<(int, int)> { (0, -1), (0, -2), (0, -3), (0, -4), (0, -5), (0, -6), (0, -7), (0, -8), (0, 1), (0, 2), (0, 3), (0, 4), (0, 5), (0, 6), (0, 7), (0, 8), (-1, 0), (-2, 0), (-3, 0), (-4, 0), (-5, 0), (-6, 0), (-7, 0), (-8, 0), (1, 0), (2, 0), (3, 0), (4, 0), (5, 0), (6, 0), (7, 0), (8, 0), (1, 1), (2, 2), (3, 3), (4, 4), (5, 5), (6, 6), (7, 7), (8, 8), (1, -1), (2, -2), (3, -3), (4, -4), (5, -5), (6, -6), (7, -7), (8, -8), (-1, 1), (-2, 2), (-3, 3), (-4, 4), (-5, 5), (-6, 6), (-7, 7), (-8, 8), (-1, -1), (-2, -2), (-3, 3), (-4, -4), (-5, -5), (-6, -6), (-7, -7), (-8, -8) };
    List<(int, int)> capturaRei = new List<(int, int)> { (-1, -1), (-1, 0), (-1, 1), (0, 1), (1, 1), (1, 0), (1, -1), (0, -1) };




    public Xadrez()
    {
        this.jogadores = new List<Jogador>();
        this.jogoEmCurso = null;
    }


    
    public void executaJogo()
    {

        string input = Console.ReadLine().ToUpper();

        while (!string.IsNullOrWhiteSpace(input))
        {
            String[] parametrosInput = input.Split(" ");

            if (parametrosInput[0] == "RJ" && parametrosInput.Length == 2)
            {
                bool registoSucesso = RegistarJogador(parametrosInput[1]);
                if (registoSucesso)
                {
                    Console.WriteLine("Jogador registado com sucesso.");
                }
                else
                {
                    Console.WriteLine("Jogador existente.");
                }
            }
            else if (parametrosInput[0] == "LJ" && parametrosInput.Length == 1)
            {
                ListarJogador();
            }
            else if (parametrosInput[0] == "IJ" && parametrosInput.Length == 4)
            {

                string nomeJogadorA = parametrosInput[2];
                string nomeJogadorB = parametrosInput[3];
                string tipoJogo = parametrosInput[1];
                string[] estadoTabuleiro;


                if (this.jogoEmCurso != null)
                {
                    Console.WriteLine("Existe um jogo em curso.");

                }
                else if (!verificarJogadorExiste(nomeJogadorA) || !verificarJogadorExiste(nomeJogadorB))
                {
                    Console.WriteLine("Jogador inexistente.");
                }
                else
                {
                    //caso de sucesso

                    if (tipoJogo == "NOVO")
                    {
                        estadoTabuleiro = jogoDefault();
                    }
                    else
                    {
                        estadoTabuleiro = new string[8];
                        for (int i = 0; i < 8; i++)
                        {
                            input = Console.ReadLine();
                            estadoTabuleiro[i] = input;
                        }

                    }

                    IniciarJogo(nomeJogadorA, nomeJogadorB, estadoTabuleiro);
                }
            }
            else if (parametrosInput[0] == "MP" && parametrosInput.Length == 4)
            {
                string nomeJogador = parametrosInput[1];
                string posicaoInicial = parametrosInput[2];
                string posicaoFinal = parametrosInput[3];

                if (this.jogoEmCurso == null)
                {
                    Console.WriteLine("Não existe jogo em curso.");

                }
                else if (!nomeJogador.Equals(this.jogoEmCurso.NomeJogadorA) && !nomeJogador.Equals(this.jogoEmCurso.NomeJogadorB))
                {
                    Console.WriteLine("Jogador não participa no jogo em curso.");
                }
                else if (!this.jogoEmCurso.validaProximoAJogar(nomeJogador))
                {
                    Console.WriteLine("Não é a vez do jogador.");
                }
                else
                {
                    movimentarPeca(nomeJogador, posicaoInicial, posicaoFinal);
                }

            }
            else if (parametrosInput[0] == "OS" && parametrosInput.Length == 4)
            {
                string nomeJogador = parametrosInput[1];
                string posicaoInicial = parametrosInput[2];
                string posicaoFinal = parametrosInput[3];

                if (this.jogoEmCurso == null)
                {
                    Console.WriteLine("Não existe jogo em curso.");

                }
                else if (!nomeJogador.Equals(this.jogoEmCurso.NomeJogadorA) && !nomeJogador.Equals(this.jogoEmCurso.NomeJogadorB))
                {
                    Console.WriteLine("Jogador não participa no jogo em curso.");
                }
                else if (!this.jogoEmCurso.validaProximoAJogar(nomeJogador))
                {
                    Console.WriteLine("Não é a vez do jogador.");
                }
                else
                {
                    operacaoEspecial(nomeJogador, posicaoInicial, posicaoFinal);
                }

            }
            else if (parametrosInput[0] == "D" && (parametrosInput.Length == 2 || parametrosInput.Length == 3))
            {
                string nomeJogador1 = null;
                string nomeJogador2 = null;

                if (parametrosInput.Length == 2)
                {
                    nomeJogador1 = parametrosInput[1];

                    if (this.jogoEmCurso == null)
                    {
                        Console.WriteLine("Não existe jogo em curso.");
                    }
                    else if (!verificarJogadorExiste(nomeJogador1))
                    {
                        Console.WriteLine("Jogador inexistente.");
                    }
                    else if (!nomeJogador1.Equals(this.jogoEmCurso.NomeJogadorA) && !nomeJogador1.Equals(this.jogoEmCurso.NomeJogadorB))
                    {
                        Console.WriteLine("Jogador não participa no jogo em curso.");
                    }
                    else
                    {
                        desistirJogo(nomeJogador1, null);
                    }

                }
                else if (parametrosInput.Length == 3)
                {
                    nomeJogador1 = parametrosInput[1];
                    nomeJogador2 = parametrosInput[2];
                    if (this.jogoEmCurso == null)
                    {
                        Console.WriteLine("Não existe jogo em curso.");
                    }
                    else if (!verificarJogadorExiste(nomeJogador1) || !verificarJogadorExiste(nomeJogador2))
                    {
                        Console.WriteLine("Jogador inexistente.");
                    }
                    else if (!nomeJogador1.Equals(this.jogoEmCurso.NomeJogadorA) && !nomeJogador1.Equals(this.jogoEmCurso.NomeJogadorB) || (!nomeJogador2.Equals(this.jogoEmCurso.NomeJogadorB) && !nomeJogador2.Equals(this.jogoEmCurso.NomeJogadorA)))
                    {
                        Console.WriteLine("Jogador não participa no jogo em curso.");
                    }
                    else
                    {
                        desistirJogo(nomeJogador1, nomeJogador2);
                    }
                }
            }
            else if (parametrosInput[0] == "DJ" && parametrosInput.Length == 1)
            {
                if (jogoEmCurso != null)
                {
                    detalhesJogo(jogoEmCurso);
                }
                else
                {
                    Console.WriteLine("Não existe jogo em curso.");
                }

            }
            else if (parametrosInput[0] == "G" && parametrosInput[1] != null && parametrosInput.Length == 2)
            {

                String fileName = parametrosInput[1];
                using StreamWriter sw = new(fileName);

                sw.WriteLine(JsonSerializer.Serialize(this.jogadores));
               
               if(this.jogoEmCurso != null) {
         
                    sw.WriteLine(JsonSerializer.Serialize("Jogo em curso"));

                    List<Jogo.Peca> tabuleiroSerializavel = new List<Jogo.Peca>();

                    for (int i = 0; i < 8; i++)
                    {
                        for (int k = 0; k < 8; k++)
                        {
                            tabuleiroSerializavel.Add(this.jogoEmCurso.Tabuleiro[i, k]);
                        }
                    }

                    sw.WriteLine(JsonSerializer.Serialize(this.jogoEmCurso.NomeJogadorA));
                    sw.WriteLine(JsonSerializer.Serialize(this.jogoEmCurso.NomeJogadorB));
                    sw.WriteLine(JsonSerializer.Serialize(tabuleiroSerializavel));
                    sw.WriteLine(JsonSerializer.Serialize(this.jogoEmCurso.turnoJogadorA));
                    sw.WriteLine(JsonSerializer.Serialize(this.jogoEmCurso.posicaoReiBlack.x));
                    sw.WriteLine(JsonSerializer.Serialize(this.jogoEmCurso.posicaoReiBlack.y));
                    
                    sw.WriteLine(JsonSerializer.Serialize(this.jogoEmCurso.posicaoReiWhite.x));
                    sw.WriteLine(JsonSerializer.Serialize(this.jogoEmCurso.posicaoReiWhite.y));

                    sw.WriteLine(JsonSerializer.Serialize(this.jogoEmCurso.ultimoMovimento.x));
                    sw.WriteLine(JsonSerializer.Serialize(this.jogoEmCurso.ultimoMovimento.y));

                    sw.WriteLine(JsonSerializer.Serialize(this.jogoEmCurso.reiBlackInCheck));
                    sw.WriteLine(JsonSerializer.Serialize(this.jogoEmCurso.reiWhiteInCheck));
               }
               else {
                    sw.WriteLine(JsonSerializer.Serialize("Sem jogo em curso"));
               }
                
                Console.WriteLine("Jogo gravado com sucesso.");
            }
            else if (parametrosInput[0] == "L" && parametrosInput[1] != null && parametrosInput.Length == 2)
            {
                if(this.jogoEmCurso == null) {
                        
                    String fileName = parametrosInput[1];
                    using StreamReader sr = new(fileName);

                    this.jogadores = JsonSerializer.Deserialize<List<Jogador>>(sr.ReadLine());

                    String jogoStatus = JsonSerializer.Deserialize<string>(sr.ReadLine());
                    
                    if(jogoStatus.Equals("Jogo em curso")) {
                        this.jogoEmCurso = new Jogo();
                        this.jogoEmCurso.NomeJogadorA = JsonSerializer.Deserialize<string>(sr.ReadLine());
                        this.jogoEmCurso.NomeJogadorB = JsonSerializer.Deserialize<string>(sr.ReadLine());

                        List<Jogo.Peca> tabuleiroSerializavel = JsonSerializer.Deserialize<List<Jogo.Peca>>(sr.ReadLine());
                        
                        int index = 0;
                        for (int i = 0; i < 8; i++)
                        {
                            for (int k = 0; k < 8; k++)
                            {
                                this.jogoEmCurso.Tabuleiro[i, k] = tabuleiroSerializavel[index++];
                            }
                        }

                        this.jogoEmCurso.turnoJogadorA = JsonSerializer.Deserialize<bool>(sr.ReadLine());
            
                        // Deserializar posições dos reis
                        this.jogoEmCurso.posicaoReiBlack = (JsonSerializer.Deserialize<int>(sr.ReadLine()), JsonSerializer.Deserialize<int>(sr.ReadLine()) );
                        this.jogoEmCurso.posicaoReiWhite = (JsonSerializer.Deserialize<int>(sr.ReadLine()), JsonSerializer.Deserialize<int>(sr.ReadLine()) );
                        
                        // Deserialize o último movimento
                        this.jogoEmCurso.ultimoMovimento = (JsonSerializer.Deserialize<int>(sr.ReadLine()), JsonSerializer.Deserialize<int>(sr.ReadLine()) );
                        
                        // Deserialize os estados de check
                        this.jogoEmCurso.reiBlackInCheck = JsonSerializer.Deserialize<bool>(sr.ReadLine());
                        this.jogoEmCurso.reiWhiteInCheck = JsonSerializer.Deserialize<bool>(sr.ReadLine());
                    }
                    else {
                        this.jogoEmCurso = null;
                    }

                    Console.WriteLine("Jogo lido com sucesso.");
                }
                else {
                    Console.WriteLine("Existe um jogo em curso.");
                }
            }
            else
            {
                Console.WriteLine("Instrução inválida.");
            }


            input = Console.ReadLine().ToUpper();
        }
    }


    public bool RegistarJogador(string nomeNovoJogador)
    {
        if (verificarJogadorExiste(nomeNovoJogador))
        {
            return false;
        }
        else
        {
            Jogador novoJogador = new Jogador(nomeNovoJogador);
            jogadores.Add(novoJogador);
            return true;
        }
    }


    public bool verificarJogadorExiste(string nomeJogador)
    {
        foreach (Jogador jogador in jogadores)
        {
            if (jogador.NomeJogador.Equals(nomeJogador))
            {
                return true;
            }
        }
        return false;
    }


    public void ListarJogador()
    {
        if (jogadores == null || jogadores.Count == 0)
        {
            Console.WriteLine("Sem jogadores registados.");
        }
        else
        {            
            for (int i = 0; i < jogadores.Count; i++)
            {
                Console.WriteLine(jogadores[i].NomeJogador + " " + jogadores[i].NumJogos + " " + jogadores[i].NumVitorias + " " + jogadores[i].NumEmpates + " " + jogadores[i].NumDerrotas);
            }
        }
    }



    public bool IniciarJogo(string nomeJogadorA, string nomeJogadorB, string[] estadoTabuleiro)
    {
        Jogo novoJogo = new Jogo(nomeJogadorA, nomeJogadorB, estadoTabuleiro);
        this.jogoEmCurso = novoJogo;

        Console.WriteLine("Jogo iniciado com sucesso.");
        return true;
    }


    public void movimentarPeca(string nomeJogador, string posicaoInicial, string posicaoFinal)
    {
        int linhaInicial = posicaoInicial[1] - '1';
        int colunaInicial = posicaoInicial[0] - 'A';
        int linhaFinal = posicaoFinal[1] - '1';
        int colunaFinal = posicaoFinal[0] - 'A';

        Jogo.Peca pecaInicial = jogoEmCurso.Tabuleiro[linhaInicial, colunaInicial];
        Jogo.Peca pecaFinal = jogoEmCurso.Tabuleiro[linhaFinal, colunaFinal];

        if (posicaoInicial.Length != 2 || posicaoInicial[0] < 'A' || posicaoInicial[0] > 'H' || posicaoInicial[1] < '1' || posicaoInicial[1] > '8'
        || posicaoFinal.Length != 2 || posicaoFinal[0] < 'A' || posicaoFinal[0] > 'H' || posicaoFinal[1] < '1' || posicaoFinal[1] > '8')
        {
            Console.WriteLine("Posição inválida.");
        }
        else if (jogoEmCurso.Tabuleiro[linhaInicial, colunaInicial] == null)
        {
            Console.WriteLine("Não existe peça na posição inicial.");
        }
        else if (!(this.jogoEmCurso.NomeJogadorA.Equals(nomeJogador) && pecaInicial.IsBlack || this.jogoEmCurso.NomeJogadorB.Equals(nomeJogador) && !pecaInicial.IsBlack))
        {
            Console.WriteLine("Movimento inválido.");
        }
        else
        {
            bool movimentacaoEncontrada = validaMovimento(linhaInicial, colunaInicial, linhaFinal, colunaFinal);

            bool enPassantEfetuado = false;

            if (!movimentacaoEncontrada)
            {
                enPassantEfetuado = validaExecutaEnPassant(linhaInicial, linhaFinal, colunaInicial, colunaFinal);
            }


            if (movimentacaoEncontrada == true || enPassantEfetuado == true)
            {
                if (!enPassantEfetuado)
                {
                    jogoEmCurso.Tabuleiro[linhaFinal, colunaFinal] = jogoEmCurso.Tabuleiro[linhaInicial, colunaInicial];
                    jogoEmCurso.Tabuleiro[linhaInicial, colunaInicial] = null;
                }

                this.jogoEmCurso.Tabuleiro[linhaFinal, colunaFinal].movimentacoesEfetuadas++;
                this.jogoEmCurso.proximoJogador();

                //Guardamos o ultimo movimento para facilitar a validaçao do en passant (no en passant precisamos garantir que o peao moveu-se 2 posicoes exatamente na ultima jogada)
                jogoEmCurso.ultimoMovimento = (colunaFinal, linhaFinal);

                // Promocao PEAO para RAINHA
                bool isPeaoPromovido = false;
                if (jogoEmCurso.Tabuleiro[linhaFinal, colunaFinal].Tipo.Equals(Jogo.TipoPeca.Peao))
                {
                    isPeaoPromovido = promocaoPeao(linhaFinal, colunaFinal);
                }

                // Atualiza posicao do Rei Preto, para podermos facilitar a validação do check e check-mate (assim nao precisamos procurar a posicao do rei em toda a matriz quando estamos a validar o check)
                if (jogoEmCurso.Tabuleiro[linhaFinal, colunaFinal].Tipo.Equals(Jogo.TipoPeca.Rei))
                {
                    if (jogoEmCurso.Tabuleiro[linhaFinal, colunaFinal].IsBlack)
                    {
                        jogoEmCurso.posicaoReiBlack = (colunaFinal, linhaFinal);

                    }
                }

                // Atualiza posicao do Rei Branco, para podermos facilitar a validação do check e check-mate (assim nao precisamos procurar a posicao do rei em toda a matriz quando estamos a validar o check)
                if (jogoEmCurso.Tabuleiro[linhaFinal, colunaFinal].Tipo.Equals(Jogo.TipoPeca.Rei))
                {
                    if (!jogoEmCurso.Tabuleiro[linhaFinal, colunaFinal].IsBlack)
                    {
                        jogoEmCurso.posicaoReiWhite = (colunaFinal, linhaFinal); ;
                    }
                }


                if (validaCheckMate())
                {

                    Jogador jogadorA = obterJogador(this.jogoEmCurso.NomeJogadorA);
                    Jogador jogadorB = obterJogador(this.jogoEmCurso.NomeJogadorB);

                    if (this.jogoEmCurso.reiBlackInCheck)
                    {
                        jogadorA.NumJogos++;
                        jogadorB.NumJogos++;

                        jogadorA.NumDerrotas++;
                        jogadorB.NumVitorias++;
                        
                        Console.WriteLine("Checkmate. " + this.jogoEmCurso.NomeJogadorB + " venceu.");
                    }
                    else
                    {
                        jogadorA.NumJogos++;
                        jogadorB.NumJogos++;

                        jogadorA.NumVitorias++;
                        jogadorB.NumDerrotas++;

                        Console.WriteLine("Checkmate. " + this.jogoEmCurso.NomeJogadorA + " venceu.");
                    }

                    this.jogoEmCurso = null;

                }
                else if (validaCheck(true))
                {
                    Console.WriteLine("Check.");
                }
                else if (pecaFinal != null)
                {
                    Console.WriteLine("Peça " + pecaFinal.CodigoPeca + " capturada.");
                }
                else if (isPeaoPromovido)
                {
                    Console.WriteLine("Peão promovido.");
                }
                else if (enPassantEfetuado)
                {
                    Console.WriteLine("En passant efetuado.");
                }
                else
                {
                    Console.WriteLine(pecaInicial.CodigoPeca + " movida com sucesso.");
                }
            }
            else
            {
                Console.WriteLine("Movimento inválido.");
            }

        }
    }



    public void operacaoEspecial(string nomeJogador, string posicaoInicial, string posicaoFinal)
    {

        int linhaInicial = posicaoInicial[1] - '1';
        int colunaInicial = posicaoInicial[0] - 'A';
        int linhaFinal = posicaoFinal[1] - '1';
        int colunaFinal = posicaoFinal[0] - 'A';

        Jogo.Peca pecaInicial = jogoEmCurso.Tabuleiro[linhaInicial, colunaInicial];
        Jogo.Peca pecaFinal = jogoEmCurso.Tabuleiro[linhaFinal, colunaFinal];

        if (posicaoInicial.Length != 2 || posicaoInicial[0] < 'A' || posicaoInicial[0] > 'H' || posicaoInicial[1] < '1' || posicaoInicial[1] > '8'
        || posicaoFinal.Length != 2 || posicaoFinal[0] < 'A' || posicaoFinal[0] > 'H' || posicaoFinal[1] < '1' || posicaoFinal[1] > '8')
        {
            Console.WriteLine("Posição inválida.");
        }
        else if (jogoEmCurso.Tabuleiro[linhaInicial, colunaInicial] == null)
        {
            Console.WriteLine("Não existe peça na posição inicial.");
        }
        else if (!(this.jogoEmCurso.NomeJogadorA.Equals(nomeJogador) && pecaInicial.IsBlack || this.jogoEmCurso.NomeJogadorB.Equals(nomeJogador) && !pecaInicial.IsBlack))
        {
            Console.WriteLine("Movimento inválido.");
        }
        else
        {
            // OPERAÇÃO ESPECIAL PEÃO
            // Para peao
            // Para peão preto (movimento especial: recuar uma casa para cima)
            // Para peão branco (movimento especial: recuar uma casa para baixo )
            // Verifica se o movimento especial já foi feito
            if (pecaInicial != null && pecaFinal == null
                && pecaInicial.Tipo == Jogo.TipoPeca.Peao && pecaInicial.movimentacoesEspecaisEfetuadas == 0
                && colunaFinal == colunaInicial &&
                ((pecaInicial.IsBlack && linhaFinal == (linhaInicial - 1)) || (!pecaInicial.IsBlack && linhaFinal == (linhaInicial + 1)))
                )
            {

                // Executa o movimento especial
                this.jogoEmCurso.Tabuleiro[linhaFinal, colunaFinal] = this.jogoEmCurso.Tabuleiro[linhaInicial, colunaInicial];
                this.jogoEmCurso.Tabuleiro[linhaInicial, colunaInicial] = null;

                // Incrementa o contador de movimentos especiais
                this.jogoEmCurso.Tabuleiro[linhaFinal, colunaFinal].movimentacoesEspecaisEfetuadas++;

                //incrementa contador das movimentações efetuadas
                this.jogoEmCurso.Tabuleiro[linhaFinal, colunaFinal].movimentacoesEfetuadas++;

                //muda de jogador
                this.jogoEmCurso.proximoJogador();

                //Guardamos o ultimo movimento para facilitar a validaçao do en passant (no en passant precisamos garantir que o peao moveu-se 2 posicoes exatamente na ultima jogada)
                jogoEmCurso.ultimoMovimento = (colunaFinal, linhaFinal);

                Console.WriteLine($"Peão {pecaInicial.CodigoPeca} recuo com sucesso.");

            }
            else if (pecaInicial != null && pecaInicial.Tipo == Jogo.TipoPeca.Cavalo &&
                Math.Abs(linhaFinal - linhaInicial) == 4 || Math.Abs(colunaFinal - colunaInicial) == 4
                && (pecaFinal == null || pecaInicial.IsBlack != pecaFinal.IsBlack))
            {   
                // OPERAÇÃO ESPECIAL CAVALO
                // Cavalo não pode ter peças à sua volta para poder executar esta operação  
                
                bool norte = true;
                bool noroeste = true;
                bool nordeste = true;
                bool oeste = true;
                bool este = true;
                bool sul = true;
                bool sudoeste = true;
                bool sudeste = true;

                if(linhaInicial == 0){
                    norte = false;
                    noroeste = false;
                    nordeste = false;
                }

                if (linhaInicial == 7) {
                    sul=false;
                    sudeste=false;
                    sudoeste=false;
                }

                if (colunaInicial == 0) {
                    oeste=false;
                    noroeste=false;
                    sudoeste=false;
                }
                
                if (colunaInicial == 7) {
                    este=false;
                    nordeste=false;
                    sudeste=false;  
                }
                 
                
                if ((norte==false || this.jogoEmCurso.Tabuleiro[linhaInicial-1, colunaInicial] == null) &&
                (noroeste== false || this.jogoEmCurso.Tabuleiro[linhaInicial-1, colunaInicial-1] == null) &&
                (nordeste==false || this.jogoEmCurso.Tabuleiro[linhaInicial-1, colunaInicial+1] == null) && 
                (oeste==false || this.jogoEmCurso.Tabuleiro[linhaInicial, colunaInicial-1] == null) && 
                (este==false || this.jogoEmCurso.Tabuleiro[linhaInicial, colunaInicial+1] == null) &&
                (sul==false || this.jogoEmCurso.Tabuleiro[linhaInicial+1, colunaInicial] == null) &&
                (sudoeste==false || this.jogoEmCurso.Tabuleiro[linhaInicial+1, colunaInicial-1] == null) &&
                (sudeste==false || this.jogoEmCurso.Tabuleiro[linhaInicial+1, colunaInicial+1] == null)) {
                
                    // Executa o movimento especial
                    this.jogoEmCurso.Tabuleiro[linhaFinal, colunaFinal] = this.jogoEmCurso.Tabuleiro[linhaInicial, colunaInicial];
                    this.jogoEmCurso.Tabuleiro[linhaInicial, colunaInicial] = null;

                    //incrementa contador das movimentações efetuadas
                    this.jogoEmCurso.Tabuleiro[linhaFinal, colunaFinal].movimentacoesEfetuadas++;

                    //muda de jogador
                    this.jogoEmCurso.proximoJogador();

                    //Guardamos o ultimo movimento para facilitar a validaçao do en passant (no en passant precisamos garantir que o peao moveu-se 2 posicoes exatamente na ultima jogada)
                    jogoEmCurso.ultimoMovimento = (colunaFinal, linhaFinal);

                    Console.WriteLine($"Cavalo {pecaInicial.CodigoPeca} avançou com sucesso.");
                
                }
                else
                {
                    Console.WriteLine("Movimento inválido");
                }


            }
            else if (pecaInicial != null && pecaInicial.Tipo == Jogo.TipoPeca.Rainha &&
                pecaFinal != null && pecaFinal.Tipo == Jogo.TipoPeca.Rei &&
                ((pecaInicial.IsBlack && pecaFinal.IsBlack && !this.jogoEmCurso.reiBlackInCheck) || (!pecaInicial.IsBlack && !pecaFinal.IsBlack && !this.jogoEmCurso.reiWhiteInCheck)) )
            {
                
                Jogo.Peca pecaAuxiliar = this.jogoEmCurso.Tabuleiro[linhaFinal, colunaFinal];
                this.jogoEmCurso.Tabuleiro[linhaFinal, colunaFinal] = this.jogoEmCurso.Tabuleiro[linhaInicial, colunaInicial];
                this.jogoEmCurso.Tabuleiro[linhaInicial, colunaInicial] = pecaAuxiliar;
                

                if (this.jogoEmCurso.Tabuleiro[linhaInicial, colunaInicial].IsBlack)
                {
                        this.jogoEmCurso.posicaoReiBlack = (colunaInicial, linhaInicial);
                }

                if (!this.jogoEmCurso.Tabuleiro[linhaInicial, colunaInicial].IsBlack)
                {
                        this.jogoEmCurso.posicaoReiWhite = (colunaInicial, linhaInicial);
                }

                //so podemos trocar a ordem da rainha com o rei se esta mudança não colocar o rei em check. 
                //se coloca o rei em check temos que desfazer a jogada (código que está no else). Desfazer a jogada signifca voltar a trocar o rei e a rainha e atualizar a posição dos reis no tabuleiro (para facilitar os checks)
                bool inCheck = validaCheck(false);

                if(!inCheck) {

                     //incrementa contador das movimentações efetuadas
                    this.jogoEmCurso.Tabuleiro[linhaFinal, colunaFinal].movimentacoesEfetuadas++;

                    //muda de jogador
                    this.jogoEmCurso.proximoJogador();

                    //Guardamos o ultimo movimento para facilitar a validaçao do en passant (no en passant precisamos garantir que o peao moveu-se 2 posicoes exatamente na ultima jogada)
                    jogoEmCurso.ultimoMovimento = (colunaFinal, linhaFinal);
                    
                    Console.WriteLine("Rainha trocou de posição com o rei.");
                }
                else {
                    
                    pecaAuxiliar = this.jogoEmCurso.Tabuleiro[linhaFinal, colunaFinal];
                    this.jogoEmCurso.Tabuleiro[linhaFinal, colunaFinal] = this.jogoEmCurso.Tabuleiro[linhaInicial, colunaInicial];
                    this.jogoEmCurso.Tabuleiro[linhaInicial, colunaInicial] = pecaAuxiliar;

                    if (this.jogoEmCurso.Tabuleiro[linhaInicial, colunaInicial].IsBlack)
                    {
                            this.jogoEmCurso.posicaoReiBlack = (colunaFinal, linhaFinal);
                    }

                    if (!this.jogoEmCurso.Tabuleiro[linhaInicial, colunaInicial].IsBlack)
                    {
                            this.jogoEmCurso.posicaoReiWhite = (colunaFinal, linhaFinal);
                    }

                    Console.WriteLine("Movimento inválido");
                }
            }
            else
            {
                Console.WriteLine("Movimento inválido.");
            }


            //executa ações genéricas para verificar estado tabuleiro

            // Atualiza posicao do Rei Preto, para poder facilitar a validação do check e check-mate (assim nao precisamos procurar a posicao do rei em toda a matriz quando estamos a validar o check)
            if (jogoEmCurso.Tabuleiro[linhaFinal, colunaFinal] != null && jogoEmCurso.Tabuleiro[linhaFinal, colunaFinal].Tipo.Equals(Jogo.TipoPeca.Rei))
            {
                if (jogoEmCurso.Tabuleiro[linhaFinal, colunaFinal].IsBlack)
                {
                    jogoEmCurso.posicaoReiBlack = (colunaFinal, linhaFinal);

                }
            }

            // Atualiza posicao do Rei Branco, para poder facilitar a validação do check e check-mate (assim nao precisamos procurar a posicao do rei em toda a matriz quando estamos a validar o check)
            if (jogoEmCurso.Tabuleiro[linhaFinal, colunaFinal] != null && jogoEmCurso.Tabuleiro[linhaFinal, colunaFinal].Tipo.Equals(Jogo.TipoPeca.Rei))
            {
                if (!jogoEmCurso.Tabuleiro[linhaFinal, colunaFinal].IsBlack)
                {
                    jogoEmCurso.posicaoReiWhite = (colunaFinal, linhaFinal); ;
                }
            }

            if (validaCheckMate())
            {

                Jogador jogadorA = obterJogador(this.jogoEmCurso.NomeJogadorA);
                Jogador jogadorB = obterJogador(this.jogoEmCurso.NomeJogadorB);

                if (this.jogoEmCurso.reiBlackInCheck)
                {
                    jogadorA.NumJogos++;
                    jogadorB.NumJogos++;
                    jogadorB.NumVitorias++;
                    jogadorA.NumDerrotas++;

                    Console.WriteLine("Checkmate. " + this.jogoEmCurso.NomeJogadorB + " venceu.");
                }
                else
                {
                    jogadorA.NumJogos++;
                    jogadorB.NumJogos++;
                    jogadorA.NumVitorias++;
                    jogadorB.NumDerrotas++;

                    Console.WriteLine("Checkmate. " + this.jogoEmCurso.NomeJogadorA + " venceu.");
                }

                this.jogoEmCurso = null;

            }
            else if (validaCheck(true))
            {
                Console.WriteLine("Check.");
            }

        }

    }
    public bool desistirJogo(string nomeJogador1, string nomeJogador2)
    {
        Jogador jogadorA = obterJogador(this.jogoEmCurso.NomeJogadorA);
        Jogador jogadorB = obterJogador(this.jogoEmCurso.NomeJogadorB);
        if (nomeJogador1 != null && nomeJogador2 != null)
        {

            jogadorA.NumJogos++;
            jogadorB.NumJogos++;
            jogadorA.NumEmpates++;
            jogadorB.NumEmpates++;
        }
        else if (nomeJogador1.Equals(this.jogoEmCurso.NomeJogadorA))
        {
            jogadorA.NumJogos++;
            jogadorB.NumJogos++;
            jogadorA.NumDerrotas++;
            jogadorB.NumVitorias++;

        }
        else if (nomeJogador1.Equals(this.jogoEmCurso.NomeJogadorB))
        {
            jogadorA.NumJogos++;
            jogadorB.NumJogos++;
            jogadorA.NumVitorias++;
            jogadorB.NumDerrotas++;
        }

        this.jogoEmCurso = null;
        Console.WriteLine("Jogo terminado com sucesso.");
        return true;

    }

    // FALTA FAZER SOMADOR DE JOGOS V E D NO FINAL DE CADA JOGO CASO SE SUCIDA Á VITORIA POR CHEKMATE
    public Jogador obterJogador(string nomeJogador)
    {
        for (int i = 0; i < jogadores.Count; i++)
        {
            if (nomeJogador.Equals(jogadores[i].NomeJogador))
            {
                return jogadores[i];
            }
        }
        return null;
    }



    public bool validaMovimento(int linhaInicial, int colunaInicial, int linhaFinal, int colunaFinal)
    {
        Jogo.Peca pecaInicial = jogoEmCurso.Tabuleiro[linhaInicial, colunaInicial];
        Jogo.Peca pecaFinal = jogoEmCurso.Tabuleiro[linhaFinal, colunaFinal];

        List<(int, int)> movimentosAplicar = new List<(int, int)>();

        if (pecaInicial != null && pecaFinal != null && pecaInicial.IsBlack == pecaFinal.IsBlack)
        {
            return false;
        }

        switch (pecaInicial.Tipo)
        {
            case Jogo.TipoPeca.Peao:
                if (pecaFinal == null)
                {
                    movimentosAplicar = movPeao.ToList(); //toList para garantir que a lista movimentosAplicar nao é a mesma de movPeao (queremos adcionar a posicao (0,2) apenas uma vez)
                }
                else
                {
                    movimentosAplicar = capturaPeao.ToList();
                }

                if (pecaInicial.movimentacoesEfetuadas == 0)
                {
                    movimentosAplicar.Add((0, 2));

                }

                break;

            case Jogo.TipoPeca.Torre:
                if (pecaFinal == null)
                {

                    movimentosAplicar = movTorre.ToList();
                }
                else
                {
                    movimentosAplicar = capturaTorre.ToList();
                }
                break;

            case Jogo.TipoPeca.Cavalo:
                if (pecaFinal == null)
                {
                    movimentosAplicar = movCavalo.ToList();
                }
                else
                {
                    movimentosAplicar = capturaCavalo.ToList();
                }
                break;

            case Jogo.TipoPeca.Bispo:
                if (pecaFinal == null)
                {
                    movimentosAplicar = movBispo.ToList();
                }
                else
                {
                    movimentosAplicar = capturaBispo.ToList();
                }
                break;

            case Jogo.TipoPeca.Rainha:
                if (pecaFinal == null)
                {
                    movimentosAplicar = movRainha.ToList();
                }
                else
                {
                    movimentosAplicar = capturaRainha.ToList();
                }
                break;

            case Jogo.TipoPeca.Rei:
                if (pecaFinal == null)
                {
                    movimentosAplicar = movRei.ToList();
                }
                else
                {
                    movimentosAplicar = capturaRei.ToList();
                }
                break;
        }


        int orientacaoPecas = 1;
        if (!pecaInicial.IsBlack) orientacaoPecas = -1;

        for (int i = 0; i < movimentosAplicar.Count; i++)
        {
            if (colunaInicial + movimentosAplicar[i].Item1 == colunaFinal && linhaInicial + (movimentosAplicar[i].Item2 * orientacaoPecas) == linhaFinal)
            {
                if (caminhoLivre(linhaInicial, colunaInicial, linhaFinal, colunaFinal))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        return false;
    }

    public bool caminhoLivre(int linhaInicial, int colunaInicial, int linhaFinal, int colunaFinal)
    {

        if (linhaInicial == linhaFinal && colunaInicial != colunaFinal)
        {
            //processamento horizontal

            int pontoA = colunaInicial;
            if (colunaFinal < colunaInicial) pontoA = colunaFinal;

            int pontoB = colunaFinal;
            if (colunaFinal < colunaInicial) pontoB = colunaInicial;


            for (int i = pontoA + 1; i < pontoB; i++)
            {
                if (this.jogoEmCurso.Tabuleiro[linhaInicial, i] != null)
                {
                    return false;
                }
            }

            return true;
        }
        else if (linhaInicial != linhaFinal && colunaInicial == colunaFinal)
        {
            //processamento vertical

            int pontoA = linhaInicial;
            if (linhaFinal < linhaInicial) pontoA = linhaFinal;

            int pontoB = linhaFinal;
            if (linhaFinal < linhaInicial) pontoB = linhaInicial;


            for (int i = pontoA + 1; i < pontoB; i++)
            {
                if (this.jogoEmCurso.Tabuleiro[i, colunaInicial] != null)
                {
                    return false;
                }
            }

            return true;
        }
        else if (linhaInicial != linhaFinal && colunaInicial != colunaFinal && Math.Abs(linhaFinal - linhaInicial) == Math.Abs(colunaFinal - colunaInicial))
        {
            //processamento diagonal

            int direcaoHorizontal = 1;
            int direcaoVertical = 1;

            if (linhaFinal < linhaInicial)
            {
                direcaoVertical = -1;
            }

            if (colunaFinal < colunaInicial)
            {
                direcaoHorizontal = -1;
            }

            int nrCasasAValidar = Math.Abs(linhaFinal - linhaInicial) - 1;

            int coluna = colunaInicial + direcaoHorizontal;
            int linha = linhaInicial + direcaoVertical;

            while (coluna != colunaFinal)
            {

                if (this.jogoEmCurso.Tabuleiro[linha, coluna] != null)
                {
                    return false;
                }

                linha += direcaoVertical;
                coluna += direcaoHorizontal;
            }

            return true;

        }

        return true;
    }

    public bool validaCheckMate()
    {
        //para estar em check-mate tem que estar em primeiro lugar já em check
        bool inCheck = validaCheck(true);

        if (!inCheck)
        {
            return false;
        }

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {

                int linhaInicial = i;
                int colunaInicial = j;

                for (int k = 0; k < 8; k++)
                {
                    for (int l = 0; l < 8; l++)
                    {
                        int linhaFinal = k;
                        int colunaFinal = l;

                        if (this.jogoEmCurso.Tabuleiro[linhaInicial, colunaInicial] != null && validaMovimento(linhaInicial, colunaInicial, linhaFinal, colunaFinal))
                        {

                            if (this.jogoEmCurso.reiBlackInCheck && this.jogoEmCurso.Tabuleiro[linhaInicial, colunaInicial].IsBlack || this.jogoEmCurso.reiWhiteInCheck && !this.jogoEmCurso.Tabuleiro[linhaInicial, colunaInicial].IsBlack)
                            {
                                Jogo.Peca pecaAuxiliar = this.jogoEmCurso.Tabuleiro[linhaFinal, colunaFinal];
                                
                                if (this.jogoEmCurso.Tabuleiro[linhaInicial, colunaInicial].Tipo.Equals(Jogo.TipoPeca.Rei) && this.jogoEmCurso.Tabuleiro[linhaInicial, colunaInicial].IsBlack)
                                {
                                    this.jogoEmCurso.posicaoReiBlack = (colunaFinal, linhaFinal);
                                }

                                if (this.jogoEmCurso.Tabuleiro[linhaInicial, colunaInicial].Tipo.Equals(Jogo.TipoPeca.Rei) && !this.jogoEmCurso.Tabuleiro[linhaInicial, colunaInicial].IsBlack)
                                {
                                    this.jogoEmCurso.posicaoReiWhite = (colunaFinal, linhaFinal);
                                }

                                this.jogoEmCurso.Tabuleiro[linhaFinal, colunaFinal] = this.jogoEmCurso.Tabuleiro[linhaInicial, colunaInicial];
                                this.jogoEmCurso.Tabuleiro[linhaInicial, colunaInicial] = null;


                                //depois de mudar a peca da posicao inicial para a final verifica se está em check. 
                                // Se não estiver em check é porque existe uma posicao em que podemos mudar a peça evitando o check, pelo que não é check-mate
                                inCheck = validaCheck(false);

                                //volta atrás com o movimento feito, dado que o mesmo era temporário (apenas para simular a jogada e verificar se ficava em check)
                                this.jogoEmCurso.Tabuleiro[linhaInicial, colunaInicial] = this.jogoEmCurso.Tabuleiro[linhaFinal, colunaFinal];
                                this.jogoEmCurso.Tabuleiro[linhaFinal, colunaFinal] = pecaAuxiliar;

                                if (this.jogoEmCurso.Tabuleiro[linhaInicial, colunaInicial].Tipo.Equals(Jogo.TipoPeca.Rei) && this.jogoEmCurso.Tabuleiro[linhaInicial, colunaInicial].IsBlack)
                                {
                                    this.jogoEmCurso.posicaoReiBlack = (colunaInicial, linhaInicial);
                                }

                                if (this.jogoEmCurso.Tabuleiro[linhaInicial, colunaInicial].Tipo.Equals(Jogo.TipoPeca.Rei) && !this.jogoEmCurso.Tabuleiro[linhaInicial, colunaInicial].IsBlack)
                                {
                                    this.jogoEmCurso.posicaoReiWhite = (colunaInicial, linhaInicial);
                                }

                                if (!inCheck)
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
            }
        }

        return true;
    }


    public bool validaCheck(bool atualizaEstadoCheck)
    {
        int linhaReiBlack = this.jogoEmCurso.posicaoReiBlack.y;
        int colunaReiBlack = this.jogoEmCurso.posicaoReiBlack.x;
        int linhaReiWhite = this.jogoEmCurso.posicaoReiWhite.y;
        int colunaReiWhite = this.jogoEmCurso.posicaoReiWhite.x;

        Jogo.Peca reiBlack = this.jogoEmCurso.Tabuleiro[linhaReiBlack, colunaReiBlack];
        Jogo.Peca reiWhite = this.jogoEmCurso.Tabuleiro[linhaReiWhite, colunaReiWhite];

        if (atualizaEstadoCheck)
        {
            this.jogoEmCurso.reiBlackInCheck = false;
            this.jogoEmCurso.reiWhiteInCheck = false;
        }

        for (int i = 0; i < 8; i++)
        {
            for (int k = 0; k < 8; k++)
            {
                if (this.jogoEmCurso.Tabuleiro[i, k] != null && !this.jogoEmCurso.Tabuleiro[i, k].IsBlack)
                {
                    if (validaMovimento(i, k, linhaReiBlack, colunaReiBlack))
                    {
                        this.jogoEmCurso.reiBlackInCheck = true;
                        return true;
                    }
                }

                if (this.jogoEmCurso.Tabuleiro[i, k] != null && this.jogoEmCurso.Tabuleiro[i, k].IsBlack)
                {
                    if (validaMovimento(i, k, linhaReiWhite, colunaReiWhite))
                    {
                        this.jogoEmCurso.reiWhiteInCheck = true;
                        return true;
                    }
                }
            }
        }

        return false;
    }


    public bool promocaoPeao(int linhaFinal, int colunaFinal)
    {
        Jogo.Peca pecaFinal = jogoEmCurso.Tabuleiro[linhaFinal, colunaFinal];


        if (linhaFinal == 7 && pecaFinal.IsBlack)
        {

            int maiorCodigo = 0;
            // procurar no tabuleiro todo pela rainha 
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)

                    if (this.jogoEmCurso.Tabuleiro[i, j] != null && this.jogoEmCurso.Tabuleiro[i, j].IsBlack && this.jogoEmCurso.Tabuleiro[i, j].Tipo == Jogo.TipoPeca.Rainha)
                    {
                        int indicePeca = int.Parse(this.jogoEmCurso.Tabuleiro[i, j].CodigoPeca.Substring(2, 1));
                        if (indicePeca > maiorCodigo)
                        {
                            maiorCodigo = indicePeca;
                        }
                    }
            }

            string codigoNovaRainhaPreta = "BQ" + (maiorCodigo + 1);
            pecaFinal.CodigoPeca = codigoNovaRainhaPreta;
            pecaFinal.Tipo = Jogo.TipoPeca.Rainha;

            return true;

        }
        else if (linhaFinal == 0 && !pecaFinal.IsBlack)
        {
            //promover para rainha branca

            int maiorCodigo = 0;
            // procurar no tabuleiro todo pela rainha 
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)

                    if (this.jogoEmCurso.Tabuleiro[i, j] != null && !this.jogoEmCurso.Tabuleiro[i, j].IsBlack && this.jogoEmCurso.Tabuleiro[i, j].Tipo == Jogo.TipoPeca.Rainha)
                    {
                        int indicePeca = int.Parse(this.jogoEmCurso.Tabuleiro[i, j].CodigoPeca.Substring(2, 1));
                        if (indicePeca > maiorCodigo)
                        {
                            maiorCodigo = indicePeca;
                        }
                    }
            }

            string codigoNovaRainhaBranca = "WQ" + (maiorCodigo + 1);
            pecaFinal.CodigoPeca = codigoNovaRainhaBranca;
            pecaFinal.Tipo = Jogo.TipoPeca.Rainha;

            return true;
        }

        return false;
    }

    public bool validaExecutaEnPassant(int linhaInicial, int linhaFinal, int colunaInicial, int colunaFinal)
    {
        // se movimento não é na diagonal devolve false
        if (colunaInicial == colunaFinal)
        {
            return false;
        }

        Jogo.Peca pecaInicial = jogoEmCurso.Tabuleiro[linhaInicial, colunaInicial];
        Jogo.Peca pecafinal = jogoEmCurso.Tabuleiro[linhaFinal, colunaFinal];
        Jogo.Peca pecaVizinha;

        int diferencaLinha = linhaFinal - linhaInicial;
        int diferencaColuna = colunaFinal - colunaInicial;
        int linhaPecaVizinha;
        int colunaPecaVizinha;

        if (colunaFinal > colunaInicial)
        {
            linhaPecaVizinha = linhaInicial;
            colunaPecaVizinha = colunaInicial + 1;
            pecaVizinha = jogoEmCurso.Tabuleiro[linhaPecaVizinha, colunaPecaVizinha];
        }
        else
        {
            linhaPecaVizinha = linhaInicial;
            colunaPecaVizinha = colunaInicial - 1;
            pecaVizinha = jogoEmCurso.Tabuleiro[linhaPecaVizinha, colunaPecaVizinha];
        }


        //Condições para o en passant:
        //  - casa vazia na posicao de destino
        //  - peça vizinha de cor diferente da peça que se quer movimentar
        //  - Se peça vizinha é preta então tem que estar na linha 4 (posicao 3 no array), se branca na linha 5 (posicao 4 no array)
        //  - Peça vizinha só se movimentou uma vez
        //  - O último movimento efetudado no jogo foi o da peça vizinha
        if (pecafinal == null && pecaVizinha != null && pecaInicial.IsBlack != pecaVizinha.IsBlack &&
            (pecaVizinha.IsBlack && linhaPecaVizinha == 3 || !pecaVizinha.IsBlack && linhaPecaVizinha == 4)
            && pecaVizinha.movimentacoesEfetuadas == 1 && this.jogoEmCurso.ultimoMovimento.x == colunaPecaVizinha && this.jogoEmCurso.ultimoMovimento.y == linhaPecaVizinha)
        {
            jogoEmCurso.Tabuleiro[linhaFinal, colunaFinal] = pecaInicial;
            jogoEmCurso.Tabuleiro[linhaInicial, colunaInicial] = null;
            jogoEmCurso.Tabuleiro[linhaPecaVizinha, colunaPecaVizinha] = null;

            return true;
        }

        return false;
    }
    String[] jogoDefault()
    {
        return new String[]{
        "BR1,BH1,BB1,BQ1,BK1,BB2,BH2,BR2",
        "BP1,BP2,BP3,BP4,BP5,BP6,BP7,BP8",
        ",,,,,,,",
        ",,,,,,,",
        ",,,,,,,",
        ",,,,,,,",
        "WP1,WP2,WP3,WP4,WP5,WP6,WP7,WP8",
        "WR1,WH1,WB1,WQ1,WK1,WB2,WH2,WR2"
        };
    }

    static void detalhesJogo(Jogo jogo)
    {
        Console.WriteLine("    A    B    C    D    E    F    G    H");

        for (int i = 0; i < 8; i++)
        {
            Console.Write($"{i + 1} ");
            for (int j = 0; j < 8; j++)
            {
                if (jogo.Tabuleiro[i, j] != null)
                {
                    Console.Write($" {jogo.Tabuleiro[i, j].CodigoPeca}");
                }
                else
                {
                    Console.Write("    ");
                }

                if (j < 7)
                {
                    Console.Write(" ");
                }
            }

            Console.Write("\n");
        }

        if (jogo.turnoJogadorA)
        {
            Console.WriteLine($"{jogo.NomeJogadorA}");
        }
        else
        {
            Console.WriteLine($"{jogo.NomeJogadorB}");
        }
    }

}

public class Jogador
{   //Verificar se queremos manter os setters depois 
    public string NomeJogador { get; set; }
    public int NumJogos { get; set; }
    public int NumVitorias { get; set; }
    public int NumEmpates { get; set; }
    public int NumDerrotas { get; set; }

    public Jogador(string nomeJogador)
    {
        this.NomeJogador = nomeJogador;
        this.NumJogos = 0;
        this.NumVitorias = 0;
        this.NumEmpates = 0;
        this.NumDerrotas = 0;
    }
}

public class Jogo
{
    public string NomeJogadorA;
    public string NomeJogadorB;

    public Peca[,] Tabuleiro = new Peca[8, 8];

    public bool turnoJogadorA;

    public (int x, int y) posicaoReiBlack;

    public (int x, int y) posicaoReiWhite;

    public (int x, int y) ultimoMovimento;

    public bool reiBlackInCheck;
    public bool reiWhiteInCheck;

    public Jogo() {

    }

    public Jogo(string nomeJogadorA, string nomeJogadorB, string[] estadoTabuleiro)
    {
        this.NomeJogadorA = nomeJogadorA;
        this.NomeJogadorB = nomeJogadorB;
        preencheTabuleiro(estadoTabuleiro);
        turnoJogadorA = false;
        carregaPosicoesReis();
        reiBlackInCheck = false;
        reiWhiteInCheck = false;
    }
    public void proximoJogador()
    {
        this.turnoJogadorA = !this.turnoJogadorA;
    }

    public Boolean validaProximoAJogar(String nomeJogador)
    {
        if (nomeJogador.Equals(this.NomeJogadorA) && turnoJogadorA == true) return true;
        if (nomeJogador.Equals(this.NomeJogadorB) && turnoJogadorA == false) return true;

        return false;
    }


    public void preencheTabuleiro(string[] estadoTabuleiro)
    {
        Peca aux;

        for (int i = 0; i < estadoTabuleiro.Length; i++)
        {
            String linha = estadoTabuleiro[i];
            String[] valoresLinha = linha.Split(",");

            for (int j = 0; j < valoresLinha.Length; j++)
            {
                if (valoresLinha[j] != null && valoresLinha[j] != "")
                {
                    aux = new Peca(valoresLinha[j]);
                    Tabuleiro[i, j] = aux;
                }
                else
                {
                    Tabuleiro[i, j] = null;
                }
            }
        }
    }

    public void carregaPosicoesReis()
    {

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (this.Tabuleiro[i, j] != null && this.Tabuleiro[i, j].IsBlack && this.Tabuleiro[i, j].Tipo == Jogo.TipoPeca.Rei)
                {
                    this.posicaoReiBlack = (j, i);
                }
                else if (this.Tabuleiro[i, j] != null && !this.Tabuleiro[i, j].IsBlack && this.Tabuleiro[i, j].Tipo == Jogo.TipoPeca.Rei)
                {
                    this.posicaoReiWhite = (j, i);
                }
            }
        }
    }

    public enum TipoPeca
    {
        Peao,
        Rei,
        Rainha,
        Bispo,
        Torre,
        Cavalo

    }

    public class Peca
    {
        public string CodigoPeca { get; set; }
        public bool IsBlack { get; set; }
        public TipoPeca Tipo;
        public int movimentacoesEfetuadas { get; set; }
        public int movimentacoesEspecaisEfetuadas { get; set; }
        public String COR_PRETA = "B";

        public Peca(string CodigoPeca)
        {
            this.CodigoPeca = CodigoPeca;

            if (CodigoPeca.Substring(0, 1).ToUpper().Equals(COR_PRETA))
            {
                IsBlack = true;
            }
            else
            {
                IsBlack = false;
            }
            this.movimentacoesEfetuadas = 0;
            this.movimentacoesEspecaisEfetuadas = 0;

            switch (CodigoPeca.Substring(1, 1).ToUpper())
            {
                case "P":
                    Tipo = TipoPeca.Peao;
                    break;
                case "R":
                    Tipo = TipoPeca.Torre;
                    break;
                case "H":
                    Tipo = TipoPeca.Cavalo;
                    break;
                case "B":
                    Tipo = TipoPeca.Bispo;
                    break;
                case "Q":
                    Tipo = TipoPeca.Rainha;
                    break;
                case "K":
                    Tipo = TipoPeca.Rei;
                    break;

            }
        }
    }
}
