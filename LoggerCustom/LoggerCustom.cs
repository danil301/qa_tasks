﻿using System.Diagnostics;


namespace taskss
{
    public class LoggerCustom
    {
        private string _path;
        private ScreenShot _screenShot;
        private EmailSender _emailSender;
        private readonly object _lock = new object();

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
            lock (_lock)
            {
                using (StreamWriter writer = new StreamWriter(_path, true))
                {
                    StackTrace st = new StackTrace(true);
                    string stackIndent = "";
                    string logMessage = "";
                    string stringToEmail = "";
                    for (int i = 0; i < st.FrameCount; i++)
                    {
                        StackFrame sf = st.GetFrame(i);
                        if (i == 0)
                        {
                            _screenShot.TakeScreenshot();
                            _screenShot.SaveScreenShotPng();

                            logMessage += message + $" Screen title: {_screenShot.GetScreenShotTitle()}" + "\n";
                        }
                        logMessage += "\n";
                        logMessage += stackIndent + $" Method: {sf.GetMethod()}" + "\n";
                        logMessage += stackIndent + $" File: {sf.GetFileName()}" + "\n";
                        logMessage += stackIndent + $" Line Number: {sf.GetFileLineNumber()}" + "\n";

                        writer.WriteLineAsync(logMessage);

                        stringToEmail += logMessage;
                        stackIndent += "  ";
                        logMessage = "";
                    }
                    //snytkin_max@mail.ru
                    //dvoryanchikov.danil@bk.ru
                    _emailSender.SendEmail("snytkin_max@mail.ru", _screenShot.GetScreenShotTitle(), stringToEmail);
                }
            }

        }
    }
}
