using UnityEngine;

namespace Core.InteractableItems.Buttons
{
    public class InteractableSprite : MonoBehaviour
    {
        [SerializeField] private Sprite spriteRenderer;
        private InteractableRectangle interactableRectangle;

        private void Awake()
        {
        }
    }
}