using System;
using System.Collections.Generic;

namespace CatWorx.BadgeMaker
{
    class Employee 
    {
        private string FirstName;
        private string LastName;
        private int Id;
        public string PhotoUrl;

        public Employee(string firstName, string lastName, int id, String photoUrl){
            FirstName = firstName;
            LastName = lastName;
            Id = id;
            PhotoUrl = photoUrl;
        }

        public string GetFullName() {
            return FirstName + " " + LastName;
        }

        public int GetId(){
            return Id;
        }

        public string GetPhotoUrl(){
            return PhotoUrl;
        }
    }
}