using System;
using Topshelf;

namespace WindowsServiceWithTopshelfInNetCore
{
    // Installation
    // go to publish folder and open your command prompt as Administrator
    // WindowsServiceWithTopshelfInNetCore.exe install -servicename "ApiAgent" -displayname "Api Agent Display Name" -description "Api Agent Description"

    // Unistall
    // WindowsServiceWithTopshelfInNetCore.exe uninstall

    class Program
    {
        static void Main(string[] args)
        {
            var rc = HostFactory.Run(host =>
            {
                host.Service<MyService>(s =>
                {
                    s.ConstructUsing(x => new MyService());
                    s.WhenStarted(x => x.Start());
                    s.WhenStopped(x => x.Stop());
                });

                host.RunAsLocalSystem();
                host.StartAutomatically();

                host.SetServiceName("MyService");
            });

            var exitCode = (int)Convert.ChangeType(rc, rc.GetTypeCode());
            Environment.ExitCode = exitCode;
        }
    }
}
