using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Speech.Recognition;
using System.Speech.Synthesis;
namespace Voicerecognition
{ 
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region usables
        SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        SpeechRecognitionEngine recogEngine = new SpeechRecognitionEngine();
        PromptBuilder builder = new PromptBuilder();
        #endregion
        // string[] commandsPD = new string[] { "songs", "videos", "photos", "workspace" };
        public MainWindow()
        {
            InitializeComponent();
        }

        #region start
        private void startBtn_Click(object sender, RoutedEventArgs e)
        {
            stopBtn.IsEnabled = true;
            startBtn.IsEnabled = false;
            MessageBox.Show("Started","On Open ",MessageBoxButton.OK,MessageBoxImage.Information);
         //   string[] commandMD = new string[] { cmd1Txt.Text, cmd2Txt.Text, cmd3Txt.Text, cmd4Txt.Text };
            Choices cmdList = new Choices();
            cmdList.Add("songs", "videos", "photos", "workspace", cmd1Txt.Text.Trim(), cmd2Txt.Text.Trim(), cmd3Txt.Text.Trim(), cmd4Txt.Text.Trim(),"shutdown","restart","Exit","clean","Assisstant");
            
            Grammar go = new Grammar(new GrammarBuilder(cmdList));
          
                recogEngine.RequestRecognizerUpdate();
                recogEngine.LoadGrammar(go);
                recogEngine.SpeechRecognized += recogEngine_SpeechRecognized;
                recogEngine.SetInputToDefaultAudioDevice();
                recogEngine.RecognizeAsync(RecognizeMode.Multiple);
                
            
            e.Handled = true;
           
        }
        #endregion
        #region event
        void recogEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            try
            {
                if (e.Result.Text.ToLower() == "exit")
                {
                    this.Close();
                }
                else
                {
                    if (e.Result.Text.ToLower() == "songs")
                    {
                        System.Diagnostics.Process.Start(songTxt.Text);
                    }
                    else if (e.Result.Text.ToLower() == "videos")
                    {
                        System.Diagnostics.Process.Start(@videoTxt.Text);
                    }
                    else if (e.Result.Text.ToLower() == "photos")
                    {
                        System.Diagnostics.Process.Start(@photoTxt.Text);
                    }
                    else if (e.Result.Text.ToLower() == "workspace")
                    {
                        System.Diagnostics.Process.Start(@workSpaceTxt.Text);
                    }
                    else if (e.Result.Text.ToLower() == cmd1Txt.Text.ToLower().Trim())
                    {
                        System.Diagnostics.Process.Start(@path1Txt.Text);
                    }
                    else if (e.Result.Text.ToLower() == cmd2Txt.Text.ToLower().Trim())
                    {
                        System.Diagnostics.Process.Start(@path2Txt.Text);
                    }
                    else if (e.Result.Text.ToLower() == cmd3Txt.Text.ToLower().Trim())
                    {
                        System.Diagnostics.Process.Start(@path3Txt.Text);
                    }
                    else if (e.Result.Text.ToLower() == cmd4Txt.Text.ToLower().Trim())
                    {
                        System.Diagnostics.Process.Start(@path4Txt.Text);
                    }
                    else if (e.Result.Text.ToLower() == "shutdown")
                    {
                        new YesNoShutDown().ShowDialog();

                    }
                    else if (e.Result.Text.ToLower() == "restart")
                    {
                        new YesNoRestart().ShowDialog();
                        // System.Diagnostics.Process.Start("shutdown", "/r /t 2");
                    }
                    else if (e.Result.Text.ToLower() == "assisstant")
                    {
                        this.Show();
                        builder.ClearContent();
                        builder.AppendText("At your service sir Adit; Please Order me");
                        synthesizer.Speak(builder);
                    }
                }
            }
            catch
            {
                return;
            }
           
        }
        #endregion
        #region about
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            new AboutWindow().ShowDialog();            
        }
#endregion
        #region textboxselect
     
        private void cmd1Txt_GotFocus(object sender, RoutedEventArgs e)
        {
           cmd1Txt.SelectAll();
        }

        private void cmd2Txt_GotFocus(object sender, RoutedEventArgs e)
        {
            cmd2Txt.SelectAll();
        }

        private void cmd3Txt_GotFocus(object sender, RoutedEventArgs e)
        {
            cmd3Txt.SelectAll();
        }

        private void cmd4Txt_GotFocus(object sender, RoutedEventArgs e)
        {
            cmd4Txt.SelectAll();
        }

        private void cmd1Txt_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if ((TextBox)sender == null)
                return;
           // Keyboard.Focus((TextBox)sender);
            ((TextBox)sender).Focus();
            e.Handled = true;
        }

        private void cmd2Txt_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if ((TextBox)sender == null)
                return;
            Keyboard.Focus((TextBox)sender);

            e.Handled = true;
        }

        private void cmd3Txt_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if ((TextBox)sender == null)
                return;
            Keyboard.Focus((TextBox)sender);

            e.Handled = true;
        }

        private void cmd4Txt_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if ((TextBox)sender == null)
                return;
            Keyboard.Focus((TextBox)sender);

            e.Handled = true;
        }
        #endregion
        #region browser
        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

      

        private void songsBrowserImg_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SMethods.dialogBoxShow(songTxt);
            e.Handled = true;
        }

        private void videoBrowserImg_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SMethods.dialogBoxShow(videoTxt);
            e.Handled = true;
        }

        private void photosBrowserImg_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SMethods.dialogBoxShow(photoTxt);
            e.Handled = true;
        }

        private void workSpaceBrowserImg_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SMethods.dialogBoxShow(workSpaceTxt);
            e.Handled = true;
        }

        private void cmd1BrowserImg_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SMethods.dialogBoxShow(path1Txt);
            e.Handled = true;
        }

        private void cmd2BrowserImg_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SMethods.dialogBoxShow(path2Txt);
            e.Handled = true;
        }

        private void cmd3BrowserImg_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SMethods.dialogBoxShow(path3Txt);
            e.Handled = true;
        }

        private void cmd4BrowserImg_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SMethods.dialogBoxShow(path4Txt);
            e.Handled = true;
        }
        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string s1 = String.Format("{0} . {1} . {2} . {3}", cmd1Txt.Text, cmd2Txt.Text, cmd3Txt.Text, cmd4Txt.Text);
            Task.Run(() =>
            {
                builder.ClearContent();
                builder.AppendText(s1);
                synthesizer.Speak(builder);
            });
            
        }

        private void stopBtn_Click(object sender, RoutedEventArgs e)
        {
            recogEngine.RecognizeAsyncStop();
            new MainWindow().Show();
            this.Close();
            
        }
    }
}
