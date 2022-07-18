using Core.UserInput;
using Modules.Level.Scripts.Logs;
using Modules.UI.LevelItem.ScriptableObjects;
using UnityEngine;

namespace Modules.Level.Scripts
{
    public class LevelManager
    {
        private bool _canClick;
        private bool _canSwipe;

        public bool CanClick => _canClick;

        public bool CanSwipe => _canSwipe;

        public LevelManager()
        {
            _canClick = true;
            _canSwipe = true;
        }
        /*
        private LevelItemHolder[][] levelItemHolderMatrix;
        [SerializeField] private LevelItemHolderDimensions levelItemHolderDimensions;
        [SerializeField] private GameObject levelItemHolderPrefab;
        [SerializeField] private Camera camera;
        private int rowCount;
        private int columnCout;
        private Vector2 creationPoint;
        private Vector2 activeLevelItem;
        private bool isExistActiveLevelItem;

        public void Start()
        {
            Mock2();
        }
        public void Activate(int height, int width, string[] levelItemTypeArray)
        {
            activeLevelItem = new Vector2();
            isExistActiveLevelItem = false;
            InitializeLevelItemHolderMatrix(height, width, levelItemTypeArray);
        }

        public void Mock()
        {
            Activate(5, 9, new []
            {
                "r", "r", "r", "r", "r", "r", "r", "r", "r",
                "r", "r", "r", "r", "r", "r", "r", "r", "r",
                "r", "r", "r", "r", "r", "r", "r", "r", "r",
                "r", "r", "r", "r", "r", "r", "r", "r", "r",
                "r", "r", "r", "r", "r", "r", "r", "r", "r"
            });
        }
        
        public void Mock2()
        {
            Activate(5, 8, new []
            {
                "r", "r", "r", "r", "r", "r", "r", "r", 
                "r", "r", "r", "r", "r", "r", "r", "r", 
                "r", "r", "r", "r", "r", "r", "r", "r",
                "r", "r", "r", "r", "r", "r", "r", "r", 
                "r", "r", "r", "r", "r", "r", "r", "r", 
            });
        }
        
        public void Mock3()
        {
            Activate(9, 9, new []
            {
                "r", "r", "r", "r", "r", "r", "r", "r", "r",
                "r", "r", "r", "r", "r", "r", "r", "r", "r",
                "r", "r", "r", "r", "r", "r", "r", "r", "r",
                "r", "r", "r", "r", "r", "r", "r", "r", "r",
                "r", "r", "r", "r", "r", "r", "r", "r", "r",
                "r", "r", "r", "r", "r", "r", "r", "r", "r",
                "r", "r", "r", "r", "r", "r", "r", "r", "r",
                "r", "r", "r", "r", "r", "r", "r", "r", "r",
                "r", "r", "r", "r", "r", "r", "r", "r", "r"
            });
        }

        private void InitializeLevelItemHolderMatrix(int height, int width, string[] levelItemTypeArray)
        {
            rowCount = height;
            columnCout = width;
            InitializeCreationPoint(height, width);
            levelItemHolderMatrix = new LevelItemHolder[columnCout][];
            int levelItemIndex = 0;
            for (int columnIndex = 0; columnIndex < columnCout; columnIndex++)
            {
                levelItemHolderMatrix[columnIndex] = new LevelItemHolder[rowCount];
                for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                {
                    levelItemHolderMatrix[columnIndex][rowIndex] = InstantiateLevelItemHolder(levelItemTypeArray[levelItemIndex], columnIndex, rowIndex);
                    
                }
            }
        }

        private void InitializeCreationPoint(int height, int width)
        {
            float totalHeight = levelItemHolderDimensions.heightOfHolder * height;
            float heightMargin = (levelItemHolderDimensions.heightOfScreen - totalHeight ) / 2;
            float coordinateY = levelItemHolderDimensions.initialCoordinateY + heightMargin;

            float totalWidth = levelItemHolderDimensions.widthOfHolder * width;
            float widthMargin = (levelItemHolderDimensions.widthOfScreen - totalWidth) / 2;
            float coordinateX = levelItemHolderDimensions.initialCoordinateX + widthMargin;

            creationPoint = new Vector2(coordinateX, coordinateY);
        }

        private LevelItemHolder InstantiateLevelItemHolder(string levelItemType, int columnIndex, int rowIndex)
        {
            float x = creationPoint.x + columnIndex * levelItemHolderDimensions.widthOfHolder;
            float y = creationPoint.y + rowIndex * levelItemHolderDimensions.heightOfHolder;
            LevelItemHolder levelItemHolder = Instantiate(levelItemHolderPrefab, new Vector2(x,y), Quaternion.identity).GetComponent<LevelItemHolder>();
            levelItemHolder.Initialize(levelItemType);
            return levelItemHolder;
        }
*/
/*
        protected override void OnSwipe(Direction direction)
        {
            if (isExistActiveLevelItem)
            {
                int x = (int) activeLevelItem.x;
                int y = (int) activeLevelItem.y;
                isExistActiveLevelItem = false;
                switch (direction)
                {
                    case Direction.Right:
                        LevelItemLog.Log("Swipe Left");
                        if (x + 1 < columnCout)
                        {
                            levelItemHolderMatrix[x][y].Swipe(levelItemHolderMatrix[x + 1][y]);
                            SwipeLevelItems(x, y, x + 1, y);
                        }
                        else
                        {
                            levelItemHolderMatrix[x][y].CannotSwipe(direction);
                        }
                        break;
                    case Direction.Left:
                        LevelItemLog.Log("Swipe Right");
                        if (x - 1 >= 0)
                        {
                            levelItemHolderMatrix[x][y].Swipe(levelItemHolderMatrix[x - 1][y]);
                            SwipeLevelItems(x, y, x - 1, y);
                        }
                        else
                        {
                            levelItemHolderMatrix[x][y].CannotSwipe(direction);
                        }
                        break;
                    case Direction.Down:
                        LevelItemLog.Log("Swipe Down");
                        if (y - 1 >= 0)
                        {
                            levelItemHolderMatrix[x][y].Swipe(levelItemHolderMatrix[x][y - 1]);
                            SwipeLevelItems(x, y, x, y - 1);
                        }
                        else
                        {
                            levelItemHolderMatrix[x][y].CannotSwipe(direction);
                        }
                        break;
                    case Direction.Up:
                        LevelItemLog.Log("Swipe Up");
                        if (y + 1 < rowCount)
                        {
                            levelItemHolderMatrix[x][y].Swipe(levelItemHolderMatrix[x][y + 1]);
                            SwipeLevelItems(x, y, x, y + 1);
                        }
                        else
                        {
                            levelItemHolderMatrix[x][y].CannotSwipe(direction);
                        }
                        break;
                    case Direction.None:
                        isExistActiveLevelItem = true;
                        break;
                }

            }
        }

        private void SwipeLevelItems(int firstX, int firstY, int secondX, int secondY)
        {
            (levelItemHolderMatrix[firstX][firstY], levelItemHolderMatrix[secondX][secondY]) = (levelItemHolderMatrix[secondX][secondY], levelItemHolderMatrix[firstX][firstY]);
        }

        protected override void OnClicked(Vector2 position)
        {
            //LevelItemLog.Log($"Clicked position {position}");
            if(isExistActiveLevelItem)
                return;
            for (int x = 0; x < columnCout; x++)
            {
                for (int y = 0; y < rowCount; y++)
                {
                    bool didItCollide = levelItemHolderMatrix[x][y].OnClicked(position);
                    if (didItCollide)
                    {
                        LevelItemLog.Log("User clicked a level item");
                        isExistActiveLevelItem = true;
                        activeLevelItem = new Vector2(x, y);
                    }
                }
            }
        }

        protected override void OnClickUp()
        {
            if (isExistActiveLevelItem)
            {
                int x = (int) activeLevelItem.x;
                int y = (int) activeLevelItem.y;
                var levelItemHolder = levelItemHolderMatrix[x][y];
                levelItemHolder.OnClickUp();
                isExistActiveLevelItem = false;
            }
            //throw new System.NotImplementedException();
        }
        */
    }
}