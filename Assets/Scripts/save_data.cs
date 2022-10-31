using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class save_data
{
    public static string[] names = new string[10];
    public static int[] score = new int[10];
}

public class saveLoad { 
    
    public static void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        using (FileStream fs = new FileStream("skorkayit.bin", FileMode.Create, FileAccess.Write))
        {
            bf.Serialize(fs, save_data.names);
            bf.Serialize(fs, save_data.score);
        }
    }

    public static void Load()
    {
        if (!File.Exists("skorkayit.bin"))
            return;

        BinaryFormatter bf = new BinaryFormatter();
        using (FileStream fs = new FileStream("skorkayit.bin", FileMode.Open, FileAccess.Read))
        {
            save_data.names = (string[])bf.Deserialize(fs);
            save_data.score = (int[])bf.Deserialize(fs);
        }
    }
}
