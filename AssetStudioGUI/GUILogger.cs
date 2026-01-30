using AssetStudio;
using System;
using System.Windows.Forms;

namespace AssetStudioGUI
{
    class GUILogger : ILogger
    {
        public bool ShowErrorMessage { get; set; }
        private Action<string> action;

        public GUILogger(Action<string> action)
        {
            this.action = action;
        }

        public void Log(LoggerEvent loggerEvent, string message)
        {
            switch (loggerEvent)
            {
                case LoggerEvent.Info:
                    Console.WriteLine(message);
                    break;
                case LoggerEvent.Debug:
                    Console.WriteLine(message);
                    break;
                case LoggerEvent.Error:
                    if (ShowErrorMessage)
                    {
                        MessageBox.Show(message);
                    }
                    break;
                default:
                    action(message);
                    break;
            }

        }
    }
}
