﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace ClassLibraryCalculPret
{
    public class Pret
    {
        private string name;
        private int capital;
        private string periodicite;
        private int dureeEnMois;
        private double taux;



        private enum Periode
        {
            Mensuelle = 1,
            Bimestrielle = 2,
            Trimestrielle = 3,
            Semestrielle = 6,
            Annuelle = 12
        }

        /// <summary>
        /// -----------------------Les properties ----------------------------------------------
        /// </summary>
        public string Name { get => name; set => name = value; }
        public int Capital { get => capital; set => capital = value; }
        public string Periodicite { get => periodicite; set => periodicite = value; }
        public int DureeEnMois { get => dureeEnMois; set => dureeEnMois = value; }
        public double Taux { get => taux; set => taux = value; }





        /// <summary>
        /// Constructeur par défaut --------------------------------------------------------------
        /// </summary>
        public Pret()
        {
            Name = "";
            Capital = 00;
            Periodicite = Periode.Mensuelle.ToString();
            DureeEnMois = 1;
            Taux = 7;
        }




        /// <summary>
        /// Constructeur de la classe ------------------------------------------------------------------
        /// </summary>
        /// <param name="_name"></param>
        /// <param name="_capital"></param>
        /// <param name="_periodicite"></param>
        /// <param name="_dureeEnMois"></param>
        /// <param name="_taux"></param>
        public Pret(string _name, int _capital, string _periodicite, int _dureeEnMois, float _taux)
        {
            Name = _name;
            Capital = _capital;
            Periodicite = _periodicite;
            DureeEnMois = _dureeEnMois;
            Taux = _taux;
        }




        /// <summary>
        /// La méthode de calculer lenombre de remboursement ----------------------------------------------
        /// </summary>
        /// <param name="_periodicite"></param>
        /// <returns></returns>
        public int NombreDRemboursement()
        {
            return DureeEnMois / NombreDeMoisDePeriodicite();
        }




        /// <summary>
        /// La méthode de calculer le montante de remnoursement --------------------------------------
        /// </summary>
        /// <returns></returns>
        public string MontanDRemboursement()
        {
            double montant = Capital * (Taux / (1 - Math.Pow((1 + Taux), -NombreDRemboursement())));
            return montant.ToString("N") + "€";
        }


        

        /// <summary>
        /// La méthode de claculer le nombre de mois selon la périodicité -----------------------------
        /// </summary>
        /// <returns></returns>
        public int NombreDeMoisDePeriodicite()
        {
            int n;
            switch (this.Periodicite)
            {
                case "Mensuelle":
                    n = (int)Periode.Mensuelle;
                    break;
                case "Bimestrielle":
                    n = (int)Periode.Bimestrielle;
                    break;
                case "Trimestrielle":
                    n = (int)Periode.Trimestrielle;
                    break;
                case "Semestrielle":
                    n = (int)Periode.Semestrielle;
                    break;
                case "Annuelle":
                    n = (int)Periode.Annuelle;
                    break;
                default:
                    n = 1;
                    break;
            }
            return n;
        }
        public override string ToString()
        {
            return name + "-" + capital + "-" + periodicite + "-" + dureeEnMois + "-" + taux;
        }

    }
}