using System;
using System.Data;
using ContactsDataAccessLayer;

namespace ContactsBusinessLayer
{
    public class clsContact
    {
       public enum enMode { AddNew = 0, Update = 1}
       public enMode Mode = enMode.AddNew;
        public int ID { get; set; }
        public string firstName{ get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string addresse { get; set; }
        public int countrayID { get; set; }

        public string ImagePath { get; set; }
        private clsContact(int ID, string firstname, string lastname,
              string email, string phone, int countrayID, string adresse, string imagePaht)
        {
            this.ID = ID;
            this.firstName = firstname;
            this.lastname = lastname;
            this.email = email;
            this.phone = phone;
            this.countrayID = countrayID;
            this.addresse = adresse;
            this.ImagePath = imagePaht;

            Mode = enMode.Update;
        }
        public clsContact()
        {
            this.ID = -1;
            this.firstName = "";
            this.lastname = "";
            this.email = "";
            this.phone = "";
            this.countrayID = -1;
            this.addresse = "";
            this.ImagePath = "";

            Mode = enMode.AddNew;
        }
        private bool _AddNewContact()
        {
            //call DataAccess Layer 

            this.ID = clsContactData.AddNewContact(this.firstName, this.lastname, this.email, this.phone
               , this.countrayID, this.addresse,this.ImagePath);

            return (this.ID != -1);
        }
        private bool _UpdateContact()
        {
            return clsContactData.UpdateContact(this.ID, this.firstName, this.lastname,
                 this.email, this.phone, this.countrayID, this.addresse,this.ImagePath);
        }
        public static clsContact Find(int ID)
        {
            string firstname = ""; string lastname = ""; string email = "";
            string phone = ""; string adresse = ""; int countrayID = -1; string ImagePath ="";
            
            if (clsContactData.GetContactByID(ID,ref firstname,
                ref lastname, ref email, ref phone, ref countrayID, ref adresse, ref ImagePath))
            {
                return new clsContact(ID, firstname, lastname,
                    email, phone, countrayID, adresse, ImagePath);
            }
            else
                return null;
        }

        public static bool DeleteContact(int ID)
        {
            return clsContactData.DeleteContact(ID);
        }

        public static DataTable GetAllContact()
        {
            return clsContactData.GetAllContact();

        }

        public static bool IsContactExist(int ID)
        {
            return clsContactData.IsContactExist(ID);
        }

        public bool Save()
        {
            switch(Mode)
            {
                    case enMode.AddNew:
                    {
                        if (_AddNewContact())
                        {
                            Mode = enMode.Update;
                            return true;
                        }
                        else
                            return false;
                    }

                case enMode.Update:
                    if (_UpdateContact())
                    {
                        return true;
                    }
                    else
                        return false;
            }

            return false;
        }

        
    }

   
}
