using ConsoleTables;
using Dapper;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace testDB_Dapper
{
    internal class CrudOpration : ICrudOpration
    {
        string connectionString;

        public CrudOpration()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
        }
        public void Add(Employee employee)
        {

            string sql = "INSERT INTO Employee (FirstName,MiddleName,LastName,EmpCode,Gender,DOB,salary,JoiningDate,ResignDate) VALUES (@firstName,@middleName,@lastName,@empCode,@gender,@dob,@Salary,@joiningDate,@resignDate);";
            var parameters = new { firstName = employee.FirstName, middleName = employee.MiddleName, lastName = employee.LastName, empCode = employee.EmpCode, gender = employee.Gender, dob = employee.DOB, Salary = employee.salary, joiningDate = employee.JoiningDate, resignDate = employee.ResignDate };

            using (var connection = new SqlConnection(connectionString))
            {

                try
                {
                    var affectedRows = connection.Execute(sql, parameters);


                    if (affectedRows == 0)
                    {
                        Console.WriteLine("Somthing Went Wrong");
                    }
                    else
                    {
                        Console.WriteLine("\n Records Inserted Successfully");
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Error Generated. Details: " + e.ToString());
                }

            }

        }
        public void Update(int UpdateId)
        {


            string updateSql =@"Update Employee set FirstName='Updated',MiddleName ='S',LastName ='Raj',EmpCode=1007,Gender=1,salary=202020,JoiningDate='2022-01-07',ResignDate='2024-2-2' Where Employee_PK=@Employee_PK;";
            var parameter = new { Employee_PK = UpdateId };

            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    var affectedRows = connection.Execute(updateSql, parameter);
                    if (affectedRows == 0)
                    {
                        Console.WriteLine("Somthing Went Wrong");
                    }
                    else
                    {
                        Console.WriteLine("\n Records Updated Successfully");
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Error Generated. Details: " + e.ToString());
                }
            }
        }
        public void Delete(int RemoveId)
        {

            string removeSql = "Delete From Employee  Where Employee_PK=@Employee_PK;";
            var parameter2 = new { Employee_PK = RemoveId };

            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    var affectedRows = connection.Execute(removeSql, parameter2);

                    if (affectedRows == 0)
                    {
                        Console.WriteLine("Somthing Went Wrong");
                    }
                    else
                    {
                        Console.WriteLine("\n Records Deleted Successfully");
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Error Generated. Details: " + e.ToString());
                }
            }
        }
        public void Read()
        {
            using (var connection = new SqlConnection(connectionString))
            {

                try
                {
                    var getallSql = "SELECT * FROM Employee";
                    var allEmployee = connection.Query(getallSql);

                    var table = new ConsoleTable("Id", "First Name", "Middle Name", "Last Name", "Employee Code", "DOB", "Salary", "Gender", "Joining Date", "Resign Date");

                    foreach (var Emp in allEmployee)
                    {
                        table.AddRow(Emp.Employee_PK, Emp.FirstName, Emp.MiddleName, Emp.LastName, Emp.EmpCode, Emp.DOB, Emp.salary, Emp.Gender, Emp.JoiningDate, Emp.ResignDate);

                    }
                    table.Options.EnableCount = false;
                    table.Write();
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Error Generated. Details: " + e.ToString());
                }

            }   
        }
        public void Read(int Id)
        {

            var parameter = new { Employee_PK = Id };
            string getbyidSql = "SELECT * FROM Employee WHERE Employee_PK=@Employee_PK";
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    var Emp = connection.QuerySingle<Employee>(getbyidSql, parameter);

                    if (Emp != null)
                    {
                        var table = new ConsoleTable("Id", "First Name", "Middle Name", "Last Name", "Employee Code", "DOB", "Salary", "Gender", "Joining Date", "Resign Date");

                        table.AddRow(Emp.Employee_PK, Emp.FirstName, Emp.MiddleName, Emp.LastName, Emp.EmpCode, Emp.DOB, Emp.salary, Emp.Gender, Emp.JoiningDate, Emp.ResignDate);
                        table.Options.EnableCount = false;
                        table.Write();
                    }
                    else
                    {
                        Console.WriteLine("\n Employee Does Not Exist");

                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Error Generated. Details: " + e.ToString());
                }


            }

        }
    }
}
