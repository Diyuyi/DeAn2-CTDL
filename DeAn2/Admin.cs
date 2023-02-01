using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace DeAn2
{
    class Admin:Iaccount
    {
        // fields
        private string userName;
        private string passWord;
        private static LinkedList<Admin> listAddMin = new LinkedList<Admin>();
        private static int count = 0;
        //attribute
        public string UserName { get => userName;private set => userName = value; }
        public string PassWord { get => passWord;set => passWord = value; }
        internal static LinkedList<Admin> ListAddMin { get => listAddMin; }
        public static int Count { get => count; }

        //constructors

        public Admin(string userName, string passWord)
        {
            this.userName = userName;
            this.passWord = passWord;
            listAddMin.AddLast(this);
            count += 1;
        }


    }
}
