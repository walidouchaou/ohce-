using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


namespace OHCE.Console
{
    internal class SystemTime
    {
        public static PériodeJournée PériodeActuelle()
        {
            int heure = DateTime.Now.Hour;

            if (heure >= 6 && heure <= 12)
            {
                return PériodeJournée.Matin;
            }
            else if (heure > 12 && heure <= 17)
            {
                return PériodeJournée.AprèsMidi;
            }
            else if (heure > 17 && heure <= 22)
            {
                return PériodeJournée.Soir;
            }
            else if (heure > 22 && heure < 6)
            {
                return PériodeJournée.Nuit;
            }
            return PériodeJournée.Defaut;
            
        }
    }
}