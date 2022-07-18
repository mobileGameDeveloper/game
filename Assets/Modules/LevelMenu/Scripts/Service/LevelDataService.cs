using System.Collections.Generic;
using Modules.LevelMenu.Scripts.Data;

namespace Modules.LevelMenu.Scripts.Service
{
    public class LevelDataService
    {
        private LevelDataRepository _repository;

        public LevelDataService(LevelDataRepository levelDataRepository)
        {
            _repository = levelDataRepository;
        }

        public bool IsExistNewLevel()
        { 
            bool isExistNewLevel = false;
            var newLevelIDs =  _repository.GetNewLevelIDs();
            if (newLevelIDs.Count > 0)
               isExistNewLevel = true;
            return isExistNewLevel;
        }

        public List<string> GetNewLevelIDs()
        {
            return _repository.GetNewLevelIDs();
        }

        public void LevelSavedPermanently(string levelID)
        {
            if (!string.IsNullOrEmpty(levelID))
            {
                _repository.DeleteNewLevelID(levelID);
                _repository.AddLevelID(levelID);
            }
        }
    }
}