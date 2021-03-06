﻿using Caliburn.Micro;
using StageManager.Models;
using StageManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageManager.ViewModels
{
    class StageopdrachtViewModel : PropertyChanged, IExcelAlgorithm
    {
        private static Random random = new Random();
        private internships stage = new WStored().SearchStageSet()[random.Next(new WStored().SearchStageSet().Count)];

        internal internships Stage
        {
            get { return stage; }
            set
            {
                stage = WStored.StageManagerEntities.internships.Find(value.id);
                NotifyOfPropertyChange(() => StartDatum);
                NotifyOfPropertyChange(() => Bedrijfsbegeleider);
                NotifyOfPropertyChange(() => Docent);
                NotifyOfPropertyChange(() => EersteStudent);
                NotifyOfPropertyChange(() => EindDatum);
                NotifyOfPropertyChange(() => Omschrijving);
                NotifyOfPropertyChange(() => TweedeStudent);
            }
        }

        public void btnSave()
        {
            WStored.PushToDB();
        }

        private string startDatum;
        public string StartDatum
        {
            get { return stage.start_date.ToShortDateString(); }
            set
            {
                startDatum = value;
                NotifyOfPropertyChange(() => StartDatum);
            }
        }

        private string eindDatum;
        public string EindDatum
        {
            get { return stage.end_date.ToShortDateString(); }
            set
            {
                eindDatum = value;
                NotifyOfPropertyChange(() => EindDatum);
            }
        }

        private string feedback;
        public string Feedback
        {
            get { return stage.feedback; }
            set
            {
                feedback = value;
                NotifyOfPropertyChange(() => Feedback);
            }
        }

        private string goedgekeurd;
        public string Goedgekeurd
        {
            get 
            {
                switch (stage.approved)
                {
                    case "0":
                        return "In afwachting";
                    case "1":
                        return "Goedgekeurd";
                    case "2":
                        return "Wordt nagekeken";
                    case "3":
                        return "Niet goedgekeurd";
                    default:
                        return "Niet nagekeken";
                }
            }
            set
            {
                goedgekeurd = value;
                NotifyOfPropertyChange(() => Goedgekeurd);
            }
        }

        public string Omschrijving
        {
            get {  return stage.description; }
            set
            {
                stage.description = value;
                NotifyOfPropertyChange(() => Omschrijving);
            }
        }

        public string EersteStudent
        {
            get 
            {
                try
                {
                    return stage.students_internships.First().students.users.name + " " + stage.students_internships.First().students.users.surname;
                }
                catch (NullReferenceException)
                {
                    return "";
                }
            }
            set { }
        }

        public string TweedeStudent
        {
            get 
            {
                string teruggave = "";
                try
                {
                      teruggave = stage.students_internships.ElementAt(1).students.users.name + " " + stage.students_internships.ElementAt(1).students.users.surname; 
                }
                catch (Exception e)
                {
                    teruggave = "";
                }
                return teruggave;
            }
            set { }
        }

        public string Bedrijfsbegeleider
        {
            get
            {
                try
                {
                    return stage.supervisor.users.name + " " + stage.supervisor.users.surname;
                }
                catch (NullReferenceException)
                {
                    return "Geen BedrijfsBegeleider gekoppeld";
                }
            }
            set { }
        }

        public string Docent
        {
            get
            {
                try
                {
                    return stage.teachers1.users.name + " " + stage.teachers1.users.surname;
                }
                catch (NullReferenceException)
                {
                    return "";
                }
            }
            set { }
        }

        public StageopdrachtViewModel(MainViewModel main,PropertyChanged last)
            :base(main,last)
        {
        }

        public StageopdrachtViewModel(MainViewModel main,PropertyChanged last, internships stage)
            : this(main,last)
        {
            Stage = stage;
        }

        public override void update(object[] o)
        {
            try
            {
                Stage = (internships)o[2];
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public void btnExport_Click()
        {
            ExportExcel ee = new ExportExcel(this);
            ee.Export();
        }

        public void createWorksheet(Microsoft.Office.Interop.Excel.Worksheet worksheet)
        {
            worksheet.Cells[1, 1] = "StartDatum";
            worksheet.Cells[2, 1] = StartDatum;
            worksheet.Cells[1, 2] = "Bedrijfsbegeleider";
            worksheet.Cells[2, 2] = Bedrijfsbegeleider;
            worksheet.Cells[1, 3] = "Docent";
            worksheet.Cells[2, 3] = Docent;
            worksheet.Cells[1, 4] = "Eerste Student";
            worksheet.Cells[2, 4] = EersteStudent;
            worksheet.Cells[1, 5] = "Tweede Student";
            worksheet.Cells[2, 5] = TweedeStudent;
            worksheet.Cells[1, 6] = "Eind Datum";
            worksheet.Cells[2, 6] = EindDatum;
            worksheet.Cells[1, 7] = "Omschrijving";
            worksheet.Cells[2, 7] = Omschrijving;
        }
    }
}