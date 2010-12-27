using System;
using System.Collections.Generic;
using System.Text;
using Landpy.ActiveDirectory.Service;
using Landpy.ActiveDirectory.Entity;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace Landpy.ActiveDirectory.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            OperatorSecurity operatorSecurity = new OperatorSecurity();
            operatorSecurity.LdapPath = "LDAP://192.168.6.67";
            operatorSecurity.UserName = "Administrator";
            operatorSecurity.Password = "liu=pxl821102";

            UserService userService = new UserService(operatorSecurity);
            User user = userService.FindObjectByCN("pangxiaoliang");

            Console.WriteLine("Sid:{0}", user.ObjectSid);
            Console.WriteLine("Guid:{0}", user.ObjectGUID);

            User newUser = userService.FindObjectByObjectGuid(user.ObjectGUID);
            Console.WriteLine("New user CN:{0}", newUser.CN);

            ICollection<User> users = userService.FindObjectsByObjectClass("person");
            foreach (User userTmp in users)
            {
                Console.WriteLine(userTmp.CN);
            }

            //Form form = new Form();
            //form.TopMost = true;
            //PictureBox pictureBox = new PictureBox();
            //pictureBox.BackColor = Color.Black;
            //pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            //form.ClientSize = new Size(pictureBox.Width, pictureBox.Height);
            //MemoryStream memoryStream = new MemoryStream(newUser.ThumbnailPhoto);
            //memoryStream.Position = 0;
            //pictureBox.Image = Image.FromStream(memoryStream);
            //form.Controls.Add(pictureBox);
            //form.ShowDialog();
            //memoryStream.Close();

            Console.ReadKey();
        }
    }
}
