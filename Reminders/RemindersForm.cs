using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Reminders
{
    public partial class RemindersForm : Form
    {
        //Declare variables
        public List<Reminder> reminders;
        public List<TextBox> reminderTexts;
        public List<TextBox> setDates;
        public List<TextBox> dueDates;
        public List<CheckBox> completeds;
        public int cNumPages; //Max num pages for completed tasks
        public int cCurrentPageNum; //Current page num for completed tasks
        public int ncNumPages; //Max num pages for non-completed tasks
        public int ncCurrentPageNum; //Current page num for non-completed tasks

        //Constructor
        public RemindersForm()
        {
            InitializeComponent();
            //Initialise variables
            reminders = new List<Reminder>();
            reminderTexts = new List<TextBox>();
            setDates = new List<TextBox>();
            dueDates = new List<TextBox>();
            completeds = new List<CheckBox>();
            cNumPages = 0;
            cCurrentPageNum = 1;
            ncNumPages = 0;
            ncCurrentPageNum = 1;
            //Run startup functions
            hideFieldsShowCreateButtonClearFieldsNoParam();
            readReminders();
            calculateNumPages();
            displayReminders(cbToggleDone.Checked);
            //Handle buttons and text
            btnPageDown.Enabled = false;
            tbPageNum.Text = cCurrentPageNum.ToString();
            if (ncCurrentPageNum == ncNumPages)
            {
                btnPageUp.Enabled = false;
            }
            //Set icon
            Icon = new Icon("bell_icon.ico");
        }

        //Method to read reminders from a file
        private void readReminders()
        {
            using (StreamReader sr = new StreamReader("reminders.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string tempLine = sr.ReadLine();
                    string[] tempSections = tempLine.Split('¶');
                    string[] tempSetDateArr = tempSections[2].Split('-');
                    Date tempSetDate = new Date(Convert.ToInt32(tempSetDateArr[2]), Convert.ToInt32(tempSetDateArr[1]), Convert.ToInt32(tempSetDateArr[0]));
                    string[] tempDueDateArr = tempSections[1].Split('-');
                    Date tempDueDate = new Date(Convert.ToInt32(tempDueDateArr[2]), Convert.ToInt32(tempDueDateArr[1]), Convert.ToInt32(tempDueDateArr[0]));
                    Reminder tempReminder = new Reminder(Convert.ToBoolean(tempSections[3]), tempSections[0], tempDueDate, tempSetDate);
                    reminders.Add(tempReminder);
                }
                sr.Close();
            }
        }

        //Method to write reminders to a file
        private void writeReminders()
        {
            //Format each reminder as text¶dueYYYY-MM-DD¶setYYYY-MM-DD¶completed
            using (StreamWriter sw = new StreamWriter("reminders.txt", false))
            {
                for (int i = 0; i < reminders.Count; i++)
                {
                    string tempWrite = $"{reminders[i].GetText()}¶{reminders[i].GetDueDate().GetYear()}-{reminders[i].GetDueDate().GetMonth()}-{reminders[i].GetDueDate().GetDay()}¶{reminders[i].GetSetDate().GetYear()}-{reminders[i].GetSetDate().GetMonth()}-{reminders[i].GetSetDate().GetDay()}¶{reminders[i].GetCompleted()}";
                    sw.WriteLine(tempWrite);
                }
                sw.Close();
            }
        }

        //Method to clear relevant reminder creation fields
        private void clearCreateFields()
        {
            tbDueDay.Text = "";
            tbDueMonth.Text = "";
            tbDueYear.Text = "";
            tbNewReminder.Text = "";
            btnAddReminder.Enabled = false;
        }

        //Method to hide relevant reminder creation fields
        private void hideCreateFields()
        {
            lblText.Hide();
            lblDueDate.Hide();
            tbNewReminder.Hide();
            tbDueDay.Hide();
            tbDueMonth.Hide();
            tbDueYear.Hide();
            btnAddReminder.Hide();
        }

        //Method to show relevant reminder creation fields
        private void showCreateFields()
        {
            lblText.Show();
            lblDueDate.Show();
            tbNewReminder.Show();
            tbDueDay.Show();
            tbDueMonth.Show();
            tbDueYear.Show();
            btnAddReminder.Show();
        }

        //Method to hide "New..." button
        private void hideCreateButtonShowCancelButton()
        {
            btnCreate.Hide();
            btnCancel.Show();
        }

        //Method to show "New..." button
        private void showCreateButtonHideCancelButton()
        {
            btnCreate.Show();
            btnCancel.Hide();
        }

        //Method to run when "New..." button is pressed
        private void showCreationFieldsHideCreateButton(object sender, EventArgs e)
        {
            showCreateFields();
            hideCreateButtonShowCancelButton();
        }

        //Method to run when "Cancel" button is pressed with parameters
        private void hideFieldsShowCreateButtonClearFields(object sender, EventArgs e)
        {
            clearCreateFields();
            hideCreateFields();
            showCreateButtonHideCancelButton();
        }

        //Method to run when "Cancel" button is pressed without parameters
        private void hideFieldsShowCreateButtonClearFieldsNoParam()
        {
            clearCreateFields();
            hideCreateFields();
            showCreateButtonHideCancelButton();
        }

        //Method to display reminders
        private void displayReminders(bool onlyCompleted)
        {
            //Hide existing controls
            for (int i = 0; i < reminderTexts.Count; i++)
            {
                reminderTexts[i].Hide();
                Controls.Remove(reminderTexts[i]);
                setDates[i].Hide();
                Controls.Remove(setDates[i]);
                dueDates[i].Hide();
                Controls.Remove(dueDates[i]);
                completeds[i].Hide();
                Controls.Remove(completeds[i]);
            }
            //Make new controls
            formatRemindersWriteToLists(onlyCompleted);
            //Show new controls
            for (int i = 0; i < reminderTexts.Count; i++)
            {
                reminderTexts[i].Show();
                Controls.Add(reminderTexts[i]);
                setDates[i].Show();
                Controls.Add(setDates[i]);
                dueDates[i].Show();
                Controls.Add(dueDates[i]);
                completeds[i].Show();
                Controls.Add(completeds[i]);
            }
        }

        //Method to format reminder data and put it in relevant lists
        private void formatRemindersWriteToLists(bool onlyCompleted)
        {
            //Empty existing controls
            reminderTexts = new List<TextBox>();
            setDates = new List<TextBox>();
            dueDates = new List<TextBox>();
            completeds = new List<CheckBox>();
            //Add new controls
            int numShown = -1; //Used to index reminderTexts
            int foundCount = 0; //Used to count how many looped so that page can be displayed
            int minIndexShown; //Used to compare to only show allowed reminders
            int maxIndexShown; //Used to compare to only show allowed reminders
            //Calculate bounds to display
            if (onlyCompleted)
            {
                minIndexShown = (cCurrentPageNum - 1) * 30;
                maxIndexShown = cCurrentPageNum * 30;
            }
            else
            {
                minIndexShown = (ncCurrentPageNum - 1) * 30;
                maxIndexShown = ncCurrentPageNum * 30;
            }
            //Loop through reminders, show required
            for (int i = 0; i < reminders.Count; i++)
            {
                if (onlyCompleted)
                {
                    if (reminders[i].GetCompleted())
                    {
                        //If valid reminder (completed), increment
                        foundCount++;
                        //If index is within bounds, display
                        if (foundCount > minIndexShown && foundCount <= maxIndexShown)
                        {
                            //ReminderTexts
                            reminderTexts.Add(new TextBox());
                            numShown++;
                            reminderTexts[numShown].Text = reminders[i].GetText();
                            reminderTexts[numShown].Size = new Size(417, 20);
                            reminderTexts[numShown].Location = new Point(15, (58 + (numShown * 25)));
                            reminderTexts[numShown].ReadOnly = true;
                            reminderTexts[numShown].TabStop = false;
                            //SetDates
                            setDates.Add(new TextBox());
                            string tempSetDate = $"{reminders[i].GetSetDate().GetYear()}-{reminders[i].GetSetDate().GetMonth()}-{reminders[i].GetSetDate().GetDay()}";
                            setDates[numShown].Text = tempSetDate;
                            setDates[numShown].Size = new Size(106, 20);
                            setDates[numShown].Location = new Point(458, (58 + (numShown * 25)));
                            setDates[numShown].ReadOnly = true;
                            setDates[numShown].TabStop = false;
                            //DueDates
                            dueDates.Add(new TextBox());
                            string tempDueDate = $"{reminders[i].GetDueDate().GetYear()}-{reminders[i].GetDueDate().GetMonth()}-{reminders[i].GetDueDate().GetDay()}";
                            dueDates[numShown].Text = tempDueDate;
                            dueDates[numShown].Size = new Size(97, 20);
                            dueDates[numShown].Location = new Point(578, (58 + (numShown * 25)));
                            dueDates[numShown].ReadOnly = true;
                            dueDates[numShown].TabStop = false;
                            //Completeds
                            completeds.Add(new CheckBox());
                            completeds[numShown].Text = "";
                            if (reminders[i].GetCompleted())
                            {
                                completeds[numShown].Checked = true;
                            }
                            else
                            {
                                completeds[numShown].Checked = false;
                            }
                            completeds[numShown].Location = new Point(689, (57 + (numShown * 25)));
                            completeds[numShown].Name = i.ToString();
                            completeds[numShown].Click += new EventHandler(toggleCompleted);
                        }
                    }
                }
                else
                {
                    if (!reminders[i].GetCompleted())
                    {
                        //If valid reminder (non-completed), increment
                        foundCount++;
                        //If index is within bounds, display
                        if (foundCount > minIndexShown && foundCount <= maxIndexShown)
                        {
                            //ReminderTexts
                            reminderTexts.Add(new TextBox());
                            numShown++;
                            reminderTexts[numShown].Text = reminders[i].GetText();
                            reminderTexts[numShown].Size = new Size(417, 20);
                            reminderTexts[numShown].Location = new Point(15, (58 + (numShown * 25)));
                            reminderTexts[numShown].ReadOnly = true;
                            reminderTexts[numShown].TabStop = false;
                            //SetDates
                            setDates.Add(new TextBox());
                            string tempSetDate = $"{reminders[i].GetSetDate().GetYear()}-{reminders[i].GetSetDate().GetMonth()}-{reminders[i].GetSetDate().GetDay()}";
                            setDates[numShown].Text = tempSetDate;
                            setDates[numShown].Size = new Size(106, 20);
                            setDates[numShown].Location = new Point(458, (58 + (numShown * 25)));
                            setDates[numShown].ReadOnly = true;
                            setDates[numShown].TabStop = false;
                            //DueDates
                            dueDates.Add(new TextBox());
                            string tempDueDate = $"{reminders[i].GetDueDate().GetYear()}-{reminders[i].GetDueDate().GetMonth()}-{reminders[i].GetDueDate().GetDay()}";
                            dueDates[numShown].Text = tempDueDate;
                            dueDates[numShown].Size = new Size(97, 20);
                            dueDates[numShown].Location = new Point(578, (58 + (numShown * 25)));
                            dueDates[numShown].ReadOnly = true;
                            dueDates[numShown].TabStop = false;
                            //Completeds
                            completeds.Add(new CheckBox());
                            completeds[numShown].Text = "";
                            if (reminders[i].GetCompleted())
                            {
                                completeds[numShown].Checked = true;
                            }
                            else
                            {
                                completeds[numShown].Checked = false;
                            }
                            completeds[numShown].Location = new Point(689, (57 + (numShown * 25)));
                            completeds[numShown].Name = i.ToString();
                            completeds[numShown].Click += new EventHandler(toggleCompleted);
                        }
                    }
                }
            }
        }

        //Method to add new reminder to list from inputs
        private void addReminderFromInputs()
        {
            string newReminderText = tbNewReminder.Text;
            Date newDueDate = new Date(Convert.ToInt32(tbDueDay.Text), Convert.ToInt32(tbDueMonth.Text), Convert.ToInt32(tbDueYear.Text));
            DateTime currentDate = DateTime.Today;
            Date newSetDate = new Date(currentDate.Day, currentDate.Month, currentDate.Year);
            Reminder newReminder = new Reminder(false, newReminderText, newDueDate, newSetDate);
            reminders.Add(newReminder);
        }

        //Method to be run when "Create Reminder" button is run
        private void createReminder(object sender, EventArgs e)
        {
            addReminderFromInputs();
            calculateNumPages();
            if (!cbToggleDone.Checked)
            {
                if (ncCurrentPageNum < ncNumPages)
                {
                    btnPageUp.Enabled = true;
                }
            }
            displayReminders(cbToggleDone.Checked);
        }

        //Method to check whether all required inputs have been filled (with parameters)
        private void checkIfCreationInputsValidChangeButton(object sender, EventArgs e)
        {
            if (checkIfCreationInputsValidNoParam())
            {
                btnAddReminder.Enabled = true;
            }
            else
            {
                btnAddReminder.Enabled = false;
            }
        }

        //Method to check whether all required inputs have been filled (without parameters)
        private bool checkIfCreationInputsValidNoParam()
        {
            bool valid = true;
            if (tbNewReminder.Text == "" || tbDueDay.Text == "" || tbDueMonth.Text == "" || tbDueYear.Text == "")
            {
                valid = false;
            }
            try
            {
                Convert.ToInt32(tbDueDay.Text);
                Convert.ToInt32(tbDueMonth.Text);
                Convert.ToInt32(tbDueYear.Text);
            }
            catch (Exception ex)
            {
                valid = false;
            }
            return valid;
        }

        //Method to run when the program is closed
        private void exitProgram(object sender, FormClosingEventArgs e)
        {
            writeReminders();
        }

        //Method to run when a checkbox is toggled
        private void toggleCompleted(object sender, EventArgs e)
        {
            //Set type of sender
            CheckBox ckbx = sender as CheckBox;
            //Set completed status of reminder - get status, set as inverse
            reminders[Convert.ToInt32(ckbx.Name)].SetCompleted(!reminders[Convert.ToInt32(ckbx.Name)].GetCompleted());
            calculateNumPages();
            //Handle page num stuff
            if (cbToggleDone.Checked)
            {
                //Checks for whether page numbers has reduced and user was on last page
                if (cCurrentPageNum > cNumPages)
                {
                    cCurrentPageNum = cNumPages;
                }
                //Handles pageup button
                if (cCurrentPageNum == cNumPages)
                {
                    btnPageUp.Enabled = false;
                }
                else
                {
                    btnPageUp.Enabled = true;
                }
                //Handles pagedown button
                if (cCurrentPageNum == 1)
                {
                    btnPageDown.Enabled = false;
                }
                else
                {
                    btnPageDown.Enabled = true;
                }
                //Sets text
                tbPageNum.Text = cCurrentPageNum.ToString();
            }
            else
            {
                //Checks for whether page numbers has reduced and user was on last page
                if (ncCurrentPageNum > ncNumPages)
                {
                    ncCurrentPageNum = ncNumPages;
                }
                //Handles pageup button
                if (ncCurrentPageNum == ncNumPages)
                {
                    btnPageUp.Enabled = false;
                }
                else
                {
                    btnPageUp.Enabled = true;
                }
                //Handles pagedown button
                if (ncCurrentPageNum == 1)
                {
                    btnPageDown.Enabled = false;
                }
                else
                {
                    btnPageDown.Enabled = true;
                }
                //Sets text
                tbPageNum.Text = ncCurrentPageNum.ToString();
            }
            //Display reminders
            displayReminders(cbToggleDone.Checked);
        }

        //Method to run when cbToggleDone is toggled
        private void toggleShowCompleted(object sender, EventArgs e)
        {
            //Handle page num stuff
            if (cbToggleDone.Checked)
            {
                cCurrentPageNum = 1;
                if (cCurrentPageNum == cNumPages)
                {
                    btnPageUp.Enabled = false;
                }
                else
                {
                    btnPageUp.Enabled = true;
                }
                tbPageNum.Text = cCurrentPageNum.ToString();
            }
            else
            {
                ncCurrentPageNum = 1;
                if (ncCurrentPageNum == ncNumPages)
                {
                    btnPageUp.Enabled = false;
                }
                else
                {
                    btnPageUp.Enabled = true;
                }
                tbPageNum.Text = ncCurrentPageNum.ToString();
            }
            btnPageDown.Enabled = false;
            //Display reminders
            displayReminders(cbToggleDone.Checked);
        }

        //Method to calculate number of pages
        private void calculateNumPages()
        {
            //Declare and initialise variables
            int nonComplete = 0;
            int complete = 0;
            //Iterate through reminder list and find number of completeds and non-completeds
            for (int i = 0; i < reminders.Count; i++)
            {
                if (reminders[i].GetCompleted())
                {
                    complete++;
                }
                else
                {
                    nonComplete++;
                }
            }
            //Calculate number of pages for each
            cNumPages = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(complete / 30m)));
            ncNumPages = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(nonComplete / 30m)));
        }

        //Method to go to page up
        private void pageUp(object sender, EventArgs e)
        {
            //Handle case showing completed tasks
            if (cbToggleDone.Checked)
            {
                cCurrentPageNum++;
                //Handle increased page number
                if (cCurrentPageNum == cNumPages)
                {
                    btnPageUp.Enabled = false;
                }
                else if (cCurrentPageNum > cNumPages)
                {
                    cCurrentPageNum = cNumPages;
                }
                //Reenable PageDown button if needed
                if (!btnPageDown.Enabled)
                {
                    btnPageDown.Enabled = true;
                }
                //Set page number textbox
                tbPageNum.Text = cCurrentPageNum.ToString();
            }
            //Handle case of non-completed tasks
            else
            {
                ncCurrentPageNum++;
                //Handle increased page number
                if (ncCurrentPageNum == ncNumPages)
                {
                    btnPageUp.Enabled = false;
                }
                else if (ncCurrentPageNum > ncNumPages)
                {
                    ncCurrentPageNum = ncNumPages;
                }
                //Reenable PageDown button if needed
                if (!btnPageDown.Enabled)
                {
                    btnPageDown.Enabled = true;
                }
                //Set page number textbox
                tbPageNum.Text = ncCurrentPageNum.ToString();
            }
            displayReminders(cbToggleDone.Checked);
        }

        //Method to go to page down
        private void pageDown(object sender, EventArgs e)
        {
            //Handle case showing completed tasks
            if (cbToggleDone.Checked)
            {
                cCurrentPageNum--;
                //Handle decreased page number
                if (cCurrentPageNum == 1)
                {
                    btnPageDown.Enabled = false;
                }
                else if (cCurrentPageNum < 1)
                {
                    cCurrentPageNum = 1;
                }
                //Reenable PageUp button if needed
                if (!btnPageUp.Enabled)
                {
                    btnPageUp.Enabled = true;
                }
                //Set page number textbox
                tbPageNum.Text = cCurrentPageNum.ToString();
            }
            //Handle case of non-completed tasks
            else
            {
                ncCurrentPageNum--;
                //Handle increased page number
                if (ncCurrentPageNum == 1)
                {
                    btnPageDown.Enabled = false;
                }
                else if (ncCurrentPageNum < 1)
                {
                    ncCurrentPageNum = 1;
                }
                //Reenable PageUp button if needed
                if (!btnPageUp.Enabled)
                {
                    btnPageUp.Enabled = true;
                }
                //Set page number textbox
                tbPageNum.Text = ncCurrentPageNum.ToString();
            }
            displayReminders(cbToggleDone.Checked);
        }
    }
}

//TODO - ADD CHECK TO MAKE SURE ¶ CANNOT BE ENTERED
//TODO - ADD PROPER CHECKING FOR IF DATE ENTERED IS VALID
//TODO - ADD OPTIONAL TIME AND MAKE NOTIFS?
//TODO - ADD PRIORITIES/SORT BY?
//TODO - MAKE SCROLLING FOR WHEN TOO MANY REMINDERS (OR PAGE NUMS??)
//"soe mommy" deleted from chat