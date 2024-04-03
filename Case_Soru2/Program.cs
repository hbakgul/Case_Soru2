using ConsoleApp1.Class;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

public class Sample
{
    protected static int row;
    protected static int col;


    public static void Main()
    {
        //Json dosyamızı getiriyoruz.
        string jsonData = File.ReadAllText(@"json/response.json");

        //Json dosyasınına uygun sınıfı oluşturup listeye çeviriyoruz
        List<JsonClass> list = JsonConvert.DeserializeObject<List<JsonClass>>(jsonData);

        //Console ekranını temizleyip, ardından üst ve sol koordinatları kaydediyoruz.
        Console.Clear();
        row = Console.CursorTop;
        col = Console.CursorLeft;

        //Json dosyasındaki ilk elemanı alıp konsola yazdırıyoruz.
        WriteAt(list[0].description, 0, 1);

        //*Açıkcası x,y koordinatında ilgiili descriptionları yazdırmak gerektiğini düşünmüştüm.
        //İstediğiniz asıl şey bu değilmiş:) Aşağıdaki yorum satırındaki kodlar, sadece
        //parse edilmiş json'u bu şekilde kullanabiliriz gibi bir örnek olarak yorum satırında
        //kalabilir diye düşündüm.*//

        //for (int i = 1; i < list.Count; i++)
        //{
        //    for (int j = 0; j < list[i].boundingPoly.vertices.Count; j++)
        //    {
        //        var desc = list[i].description;
        //        var x = list[i].boundingPoly.vertices[j].x;
        //        var y = list[i].boundingPoly.vertices[j].y;
        //        WriteAt(desc, x, y);
        //    }

        //}

        Console.WriteLine();

    }
    protected static void WriteAt(string s, int x, int y)
    {
        try
        {
            Console.SetCursorPosition(col + x, row + y);
            Console.Write(s);
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.Clear();
            Console.WriteLine(e.Message);
        }
    }

}
