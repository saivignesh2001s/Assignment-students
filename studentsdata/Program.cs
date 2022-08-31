using System.IO;
namespace studentsdata
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Do you want to populate?");
            string ks=Console.ReadLine();
            if (ks == "Yes")
            {
                Console.WriteLine("Enter the no.of students");
                int n;
                n = Convert.ToInt32(Console.ReadLine());
                student[] arr = new student[n];
                for (int i = 0; i < n; i++)
                {
                    student ps = new student();
                    Console.WriteLine("Enter student id");
                    ps.Id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter student Name");
                    ps.Name = Console.ReadLine();
                    Console.WriteLine("Enter student age");
                    ps.Age = Convert.ToInt32(Console.ReadLine());
                    arr[i] = ps;
                }
                Console.WriteLine("Enter filename to populate");
                string s = @"C:\Users\saivignesh\Desktop\";
                string p = Console.ReadLine();
                string k = s + p;

                FileStream fs = new FileStream(k, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sr = new StreamWriter(fs);
                for (int i = 0; i < n; i++)
                {
                    sr.Write("{0}\t{1}\t{2}\n", arr[i].Id, arr[i].Name, arr[i].Age);
                }
                sr.Close();
                fs.Close();
                sr.Dispose();
                fs.Dispose();
            }
            else
            {
                string s = @"C:\Users\saivignesh\Desktop\";
                Console.WriteLine("Enter filename to retrieve");
                string po = Console.ReadLine();
                string jo = s + po;
                var lc = File.ReadAllLines(jo).Length;
                FileStream ms = new FileStream(jo, FileMode.Open, FileAccess.Read);
                StreamReader rs = new StreamReader(ms);
                student[] pty = new student[lc];
                for (int i = 0; i < lc; i++)
                {
                    string pu = rs.ReadLine();
                    if (pu != null)
                    {
                        char[] whitespace = new char[] { ' ', '\t' };
                        string[] words = pu.Split(whitespace);

                        student py = new student();
                        int ut = Convert.ToInt32(words[0]);
                        string pot = words[1];
                        int mt = Convert.ToInt32(words[2]);
                        py.accept(ut, pot, mt);
                        pty[i] = py;
                    }
                }

                ms.Flush();
                rs.Close();
                ms.Close();
                rs.Dispose();
                ms.Dispose();


                Console.WriteLine("1.Display\n2.Sortbyid\n3.SearchByid");
                int ki = Convert.ToInt32(Console.ReadLine());
                switch (ki)
                {
                    case 1:
                        for (int i = 0; i < pty.Length; i++)
                        {
                            Console.WriteLine("{0}\t{1}\t{2}", pty[i].Id, pty[i].Name, pty[i].Age);
                        }
                        break;
                    case 2:
                        var gt = pty.OrderBy(pty => pty.Id).ToArray();
                        for (int i = 0; i < gt.Length; i++)
                        {
                            Console.WriteLine("{0}\t{1}\t{2}\n", gt[i].Id, gt[i].Name, gt[i].Age);

                        }
                        break;
                    case 3:
                        for (int i = 0; i < pty.Length; i++)
                        {
                            Console.WriteLine("{0}\t{1}\t{2}\n", pty[i].Id, pty[i].Name, pty[i].Age);
                        }
                        Console.WriteLine("Enter id to search");
                        int pd = Convert.ToInt32(Console.ReadLine());

                        var pt = pty.Where(pty => pty.Id == pd).ToArray();
                        for (int i = 0; i < pt.Length; i++)
                        {
                            Console.WriteLine("{0}\t{1}\t{2}\n", pt[i].Id, pt[i].Name, pt[i].Age);
                        }
                        break;


                }

            }
            
        }
    }
    public class student
    {
        string name;
        int id;
        int age;
        public void accept(int _id,string _name,int _age)
        {
            id = _id;
            name = _name;
            age = _age;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Id
        {
            get { return id; }
            set { id=value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
    }
}