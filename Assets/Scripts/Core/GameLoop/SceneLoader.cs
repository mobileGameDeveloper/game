using System;
using Core.Bootstrap;
using Core.Core;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.GameLoop
{
    public class SceneLoader : MonoBehaviour
    {
        protected bool IsReady = false;
        private float _timer;
        private bool _isCompleted;
        private bool _isRemoteFetched;
        

        private float _startTime = 0;
        private float _MinDelayTime = 0.4f;
        [SerializeField] private LeveDataFetcher _leveDataFetcher;
        
        [SerializeField] private ServiceLocatorBootstrapper serviceLocatorBootstrapper;
        private void Awake()
        {
            ServiceLocator.Clear();
            serviceLocatorBootstrapper.Bootstrap();
            _leveDataFetcher.Activate();
            //OnSceneLoaderAssetManagementComplete();
        }
        
        private void Update()
        {
            /*
            if (_isCompleted)
            {
                return;
            }
            else
            {
                if (IsReady)
                {
                    PrepareData();
                }
                else
                {
                    if (_timer > 10)
                    {
                        PrepareData();
                    }
                    else
                    {
                        _timer += Time.deltaTime;
                    }
                }
            }
            */
        }
        
        private void OnSceneLoaderAssetManagementComplete()
        {
            int sceneToLoad = 1;

            float timeWaited = Time.time - _startTime;
            if (timeWaited > _MinDelayTime)
            {
                SceneManager.LoadScene(sceneToLoad);
            }
            else
            {
                DOVirtual.DelayedCall(_MinDelayTime - timeWaited, (() =>
                {
                    SceneManager.LoadScene(sceneToLoad);
                }));
            }
        }
    }
}