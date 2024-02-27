using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskss.Diary
{
    public class LoggerCustom
    {
        private string path;

        public LoggerCustom(string path)
        {
            this.path = path;
        }

        /// <summary>
        /// Логгирование сообщения в указанный при инициализации класса файл
        /// </summary>
        /// <param name="method"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task LogAsync(string method, string message)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                await writer.WriteLineAsync($"Method: {method}, Message: {message}, Time: {DateTime.Now}");               
            }
        }
    }
}
