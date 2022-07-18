using System;
using Modules.Level.Scripts.LevelItems;
using UnityEngine;

namespace Modules.UI.LevelItem.ScriptableObjects
{
    [CreateAssetMenu(fileName = "LevelItemTypes", menuName = "Modules/Level/LevelItemTypes", order = 1)]
    public class LevelItemTypes : ScriptableObject
    {
        [SerializeField] public LevelItemTypeParam green;
        [SerializeField] public LevelItemTypeParam blue;
        [SerializeField] public LevelItemTypeParam yellow;
        [SerializeField] public LevelItemTypeParam red;
        [SerializeField] public LevelItemTypeParam checkMark;
    }
}