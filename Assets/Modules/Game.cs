using System;
using Modules.Level.Scripts;
using Modules.Level.Scripts.Factory;
using UnityEngine;

namespace Modules
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private LevelFactory _levelFactory;
        [SerializeField] private LevelSwipeManager _levelSwipeManager;

        private void Awake()
        {
            var level = _levelFactory.CreateLevel(5, 9, new []
            {
                "r", "g", "r", "r", "r", "r", "r", "r", "r",
                "r", "y", "r", "r", "r", "r", "r", "r", "r",
                "r", "b", "r", "r", "y", "r", "r", "r", "r",
                "r", "r", "r", "r", "r", "r", "r", "r", "r",
                "r", "r", "r", "r", "r", "r", "r", "r", "r"
            });
            
            _levelSwipeManager.Activate(level);
        }
    }
}