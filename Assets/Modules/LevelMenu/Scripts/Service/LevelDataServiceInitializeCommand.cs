using System.Windows.Input;
using Core.Command;
using Core.Core;
using Modules.LevelMenu.Scripts.Data;
using ICommand = Core.Command.ICommand;

namespace Modules.LevelMenu.Scripts.Service
{
    public class LevelDataServiceInitializeCommand : ICommand
    {
        public void Execute()
        {
            LevelDataService service = new LevelDataService(
                new LevelDataRepository(new LevelDataSaveLoad())
            );
            ServiceLocator.Add<LevelDataService>(service);
        }
    }
}