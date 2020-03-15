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
        [Theory]
        [InlineData(2, new double[] { 800, 900 })]
        [InlineData(4, new double[] { 100, 1200,1400, 1600})]
        public void NaoPermiteNovosLancesDadoLeilaoFinalizado(int qtdeEsperado, double[] ofertas)
        {
            var leilao = new Leilao("Van Gough");
            var fulano = new Interessada("Fulano", leilao);

            foreach(var oferta in ofertas)
            {
                leilao.RecebeLance(fulano, oferta);
            }
            leilao.TerminaPregao();

            leilao.RecebeLance(fulano, 1000);
            
            var qtdeObtida = leilao.Lances.Count();

            Assert.Equal(qtdeEsperado, qtdeObtida);
        }
    }
}
