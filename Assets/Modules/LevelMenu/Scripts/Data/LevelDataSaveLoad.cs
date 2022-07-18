using UnityEngine;

namespace Modules.LevelMenu.Scripts.Data
{
    public class LevelDataSaveLoad : ILevelDataSaveLoad
    {
        private const string LoadLevelDataPath = "Data/LevelData";
        private const string SaveLevelDataPath = "/Resources/Data/LevelData.json";
        
        public void Save(LevelData levelData)
        {
            string json = JsonUtility.ToJson(levelData);
            System.IO.File.WriteAllText(Application.dataPath + SaveLevelDataPath, json);
        }

        public LevelData Load()
        {
            TextAsset textAsset = Resources.Load<TextAsset>(LoadLevelDataPath);
            return JsonUtility.FromJson<LevelData>(textAsset.text);
        }
    }
}