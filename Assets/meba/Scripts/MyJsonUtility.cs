using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace meba
{
    public class MyJsonUtility : MonoBehaviour
    {
        private List<Level> levelList = new List<Level>();
        private List<Save> saveList = new List<Save>();

        private string path = "Assets/Levels/";
        private string savePath = "Assets/meba/Saves/";
        private string currentLevelPath = "Assets/meba/currentLevel.txt";

        public void LoadFromJson()
        {
            Level level = new Level();
            Save save = new Save();

            levelList = new List<Level>();
            saveList = new List<Save>();

            for(int i = 1; i <= 20; i++)
            {
                string levelData = File.ReadAllText(path + "level_" + i + ".json");
                level = JsonUtility.FromJson<Level>(levelData);
                levelList.Add(level);

                string saveData = File.ReadAllText(savePath + "save_" + i + ".json");
                save = JsonUtility.FromJson<Save>(saveData);
                saveList.Add(save);
            }
        }

        public List<Level> GetLevelList()
        {
            return levelList;
        }

        public Level GetLevel(int curLevel)
        {
            return levelList[curLevel - 1];
        }

        public List<Save> GetSaveList()
        {
            return saveList;
        }

        public Save GetSave(int curLevel)
        {
            return saveList[curLevel - 1];
        }

        public void SaveHighscoreChanged(int score)
        {
            Save save = new Save();
            int curLevel = Int32.Parse(File.ReadAllText(currentLevelPath));

            save.highscore = score;
            save.open = true;

            string jsonData = JsonUtility.ToJson(save);
            File.WriteAllText(savePath + "save_" + curLevel + ".json", jsonData);

            save.highscore = 0;
            save.open = true;

            jsonData = JsonUtility.ToJson(save);
            File.WriteAllText(savePath + "save_" + (curLevel + 1) + ".json", jsonData);
        }
    }

    [System.Serializable]
    public class Level
    {
        public string title;
        public List<Tile> tiles;
    }

    [System.Serializable]
    public class Tile
    {
        public int id;
        public Vector3 position;
        public string character;
        public List<int> children;
    }

    [System.Serializable]
    public class Save
    {
        public bool open;
        public int highscore;
    }
}