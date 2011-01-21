using System;
using System.Collections.Generic;
using System.Text;
using Landpy.ActiveDirectory.Service;
using Landpy.ActiveDirectory.Object;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace Landpy.ActiveDirectory.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            OperatorSecurity operatorSecurity = new OperatorSecurity("LDAP://192.168.6.67", "Administrator", "liu-pxl821102");
            Console.ReadKey();
        }
    }
}
