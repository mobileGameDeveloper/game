using Modules.Level.Scripts.LevelItemHolders;
using Modules.UI.LevelItem.ScriptableObjects;
using UnityEngine;

namespace Modules.Level.Scripts.Factory
{
    public class LevelFactory : MonoBehaviour
    {
        [SerializeField] private LevelItemFactory _levelItemFactory;
        private LevelItemHolderController[][] levelItemHolderMatrix;
        [SerializeField] private LevelItemHolderDimensions levelItemHolderDimensions;
        [SerializeField] private GameObject levelItemHolderPrefab;
        [SerializeField] private Camera camera;
        private int rowCount;
        private int columnCout;
        private Vector2 creationPoint;
        
        public Level CreateLevel(int height, int width, string[] levelItemTypeArray)
        {
            InitializeLevelItemHolderMatrix(height, width, levelItemTypeArray);
            LevelSwipeController levelSwipeController =
                new LevelSwipeController(rowCount, columnCout, levelItemHolderMatrix);
            LevelManager levelManager = new LevelManager();
            return new Level(levelManager, levelSwipeController);
        }
        
        private void InitializeLevelItemHolderMatrix(int height, int width, string[] levelItemTypeArray)
        {
            rowCount = height;
            columnCout = width;
            InitializeCreationPoint(height, width);
            levelItemHolderMatrix = new LevelItemHolderController[columnCout][];
            int levelItemIndex = 0;
            for (int columnIndex = 0; columnIndex < columnCout; columnIndex++)
            {
                levelItemHolderMatrix[columnIndex] = new LevelItemHolderController[rowCount];
                for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                {
                    levelItemHolderMatrix[columnIndex][rowIndex] = InstantiateLevelItemHolderController(levelItemTypeArray[levelItemIndex], columnIndex, rowIndex);
                    levelItemIndex++;
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
        
        private LevelItemHolderController InstantiateLevelItemHolderController(string levelItemType, int columnIndex, int rowIndex)
        {
            float x = creationPoint.x + columnIndex * levelItemHolderDimensions.widthOfHolder;
            float y = creationPoint.y + rowIndex * levelItemHolderDimensions.heightOfHolder;
            LevelItemHolder levelItemHolder = Instantiate(levelItemHolderPrefab, new Vector2(x,y), Quaternion.identity).GetComponent<LevelItemHolder>();
            var levelItemController = _levelItemFactory.InstantiateLevelItem(levelItemType, x, y);
            var levelItemHolderController = levelItemHolder.GetLevelItemController();
            levelItemHolderController.AddLevelItemController(levelItemController);
            return levelItemHolderController;
        }

    }
}