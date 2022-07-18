using System;
using Core.UserInput;
using UnityEngine;

namespace Modules.Level.Scripts
{
    public class LevelSwipeManager : SwipeInputManager
    {
        private Level _level;
        
        
        public void Activate(Level level)
        {
            _level = level;
            _level.OnLevelEnd += Deactivate;
            isListeingEnable = true;
        }

        private void Deactivate()
        {
            _level.OnLevelEnd -= Deactivate;
            isListeingEnable = false;
        }

        protected override void OnSwipe(Direction direction)
        {
            _level.OnSwipe(direction);
        }

        protected override void OnClicked(Vector2 position)
        {
            _level.OnClicked(position);
        }

        protected override void OnClickUp()
        {
            _level.OnClickUp();
        }
    }
}