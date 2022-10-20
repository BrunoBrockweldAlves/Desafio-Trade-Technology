using IronPython.Hosting;
using MeuCampeonatoAPI.Domain.Entities;
using System.Diagnostics;
using System.Text;

namespace MeuCampeonatoAPI.Application.Utils
{
    public class PythonHelper
    {
        public PythonHelper()
        { }

        public string run_cmd(string cmd)
        {
            var uri1 = new Uri(@"C:\Users\bruno.brockweld\source\repos\SimuladorCampeonato\SimuladorCampeonatoAPI\Scripts\teste.py");
            var uri2 = new Uri(AppDomain.CurrentDomain.BaseDirectory);

            string relativePath = uri2.MakeRelativeUri(uri1).ToString();

            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "../../../../SimuladorCampeonatoAPI/Scripts/teste.py";
            start.UseShellExecute = false;
            start.CreateNoWindow = true;
            start.RedirectStandardOutput = true;
            start.RedirectStandardError = true;

            var errors = "";
            string results = "";

            using (var process = Process.Start(start))
            {
                errors = process.StandardError.ReadToEnd();
                results = process.StandardOutput.ReadToEnd();
            }

            return results;
        }

        public TimeCampeonato GerarResultadosJogo(ref TimeCampeonato timeUm, ref TimeCampeonato timeDois)
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
            
            var resultados = str(result.ToArray()).Split("\r\n");

            short golsTimeUm = short.Parse(resultados[0]);
            short golsTimeDois = short.Parse(resultados[1]);

            timeUm.AdicionarResultadoJogo(golsTimeUm, golsTimeDois);
            timeDois.AdicionarResultadoJogo(golsTimeDois, golsTimeUm);

            return resultados;
        }
    }
}