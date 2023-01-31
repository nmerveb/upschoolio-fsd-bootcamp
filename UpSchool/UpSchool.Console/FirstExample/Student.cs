using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace UpSchool.Console.FirstExample
{
    //:---> kalitimi gostermek icin kullaniriz.
    public class Student : PersonBase, ITurkishPerson, IAge
    {
        public int SchoolNumber { get; set; }
        #region Iyilestirme oncesi
        //public int Score1 { get; set; }
        //public int Score2 { get; set; }
        //public int Score3 { get; set; }
        //public int FinalNotes => (Score1 + Score2 + Score3) / 3;

        //private int TotalScore() { return Score1 + Score2 + Score3; }
        #endregion

        public List<int> Scores { get; set; }
        public string TCID { get; set; } //interface icinde tanimladigimiz alanlari implemente ettigimiz siniflarda da tanimlamamiz gerekir, base siniflar icin bu gecerli degildir.
        public string GovermentId { get; set; }
        public int Age { get; set; }
        //lamda kullandigimizda ilgili propertynin setterini kaldirmis oluruz.
        //public string FullName => $"{SchoolNumber} {FirstName} {LastName}";

        public string FullName
        {
            get// student.FullName --> bu sekilde property cagirdigimizda da get fonk sonucunu bize doner.
            {
                return $"{SchoolNumber} {FirstName} {LastName}";
            }
            set //student.FullName = "atama degeri" --> bu sekilde atama yaptigimiz yerler ilgili property'nin setterini calistirir.
            {
                value = $"Sampiyon {FirstName} {LastName}";
            }
        }

        #region Getter example
        //public string FullName { 
        //    get
        //    { 
        //        if(string.IsNullOrEmpty(FirstName)) //Empty= ""
        //        {
        //            return "Isimsiz";
        //        }
        //        return $"{FirstName} {LastName}"; 
        //    }
        // }
        #endregion

        //disaridanb erisilmesini istemedigimiz propertyleri  private tanimlariz
        private int TotalScore() 
        {
            var totalScore = 0;
            foreach(var score in Scores)
            {
                totalScore+= score;
            }    
            return totalScore/Scores.Count;
        }

        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
