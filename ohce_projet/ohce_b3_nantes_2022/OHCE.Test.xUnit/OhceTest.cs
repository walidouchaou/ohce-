using OHCE.Langues;
using OHCE.Test.xUnit.Utilities;
using OHCE.Test.xUnit.Utilities.Builders;

namespace OHCE.Test.xUnit;

public class OhceTest
{
    [Fact(DisplayName = 
        "QUAND on entre une chaîne de caractères " +
        "ALORS elle est renvoyée en miroir")]
    public void MiroirTest()
    {
        var ohce = OhceBuilder.Default;

        // QUAND on entre une chaîne de caractère
        var sortie = ohce.Palindrome("toto");

        // ALORS elle est renvoyée en miroir
        Assert.Contains("otot", sortie);
    }

    [Theory(DisplayName = "ETANT DONNE un utilisateur parlant une langue" +
                          "QUAND on entre un palindrome " +
                          "ALORS il est renvoyé " +
                          "ET le <bienDit> de cette langue est envoyé")]
    [MemberData(nameof(LanguesSeules))]
    public void PalindromeTest(ILangue langue)
    {
        // ETANT DONNE un utilisateur parlant <langue>
        var ohce = new OhceBuilder()
            .AyantPourLangue(langue)
            .Build();

        // QUAND on entre un palindrome
        const string palindrome = "kayak";
        var sortie = ohce.Palindrome(palindrome);

        // ALORS il est renvoyé
        // ET <bienDit> en <langue> est envoyé
        Assert.Contains(
            palindrome + langue.BienDit, 
            sortie);
    }

    private static readonly IEnumerable<ILangue> Langues = new ILangue[]
    {
        new LangueAnglaise(), 
        new LangueFrançaise()
    };

    private static readonly IEnumerable<PériodeJournée> Périodes = new PériodeJournée[]
    {
        PériodeJournée.Matin, 
        PériodeJournée.AprèsMidi, 
        PériodeJournée.Soir, 
        PériodeJournée.Nuit, 
        PériodeJournée.Defaut
    };

    public static IEnumerable<object[]> LanguesSeules => new CartesianData(Langues);
    public static IEnumerable<object[]> LanguesEtPériodes => new CartesianData(Langues, Périodes);

    [Theory(DisplayName = "ETANT DONNE un utilisateur parlant une langue" +
                          "ET que la période de la journée est <période>" +
                          "QUAND l'app démarre " +
                          "ALORS <bonjour> de cette langue à cette période est envoyé")]
    [MemberData(nameof(LanguesEtPériodes))]
    public void DémarrageTest(ILangue langue, PériodeJournée période)
    {
        // ETANT DONNE un utilisateur parlant une langue
        // ET que la période de la journée est <période>
        var ohce = new OhceBuilder()
            .AyantPourLangue(langue)
            .AyantPourPériodeDeLaJournée(période)
            .Build();

        // QUAND l'app démarre
        var sortie = ohce.Palindrome(string.Empty);

        // ALORS <bonjour> de cette langue à cette période est envoyé
        Assert.StartsWith(langue.DireBonjour(période), sortie);
    }

    [Theory(DisplayName = "ETANT DONNE un utilisateur parlant une langue" +
                          "QUAND l'app se ferme " +
                          "ALORS <auRevoir> dans cette langue est envoyé")]
    [MemberData(nameof(LanguesSeules))]
    public void FermetureTest(ILangue langue)
    {
        // ETANT DONNE un utilisateur parlant une langue
        var ohce = new OhceBuilder()
            .AyantPourLangue(langue)
            .Build();

        // QUAND l'app démarre
        var sortie = ohce.Palindrome(string.Empty);

        // ALORS <auRevoir> dans cette langue est envoyé
        Assert.EndsWith(langue.AuRevoir, sortie);
    }
}