using FluentAssertions;
using MeuCampeonatoAPI.Application.Utils;
using System;

namespace Teste
{
    public class UnitTest1
    {
        [Fact]
        public void TestarMetodo()
        {
            var pyHelper = new PythonHelper();
            string[] resultado = pyHelper.GerarResultadosJogo();

            var a = 1 == 1;
            resultado.Length.Should().NotBe(0);
        }
    }
}