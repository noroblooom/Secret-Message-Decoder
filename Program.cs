using System;

class Program
{
    static void Main()
    {
        var decoder = new SecretMessageDecoder();
        decoder.DecodeFromTextFile("hello.txt");
    }
}