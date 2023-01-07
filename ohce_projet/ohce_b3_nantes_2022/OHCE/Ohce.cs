using System.Text;

namespace OHCE;

public class Ohce
{
    private readonly ILangue _langue;
    private readonly PériodeJournée _périodeJournée;

    public Ohce(ILangue langue, PériodeJournée périodeJournée)
    {
        _langue = langue;
        _périodeJournée = périodeJournée;
    }

    public string Salutation (){
        return _langue.DireBonjour(_périodeJournée)
    }
    public string PalindromeDemande(){
        return _langue.PalindromeDemande
    }

    public string Palindrome(string input)
    {
        var stringBuilder = 
            new StringBuilder(_langue.DireBonjour(_périodeJournée));

        var reversed = new string(
            input.Reverse().ToArray()
        );

        stringBuilder.Append(reversed);

        if (reversed.Equals(input))
            stringBuilder.Append(_langue.BienDit);

        stringBuilder.Append(_langue.AuRevoir);

        return stringBuilder.ToString();
    }
}