using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_LB2.Shop
{
    public class Shop : IComparable<Shop>
    {
        // Properties
        string title;
        public string Title
        {
            get { return title; }
            set
            {
                if (value != string.Empty)
                {
                    title = value;
                }
                else
                    throw new Exception("Name cannot be empty");
            }
        }

        string adress;
        public string Adress
        {
            get { return adress; }
            set
            {
                if (value != string.Empty)
                {
                    adress = value;
                }
                else
                    throw new Exception("Name cannot be empty");
            }
        }

        int number_of_departments;
        public int Number_Of_Departments
        {
            get { return number_of_departments; }
            set
            {
                if (value > 0)
                {
                    number_of_departments = value;
                }
                else
                    throw new Exception("Value cannot be less than zero");
            }
        }

        int number_of_workers;
        public int Number_Of_Workrers
        {
            get { return number_of_workers ; }
            set
            {
                if (value > 0)
                {
                    number_of_workers = value;
                }
                else
                    throw new Exception("Value cannot be less than zero");
            }
        }

        double total_income;
        public double Total_Income
        {
            get { return total_income; }
            set
            {
                if (value > 0)
                {
                    total_income = value;
                }
                else
                    throw new Exception("Value cannot be less than zero");
            }
        }

        double total_outcome;
        public double Total_Outcome
        {
            get { return total_outcome; }
            set
            {
                if (value > 0)
                {
                    total_outcome = value;
                }
                else
                    throw new Exception("Value cannot be less than zero");
            }
        }

        double total_salary;
        public double Total_Salary
        {
            get { return total_salary; }
            set
            {
                if (value > 0)
                {
                    total_salary = value;
                }
                else
                    throw new Exception("Value cannot be less than zero");
            }
        }

        int number_of_goods;
        public int Number_Of_Goods
        {
            get { return number_of_goods; }
            set 
            {
                if(value > 0)
                {
                    number_of_goods = value;
                }
                else
                    throw new Exception("Value cannot be less than zero");
            }
        }

        public List<Shop> List = new List<Shop>();

        // Constructors
        public Shop()
        {
            Title = string.Empty;
            Adress = string.Empty;
            Number_Of_Departments = 0;
            Number_Of_Workrers = 0;
            Total_Income = 0;
            Total_Outcome = 0;
            Total_Salary = 0;
            Number_Of_Goods = 0;
            List = new List<Shop>();
        }

        public Shop(string shop_title, string shop_adress, int number_of_departments, int number_of_workers, double total_income, double total_outcome, double total_salary, int number_of_goods)
        {
            Title = shop_title;
            Adress = shop_adress;
            Number_Of_Departments = number_of_departments;
            Number_Of_Workrers = number_of_workers;
            Total_Income = total_income;
            Total_Outcome = total_outcome;
            Total_Salary = total_salary;
            Number_Of_Goods = number_of_goods;
            List = new List<Shop>();
        }

        public Shop(Shop copied)
        {
            if (copied == null)
            {
                throw new ArgumentNullException();
            }

            Title = copied.Title;
            Adress = copied.Adress;
            Number_Of_Departments = copied.Number_Of_Departments;
            Number_Of_Workrers = copied.Number_Of_Workrers;
            Total_Income = copied.Total_Income;
            Total_Outcome = copied.Total_Outcome;
            Total_Salary = copied.Total_Salary;
            Number_Of_Goods = copied.Number_Of_Goods;
            List = new List<Shop>();
        }

        // Business logic
        public double Income_Per_Time(double months)
        {
            double income = months * (this.Total_Income - (this.Total_Outcome + this.Total_Salary));
            return income;
        }

        public double Annual_Tax(double percent)
        {
            double annual_tax = (this.Total_Income * 12 * percent) / 100;
            return annual_tax;
        }

        public int CompareTo(Shop compared)
        {
            if(compared == null)
            {
                throw new ArgumentNullException();
            }

            if(this.Number_Of_Departments > compared.Number_Of_Departments)
            {
                return 1;
            }
            else if (this.Number_Of_Departments < compared.Number_Of_Departments)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public override string ToString()
        {
            string info_about_shop = "";

            info_about_shop = "Shop title: " + this.Title +
                "Address: " + this.Adress +
                "Amount of departments: " + this.Number_Of_Departments +
                "Amount of workers: " + this.Number_Of_Workrers +
                "Amount of goods: " + this.Number_Of_Goods +
                "Profit per month: " + this.Income_Per_Time(1);
            return info_about_shop;
        }

        // Operators
        public static Shop operator ++(Shop shop)
        {
            shop.Number_Of_Workrers += 1;
            return shop;
        }

        public static Shop operator --(Shop shop)
        {
            shop.Number_Of_Workrers -= 1;
            return shop;
        }

        public int this[string parameter]
        {
            get
            {
                switch(parameter)
                {
                    case "Income": return (int)this.Income_Per_Time(1);
                    case "Outcome": return (int)this.Total_Outcome;
                    case "Salary": return (int)this.Total_Salary;
                    default: throw new Exception("Unidentified property");
                }
            }
        }
    }
}
