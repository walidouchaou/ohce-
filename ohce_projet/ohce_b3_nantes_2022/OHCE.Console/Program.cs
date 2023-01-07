using OHCE;
using OHCE.Console;
using OHCE.Langues;
using System.GLobalization


var ohce = new ohce(new SystemLang(), SystemTimePériodeJournéeAdapter.PériodeActuelle());

Console.writeLine(ohce.Salutation());
Console.writeLine(ohce.PalindromeDemande());
Console.writeLine(ohce.Palindrome(Console?ReadLine()?? string.Empty));
