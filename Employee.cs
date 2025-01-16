using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_03
{
    
    //We need to restrict the Gender field to be only M or F [Male or Female] 
    public enum Gender
    {
        Female = 1,
        Male
    }

    

   
    //Assign the following security privileges to the employee (guest, Developer, secretary and DBA) in a form of Enum
    [Flags]
    public enum SecurityLevel : byte
    {
        guest =1 , 
        Developer =2, 
        secretary =4,
        DBA =8
    }

    


    public class Employee  : IComparable 
    {
        
        // Design and implement a Class for the employees in a company:
        // Employee is identified by an ID, Name, security level, salary, hire date and Gender.



        
        private int id;
        private string name;
        public SecurityLevel securityLevel { get; set; }
        private Gender gender;
        private double salary;
        private HirringDate hirringDate;

        public HirringDate HirringDate
        {
            get { return hirringDate; }
            set { hirringDate = value; }
        }


        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }


        public Gender Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public SecurityLevel SecurityLevel
        {
            get { return SecurityLevel; }
            set { SecurityLevel = value; }
        }

        

        public string Name
        {
            get { return name; }
            set { name = value; }
        }




       
        public Employee()
        {
            hirringDate = new HirringDate();
        }
     



        

        
        //We want to provide the Employee Class to represent Employee data in a string Form (override ToString ()), display employee salary in a currency format. [ use String.Format Function]
        public override string ToString()
        {
            return $"ID:{id}\nName:{Name}\nSecurityLevel:{securityLevel}\nGender:{gender}\n" +
                $"Salary:{Salary:C}\nHiringDate:{hirringDate}";
        }

    

        
        public static Employee[] CreateEmp(int size)
        {
            if (size > 0)
            {
                Employee[] employees = new Employee[size];
                for (int i = 0; i < size; i++)
                {
                    employees[i] = new Employee();
                }
                return employees;
            }
            throw new ArgumentOutOfRangeException();
        }
  

    
        public static void InsertData(Employee[] employee)
        {
            if(employee is not null)
            {
                for (int i = 0; i < employee.Length; i++)
                {
                    Console.WriteLine($"Enter Data for Employee number {i + 1}");
                    Console.WriteLine("================================");

                    bool valid;
                    do
                    {
                        Console.WriteLine("ID: ");
                        valid = int.TryParse(Console.ReadLine(), out employee[i].id);
                    } while (!valid);

                    do
                    {
                        Console.WriteLine("Name: ");
                        employee[i].name = Console.ReadLine();
                    } while (String.IsNullOrWhiteSpace(employee[i].name));

                    do
                    {
                        Console.WriteLine("Salary: ");
                        valid = double.TryParse(Console.ReadLine(), out employee[i].salary);
                    } while (!valid);

                    int gender;
                    Console.WriteLine("1 for Male & 2 for Female");

                    do
                    {
                        Console.WriteLine("Gender: ");
                        valid = int.TryParse(Console.ReadLine(), out gender);
                    } while (!(valid &&  Enum.IsDefined(typeof(Gender) , gender)));

                    employee[i].gender = (Gender)gender;

                    int sl;
                    do
                    {
                        Console.WriteLine("SecurityLevel:");
                        valid = int.TryParse(Console.ReadLine(), out sl);
                    } while (!valid || !(sl > 0 && sl <= 15));

                    employee[i].securityLevel = (SecurityLevel)sl;

                    Console.WriteLine("HiringDate");

                    int day, month, year;

                    do
                    {
                        Console.WriteLine("Day: ");
                        valid = int.TryParse(Console.ReadLine(), out day);
                    } while (!valid);

                    employee[i].hirringDate.Day = day;

                    {
                        Console.WriteLine("Month: ");
                        valid = int.TryParse(Console.ReadLine(), out month);
                    } while (!valid);

                    employee[i].hirringDate.Month = month;
                    do
                    {
                        Console.WriteLine("Year: ");
                        valid = int.TryParse(Console.ReadLine(), out year);
                    } while (!valid);

                    employee[i].hirringDate.Year = year;
                }
            }
        }

      

        

        public static void printArray(Employee[] employees)
        {
            for(int i =0;  i<employees.Length; i++)
            {
                Console.WriteLine($" Data for Employee number {i + 1}");
                Console.WriteLine("================================");
                Console.WriteLine(employees[i]);
                Console.WriteLine("================================");
            }
        }


      


        public static void SortAray(Employee[] employees)
        {
            if(employees is not null)
            {
                Array.Sort(employees);
            }
        }
        public int CompareTo(object? obj)
        {
            Employee right = obj as Employee;

            if(hirringDate.Year> right.hirringDate.Year)
            {
                return -1;
            }else if(hirringDate.Year < right.hirringDate.Year)
            {
                return 1;
            }
            else
            {
                if(hirringDate.Month > right.hirringDate.Month)
                {
                    return -1;
                }else if(hirringDate.Month < right.hirringDate.Month)
                {
                    return 1;

                }
                else
                {
                    if (hirringDate.Day > right.hirringDate.Day)
                    {
                        return -1;
                    }
                    else if (hirringDate.Day < right.hirringDate.Day)
                    {
                        return 1;

                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }
        
    }
}
