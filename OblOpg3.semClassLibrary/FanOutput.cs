using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FanOutputLibrary
{
    public class FanOutput
    {

        //Properties
        private string _navn;
        private int _temp;
        private int _fugt;

        public int Id { get; set; }

        public string Navn
        {
            get => _navn;
            set => _navn = TestNavnLength(value);
        }

        public int Temp
        {
            get => _temp;
            set => _temp = TestTempValue(value);
        }

        public int Fugt
        {
            get => _fugt;
            set => _fugt = TestFugtValue(value);
        }

        //Constructors
        public FanOutput(string navn, int temp, int fugt)
        {
            Navn = navn;
            Temp = temp;
            Fugt = fugt;
        }

        public FanOutput()
        {
            
        }

        //Method to check that the Navn property is at least 2 characters long
        public string TestNavnLength(string navnString)
        {
            if (navnString.Length < 2)
            {
               throw new ArgumentException("Navn skal minimum være på 2 karakterer"); 
            }
            else
            {
                return navnString;
            }
        }

        //Method to check that the Temp value is within the allowed values
        public int TestTempValue(int tempValue)
        {
            if (tempValue < 15)
            {
                throw new ArgumentException("Temperaturen er for lav");
            }
            else if (tempValue > 25)
            {
                throw new ArgumentException("Temperaturen er for høj");
            }
            else
            {
                return tempValue;
            }
        }

        //Method to check that the fugt value is within the allowed values
        public int TestFugtValue(int fugtValue)
        {
            if (fugtValue < 30)
            {
                throw new ArgumentException("Fugtigheden er for lav");
            }
            else if (fugtValue > 80)
            {
                throw new ArgumentException("Fugtigheden er for høj");
            }
            else
            {
                return fugtValue;
            }
        }
    }
}
