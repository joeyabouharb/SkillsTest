using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JosephAbouharbTest
{
    public class MyProperty_
    {
        //statics 
       
        public static string[] Numbers = { "PET1", "STA1", "STA2", "PET2" };
        public static string[] Suburbs = { "Petersham", "Stanmore", "Stanmore", "Petersham" };
        public static int[] BedroomNums = { 1, 3, 2, 2 };
        public static double[] Rents = { 160, 240, 70, 190 };
        public static string[] Statuses = { "New", "Renovated", "Old", "Renovated" };
        //fields
        private string propertyNumber;
        private string propertySuburb;
        private int propertyBedroomNum;
        private double propertyRent;
        private string propertyStatus;

        //properties
        public string PropertyNumber
        {
            get
            {
                return propertyNumber;
            }

            set
            {
                propertyNumber = value;
            }
        }

        public string PropertySuburb
        {
            get
            {
                return propertySuburb;
            }

            set
            {
                propertySuburb = value;
            }
        }

        public string PropertyStatus
        {
            get
            {
                return propertyStatus;
            }

            set
            {
                propertyStatus = value;
            }
        }

        public double PropertyRent
        {
            get
            {
                return propertyRent;
            }

            set
            {
                propertyRent = value;
            }
        }

        public int PropertyBedroomNum
        {
            get
            {
                return propertyBedroomNum;
            }

            set
            {
                propertyBedroomNum = value;
            }
        }

        //constructors
        public MyProperty_()
        {

        }

        public MyProperty_(string propertyNumber, string propertySuburb, int propertyBedroomNum, double propertyRent, string propertyStatus)
        {
            this.propertyNumber = propertyNumber;
            this.propertySuburb = propertySuburb;
            this.PropertyBedroomNum = propertyBedroomNum;
            this.PropertyRent = propertyRent;
            this.propertyStatus = propertyStatus;

        }

        //Methods

        public string PrintInfo()
        {
            string msg = "";
            msg += propertyNumber + ", " + propertySuburb + ", " + PropertyBedroomNum + ", " +
                   PropertyRent.ToString("C") + ", " + propertyStatus + "\n";
            return msg;
        }
    }
}
