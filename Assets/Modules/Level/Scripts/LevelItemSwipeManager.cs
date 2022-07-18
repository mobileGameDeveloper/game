using Core.UserInput;
using UnityEngine;

namespace Modules.Level.Scripts
{
    public abstract class LevelItemSwipeManager : SwipeInputManager
    {
        protected override void OnSwipe(Direction direction)
        {
            throw new System.NotImplementedException();
        }

        protected override void OnClicked(Vector2 position)
        {
        }

        protected override void OnClickUp()
        {
            throw new System.NotImplementedException();
        }
    }
}