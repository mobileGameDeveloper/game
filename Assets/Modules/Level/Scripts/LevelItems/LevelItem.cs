using System;
using UnityEngine;

namespace Modules.Level.Scripts.LevelItems
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class LevelItem : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer renderer;
        private LevelItemController _levelItemController;

        private void Awake()
        {
            renderer.sortingOrder = 100;
            _levelItemController = new LevelItemController(renderer, transform);
        }

        public LevelItemController GetLevelItemController()
        {
            return _levelItemController;
        }
    }
}
