using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public static class Saver
{
    public static List<GameData> savedGames = new List<GameData>();


    public static void Save()
    {
        Saver.savedGames.Add(GameData.current);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + Path.DirectorySeparatorChar + "savedGames.gd");
        bf.Serialize(file, Saver.savedGames);
        file.Close();
    }

    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + Path.DirectorySeparatorChar + "savedGames.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + Path.DirectorySeparatorChar + "savedGames.gd", FileMode.Open);
            Saver.savedGames = (List<GameData>)bf.Deserialize(file);
            file.Close();
        }

    }
}
