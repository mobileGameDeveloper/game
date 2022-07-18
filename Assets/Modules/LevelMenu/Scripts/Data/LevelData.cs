using System;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.LevelMenu.Scripts.Data
{
    [Serializable]
    public class LevelData
    {
        public List<string> levelIDs = new List<string>();
        public List<string> newLevelIDs = new List<string>();
        
        public static T ImportJson<T>(string path)
        {
            TextAsset textAsset = Resources.Load<TextAsset>(path);
            return JsonUtility.FromJson<T>(textAsset.text);
        }

    } 
    
    
    
    
    
}