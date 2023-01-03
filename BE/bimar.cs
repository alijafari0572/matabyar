 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
     public class bimar
    {
        public int id { get; set; }
        public int codesabt { get; set; }
        public string sex { get; set; }
        public string name { get; set; }
        public string family { get; set; }
        public string fathername { get; set; }
        public string codemeli { get; set; }
        public string mobile { get; set; }
        public string tell { get; set; }
        public string datesabt { get; set; }
        public string datetavlod { get; set; }
        public string age { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        ///اطلاعت شخصی تکمیلی
        public int height { get; set; }
        public int weight { get; set; }
        public string education { get; set; }
        public string singleormarried { get; set; }
        public int children { get; set; }
        ///اطلاعت تکمیلی
        public string bloodtype { get; set; }
        public bool blooddonation { get; set; }
        public string blooddonationdate { get; set; }
        public bool cupping { get; set; }//حجامت
        public string cuppingdate { get; set; }
        public bool alcohol_addiction { get; set; }
        public bool drug_addiction { get; set; }
        public bool smoke { get; set; }
        public string drug_addiction_what { get; set; }
        public bool allergies { get; set; }
        public string allergies_what { get; set; }
        public bool surgery { get; set; }
        public string surgery_what { get; set; }
        ///سوابق بیماری
        public bool heart_disease { get; set; }
        public bool blood_pressure { get; set; }
        public bool diabetes { get; set; }
        public bool hepatitis { get; set; }
        public bool epilepsy { get; set; }
        public bool drug_allergy { get; set; }
        public string drug_allergy_what { get; set; }
        public bool kidney_failure { get; set; }
        public bool liver_failure { get; set; }
        public bool lung_failure { get; set; }
        public bool thyroid_failure { get; set; }
        public bool gastrointestinal_insufficiency { get; set; }
        public bool While_taking_medicine { get; set; }
        public string While_taking_medicine_what { get; set; }
        public bool hospital_history { get; set; }
        public string hospital_history_what { get; set; }
        public bool pregnancy { get; set; }
        public string pregnancy_what { get; set; }
        public bool breastfeeding { get; set; }
        public string other_disease_what { get; set; }
        public List<pazireshbimar> pazireshbimars { get; set; } = new List<pazireshbimar>();
        public List<reservbimar> reservbimars { get; set; } = new List<reservbimar>();
        public List<tazrigh> tazrighs { get; set; } = new List<tazrigh>();
        //public int bime { get; set; }
        //public string shomarbime { get; set; }
        //public List<pezeshk> pezeshks { get; set; } = new List<pezeshk>();
    }
}
