namespace Modules.LevelMenu.Scripts.Data
{
    public interface ILevelDataSaveLoad
    {
        void Save(LevelData levelData);
        LevelData Load();
    }
}