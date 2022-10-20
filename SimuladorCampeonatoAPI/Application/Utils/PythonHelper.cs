using IronPython.Hosting;
using System.Text;

namespace MeuCampeonatoAPI.Application.Utils
{
    public class PythonHelper
    {
        public List<short> GerarResultadosJogo()
        {
            var engine = Python.CreateEngine();
            var script = "../../../../SimuladorCampeonatoAPI/Scripts/teste.py";

            var source = engine.CreateScriptSourceFromFile(script);

            var arg = new List<string>();
            engine.GetSysModule().SetVariable("arg", arg);

            var eIO = engine.Runtime.IO;

            var errors = new MemoryStream();
            eIO.SetErrorOutput(errors, Encoding.Default);

            var result = new MemoryStream();
            eIO.SetOutput(result, Encoding.Default);

            var scope = engine.CreateScope();

            source.Execute(scope);

            string str(byte[] x) => Encoding.Default.GetString(x);
            
            var resultados = str(result.ToArray()).Split("\r\n", 2).Select(x => short.Parse(x));

            return (List<short>)resultados;
        }
    }
}