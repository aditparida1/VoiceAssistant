using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Voicerecognition
{
   public  class SMethods
    {
       public static void dialogBoxShow(TextBox e)
       {
           System.Windows.Forms.FolderBrowserDialog brswer = new System.Windows.Forms.FolderBrowserDialog();
           brswer.ShowDialog();


           if (!String.IsNullOrWhiteSpace(brswer.SelectedPath))
               e.Text = brswer.SelectedPath;

       }
    }
}
