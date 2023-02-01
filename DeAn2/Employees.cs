using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace DeAn2
{
    class Employees : Iaccount
    {
        // fiedls
        private string userName;
        private string passWord;
        private User user;
        private static LinkedList<Employees> listEmployees = new LinkedList<Employees>();
        private static int count = 0;

        // attribute

        public string UserName { get => userName; private set => userName = value; }
        public string PassWord { get => passWord; set => passWord = value; }
        public User User { get => user; set => user = value; }
        internal static LinkedList<Employees> ListEmployees { get => listEmployees; set => listEmployees = value; }
        public static int Count { get => count; }

        // method

        public Employees(string userName, string passWord, string hoTen, string diaChi, string sdt, string email)
        {
            this.UserName = userName;
            this.PassWord = passWord;
            user = new User(hoTen, diaChi, sdt, email);
            listEmployees.AddLast(this);
            count += 1;
        }


        public override string ToString()
        {
            return $"{this.UserName}#{this.PassWord}";
        }

        public static void AddToFile()
        { 
            LinkedListNode<Employees> p = Employees.listEmployees.First;
            StreamWriter sw = new StreamWriter("employees.txt");
            using (sw)
            {
                while (p != null)
                {
                    sw.WriteLine(p.Value.ToString());
                    p = p.Next;
                }
            }
        }

        public string baseToString()
        {
            return $"{User.ToString()}";
        }

    }
}
