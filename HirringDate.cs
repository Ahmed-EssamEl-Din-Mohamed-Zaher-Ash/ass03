using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_03
{
    public class HirringDate
    {
         
        // Develop a Class to represent the Hiring Date Data:
        // consisting of fields to hold the day, month and Years.

      
        
        private int day;
        private int month;
        private int year;



        


        public HirringDate()
        {
            
        }
        public HirringDate(int _day , int _month , int _year)
        {
            Day = _day;
            Month = _month;
            Year = _year;
        }
      

        public int Year
        {
            get { return year; }
            set { year = value >= 2000 && value <= DateTime.Now.Year ? value : 2010; }
        }


        public int Month
        {
            get { return month; }
            set { month = value >= 1 && value <= 12 ? value : 1; }
        }

        public int Day
        {
            get { return day; }
            set { day = value > 0 && value <= 31 ? value : 1; }
        }

     

        public override string ToString()
        {
            return $"{day}/{month}/{year}";
        }

       
    }
}
