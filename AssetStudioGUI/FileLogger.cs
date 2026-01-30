using AssetStudio;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace AssetStudioGUI
{
    class FileLogger : ILogger
    {
        public bool ShowErrorMessage { get; set; }

        private Action<string> action;

        private string m_FileName;

        private string m_OutPath;

        public FileLogger(Action<string> action)
        {
            this.action = action;

            DateTime time = DateTime.Now;
            m_FileName = string.Format("Log_{0}.txt", time.ToString("yyyyMMddHHmmss"));

            var rootPath = Path.Combine(Environment.CurrentDirectory, "Logs");

            if (!Directory.Exists(rootPath))
            {
                Directory.CreateDirectory(rootPath);
            }

            m_OutPath = Path.Combine(rootPath, m_FileName);
        }

        public void Log(LoggerEvent loggerEvent, string message)
        {
            switch (loggerEvent)
            {
                case LoggerEvent.Info:
                    WriteLogFile(message);
                    break;
                case LoggerEvent.Debug:
                    WriteLogFile(message);
                    break;
                case LoggerEvent.Error:
                    if (ShowErrorMessage)
                    {
                        WriteLogFile(message);
                    }
                    break;
                default:
                    action(message);
                    break;
            }

        }

        public void WriteLogFile(string message)
        {
            using (StreamWriter writer = new StreamWriter(m_OutPath, true, Encoding.UTF8))
            {
                writer.WriteLine(message);
            }
        }
    }
}
