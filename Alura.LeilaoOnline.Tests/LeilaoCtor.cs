using Alura.LeilaoOnline.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoCtor
    {
        [Fact]
        public void LancaArgumentExceptionDadoValorNegativo()
        {
            var valorNegativo = -100;

            Assert.Throws<ArgumentException>(
                () => new Lance(null, valorNegativo)
            );
        }
    }
}
