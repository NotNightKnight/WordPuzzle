using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Windows;

namespace meba.json
{
    public class JsonParser : MonoBehaviour
    {
        private string path = "Assets/Levels/";

        private string savePath = "Assets/meba/Save/";

        private List<Level> levelList = new List<Level>();

        private List<LevelInfo> LevelInfoList = new List<LevelInfo>();

        private void Start()
        {
            Level level = new Level();
            string jsonText;
            DirectoryInfo info = new DirectoryInfo(path);
            FileInfo[] fileInfo = info.GetFiles("*.json");
            for(int i = 1; i <= fileInfo.Length; i++)
            {
                using (StreamReader sr = new StreamReader(path + "level_" + i + ".json"))
                {
                    jsonText = sr.ReadToEnd();
                }
                //level = JsonUtility.FromJson<Level>(jsonText);
                level = JsonConvert.DeserializeObject<Level>(jsonText);
                Debug.Log(level.tiles[0]);
                levelList.Add(level);
            }

            LevelInfo levelInfo = new LevelInfo();
            info = new DirectoryInfo(savePath);
            fileInfo = info.GetFiles("*.json");
            for(int i = 1; i <= fileInfo.Length; i++)
            {
                using (StreamReader sr = new StreamReader(savePath + "save" + i + ".json"))
                {
                    jsonText = sr.ReadToEnd();
                }
                levelInfo = JsonUtility.FromJson<LevelInfo>(jsonText);
                LevelInfoList.Add(levelInfo);
            }
        }

        public void ChangeLevelInfo(LevelInfo levelInfo, int levelNumber)
        {
            string jsonText;
            jsonText = JsonUtility.ToJson(levelInfo);
            using(StreamWriter sw = new StreamWriter(savePath + "save" + levelNumber + ".json"))
            {
                sw.WriteLine(jsonText);
            }
            LevelInfoList[levelNumber+1] = levelInfo;
        }

        public List<Level> GetLevelList()
        {
            return levelList;
        }

        public Level GetLevel(int levelNumber)
        {
            return levelList[levelNumber];
        }

        public List<LevelInfo> GetLevelInfoList()
        {
            return LevelInfoList;
        }

        public LevelInfo GetLevelInfo(int levelNumber)
        {
            return LevelInfoList[levelNumber];
        }
    }
}