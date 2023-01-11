// See https://aka.ms/new-console-template for more information
using morseovka;

Console.WriteLine("Hello, World!");
rumicek omegalul = new rumicek();

string encryptedString = omegalul.Encode("jak se máš?");
Console.WriteLine(encryptedString);
Console.WriteLine(omegalul.Decode(encryptedString));
