using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ProgressForm;

namespace TestLibrary
{
    public class Class1
    {

        public static void ProgressStart()
        {
            ProgressForm.ProgressForm form1 = new ProgressForm.ProgressForm();
            int max = 10;
            form1.progressBar1.Maximum = max;
            form1.Show();
            int i = 1;
            //this is here just to represent doing some kind of task.
            while (i < max+1)
            {
                form1.ProgressUpdate("Performing Step" +  i, i);
                i++;
                //this is here to simulate the program doing something that takes time.
                Thread.Sleep(3000);
            }
            //this is so you can see it before it closes.
            Thread.Sleep(5000);
            form1.Dispose();
        }
    }
}
