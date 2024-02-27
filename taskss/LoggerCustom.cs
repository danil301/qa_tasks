using System.Diagnostics;


namespace taskss
{
    public class LoggerCustom
    {
        private string _path;

        public LoggerCustom(string path)
        {
            _path = path;
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
                        writer.WriteLine(message);
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
