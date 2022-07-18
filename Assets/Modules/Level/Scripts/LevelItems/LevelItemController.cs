using Modules.Level.Scripts.LevelItems.Behaviors;
using UnityEngine;

namespace Modules.Level.Scripts.LevelItems
{
    public class LevelItemController
    {
        private LevelItemComponents _levelItemComponents;

        public LevelItemComponents Components
        {
            get => _levelItemComponents;
            set => _levelItemComponents = value;
        }

        public LevelItemController(SpriteRenderer spriteRenderer, Transform transform)
        {
            Components = new LevelItemComponents();
            var basicSpriteRenderer = new BasicSpriteRenderer(spriteRenderer);
            var basicTransform = new BasicTransform(transform);
            Components.AddComponent(basicSpriteRenderer);
            Components.AddComponent(basicTransform);
        }

        public void OnClicked()
        {
            //throw new System.NotImplementedException();
        }

        public void OnClickedUp()
        {
            //throw new System.NotImplementedException();
        }

        public bool EnableToSwipe()
        {
            return true;
        }

        public void CannotSwipe()
        {
            //throw new System.NotImplementedException();
        }
    }
}