using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace meba.json
{
    public class MyJsonUtility : MonoBehaviour
    {
        private List<Level> levelList = new List<Level>();

        private string path = "Assets/Levels/";

        public void LoadFromJson()
        {
            Level level = new Level();

            for(int i = 1; i <= 20; i++)
            {
                string levelData = File.ReadAllText(path + "level_" + i + ".json");
                level = JsonUtility.FromJson<Level>(levelData);
                levelList.Add(level);
            }
        }

        public List<Level> GetLevelList()
        {
            return levelList;
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
}