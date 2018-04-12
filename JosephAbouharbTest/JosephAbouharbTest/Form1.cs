using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JosephAbouharbTest
{
    public partial class Form1 : Form
    {
        //declare our property object array
        MyProperty_[] myProperties = new MyProperty_[10];
        //constant that refers to the first 4 porperty info to be inserted into arr
         const int INSERTEDPROPERTIES = 4;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            //insert data
            string propertyNumber = txtPropertyNo.Text;
            string propertySuburb = txtSuburb.Text;
            int propertyBedroomNum = int.Parse(txtBedroomNum.Text);
            double propertyRent = double.Parse(txtRent.Text);
            string propertyStatus = (string)txtStatus.SelectedItem;

            //clear textboxes
            txtBedroomNum.Clear();
            txtPropertyNo.Clear();
            txtRent.Clear();
            txtSearchBy.Clear();
            txtStatus.SelectedIndex = -1;
            txtSuburb.Clear();

            //insert data into constructor
            MyProperty_ myProperty = new MyProperty_(propertyNumber, propertySuburb,
                                     propertyBedroomNum, propertyRent, propertyStatus);
            //insert data into an array and return a bool apon completion
            bool InsertInto = CanBeInsertedIntoArr(myProperty);
            if(InsertInto == false)
            {
                MessageBox.Show("Array Is Full. Can Not Save Property Details");
                return;
            }
            MessageBox.Show("Property Details inserted");
        
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //get user input
            string searchByPropertyNum = txtSearchBy.Text;
         
            //return a valid index apon success on search
            int index = SearchByPropertyNum(searchByPropertyNum);

            //clear textboxes
            txtSearchBy.Clear();

            //let -1 be an error msg
            if ( index == -1)
            {
                MessageBox.Show("Property Does not Exist");
                txtSearchBy.Focus();
                return;
            }
            //output relevant info
            MessageBox.Show("property Details are: " + myProperties[index].PrintInfo());
            txtSearchBy.Focus();
        }

       private int SearchByPropertyNum(string searchByPropertyNum)
        {
            for(int i = 0; i < myProperties.Length; i++)
            {
                if(myProperties[i] == null)
                {
                    //return an invalid number
                    return -1;
                }

                if(myProperties[i].PropertyNumber == searchByPropertyNum)
                {
                    //return index
                    return i;
                }

            }
            return -1;
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            //display all details
            MessageBox.Show(DispayAllProperties());
           

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //lets insert  stored data array apon form load
            for(int i = 0; i < INSERTEDPROPERTIES; i++)
            {
                //point to constructor and insert data 
                MyProperty_ myProperty = new MyProperty_(MyProperty_.Numbers[i], MyProperty_.Suburbs[i],
                    MyProperty_.BedroomNums[i], MyProperty_.Rents[i] ,MyProperty_.Statuses[i]);
                //point to the method to store the info into the array
                bool isInserted = CanBeInsertedIntoArr(myProperty);


            }
        }

        private bool CanBeInsertedIntoArr(MyProperty_ myProperty)
        {
            
            for(int i = 0; i < myProperties.Length; i++)
            {
                //enter data where array index is null
                if(myProperties[i] == null)
                {
                    myProperties[i] = myProperty;
                    return true;
                }
            }
            return false;
        }

        private string DispayAllProperties()
        {
            string msg = "";
            for(int i = 0; i < myProperties.Length; i++)
            {
                //stop loop if array at current index is null to avoid errors
                if(myProperties[i] == null)
                {
                    return msg;
                }
                //output data into string
                msg += myProperties[i].PrintInfo();

            }
            //return string upon completion
            return msg;
        }

        private void btnAvg_Click(object sender, EventArgs e)
        {
            //point to the method that calculates the avg
            double avgRent = CalcAvgRent();

            MessageBox.Show("Average Rent: " + avgRent.ToString("C"));
        }

        private double CalcAvgRent()
        {
            double sumOfRent = 0;
            //int to determine what to divide the sum by
            int i = 0;
            //loop to get sum
            for (i = 0; i < myProperties.Length; i++)
            {
                if(myProperties[i] == null)
                {
                    break;
                }
                sumOfRent += myProperties[i].PropertyRent;
            }
            //get the average by division and output the result
            double avgRent = sumOfRent / i;
            return avgRent;
        }
    }
}
