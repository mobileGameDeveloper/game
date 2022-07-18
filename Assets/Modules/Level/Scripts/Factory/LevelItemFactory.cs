using System;
using Modules.Level.Scripts.LevelItems;
using Modules.Level.Scripts.LevelItems.Behaviors;
using Modules.UI.LevelItem.ScriptableObjects;
using UnityEngine;

namespace Modules.Level.Scripts.Factory
{
    public class LevelItemFactory : MonoBehaviour
    {
        [SerializeField] private LevelItemTypes _levelItemTypes;
        [SerializeField] private GameObject _levelItemPrefab;

        public LevelItemController InstantiateLevelItem(string levelItemTypeString, float x, float y)
        {
            LevelItem levelItem = Instantiate(_levelItemPrefab, new Vector2(x,y), Quaternion.identity).GetComponent<LevelItem>();
            LevelItemController levelItemController = levelItem.GetLevelItemController();
            var basicSpriteRenderer = levelItemController.Components.GetComponent<BasicSpriteRenderer>();
            Sprite levelItemSprite = GetLevelItemSprite(levelItemTypeString);
            basicSpriteRenderer.SetSprite(levelItemSprite);
            return levelItemController;
        }

        private Sprite GetLevelItemSprite(string levelItemTypeString)
        {
            Sprite sprite = _levelItemTypes.yellow.background;
            if (levelItemTypeString.Equals(_levelItemTypes.blue.LevelItemTypeSting, StringComparison.Ordinal))
                sprite = _levelItemTypes.blue.background;
            else if (levelItemTypeString.Equals(_levelItemTypes.green.LevelItemTypeSting, StringComparison.Ordinal))
                sprite = _levelItemTypes.green.background;
            else if (levelItemTypeString.Equals(_levelItemTypes.red.LevelItemTypeSting, StringComparison.Ordinal))
                sprite = _levelItemTypes.red.background;
            
            return sprite;
        }
    }
}