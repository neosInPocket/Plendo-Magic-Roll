using System.IO;
using UnityEngine;

public class SavingManager : MonoBehaviour
{
    [SerializeField] private bool reset;
    private static string jsonFilePath => Application.persistentDataPath + "/SavingsManagerData.json";
    public static SavingManagerData Manager { get; private set; }

    private void Awake()
    {
        if (reset)
        {
            Manager = new SavingManagerData();
            Save();
        }
        else
        {
            LoadData();
        }
    }

    public static void Save()
    {
        if (!File.Exists(jsonFilePath))
        {
            LoadNewDataFile();
        }
        else
        {
            SetDataFile();
        }
    }

    public static void LoadData()
    {
        if (!File.Exists(jsonFilePath))
        {
            LoadNewDataFile();
        }
        else
        {
            string text = File.ReadAllText(jsonFilePath);
            Manager = JsonUtility.FromJson<SavingManagerData>(text);
        }
    }

    private static void LoadNewDataFile()
    {
        Manager = new SavingManagerData();
        File.WriteAllText(jsonFilePath, JsonUtility.ToJson(Manager));
    }

    private static void SetDataFile()
    {
        File.WriteAllText(jsonFilePath, JsonUtility.ToJson(Manager));
    }
}
