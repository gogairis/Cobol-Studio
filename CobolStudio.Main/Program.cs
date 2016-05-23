using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cobol.BLL.DivisionsProcessor.Impl;


namespace CobolStudio.Main
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            //Console.Write(Utils.BuildCommentHeader());
            //Console.Write(Utils.BuildCommentLine("jatin ahdjhsajda hjhjdhfjh hjfdshfjhsdjhfdjshfjds hsjdfhjsdhfjsd hsdjfhjsdhfjds",true));
            //Console.Write(Utils.BuildCommentHeader());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false); 
            Application.Run(new Forms.CobolStudio());
        }
    }
}
