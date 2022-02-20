using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_App1
{
    internal class Student
    {
        private string _id;
        private string _name;
        private string _major;
        private string _gpa;
        private double sum =0;
        private int n =0;
       
        public Student(string id,string name, string major,string gpa)
        {
            this._id = id;  
            this._name = name;  
            this._major = major;    
            this._gpa = gpa;
        }
        public string getId() { return _id; }
        public string getName() { return _name; }
        public string getMajor() { return _major;}
        public string getGpa() { return _gpa;}

 
    }
}
