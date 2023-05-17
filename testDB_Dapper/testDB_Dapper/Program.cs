using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace testDB_Dapper
{
    internal class Program
    {
        public enum crud
        {
            Getall = 0,
            insert = 1,
            update = 2,
            delete = 3,
            GetByID = 4
        }
        static void Main(string[] args)
        {

            string status;

            do
            {
                Console.WriteLine($"\n Enter Your Choice:");
                Console.WriteLine($"0 - Get ALL");
                Console.WriteLine($"1 - Insert");
                Console.WriteLine($"2 - Update");
                Console.WriteLine($"3 - Delete");
                Console.WriteLine($"4 - Get BY ID \n");



                string choice = Console.ReadLine();
                int intChoice = Convert.ToInt32(choice);
                crud userSelected = (crud)intChoice;

                switch (userSelected)
                {
                    case crud.insert:
                        var newEmployee = new Employee()
                        {
                            FirstName = "Akash",
                            MiddleName = "i",
                            LastName = "Rana",
                            EmpCode = 12,
                            Gender = 1,
                            DOB = DateTime.Now,
                            salary = 54166,
                            JoiningDate = DateTime.Now,
                            ResignDate = DateTime.Now,

                        };
                        CrudOpration insert = new CrudOpration();
                        insert.Add(newEmployee);
                        break;
                    case crud.update:
                        Console.WriteLine("Enter Id: ");
                        int UpdateId;

                        if (int.TryParse(Console.ReadLine(), out UpdateId))
                        {
                            CrudOpration update = new CrudOpration();
                            update.Update(UpdateId);
                        }
                        else
                        {
                            Console.WriteLine("Pelese Provide Valid Input");

                        }
                        break;

                    case crud.delete:
                        Console.WriteLine("Enter Id: ");
                        int Id;
                        if (int.TryParse(Console.ReadLine(), out Id))
                        {
                            CrudOpration Remove = new CrudOpration();
                            Remove.Delete(Id);
                        }
                        else
                        {
                            Console.WriteLine("Pelese Provide Valid Input");

                        }
                        break;
                    case crud.Getall:
                        CrudOpration read = new CrudOpration();
                        read.Read();
                        break;
                    case crud.GetByID:
                        Console.WriteLine("Enter Id : ");
                        int readId;
                        if (int.TryParse(Console.ReadLine(), out readId))
                        {
                            CrudOpration readByID = new CrudOpration();
                            readByID.Read(readId);
                        }
                        else
                        {
                            Console.WriteLine("Pelese Provide Valid Input");

                        }

                        break;

                    default:
                        Console.WriteLine("Pelese Provide Valid Input");
                        break;
                }

                Console.ReadLine();
                Console.Write("Do you want to continue(y/n):");
                status = Console.ReadLine();
            }
            while (status == "y" || status == "Y");

            Console.ReadKey();
        
           }
    }
}
