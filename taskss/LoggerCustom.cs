using System.Diagnostics;


namespace taskss
{
    public class LoggerCustom
    {
        private string _path;
        private ScreenShot _screenShot;
        private EmailSender _emailSender;

        public LoggerCustom(string path, string imgPath)
        {
            _path = path;
            _screenShot = new ScreenShot(imgPath);
            _emailSender = new EmailSender();
        }

        /// <summary>
        /// Логгирование сообщения в указанный при инициализации класса файл
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task LogAsync(string message)
        {
            using (StreamWriter writer = new StreamWriter(_path, true))
            {
                StackTrace st = new StackTrace(true);
                string stackIndent = "";
                for (int i = 0; i < st.FrameCount; i++)
                {
                    StackFrame sf = st.GetFrame(i);
                    if (i == 0)
                    {
                        _screenShot.TakeScreenshot();
                        _screenShot.SaveScreenShotPng();
                        writer.WriteLine(message + $" Screen title: {_screenShot.GetScreenShotTitle()}");

                        _emailSender.SendEmail("dvoryanchikov.danil@bk.ru", _screenShot.GetScreenShotTitle());
                    }
                    writer.WriteLine();
                    writer.WriteLine(stackIndent + " Method: {0}", sf.GetMethod());
                    writer.WriteLine(stackIndent + " File: {0}", sf.GetFileName());
                    writer.WriteLine(stackIndent + " Line Number: {0}", sf.GetFileLineNumber());
                    stackIndent += "  ";
                    await writer.WriteLineAsync();
                }
            }
        }
    }
}
