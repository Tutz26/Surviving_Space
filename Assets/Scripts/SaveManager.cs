using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveManager
{

    //Save information in player data 
    public static void Save(PlayerController playerController)
        {

            BinaryFormatter formatter = new BinaryFormatter();
            string filePath = Application.persistentDataPath + "/Spooky.scary";
            FileStream stream = new FileStream(filePath, FileMode.Create);
    
            PlayerData playerData = new PlayerData(playerController);

            formatter.Serialize(stream, playerData);
            stream.Close();
        }


     //Load information to player Data.
    public static PlayerData Load() 
        {
            string filePath = Application.persistentDataPath + "/Spooky.scary";

            if (File.Exists(filePath))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(filePath, FileMode.Open);

                PlayerData data = formatter.Deserialize(stream) as PlayerData;
                stream.Close();

                return data;
            }
            else
            {
                Debug.LogError("File not found " + filePath);
                return null;
            }

        }
}