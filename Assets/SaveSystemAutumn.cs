using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystemAutumn
{
    public static void SavePlayer(PlayerControlAutumn player)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/playerAutumn.fungame";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerDataAutumn data = new PlayerDataAutumn(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerDataAutumn LoadPlayer()
    {
        string path = Application.persistentDataPath + "/playerAutumn.fungame";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerDataAutumn data = formatter.Deserialize(stream) as PlayerDataAutumn;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file tidak ada pada " + path);
            return null;
        }
    }
}
