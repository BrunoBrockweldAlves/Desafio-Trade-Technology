using FluentAssertions;
using MeuCampeonatoAPI.Application.Utils;

namespace Teste
{
    public class PythonHelperTests
    {
        [Fact]
        public void TestarMetodo()
        {
            var pyHelper = new PythonHelper();
            var resultado = pyHelper.GerarResultadosJogo();

            resultado.Count().Should().Be(2);
            resultado[0].Should().BeInRange(0, 8);
            resultado[1].Should().BeInRange(0, 8);
        }
    }
}