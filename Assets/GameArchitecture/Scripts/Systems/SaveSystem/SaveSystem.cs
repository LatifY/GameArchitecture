using System.IO;
using UnityEngine;

public static class SaveSystem {

    private static readonly string SAVE_FOLDER = Application.dataPath + "/Saves/";
    private const string SAVE_EXTENSION = ".txt";

    public static void Init() {
        // Test if Save Folder exists
        if (!Directory.Exists(SAVE_FOLDER)) {
            // Create Save Folder
            Directory.CreateDirectory(SAVE_FOLDER);
        }
    }

    public static void Save(string saveString) {
        File.WriteAllText(SAVE_FOLDER + "data" +SAVE_EXTENSION, saveString);
    }

    public static string Load() {
        string saveString = File.ReadAllText(SAVE_FOLDER + "data" + SAVE_EXTENSION);
        return saveString;
    }

}
