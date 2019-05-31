using System;
using System.IO;

namespace WindowsServiceWithTopshelfInNetCore
{
    public class MyService
    {
        public void Dispose()
        {

        }

        public bool Start()
        {
            var text = $"{DateTime.Now.ToString("yyyy-MM-dd HH: mm: ss")}, Testing write." + Environment.NewLine;

            File.WriteAllText(@"D:\Service.Write.txt", text);

            Console.WriteLine($"[{nameof(MyService)}] has been started.....");

            return true;
        }

        public bool Stop()
        {
            Console.WriteLine($"[{nameof(MyService)}] has been stopped.....");

            return true;
        }
    }
}
