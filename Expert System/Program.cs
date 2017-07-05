using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Expert_System
{
    public struct Rule
    {
        public string device;
        public string question;
        public string problem;
        public string solution;
        public int cf;
        public Rule(string device , string question, string problem, string solution, int cf)
        {
            this.device = device;
            this.problem = problem;
            this.question = question;
            this.solution = solution;
            this.cf = cf;
        }
    }
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Start());
        }
    }
}
