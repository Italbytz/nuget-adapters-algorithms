using System;
using System.Globalization;
using System.IO;
using Italbytz.Adapters.Algorithms.Util;
using Italbytz.Ports.Algorithms.AI.Search.Continuous;
using LpSolveDotNet;
using Microsoft.Extensions.Logging;

namespace Italbytz.Adapters.Algorithms.Search.Continuous
{
    public class LPSolver : ILPSolver
    {
        public LPSolver(ILoggerFactory loggerFactory) =>
            LoggingExtensions.InitLoggers(loggerFactory);

        public LPSolver()
        {
            LpSolve.Init();
        }

        public ILPSolution Solve(string model, LPFileFormat format)
        {
            var lpTempFile = Path.GetTempFileName();
            using var outputFile = new StreamWriter(lpTempFile);
            outputFile.Write(model);
            outputFile.Close();

            var lp = LpSolve.read_LP(lpTempFile, 0, null);
            lp.put_logfunc(Logfunc, IntPtr.Zero);
            var statuscode = lp.solve();

            var objTempFile = Path.GetTempFileName();
            lp.set_outputfile(objTempFile);
            lp.print_objective();
            lp.set_outputfile(null);

            double objective;
            using (var inputFile = new StreamReader(objTempFile))
            {
                var line = inputFile.ReadToEnd();
                var replacement =
                    line.Replace("Value of objective function: ", "");
                objective = double.Parse(replacement,
                    CultureInfo.CreateSpecificCulture("en-US"));
            }

            var solTempFile = Path.GetTempFileName();
            lp.set_outputfile(solTempFile);
            lp.print_solution(1);
            lp.set_outputfile(null);

            double[] solution;

            using (var inputFile = new StreamReader(solTempFile))
            {
                var lines = inputFile.ReadToEnd().Split('\n');
                solution = new double[lines.Length - 3];
                for (var i = 0; i < lines.Length - 3; i++)
                {
                    var replacement = lines[i + 2].Replace("x" + i, "");
                    solution[i] = double.Parse(replacement,
                        CultureInfo.CreateSpecificCulture("en-US"));
                }
            }

            return new LPSolution
            {
                Objective = objective, Solution = solution
            };
        }

        public ILPSolution Solve(ILPModel model) =>
            throw new NotImplementedException();

        private void Logfunc(IntPtr lp, IntPtr userhandle, string buf)
        {
            this.Log(LogLevel.Information, buf);
        }
    }
}