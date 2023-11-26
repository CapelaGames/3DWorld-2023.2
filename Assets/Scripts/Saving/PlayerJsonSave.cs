using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Net;

public static class PlayerJsonSave
{
    public static string file = Application.dataPath + "/playersave.json";

    public static void Save(PlayerData data)
    {
        if (Directory.Exists(Application.dataPath))
        {
            string json = JsonUtility.ToJson(data);

            File.WriteAllText(file, json);
        }
    }

    public static PlayerData Load()
    {
        if (File.Exists(file))
        {
            string json = File.ReadAllText(file);

            return JsonUtility.FromJson<PlayerData>(json);
        }
        else
        {
            return null;
        }
    }
}
