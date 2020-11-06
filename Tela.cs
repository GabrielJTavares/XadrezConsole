using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;
using jogo;

namespace Xadrez
{
    class Tela
    {
        public static void imprimirPartida(PartidaXadrez partida)
        {
            imprimirTabuleiro(partida.tab);
            Console.WriteLine();
            imprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.turno);
            if (!partida.terminada)
            {
                Console.WriteLine("Aguardando a jogada da peça: " + partida.jogadorAtual);

                if (partida.xeque)
                {
                    Console.WriteLine("XEQUE!");
                }
            }
            else
            {
                Console.WriteLine("XEQUEMATE!");
                Console.WriteLine("Vencedor: "+partida.jogadorAtual);
            }

        }

        public static void imprimirPecasCapturadas(PartidaXadrez partida)
        {
            Console.WriteLine("Peças Capturadas: ");
            Console.Write("Brancas: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Branca));
            Console.WriteLine();
            Console.Write("Pretas:  ");
            imprimirConjunto(partida.pecasCapturadas(Cor.preta));
            Console.WriteLine();
        }

        public static void imprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[ ");
            foreach(Peca x in conjunto)
            {
                ConsoleColor origins = Console.ForegroundColor;
                ConsoleColor alt = ConsoleColor.Red;
                if (x.cor == Cor.preta)
                { 
                    Console.ForegroundColor = alt;
                }
                
               
                Console.Write(x + " ");
                Console.ForegroundColor = origins;
            }
            Console.Write(" ]");

        }

        public static void imprimirTabuleiro(Tabuleiro tab)
        {

            for (int i = 0; i < tab.linhas; i++)
            {
                ConsoleColor x = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(8 - i + " ");
                Console.ForegroundColor = x;

                for (int j = -0; j < tab.colunas; j++)
                {


                    imprimirPeca(tab.peca(i, j));



                }
                Console.WriteLine();
            }

            ConsoleColor z = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  a b c d e f g h");
            Console.ForegroundColor = z;


        }

        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;
            for (int i = 0; i < tab.linhas; i++)
            {
                ConsoleColor x = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(8 - i + " ");
                Console.ForegroundColor = x;

                for (int j = -0; j < tab.colunas; j++)
                {
                    if (posicoesPossiveis[i, j])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }



                    imprimirPeca(tab.peca(i, j));
                    Console.BackgroundColor = fundoOriginal;



                }
                Console.WriteLine();
            }

            ConsoleColor z = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = fundoOriginal;
            Console.ForegroundColor = z;
            Console.BackgroundColor = fundoOriginal;


        }


        public static PosicaoXadrez lerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }

        public static void imprimirPeca(Peca peca)
        {

            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (peca.cor == Cor.Branca)
                {
                    Console.Write(peca);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }


    }
}
