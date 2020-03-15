using Alura.LeilaoOnline.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoRecebeOferta
    {
        [Fact]
        public void NaoAceitaProximoLanceDadoMesmoClienteRealizouUltimoLance()
        {
            var leilao = new Leilao("Van Gough");
            var fulano = new Interessada("Fulano", leilao);

            leilao.IniciaPregao();
            leilao.RecebeLance(fulano, 400);
            leilao.RecebeLance(fulano, 1000);

            var qtdeEsperado = 1;
            var qtdeObtida = leilao.Lances.Count();

            Assert.Equal(qtdeEsperado, qtdeObtida);
        }

        [Theory]
        [InlineData(2, new double[] { 800, 900 })]
        [InlineData(4, new double[] { 100, 1200,1400, 1600})]
        public void NaoPermiteNovosLancesDadoLeilaoFinalizado(int qtdeEsperado, double[] ofertas)
        {
            var leilao = new Leilao("Van Gough");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);
            leilao.IniciaPregao();
            
            for(int i = 0; i < ofertas.Length; i++)
            {
                var valor = ofertas[i];
                if ((i % 2) == 0)
                {
                    leilao.RecebeLance(fulano, valor);
                }
                else
                {
                    leilao.RecebeLance(maria, valor);
                }
            }

            leilao.TerminaPregao();

            leilao.RecebeLance(fulano, 1000);
            
            var qtdeObtida = leilao.Lances.Count();

            Assert.Equal(qtdeEsperado, qtdeObtida);
        }
    }
}
