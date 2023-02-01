using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DeAn2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Tool.ReadFileToList();
            int choose = 0;
            do
            {
                Console.WriteLine("ban la nhan vien hay admin");
                Console.WriteLine("nhan vien an phim 1 va ad min an phim 2");
                choose = Convert.ToInt32(Console.ReadLine());
            } while (choose != 1 && choose != 2);
            if (choose == 1 )
            {
                Tool.LoginEmPloyee();
            }
            else
            {
                Tool.LoginAdmin();
            }
        }
    }
}
