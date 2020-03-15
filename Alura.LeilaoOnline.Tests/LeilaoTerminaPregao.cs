using Alura.LeilaoOnline.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoTerminaPregao
    {
        

        [Fact]
        public void RetornaZeroDadoLeilaoSemLance()
        {
            var leilao = new Leilao("Van Gough");
            
           
            leilao.TerminaPregao();

            var valorEsperado = 0;
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
        }

        [Theory]
        [InlineData(1200,new double[] { 800, 900, 1000, 1200 })]
        [InlineData(1000,new double[] { 800, 900, 1000, 990 })]
        [InlineData(800, new double[] { 800 })]
        public void RetornaMaiorValorDadoLeilaoComPeloMenosUmLance(double valorEsperado, double[] ofertas)
        {
            var leilao = new Leilao("Van Gough");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);

            foreach(var valor in ofertas)
            {
                leilao.RecebeLance(fulano, valor);
            }

            leilao.TerminaPregao();
            
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);

        }
        

        
    }
}
