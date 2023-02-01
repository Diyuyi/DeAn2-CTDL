using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DeAn2
{
    class Tool
    {
        public static void AddEmployee() // ham add them 1 employee vao danh sach
        {
            string userName = string.Empty;
            string passWord = "111111";
            string hoTen;
            string diaChi;
            string sdt;
            string email;
            do
            {
                Console.WriteLine("nhap username");
                userName = Convert.ToString(Console.ReadLine());
            } while (userName == string.Empty);
            do
            {
                Console.WriteLine("nhap dia chi");
                diaChi = Convert.ToString(Console.ReadLine());
            } while (diaChi == string.Empty);
            do
            {
                Console.WriteLine("nhap ho ten");
                hoTen = Convert.ToString(Console.ReadLine());
            } while (hoTen == string.Empty);
            do
            {
                Console.WriteLine("nhap sdt");
                sdt = Convert.ToString(Console.ReadLine());
            } while (!CheckPhoneNumber(sdt));
            do
            {
                Console.WriteLine("nhap email");
                email = Convert.ToString(Console.ReadLine());
            } while (!CheckEmail(email));
            Employees temp = new Employees(userName, passWord, hoTen, diaChi, sdt, email);
            Employees.AddToFile();
            User.AddToFile();
        }

        public static bool CheckPhoneNumber(string sdt) // ham kiem tra so dien thoai
        {
            if (sdt.Length < 10 && sdt.Length>10)
            {
                return false;
            }
            for (int i = 0; i <sdt.Length; i++)
            {
                if (sdt[i] <'0' || sdt[i]>'9')
                {
                    return false;
                }
            }
            return true;
        }

        public static void DeleteEmployee() // ham xoa 1 employees thong qua username
        {
            LinkedListNode<Employees> temp = Employees.ListEmployees.First;
            string username = string.Empty;
            for (; temp != null; temp = temp.Next)
            {
                if (temp.Value.UserName == username)
                {
                    Employees.ListEmployees.Remove(temp);
                    Console.WriteLine($"tim thay va xoa thanh cong user name {username}");
                    Employees.AddToFile();
                    return;
                }
            }
            Console.WriteLine("khong tim thay username ban muon xoa trong danh sach");
        }

        public static void FindEmployee() // ham tim va in thong tin 1 nhan vien thong qua username
        {
            LinkedListNode<Employees> temp = Employees.ListEmployees.First;
            string username = string.Empty;
            for (; temp != null; temp = temp.Next)
            {
                if (temp.Value.UserName == username)
                {
                    Console.WriteLine($"tim thay user name {username}");
                    Console.WriteLine($"{temp.ToString()}#{temp.Value.baseToString()}");
                    return;
                }
            }
            Console.WriteLine("khong tim thay username ban muon trong danh sach");
        }

        public static void UpDateInfoEmployee() // cap nhat thong tin employee
        {
            LinkedListNode<Employees> temp = Employees.ListEmployees.First;
            string userName = string.Empty;
            bool bCheck = false;
            int choose;
            for (LinkedListNode<Employees> i = Employees.ListEmployees.First; i != null; i = i.Next)
            {
                if (i.Value.UserName == userName)
                {
                    temp = i;
                    bCheck = true;
                }

            }
            if (bCheck == false)
            {
                Console.WriteLine(" Không có user cần update ");
                return;
            }       
            do
            {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(" Mời bạn lựa chọn thứ bạn muốn update ");
            Console.WriteLine("*************** Menu UpDate **************");
            Console.WriteLine("1. dia chi  ");
            Console.WriteLine("2. so dien thoai .");
            Console.WriteLine("3. email  ");
            Console.WriteLine("********************************************");
                Console.Write("Chọn chức năng:");
                int.TryParse(Console.ReadLine(), out choose);
            switch (choose)
            {
                case 1:
                    {
                        Console.Write(" Mời nhập địa chỉ muốn update ");
                        string value = Console.ReadLine();
                        temp.Value.User.DiaChi = value;
                    }
                    break;
                case 2:
                    {
                        string value;
                        do
                        {
                            Console.Write(" Mời nhập Số điện thoại muốn update ");
                            value = Convert.ToString(Console.ReadLine());
                            if (CheckPhoneNumber(value) == false)
                            {
                                Console.Write("Số điện thoại phải là 10 số va khong chua ki tu chu");
                            }
                        } while (CheckPhoneNumber(value) == false);
                            temp.Value.User.Sdt = value;
                    }
                    break;
                case 3:
                    {
                            string value;
                            Console.Write("moi ban nhap email");
                            do
                            {
                             value = Convert.ToString(Console.ReadLine());
                            } while (CheckEmail(value) == false);
                            temp.Value.User.Email = value;
                    }
                    break;
                }

            } while (choose < 1 || choose > 3);
        }

        public static bool CheckEmail(string email)
        {
            if (email.Contains('@') == true && email[0] != '@')
            {
                return true;
            }
            return false;
        }

        public static void ReadFileToList()
        {
            string[] array = new string[0];
            int count = 0;
            try
            {
                System.IO.FileStream fs = new System.IO.FileStream("username.txt", System.IO.FileMode.Open, System.IO.FileAccess.Read);
                StreamReader sr = new System.IO.StreamReader(fs);
                using (sr)
                {
                    while (sr.Peek() != -1)
                    {
                        System.Array.Resize(ref array, array.Length + 1);
                        array[array.Length - 1] = sr.ReadLine();
                    }
                }
            }
            catch (Exception a)
            {
                Console.WriteLine("doc file username.txt khong thanh cong");
                Console.WriteLine(a.Message);
            }
            try
            {
                System.IO.FileStream fs = new System.IO.FileStream("employees.txt", System.IO.FileMode.Open, System.IO.FileAccess.Read);
                StreamReader sr = new System.IO.StreamReader(fs);
                using (sr)
                {
                    while (sr.Peek() != -1)
                    {
                        string[] arrayem = sr.ReadLine().Split('#');
                        string[] arrayuser = array[count].Split('#');
                        Employees temp = new Employees(arrayem[0], arrayem[1], arrayuser[0], arrayuser[1], arrayuser[2], arrayuser[3]);
                        count += 1;
                    }
                }
        
            }
            catch (Exception e)
            {

                Console.WriteLine("doc file employees.txt khong thanh cong");
                Console.WriteLine(e.Message);
            }
            try
            {
                System.IO.FileStream fs = new System.IO.FileStream("Administrators.txt", System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite);
                StreamReader sr = new System.IO.StreamReader(fs);
                using (sr)
                {
                    while (sr.Peek() != -1)
                    {
                        string[] arruser = sr.ReadLine().Split('#');
                        Admin temp = new Admin(arruser[0], arruser[1]);
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("doc file admin.txt khong thanh cong");
                Console.WriteLine(e.Message);
            }
        }

        public static void PrintfEmployees()
        {
            LinkedListNode<Employees> temp = Employees.ListEmployees.First;
            while (temp != null)
            {
                Console.WriteLine($"{temp.Value.ToString()}#{temp.Value.baseToString()}");
                temp = temp.Next;
            }

        }

        public static string HashPassWord()
        {
            string password = "";
            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter)
            {
                if (info.Key != ConsoleKey.Backspace)
                {
                    Console.Write("*");
                    password += info.KeyChar;
                }
                else if (info.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(password))
                    {
                        //xoa ky tu pass an
                        password = password.Substring(0, password.Length - 1);
                        //gán độ dài con trỏ từ phải sang trai
                        int pos = Console.CursorLeft;
                        // lùi con trỏ sang trái
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                        // chỗ ký tự bị xoá ngầm chèn zo đó khoảng trắng
                        Console.Write(" ");
                        // // lùi con trỏ sang trái dưới chân khoảng trắng
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                    }
                }
                info = Console.ReadKey(true);
            }
            return password;
        }

        public static bool CheckLoginAdmin(string username,string password)
        {
            LinkedListNode<Admin> temp = Admin.ListAddMin.First;
            while (temp != null)
            {
                if (username == temp.Value.UserName && password == temp.Value.PassWord)
                {
                    return true;
                }
                temp = temp.Next;
            }
            return false;
        }

        public static bool CheckLoginEmploy(string username, string password)
        {
            LinkedListNode<Employees> temp = Employees.ListEmployees.First;
            while (temp != null)
            {
                if (username == temp.Value.UserName && password == temp.Value.PassWord)
                {
                    return true;
                }
                temp = temp.Next;
            }
            return false;
        }

        public static void LoginAdmin()
        {
            string username = "";
            string password = "";
            int choose = 0;
            // Menu đăng nhập
            do
            {

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("*****************************************");
                Console.Write("*\t\t");
                Console.Write("\t\t*");
                Console.WriteLine();
                Console.WriteLine("*****************************************");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("ADMIN");
                Console.Write("Username:\t");
                username = Console.ReadLine();
                Console.Write("Password:\t");
                password = HashPassWord(); //ReadPassword();
                Console.Clear();
            } while (CheckLoginAdmin(username,password) == false);

            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("************* MENU **************");
                Console.WriteLine("1.Thêm employee");
                Console.WriteLine("2.Xóa employee");
                Console.WriteLine("3.Tìm employee");
                Console.WriteLine("4.Cập nhật employee");
                Console.WriteLine("5.Hiển thị thông tin employee");
                Console.WriteLine("6.Thoát!");
                Console.WriteLine("*********************************");
                Console.Write("Chọn chức năng:");
                choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        AddEmployee(); break;
                    case 2:
                        DeleteEmployee(); break;
                    case 3:
                        FindEmployee(); break;
                    case 4:
                        UpDateInfoEmployee(); break;
                    case 5:
                        PrintfEmployees();
                        Console.ReadKey(); ; break;
                    case 6:
                        break;
                }
                Console.WriteLine("an phim bat ky de tiep tuc");
                Console.ReadKey();
            } while (choose>0&&choose<6);
        }

        public static void LoginEmPloyee()
        {
            string username = "";
            string password = "";
            int choose = 0;
            int count = 0;
            // Menu đăng nhập
            do
            {
                count += 1;
                if (count == 3)
                {
                    return;
                }
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("*****************************************");
                Console.Write("*\t\t");
                Console.Write("\t\t*");
                Console.WriteLine();
                Console.WriteLine("*****************************************");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("EmPloyee");
                Console.Write("Username:\t");
                username = Console.ReadLine();
                Console.Write("Password:\t");
                password = HashPassWord(); //ReadPassword();
                Console.Clear();
            } while (CheckLoginEmploy(username, password) == false);
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("************* MENU **************");
                Console.WriteLine("1.xem thong tin");
                Console.WriteLine("2.doi mat khau");
                Console.WriteLine("3.thoat");
                Console.WriteLine("*********************************");
                Console.Write("Chọn chức năng:");
                choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        PrintInfoEmPloyee(username) ; break;
                    case 2:
                        DeleteEmployee(); break;
                    case 3:
                        ; break;
                }
                Console.WriteLine("an phim bat ky de tiep tuc");
                Console.ReadKey();
            } while (choose > 0 && choose < 3);
        }

        public static void PrintInfoEmPloyee(string username)
        {
            LinkedListNode<Employees> p = Employees.ListEmployees.First;
            while (p!= null)
            {
                if (p.Value.UserName == username)
                {
                    Console.WriteLine($"{p.Value.ToString()}#{p.Value.baseToString()}");
                    return;
                }
            }
        }

    }


}
