using Alura.LeilaoOnline.Core;
using System;

namespace Alura.LeliaoOnline.ConsoleApp
{
    class Program
    {

        private static void Verifica(double esperado, double obtido)
        {
            if(esperado == obtido)
            {
                Console.WriteLine("TESTE OK");
            }
            else
            {
                Console.WriteLine("TESTE FALHOU");
            }
        }

        private static void LeilaoComVariosLances()
        {
            var leilao = new Leilao("Van Gough");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.RecebeLance(fulano, 800);
            leilao.RecebeLance(maria, 900);
            leilao.RecebeLance(fulano, 1000);
            leilao.RecebeLance(maria, 990);

            leilao.TerminaPregao();

            var valorEsperado = 1000;
            var valorObtido = leilao.Ganhador.Valor;

            Verifica(valorEsperado, valorObtido);

        }

        private static void LeilaoComApenasUmLance()
        {
            var leilao = new Leilao("Van Gough");
            var fulano = new Interessada("Fulano", leilao);
            
            leilao.RecebeLance(fulano, 800);
           
            leilao.TerminaPregao();

            var valorEsperado = 800;
            var valorObtido = leilao.Ganhador.Valor;

            Verifica(valorEsperado, valorObtido);
        }

        static void Main(string[] args)
        {
            LeilaoComVariosLances();
            LeilaoComApenasUmLance();
        }

        
    }
}
