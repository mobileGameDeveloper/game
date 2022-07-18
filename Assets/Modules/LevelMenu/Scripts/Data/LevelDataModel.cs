using System.Collections.Generic;
using UnityEngine;

namespace Modules.LevelMenu.Scripts.Data
{
    
    [CreateAssetMenu(fileName = "LevelDataModel", menuName = "Data/LevelDataModel", order = 1)]
    public class LevelDataModel : ScriptableObject
    {
        public int levelNumber;
        public int gridWidth;
        public int gridHeight;
        public int moveCount;
        public string[] grid;
    }
    
}