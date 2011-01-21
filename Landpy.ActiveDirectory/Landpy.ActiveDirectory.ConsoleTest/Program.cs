using System;
using Landpy.ActiveDirectory.Object;
using Landpy.ActiveDirectory.Service;

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
