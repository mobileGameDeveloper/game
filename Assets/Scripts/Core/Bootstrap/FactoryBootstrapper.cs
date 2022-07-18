using UnityEngine;

namespace Core.Bootstrap
{
    public class FactoryBootstrapper : MonoBehaviour, IBootstrapper
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            Bootstrap();
        }

        private void OnDestroy()
        {
        }

        public void Bootstrap()
        {
           
        }
        
        public void Dispose()
        {
            Destroy(gameObject);
        }
    }
}