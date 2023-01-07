using OHCE.Langues;
using System.Globalization;

namespace OHCE.Console
{
    internal class SystemLang : ILangue
    {

        public string BienDit => BienDitValue();
        
        /// <inheritdoc />
        public string DireBonjour(PériodeJournée période)
        {
            if (locallangue == "fr-FR")
            {
                return période == PériodeJournée.Soir
                ? Expressions.Français.Bonsoir
                : Expressions.Français.Bonjour;
            }
            else if (locallangue == "en-US")
            {
                return période == PériodeJournée.Soir
                ? Expressions.English.AuRevoir
                : Expressions.English.Bonjour;
            }
            else
            {
                return période == PériodeJournée.Soir
                ? Expressions.Français.Bonsoir
                : Expressions.Français.Bonjour;
            }

        }

        /// <inheritdoc />
        public string AuRevoir => AuRevoirValue();





        public string PalindromeDemande => PalindromeDemandeValue();

        private string locallangue = CultureInfo.CurrentCulture.Name;

        private string BienDitValue()
        {
            if (locallangue == "fr-FR")
            {
                return Expressions.Français.BienDit;
            }
            else if (locallangue == "en-US")
            {
                return Expressions.English.BienDit;
            }
            else
            {
                return Expressions.Français.BienDit;
            }
        }

        private string AuRevoirValue()
        {
            if (locallangue == "fr-FR")
            {
                return Expressions.Français.AuRevoir;
            }
            else if (locallangue == "en-US")
            {
                return Expressions.English.AuRevoir;
            }
            else
            {
                return Expressions.Français.AuRevoir;
            }
        }

        private string PalindromeDemandeValue()
        {
            if (locallangue == "fr-FR")
            {
                return Expressions.Français.PalindromeDemande;
            }
            else if (locallangue == "en-US")
            {
                return Expressions.English.PalindromeDemande;
            }
            else
            {
                return Expressions.Français.PalindromeDemande;
            }
        }
    }
}