using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RepositoryApp
{
    struct Repository
    {
        private Employee[] employees;

        private string path;

        int index;

        public Repository(string Path)
        {
            this.path = Path;
            this.index = 0;
            this.employees = new Employee[1];
            if (File.Exists(Path) == false)
            {
                Console.WriteLine("Add the first employee to the file\n");
                FileStream fs = File.Create(Path);
                fs.Close();
                Add();
                Save(Path);
            }
            else this.Load();


        }

        private void Resize(bool Flag)
        {
            if (Flag)
            {
                Array.Resize(ref this.employees, this.employees.Length * 2);
            }
        }

        public void Add()
        {

            this.Resize(index >= this.employees.Length);
            this.employees[index].ID = index + 1;
            this.employees[index].VDateTime = DateTime.Now;
            Console.WriteLine("Enter the name:"); this.employees[index].Name = Console.ReadLine();
            Console.WriteLine("Enter age:"); this.employees[index].Age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter height:"); this.employees[index].Height = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the date of birth (DD.MM.YYYY):"); this.employees[index].BirthDate = Console.ReadLine();
            Console.WriteLine("Enter the place of birth"); this.employees[index].Place = Console.ReadLine();
            this.index++;

        }

        public void AddFrom(Employee ConcreteWorker)
        {
            this.Resize(index >= this.employees.Length);
            this.employees[index] = ConcreteWorker;
            this.index++;
        }

        private void Load()
        {
            {
                using (StreamReader sr = new StreamReader(this.path))
                {

                    while (!sr.EndOfStream)
                    {
                        string[] args = sr.ReadLine().Split('#');

                        AddFrom(new Employee(Convert.ToInt32(args[0]), Convert.ToDateTime(args[1]), args[2], Convert.ToInt32(args[3]), Convert.ToInt32(args[4]), args[5], args[6]));
                    }
                }
            }
        }

        public void Save(string Path)
        {
            File.WriteAllText(Path, null);
            for (int i = 0; i < this.index; i++)
            {
                if (this.employees[i].ID > 0)
                {
                    string temp = String.Format("{0}#{1}#{2}#{3}#{4}#{5}#{6}",
                                            this.employees[i].ID,
                                            this.employees[i].VDateTime,
                                            this.employees[i].Name,
                                            this.employees[i].Age,
                                            this.employees[i].Height,
                                            this.employees[i].BirthDate,
                                            this.employees[i].Place);

                    File.AppendAllText(Path, $"{temp}\n");
                }

            }
        }

        public void PrintAllToConsole()
        {

            for (int i = 0; i < index; i++)
            {
                Console.WriteLine(this.employees[i].Print());
            }
        }



        public void PrintConcreteToConsole()
        {
            Console.WriteLine("Enter ID to print:");
            int i = int.Parse(Console.ReadLine()) - 1;
            Console.WriteLine(this.employees[i].Print());

        }

        public void DeleteConcrete()
        {
            Console.WriteLine("Enter ID to delete:");
            int i = int.Parse(Console.ReadLine()) - 1;

            for (; i < this.index; i++)
            {
                this.Resize(index >= this.employees.Length);
                this.employees[i] = this.employees[i + 1];
                this.employees[i].ID--;
            }


        }

        public void EditConcrete()
        {
            Console.WriteLine("Enter ID to edit:");
            int i = int.Parse(Console.ReadLine()) - 1;
            this.employees[i].VDateTime = DateTime.Now;
            Console.WriteLine("Enter the name:"); this.employees[i].Name = Console.ReadLine();
            Console.WriteLine("Enter age:"); this.employees[i].Age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter height:"); this.employees[i].Height = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the date of birth (DD.MM.YYYY):"); this.employees[i].BirthDate = Console.ReadLine();
            Console.WriteLine("Enter the place of birth"); this.employees[i].Place = Console.ReadLine();

        }

        public void ChooseDate()
        {
            Console.WriteLine("Enter start date(DD.MM.YYYY):"); string x = Console.ReadLine();
            Console.WriteLine("Enter end date(DD.MM.YYYY):"); string y = Console.ReadLine();
            DateTime x1 = Convert.ToDateTime(x);
            DateTime y1 = Convert.ToDateTime(y);

            for (int i = 0; i < index; i++)
            {
                if (employees[i].VDateTime >= x1 && employees[i].VDateTime <= y1)
                {
                    Console.WriteLine(this.employees[i].Print());
                }
            }


        }


        public void SwitchSort()
        {
            Employee[] temp = this.employees;
            DateTime[] dateTimes = new DateTime[this.index];
            for (int i = 0; i < index; i++)
            {
                dateTimes[i] = this.employees[i].VDateTime;
            }
            DateTime[] result = dateTimes.OrderByDescending(x => x).ToArray();
            Array.Sort(result, temp);
            for (int i = 0; i < index; i++)
            {
                Console.WriteLine(temp[i].Print());
            }

        }


        public void Choose1()
        {
            Console.WriteLine(@"Press
1 To print all employees
2 to print concrete employee
3 to specify date range, then print
4 to add new employee");

            while (true)
            {
                int key = int.Parse(Console.ReadLine());
                Console.WriteLine();
                switch (key)
                {
                    case 1:
                        PrintAllToConsole();
                        break;
                    case 2:
                        PrintConcreteToConsole();
                        break;
                    case 3:
                        ChooseDate();
                        break;
                    case 4:
                        Add();
                        Console.WriteLine("Employee succesfully added");
                        Choose1();
                        break;
                    default:
                        Console.WriteLine("Enter 1 - 4");
                        continue;
                }
                break;
            }
            Console.WriteLine();
            Choose2();
        }

        public void Choose2()
        {
            Console.WriteLine();
            Console.WriteLine(@"Press
1 To edit concrete employee
2 to delete concrete employee
3 to add new employee
4 to switch sort order
5 to save data and exit");
            while (true)
            {
                int key = int.Parse(Console.ReadLine());
                Console.WriteLine();
                switch (key)
                {
                    case 1:
                        EditConcrete();
                        Console.WriteLine("Employee succesfully edited");
                        Choose2();
                        break;
                    case 2:
                        DeleteConcrete();
                        Console.WriteLine("Employee succesfully deleted");
                        Choose2();
                        break;
                    case 3:
                        Add();
                        Console.WriteLine("Employee succesfully added");
                        Choose2();
                        break;
                    case 4:
                        SwitchSort();
                        Choose2();
                        break;
                    case 5:
                        Save(path);
                        break;
                    default:
                        Console.WriteLine("Enter 1 - 6");
                        continue;
                }
                break;
            }
            Console.WriteLine();
        }

    }
}
