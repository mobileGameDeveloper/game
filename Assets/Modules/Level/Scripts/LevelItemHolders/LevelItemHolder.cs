using Core.InteractableItems;
using DG.Tweening;
using UnityEngine;

namespace Modules.Level.Scripts.LevelItemHolders
{
    public class LevelItemHolder : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _renderer;
        private Camera _camera;
        private LevelItemHolderController _levelItemHolderController;

        private void Awake()
        {
            _renderer.sortingOrder = 0;
            var bounds = _renderer.bounds;
            var position = transform.position;
            _levelItemHolderController = new LevelItemHolderController(new InteractableRectangle(position, bounds.size.x, bounds.size.y));
        }
        
        public LevelItemHolderController GetLevelItemController()
        {
            return _levelItemHolderController;
        }
        
        
    }
}