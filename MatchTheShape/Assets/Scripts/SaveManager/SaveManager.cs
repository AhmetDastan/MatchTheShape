using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

public class SaveManager : MonoBehaviour
{
    private PlayerScript playerScript;
    FileStream file;
    private void Awake()
    {
        playerScript = GameObject.FindObjectOfType<PlayerScript>();
    }

    public void Save()
    {
        playerScript.SendStatsToSaveFile();
        file = new FileStream(Application.persistentDataPath + "/Player.dat", FileMode.OpenOrCreate);
        try
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(file, playerScript.playerStats);
        }
        catch(SerializationException e)
        {
            Debug.Log("Save manager issue: " + e.Message);
        }
        finally
        {
            file.Close();
        }
    }

    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/Player.dat"))
        {

            file = new FileStream(Application.persistentDataPath + "/Player.dat", FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                playerScript.playerStats = (Stats)formatter.Deserialize(file);
            }
            catch (SerializationException e)
            {
                Debug.LogError("load manager issue " + e.Message);
            }
            finally
            {
                file.Close();
            }
            playerScript.TakeStatsFromSaveFile();
        }
    }

    public void ResetStats()
    {
        if(File.Exists(Application.persistentDataPath + "/Player.dat"))
        {
            try
            {
                File.Delete(Application.persistentDataPath + "/Player.dat");
            }
            catch (System.Exception ex)
            {
                Debug.LogException(ex);
            }
            finally
            {
                Debug.Log("Data deleted");
            }
        }
        else Debug.Log("There is no folder");
    }

}
