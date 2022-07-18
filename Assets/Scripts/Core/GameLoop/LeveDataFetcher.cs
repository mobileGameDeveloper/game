using System;
using System.Collections;
using Core.Core;
using Modules.LevelMenu.Scripts.Data;
using Modules.LevelMenu.Scripts.Service;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

namespace Core.GameLoop
{

    public class LeveDataFetcher : MonoBehaviour
    {
        private const string GoogleUrl = "http://google.com";
        private const string LevelUrl = "https://row-match.s3.amazonaws.com/levels/";
        private const string ScriptableObjectPath = "Assets/Resources/Data/LevelDataModels/";
        private LevelDataService _levelDataService;
        
        public void Activate()
        {
            _levelDataService = ServiceLocator.Get<LevelDataService>();
            StartCoroutine(PullLevelDataFromRemote());
        }
        
        public IEnumerator PullLevelDataFromRemote()
        {
            while (true)
            {
                StartCoroutine(CheckInternetConnection((isConnected) =>
                {
                    if (isConnected)
                    {
                        if (_levelDataService.IsExistNewLevel())
                        {
                            var newLevelIDs = _levelDataService.GetNewLevelIDs();
                            foreach (var newLevelID in newLevelIDs)
                            {
                                StartCoroutine(GetText(newLevelID));
                            }
                            
                            StopCoroutine(PullLevelDataFromRemote());
                        }
                    }
                }));
                yield return new WaitForSeconds(180);
            }
        }

        IEnumerator CheckInternetConnection(Action<bool> action)
        {
            WWW www = new WWW(GoogleUrl);
            yield return www;
            action(www.error == null);
        }

        IEnumerator GetText(string levelId)
        {
            using (UnityWebRequest www = UnityWebRequest.Get(LevelUrl + levelId))
            {
                yield return www.Send();

                if (www.isNetworkError || www.isHttpError)
                {
                    Debug.Log(www.error);
                }
                else
                {
                    string data = www.downloadHandler.text;
                    SaveLevelDataModel(data, levelId);
                }
            }
        }

        private void SaveLevelDataModel(string data, string levelId)
        {
            string[] lines = data.Split('\n');

            int level_number = 0;
            int grid_width = 0;
            int grid_height = 0;
            int move_count = 0;
            string[] grid = { };

            for (int lineNumber = 0; lineNumber < lines.Length; lineNumber++)
            {
                if (lineNumber == 0)
                {
                    level_number = Int16.Parse(lines[lineNumber].Split(':')[1]);
                }
                else if (lineNumber == 1)
                {
                    grid_width = Int16.Parse(lines[lineNumber].Split(':')[1]);
                }
                else if (lineNumber == 2)
                {
                    grid_height = Int16.Parse(lines[lineNumber].Split(':')[1]);
                }
                else if (lineNumber == 3)
                {
                    move_count = Int16.Parse(lines[lineNumber].Split(':')[1]);
                }
                else if (lineNumber == 4)
                {
                    grid = lines[lineNumber].Split(':')[1].Split(',');
                }
            }
            LevelDataModel levelDataModel = new LevelDataModel();
            levelDataModel.grid = grid;
            levelDataModel.gridWidth = grid_width;
            levelDataModel.gridHeight = grid_height;
            levelDataModel.moveCount = move_count;
            levelDataModel.levelNumber = level_number;
                    
            AssetDatabase.CreateAsset(levelDataModel,  ScriptableObjectPath + levelId + ".asset");
            _levelDataService.LevelSavedPermanently(levelId);
        }
    }
}