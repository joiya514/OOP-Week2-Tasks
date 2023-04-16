using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2Tasks.BL;
using System.IO;

namespace Week2Tasks
{
    class Program
    {
        //class students
        //{
        //    public string name;
        //    public int roll_no;
        //    public float cgpa;
        //}
        static void Main(string[] args)
        {
            //students[] s1 = new students[10];
            //product[] product = new product[10];
            signUp[] newUser = new signUp[100];
            char option;
            int count = 0;
            //task1();
            //task2();

            //FOR TASK 3
            //while (true)
            //{
            //    option = menu();
            //    if (option == '1')
            //    {
            //        s1[count] = addStudent();
            //        count++;
            //    }
            //    if (option == '2')
            //    {
            //        viewStudents(s1, count);
            //    }
            //    if (option == '3')
            //    {
            //        topStudent(s1, count);
            //    }
            //    if (option == '4')
            //    {
            //        return;
            //    }
            //    Console.ReadLine();
            //}

            // FOR CHALLENGE 1
            //while (true)
            //{
            //    option = productMenu();
            //    if (option == '1')
            //    {
            //        product[count] = addProduct();
            //        count++;
            //    }
            //    if (option == '2')
            //    {
            //        viewProducts(product, count);
            //    }
            //    if (option == '3')
            //    {
            //        float sum = totalPrice(product, count);
            //        Console.Write(" Total Store Worth is: " + sum);
            //    }
            //    if (option == '4')
            //    {
            //        return;
            //    }
            //    Console.ReadLine();
            //}
            while (true)
            {
                readData(ref count,ref newUser);
                Console.Clear();
                header();
                option = signMenu();
                if (option == '1')
                {
                    int index = signIn(newUser, count);
                    Console.WriteLine(newUser[index].role);
                }
                if (option == '2')
                {
                    newUser[count] = addNewUser(ref count, newUser);
                    count++;
                }

                if (option == '3')
                {
                    return;
                }
            }
        }

        static void header()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("*****************************************************************************************************");
            Console.WriteLine("*****     $                     -(ELECTRIC BILLS MANAGEMENT SYSTEM)-                      $     *****");
            Console.WriteLine("*****************************************************************************************************");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;
        }
        static void task1()
        {
            students s1 = new students();
            s1.name = "me";
            s1.roll_no = 16;
            s1.cgpa = 3.5f;
            Console.WriteLine(" Name: {0}\n Roll No: {1}\n CGPA: {2}\n", s1.name, s1.roll_no, s1.cgpa);
            students s2 = new students();
            s2.name = "He";
            s2.roll_no = 16;
            s2.cgpa = 3.5f;
            Console.WriteLine(" Name: {0}\n Roll No: {1}\n CGPA: {2}\n", s2.name, s2.roll_no, s2.cgpa);
        }

        static void task2()
        {
            students s1 = new students();
            Console.Write("Enter Name: ");
            s1.name = Console.ReadLine();
            Console.Write("Enter Roll No: ");
            s1.roll_no = int.Parse(Console.ReadLine());
            Console.Write("Enter CGPA: ");
            s1.cgpa = float.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine(" Name: {0}\n Roll No: {1}\n CGPA: {2}\n", s1.name, s1.roll_no, s1.cgpa);
        }

               //TASK 3 FUNCTIONS
        static char menu()
        {
            Console.Clear();
            Console.WriteLine(" 1: Add a student");
            Console.WriteLine(" 2: View students");
            Console.WriteLine(" 3: Top 3 students");
            Console.WriteLine(" 4: Exit");
            Console.Write("  Enter Your Choice: ");
            char choice = char.Parse(Console.ReadLine());
            return choice;
        }

        static students addStudent()
        {
            Console.Clear();
            students s1 = new students();
            Console.Write("Enter Name: ");
            s1.name = Console.ReadLine();
            Console.Write("Enter Roll No: ");
            s1.roll_no = int.Parse(Console.ReadLine());
            Console.Write("Enter CGPA: ");
            s1.cgpa = float.Parse(Console.ReadLine());
            Console.Write("Enter Department: ");
            s1.department = Console.ReadLine();
            Console.Write("Is Hostelide: ");
            s1.isHostelide = char.Parse(Console.ReadLine());
            return s1;
        }
        static void viewStudents(students[] s1, int count)
        {
            Console.Clear();
            for(int x = 0; x < count; x++)
            {
                Console.WriteLine(" Name: {0}\n Roll No: {1}\n CGPA: {2}\n Department: {3}\n Is Hostelide: {4}\n", s1[x].name, s1[x].roll_no, s1[x].cgpa, s1[x].department, s1[x].isHostelide);
            }
        }

        static int largest(students[] s, int start, int end)
        {
            int index = start;
            float large = s[start].cgpa;
            for (int x = start; x < end; x++)
            {
                if (large < s[x].cgpa)
                {
                    large = s[x].cgpa;
                    index = x;
                }
            }
            return index;
        }
        static void topStudent(students[] s, int count)
        {
            Console.Clear();
            if (count == 0)
            {
                Console.WriteLine("No Record Present");
            }
            else if (count == 1)
            {
                viewStudents(s, 1);
            }
            else if (count == 2)
            {
                for (int x = 0; x < 2; x++)
                {
                    int index = largest(s, x, count);
                    students temp = s[index];
                    s[index] = s[x];
                    s[x] = temp;
                }
                viewStudents(s, 2);
            }
            else
            {
                for (int x = 0; x < 3; x++)
                {
                    int index = largest(s, x, count);
                    students temp = s[index];
                    s[index] = s[x];
                    s[x] = temp;
                }
                viewStudents(s, 3);
            }
        }

