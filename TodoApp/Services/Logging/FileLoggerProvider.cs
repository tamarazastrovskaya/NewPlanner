using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Services
{
     internal class FileLoggerProvider : ILoggerProvider
        // путь, куда будут записываться логи
        {
            private string path;
            // свойство для хранения пути
            public FileLoggerProvider(string _path)// конструктор для создания провайдера с заданными настройками
            {
                this.path = _path;
            }

            public ILogger CreateLogger(string categoryName) // создаёт  соединение
            {
                return FileLogger(path);// возвращает класс, который отвечает за запись логов туда
            }

            private ILogger FileLogger(string path)
            {
                throw new NotImplementedException();
            }

            public void Dispose()// удаляет соединение
            {

            }
        }
}
