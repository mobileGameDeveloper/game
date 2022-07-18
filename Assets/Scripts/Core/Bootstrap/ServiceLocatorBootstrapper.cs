using Modules.LevelMenu.Scripts.Service;
using UnityEngine;

namespace Core.Bootstrap
{
    public class ServiceLocatorBootstrapper : MonoBehaviour, IBootstrapper
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        public void Bootstrap()
        {
            new LevelDataServiceInitializeCommand().Execute();
        }
        public void Dispose()
        {
            Destroy(gameObject);
        }
    }
}
