using System;
using System.Collections.Generic;

namespace Modules.LevelMenu.Scripts.Data
{
    public class LevelDataRepository
    {
        private ILevelDataSaveLoad _levelDataSaveLoad;
        private LevelData _levelData;

        public LevelDataRepository(ILevelDataSaveLoad levelDataSaveLoad)
        {
            _levelDataSaveLoad = levelDataSaveLoad;
            _levelData = Load();
        }

        private LevelData Load()
        {
           return _levelDataSaveLoad.Load();
        }

        private void Save(LevelData levelData)
        {
            _levelDataSaveLoad.Save(levelData);
            _levelData = levelData;
        }

        public List<string> GetLevelIDs()
        {
            return _levelData.levelIDs;
        }

        public List<string> GetNewLevelIDs()
        {
            return _levelData.newLevelIDs;
        }

        public void AddLevelID(string levelID)
        {
            _levelData.levelIDs.Add(levelID);
            Save(_levelData);
        }

        public void DeleteNewLevelID(string newLevelID)
        {
            for (int levelIDIndex = 0; levelIDIndex < _levelData.newLevelIDs.Count; levelIDIndex++)
            {
                var existingLevelID = _levelData.newLevelIDs[levelIDIndex];
                if (newLevelID.Equals(existingLevelID, StringComparison.Ordinal))
                {
                    _levelData.newLevelIDs.RemoveAt(levelIDIndex);
                    Save(_levelData);
                    break;
                }
            }
        }
        
        
    }
}