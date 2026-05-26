using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Programming
{
    public class CrewMember
    {
        private string snp;
        protected string profession;
        private int age;
        private int term_of_work;

        public CrewMember() : this("Unknown", "Unknown", 0, 0) { }

        public CrewMember(string Snp, string proffesion, int age0, int Term)
        {
            SNP = Snp;
            Proffession = proffesion;
            Age = age0;
            Term_of_work = Term;
        }
        public void Change_profession(string profession)
        {
            Proffession = profession;
        }
        public string Proffession
        {
            get { return profession; }
            set
            {
                profession = value;
            }
        }
        public int Age
        {
            get { return age; }
            set
            {
                if (value < 16)
                {
                    throw new ArgumentException("Age can't be lesser than 16");
                }
                age = value;
            }

        }
        public int Term_of_work
        {
            get { return term_of_work; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The term of the work can't be negative");
                }
            }
        }
        public string SNP
        {
            get { return snp; }
            set
            {
                snp = value;
            }
        }

    }
}
