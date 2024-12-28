using ContactsDataAccessLayer;
using System;
using System.Runtime.CompilerServices;

namespace ContactsBusinessLayer
{
    public class clsCountry
    {

        public enum enMode { AddNew = 0, Update = 1}
        enMode Mode = enMode.AddNew;
        public string CountryName { get; set; }
        public int CountryID { get; set; }


        private clsCountry(string countryName, int countryID)
        {
            this.CountryName = countryName;
            this.CountryID = countryID;

            Mode = enMode.Update;
        }

        private bool _AddNewCountry()
        {
            this.CountryID = clsCountryData.AddNewCountry(this.CountryName);
            return (this.CountryID != -1);
        }

        private bool _UpdateCountry()
        {
            return clsCountryData.UpdateCountry(this.CountryID, this.CountryName);
        }

        public clsCountry()
        {
            this.CountryID = -1;
            this.CountryName = "";
            Mode = enMode.AddNew;
        }
        public static clsCountry FindByName(string CountryName)
        {
             int CountryID = -1;

            if (clsCountryData.FindCountryByName(CountryName, ref CountryID))
            {
                return new clsCountry(CountryName, CountryID);
            }
            else
                return null;
        }

        public static bool IsCountryExist(string CountryName)
        {
            return clsCountryData.IsCountryExist(CountryName);         
        }

        public static clsCountry FindByID(int id)
        {
            string name = "";

            if (clsCountryData.FindCountryByID(id, ref name))
            {
                return new clsCountry(name, id);
            }
            else
                return null;
        }
        public static bool IsCountryExistByID(int id)
        {
            return clsCountryData.IsCountryExistByID(id);
        }

        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                {
                    if (_AddNewCountry())
                    {
                        Mode = enMode.Update;
                            return true;
                    }
                    else
                            return false;
                }
                case enMode.Update:
                    {
                        if (_UpdateCountry())
                        {
                            return true;
                        }
                        else
                            return false;
                    }
                
            }

            return false;
        }

        
    }
}
