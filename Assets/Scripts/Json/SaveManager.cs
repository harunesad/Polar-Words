using UnityEngine;
using System.IO;

namespace Json
{
    public static class SaveManager
    {
        private const string DirectoryName = "/SaveData/";
        private const string FileName = "SaveProduct.json";
        public static void Save(SaveObject so)
        {
            string dir = Application.persistentDataPath + DirectoryName;

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            string json = JsonUtility.ToJson(so);
            File.WriteAllText(dir + FileName, json);
        }
        public static SaveObject Load()
        {
            string fullPath = Application.persistentDataPath + DirectoryName + FileName;
            SaveObject so = new SaveObject();

            if (File.Exists(fullPath))
            {
                string json = File.ReadAllText(fullPath);
                so = JsonUtility.FromJson<SaveObject>(json);
            }
            else
            {
                Debug.Log("failed");
            }
            return so;
        }
    }

}
