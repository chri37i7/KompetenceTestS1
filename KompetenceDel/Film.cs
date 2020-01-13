using System;
using System.Collections.Generic;
using System.Text;

namespace KompetenceDel
{
    class Film
    {
        // En film består af titel, udgivelsesår, instruktør og filmselskab.
        // Fields
        private string filmTitle;
        private int filmYear;
        private string filmInstructor;
        private string filmCompany;

        // Constructor
        public Film(string filmTitle, int filmYear, string filmInstructor, string filmCompany)
        {
            FilmTitle = filmTitle;
            FilmYear = filmYear;
            FilmInstructor = filmInstructor;
            FilmCompany = filmCompany;
        }

        // Properties
        public string FilmTitle
        {
            get
            {
                return filmTitle;
            }
            set
            {
                filmTitle = value;
            }
        }
        public int FilmYear
        {
            get
            {
                return filmYear;
            }
            set
            {
                filmYear = value;
            }
        }
        public string FilmInstructor
        {
            get
            {
                return filmInstructor;
            }
            set
            {
                filmInstructor = value;
            }
        }
        public string FilmCompany
        {
            get
            {
                return filmCompany;
            }
            set
            {
                filmCompany = value;
            }
        }
    }
}