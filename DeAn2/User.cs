using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace DeAn2
{
    class User
    {
        // fields
        private string hoTen;
        private string diaChi;
        private string sdt;
        private string email;
        private static LinkedList<User> listUser = new LinkedList<User>();
        private static int count = 0;
        // attribute
        public string HoTen { get => hoTen; private set => hoTen = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string Email { get => email; set => email = value; }
        public static int Count { get => count; }
        // method
        public User(string hoTen, string diaChi, string sdt, string email)
        {
            this.HoTen = hoTen;
            this.DiaChi = diaChi;
            this.Sdt = sdt;
            this.Email = email;
            listUser.AddLast(this);
            count += 1;
        }


        public static void AddToFile()
        {
            LinkedListNode<User> p = User.listUser.First;
            StreamWriter sw = new StreamWriter("username.txt");
            using (sw)
            {
                while (p != null)
                {
                    sw.WriteLine(p.Value.ToString());
                    p = p.Next;
                }
            }
        }

        public override string ToString()
        {
            return $"{this.HoTen}#{this.DiaChi}#{this.Sdt}${this.Email}";
        }


    }
}
