using System;
using Core.UserInput;
using UnityEngine;

namespace Modules.Level.Scripts
{
    public class Level
    {
        public event Action OnLevelEnd;
        private LevelManager _levelManager;
        private LevelSwipeController _levelSwipeController;

        public Level(LevelManager levelManager, LevelSwipeController levelSwipeController)
        {
            _levelManager = levelManager;
            _levelSwipeController = levelSwipeController;
        }
        

        public void OnSwipe(Direction direction)
        {
            if (_levelManager.CanSwipe)
            {
                _levelSwipeController.OnSwipe(direction);
            }
        }

        public void OnClicked(Vector2 position)
        {
            if (_levelManager.CanClick)
            {
                _levelSwipeController.OnClicked(position);
            }
        }

        public void OnClickUp()
        {
            _levelSwipeController.OnClickUp();
        }
    }
}