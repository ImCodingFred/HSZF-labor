using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Eventek
{
    public class FileProcessedEventArgs : EventArgs 
    {
        public string FileName { get; }
        public FileProcessedEventArgs(string filename) 
        {
            FileName = filename;
        }
    }
    public class FileProcessor 
    {
        public event Action<string>? FileProcessed;
        public event EventHandler<FileProcessedEventArgs>? FileProcessGeneric;
        public void Process(string file) 
        {
            Console.WriteLine($"Processsing: {file}");
            FileProcessed?.Invoke( file );
            FileProcessGeneric?.Invoke(this, new FileProcessedEventArgs(file));
        }
    }
    internal class Basic
    {
        public Basic()
        {
            var processor = new FileProcessor();
            processor.FileProcessed += f => Console.WriteLine($"Log: {f} done.");
            processor.FileProcessed += f => Console.WriteLine($"Notify: {f} complete.");

            EventHandler<FileProcessedEventArgs> auditHandler = 
                (sender, e) => Console.WriteLine($"Audit: {e.FileName}");
            processor.FileProcessGeneric += auditHandler;
            processor.Process("data1.csv");
            processor.Process("data2.csv");
            processor.FileProcessGeneric -= auditHandler;
            processor.Process("data3.csv");

        }
    }
}
