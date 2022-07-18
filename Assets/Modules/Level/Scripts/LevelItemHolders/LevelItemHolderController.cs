using Core.InteractableItems;
using Core.UserInput;
using Modules.Level.Scripts.LevelItems;
using Modules.Level.Scripts.LevelItems.Behaviors;
using UnityEngine;

namespace Modules.Level.Scripts.LevelItemHolders
{
    public class LevelItemHolderController
    {
        private LevelItemController _levelItemController;
        private InteractableRectangle interactableRectangle;

        public LevelItemHolderController(InteractableRectangle interactableRectangle)
        {
            this.interactableRectangle = interactableRectangle;
        }

        public bool EnableToSwipe()
        {
            return _levelItemController.EnableToSwipe();
        }

        public void CannotSwipe(Direction direction)
        {
            _levelItemController.CannotSwipe();
        }

        public void Swipe(LevelItemHolderController otherLevelItemHolderController)
        {
            var firstLevelItemTransform = _levelItemController.Components.GetComponent<BasicTransform>();
            var firstCenter = firstLevelItemTransform.GetPosition();
            var secondLevelItemTransform = otherLevelItemHolderController._levelItemController.Components
                .GetComponent<BasicTransform>();
            var secondCenter = secondLevelItemTransform.GetPosition();

            firstLevelItemTransform.MoveToPos(secondCenter, 0.5f);
            secondLevelItemTransform.MoveToPos(firstCenter, 0.5f);

            ChangeLevelItemControllers(otherLevelItemHolderController);
        }

        private void ChangeLevelItemControllers(LevelItemHolderController otherLevelItemHolderController)
        {
            (_levelItemController, otherLevelItemHolderController._levelItemController) = (otherLevelItemHolderController._levelItemController, _levelItemController);
        }

        public bool DidItCollide(Vector2 position)
        {
            return interactableRectangle.DidPointCollide(position);
        }

        public void OnClicked()
        {
            _levelItemController.OnClicked();
        }

        public void OnClickUp()
        {
            _levelItemController.OnClickedUp();
        }

        public void AddLevelItemController(LevelItemController levelItemController)
        {
            _levelItemController = levelItemController;
        }
    }
}