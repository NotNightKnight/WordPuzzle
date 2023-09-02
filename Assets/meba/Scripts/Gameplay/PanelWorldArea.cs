using meba.json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace meba.game
{
    public class PanelWorldArea : MonoBehaviour
    {
        [SerializeField]
        private JsonParser parser;

        [SerializeField]
        private TextMeshProUGUI titleTMP;

        [SerializeField]
        private GameObject letterTiles;

        [SerializeField]
        private GameObject tilePrefab;

        private Tile[] tiles;

        private string curLevelPath = "Assets/meba/Scripts/currentLevel.txt";

        private int curLevel;

        Level level;
        LevelInfo levelInfo;

        private void Start()
        {
            using(StreamReader sr = new StreamReader(curLevelPath))
            {
                string curL = sr.ReadLine();
                curLevel = int.Parse(curL);
            }

            level = parser.GetLevel(curLevel-1);
            levelInfo = parser.GetLevelInfo(curLevel-1);

            titleTMP.text = level.title;

            tiles = level.tiles;

            //foreach (Tile tile in tiles)
            //{
            //    if (tile == null)
            //    {
            //        Debug.Log("null");
            //    }
            //    GameObject newTile = Instantiate(tilePrefab, letterTiles.transform);
            //    Tile newSc = newTile.GetComponent<Tile>();
            //    newSc.id = tile.id;
            //    newSc.position = tile.position;
            //    newSc.character = tile.character;
            //    newSc.children = tile.children;
            //    newTile.transform.position = newSc.position;
            //}
        }
    }
}