using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminders
{
    public class Date
    {
        private int day;
        private int month;
        private int year;
        private string[] months;
        private int[] daysPerMonth;

        //Constructor with no parameters (-1 set for blank values)
        public Date()
        {
            day = -1;
            month = -1;
            year = -1;
            months = new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            daysPerMonth = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        }

        //Constructor that takes all parameters
        public Date(int gDay, int gMonth, int gYear)
        {
            day = gDay;
            month = gMonth;
            year = gYear;
            months = new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            daysPerMonth = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        }

        //Method to get the value of day
        public int GetDay()
        {
            return day;
        }

        //Method to set the value of day
        public void SetDay(int newDay)
        {
            //If month is entered, checks if day given is valid
            if (month != -1)
            {
                if (newDay > 0 && newDay <= daysPerMonth[month-1])
                {
                    day = newDay;
                }
                else
                {
                    day = -1;
                }
            }
            else
            {
                day = -1;
            }
        }

        //Method to get the value of month
        public int GetMonth()
        {
            return month;
        }

        //Method to set the value of month
        public void SetMonth(int newMonth)
        {
            if (newMonth > 0 && newMonth <= 12)
            {
                month = newMonth;
            }
            else
            {
                month = -1;
            }
        }

        //Method to get the actual month (in text)
        public string GetActualMonth()
        {
            if (month != -1)
            {
                return months[month - 1];
            }
            else
            {
                return "Error - month either invalid or not set";
            }
        }

        //Method to get the value of year
        public int GetYear()
        {
            return year;
        }

        //Method to set the value of year
        public void SetYear(int newYear)
        {
            year = newYear;
        }

        //Method to check whether a date is valid
        public bool isDateValid()
        {
            bool valid = true;
            if (day == -1 || month == -1 || year == -1)
            {
                valid = false;
            }
            return valid;
        }
    }
}
