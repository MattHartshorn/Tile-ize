using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ProjectTile.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                new Win32AppService().Start();
            }
            catch (InvalidOperationException)
            {
                // The app is not running in a UWP Package
                Console.WriteLine("[ERROR] : Application is not running under an App Package.");
            }
        }
    }
}
