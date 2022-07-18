using System;
using UnityEngine;

namespace Modules.Level.Scripts.LevelItems
{
    [Serializable]
    public class LevelItemTypeParam 
    {
        public Sprite background;
        public LevelItemType levelItemType;
        public String LevelItemTypeSting;
        public int point;
    }
}