             //CHALLENGE 1 FUNCTIONS
             static char productMenu()
        {
            Console.Clear();
            Console.WriteLine(" 1: Add a Product");
            Console.WriteLine(" 2: View Products");
            Console.WriteLine(" 3: Total Store Worth");
            Console.WriteLine(" 4: Exit");
            Console.Write("  Enter Your Choice: ");
            char choice = char.Parse(Console.ReadLine());
            return choice;
        }
        static product addProduct()
        {
            Console.Clear();
            product product = new product();
            Console.Write("Enter Product Name: ");
            product.name = Console.ReadLine();
            Console.Write("Enter Product ID: ");
            product.id = Console.ReadLine();
            Console.Write("Enter Price: ");
            product.price = float.Parse(Console.ReadLine());
            Console.Write("Enter Category: ");
            product.category = Console.ReadLine();
            Console.Write("Enter Brand Name: ");
            product.brand = Console.ReadLine();
            Console.Write("Enter Country Name: ");
            product.country = Console.ReadLine();
            return product;
        }

        static void viewProducts(product[] product,int count)
        {
            Console.Clear();
            for (int x = 0; x < count; x++)
            {
                Console.WriteLine(" Product Name: {0}\n Product ID: {1}\n Price: {2}\n Category: {3}\n Brand Name: {4}\n Country Name: {5}\n", product[x].name, product[x].id, product[x].price, product[x].category, product[x].brand, product[x].country);
            }
        }
        static float totalPrice(product[] product, int count)
        {
            float sum = 0;
            for(int x = 0; x < count; x++)
            {
                sum = sum + product[x].price;
            }
            return sum;
        }
        // CHALLENGE 2 FUNCTIONS
        static char signMenu()
        {
            Console.Clear();
            header();
            Console.WriteLine(" 1: Sign In");
            Console.WriteLine(" 2: Sign Up");
            Console.WriteLine(" 3: Exit");
            Console.Write("  Enter Your Choice: ");
            char choice = char.Parse(Console.ReadLine());
            return choice;
        }
        static signUp addNewUser(ref int count,signUp[] newUser)
        {
            string username;
            signUp newUsers = new signUp();

            int y = 0;
            while (true)
            {
                Console.Clear();
                header();
                if (y != 0)
                {
                    Console.WriteLine("\n  (Not Valid UserName!)");
                }
                Console.Write(" Enter Username: ");
                username = Console.ReadLine();
                bool flag = isValidName(username, count, newUser);
                if (flag == true)
                {
                    break;
                }
                y++;
            }

            Console.Write("Enter Passward: ");
            newUsers.passward = Console.ReadLine();
            Console.Write("Enter Role: ");
            newUsers.role = Console.ReadLine();
            addDataFunction(count, username, newUsers.passward, newUsers.role);
            return newUsers;
        }
        static int signIn(signUp[] newUser,int count)
        {
            Console.Clear();
            header();
            string username;
            string passward;
            int index = -1;

            Console.Write(" Enter Username: ");
            username = Console.ReadLine();
            Console.Write(" Enter Passward: ");
            passward = Console.ReadLine();
            for(int x = 0; x < count; x++)
            {
                if(newUser[x].userName == username || newUser[x].passward == passward)
                {
                    index = x;
                    break;
                }
            }
            return index;
        }
        static bool isValidName(string name, int usersCount, signUp[] newUser)
        {
            for (int x = 0; x < name.Length; x++)
            {
                if ((name[x] < 65) || (name[x] > 90 && name[x] < 97) || (name[x] > 122))
                {
                    return false;
                }
            }
            for (int x = 0; x < usersCount; x++)
            {
                if (name == newUser[x].userName)
                {
                    return false;
                }
            }
            return true;
        }

        static void readData(ref int usersCount,ref signUp[] newUser)
        {
            string path = "E:\\OOP\\Week2Tasks\\Week2Tasks\\signData.txt";
            string record = "";
            if (File.Exists(path))
            {
                StreamReader data = new StreamReader(path);
                while ((record = data.ReadLine()) != null)
                {

                    //string fileContents = File.ReadAllText(path);
                    //Console.WriteLine(fileContents);
                    newUser[usersCount] = new signUp();
                    newUser[usersCount].userName = parseData(record, 1);
                    newUser[usersCount].passward = parseData(record, 2);
                    newUser[usersCount].role = parseData(record, 3);
                    usersCount = usersCount + 1;
                }
                data.Close();
            }
            else
            {
                Console.WriteLine("File Not Exists!");
            }
        }

        static string parseData(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item = item + record[x];
                }
            }
            return item;
        }

        static void addDataFunction(int usersCount, string userName, string passward, string role)
        {
            string path = "E:\\OOP\\Week2Tasks\\Week2Tasks\\signData.txt";
            StreamWriter f1 = new StreamWriter(path, true);
            f1.WriteLine(userName + "," + passward + "," + role);
            f1.Flush();
            f1.Close();
        }

    }
}
