using Core.UserInput;
using Modules.Level.Scripts.LevelItemHolders;
using Modules.Level.Scripts.Logs;
using UnityEngine;

namespace Modules.Level.Scripts
{
    public class LevelSwipeController
    {
        private int _rowCount;
        private int _columnCount;
        private bool _isExistActiveLevelItem;
        private Vector2 _activeLevelItem;
        private LevelItemHolderController[][] _levelItemHolderMatrix;

        public LevelSwipeController(int rowCount, int columnCount, LevelItemHolderController[][] levelItemHolderMatrix)
        {
            _rowCount = rowCount;
            _columnCount = columnCount;
            _levelItemHolderMatrix = levelItemHolderMatrix;
        }

        public void OnSwipe(Direction direction)
        {
            if (_isExistActiveLevelItem)
            {
                int x = (int) _activeLevelItem.x;
                int y = (int) _activeLevelItem.y;
                _isExistActiveLevelItem = false;
                if (!_levelItemHolderMatrix[x][y].EnableToSwipe())
                {
                    _levelItemHolderMatrix[x][y].CannotSwipe(direction);
                    return;
                }
                switch (direction)
                {
                    case Direction.Right:
                        LevelItemLog.Log("Swipe Left");
                        if (x + 1 < _columnCount)
                            SwipeLevelItems(x, y, x + 1, y, direction);
                        else
                            _levelItemHolderMatrix[x][y].CannotSwipe(direction);
                        
                        break;
                    
                    case Direction.Left:
                        LevelItemLog.Log("Swipe Right");
                        if (x - 1 >= 0)
                            SwipeLevelItems(x, y, x - 1, y, direction);
                        else
                            _levelItemHolderMatrix[x][y].CannotSwipe(direction);
                        
                        break;
                    
                    case Direction.Down:
                        LevelItemLog.Log("Swipe Down");
                        if (y - 1 >= 0)
                            SwipeLevelItems(x, y, x, y - 1, direction);
                        else
                            _levelItemHolderMatrix[x][y].CannotSwipe(direction);
                      
                        break;
                    
                    case Direction.Up:
                        LevelItemLog.Log("Swipe Up");
                        if (y + 1 < _rowCount)
                            SwipeLevelItems(x, y, x, y + 1, direction);
                        else
                            _levelItemHolderMatrix[x][y].CannotSwipe(direction);
                        
                        break;
                    
                    case Direction.None:
                        _isExistActiveLevelItem = true;
                        break;
                }

            }
        }
        
        private void SwipeLevelItems(int firstX, int firstY, int secondX, int secondY, Direction direction)
        {
            if (!_levelItemHolderMatrix[secondX][secondY].EnableToSwipe())
            {
                _levelItemHolderMatrix[firstX][firstY].CannotSwipe(direction);
            }
            else
            {
                _levelItemHolderMatrix[firstX][firstY].Swipe(_levelItemHolderMatrix[secondX][secondY]);
            }
            
        }

        public void OnClicked(Vector2 position)
        {
            if(_isExistActiveLevelItem)
                return;
            for (int x = 0; x < _columnCount; x++)
            {
                for (int y = 0; y < _rowCount; y++)
                {
                    bool didItCollide = _levelItemHolderMatrix[x][y].DidItCollide(position);
                    if (didItCollide)
                    {
                        _levelItemHolderMatrix[x][y].OnClicked();
                        LevelItemLog.Log("User clicked a level item");
                        _isExistActiveLevelItem = true;
                        _activeLevelItem = new Vector2(x, y);
                    }
                }
            }
        }

        public void OnClickUp()
        {
            if (_isExistActiveLevelItem)
            {
                int x = (int) _activeLevelItem.x;
                int y = (int) _activeLevelItem.y;
                var levelItemHolder = _levelItemHolderMatrix[x][y];
                levelItemHolder.OnClickUp();
                _isExistActiveLevelItem = false;
            }
        }
    }
}