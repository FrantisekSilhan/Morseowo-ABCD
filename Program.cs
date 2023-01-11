using morseovka;
rumicek omegalul = new rumicek();

string encryptedString = omegalul.Encode("jak se máš nevim chobotnice");
Console.WriteLine(encryptedString);

Console.WriteLine(omegalul.Decode(encryptedString));
