using UnityEngine;

namespace Modules.Level.Scripts.LevelItems.Behaviors
{
    public class BasicSpriteRenderer
    {
        private SpriteRenderer spriteRenderer;
        
        
        public BasicSpriteRenderer(SpriteRenderer spriteRenderer)
        {
            this.spriteRenderer = spriteRenderer;
        }

        public void SetSprite(Sprite levelItemSprite)
        {
            spriteRenderer.sprite = levelItemSprite;
        }
    }
}