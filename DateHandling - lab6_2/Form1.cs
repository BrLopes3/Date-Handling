using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DateHandling___lab6_2
{
    //Student - Bruno Lopes 
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime currentDate = DateTime.Now; //Struct that define the date
            DateTime inputDate; //input from the user
            TimeSpan intervalTime; //Struct used to find interval of time
            int intervalDays; //number of days of interval
            try
            {
                inputDate = DateTime.Parse(textBox1.Text.Trim()); //convert the string in the textbox into a date
                intervalTime = inputDate - currentDate; //calculate the interval of time
                intervalDays = intervalTime.Days; //convert the interval of time into days
                if(intervalDays > 0)
                {
                    MessageBox.Show($"Current Date: {currentDate.ToString("MM/dd/yyyy")}\n\nFuture Date: {inputDate.ToString("MM/dd/yyyy")}\n\nDays until due: {intervalDays}","Due Days Calculation");

                }
                else if(intervalDays == 0)
                {
                    MessageBox.Show("The due day is TODAY", "Due Days Calculation");
                }
                else
                {
                    MessageBox.Show($"The due day passed {-1*intervalDays} days ago", "Due Days Calculation");
                }

            }
            catch(Exception ex0)
            {
                MessageBox.Show(ex0.Message, "Date Error!");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime currentDate = DateTime.Today; //Struct that define the date today
            DateTime inputDate; //input from the user
            int yearOld; //variable for the age
            try
            {
                inputDate = DateTime.Parse(textBox2.Text.Trim());
                yearOld = currentDate.Year - inputDate.Year;

                //deal with the situation when the month of the aniversaty did't arrived yet
                if (currentDate.Month < inputDate.Month)
                {
                    yearOld = yearOld - 1;
                }

                //deal with the situation when the month of the aniversaty is the same but the day did't arrived yet
                else if (currentDate.Month == inputDate.Month && currentDate.Day > inputDate.Day)
                {
                    yearOld = yearOld - 1;
                }
                //deal with the situation when is the aniversary of the user
                else if (currentDate.Month == inputDate.Month && currentDate.Day == inputDate.Day)
                {
                    if (yearOld >= 18)
                    {
                        MessageBox.Show("Happy Birthday", "You can have a beer today!");
                        
                    }
                    else
                    {
                        MessageBox.Show("Happy Birthday!", "Enjoy your day!");
                    }
                }
                
                
                    MessageBox.Show($"Current Date: {currentDate.ToString("MM/dd/yyyy")}\n\nBirth Date: {inputDate.ToString("MM/dd/yyyy")}\n\nAge: {yearOld}", "Age Calculation");
                

            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.Message, "Date Error!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("All information will be lost. Are you sure to cancel and exit?", "Exit", MessageBoxButtons.YesNo,MessageBoxIcon.Question).ToString() == "Yes")
            {
                Close();
            }
        }
    }
}
