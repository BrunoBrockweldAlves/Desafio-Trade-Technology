using System.Diagnostics;

namespace MeuCampeonatoAPI.Application.Utils
{
    public class PythonHelper
    {
        public void RunScript()
        {

        }
        private string run_cmd(string cmd)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "..\\Scripts\\teste.py";
            start.Arguments = string.Format("{0} {1}", cmd);
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;

            string result;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    result = reader.ReadToEnd();
                }
            }

            return result;
        }

        [Fact]
    }
}