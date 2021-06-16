using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminders
{
    public class Reminder
    {
        //Declare variables
        private bool completed;
        private string reminderText;
        private Date setDate;
        private Date dueDate;

        //Constructor for blank reminder
        public Reminder()
        {
            completed = false;
            reminderText = "";
            setDate = new Date();
            dueDate = new Date();
        }

        //Constructor with just a string parameter
        public Reminder(string gReminderText)
        {
            completed = false;
            reminderText = gReminderText;
            setDate = new Date();
            dueDate = new Date();
        }

        //Constructor with completed and text parameters
        public Reminder(bool gCompleted, string gReminderText)
        {
            completed = gCompleted;
            reminderText = gReminderText;
            setDate = new Date();
            dueDate = new Date();
        }

        //Constructor with all parameters (minus setDate)
        public Reminder(bool gCompleted, string gReminderText, Date gDueDate)
        {
            completed = gCompleted;
            reminderText = gReminderText;
            setDate = new Date();
            dueDate = gDueDate;
        }

        //Constructor with all parameters
        public Reminder(bool gCompleted, string gReminderText, Date gDueDate, Date gSetDate)
        {
            completed = gCompleted;
            reminderText = gReminderText;
            setDate = gSetDate;
            dueDate = gDueDate;
        }

        //Method to get the value of completed
        public bool GetCompleted()
        {
            return completed;
        }

        //Method to set the value of completed
        public void SetCompleted(bool newValue)
        {
            completed = newValue;
        }

        //Method to get the value of reminderText
        public string GetText()
        {
            return reminderText;
        }

        //Method to set the value of reminderText
        public void SetText(string newReminderText)
        {
            reminderText = newReminderText;
        }

        //Method to get the value of setDate
        public Date GetSetDate()
        {
            return setDate;
        }

        //Method to set the value of setDate
        public void SetSetDate(Date newSetDate)
        {
            setDate = newSetDate;
        }

        //Method to get the value of dueDate
        public Date GetDueDate()
        {
            return dueDate;
        }

        //Method to set the value of dueDate
        public void SetDueDate(Date newDueDate)
        {
            dueDate = newDueDate;
        }
    }
}
