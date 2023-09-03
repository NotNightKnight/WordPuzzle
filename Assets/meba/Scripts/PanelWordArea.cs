using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using DG.Tweening;
using System.Linq;
using TMPro;
using meba.menu;
using UnityEngine.UI;

namespace meba
{
    public class PanelWordArea : MonoBehaviour
    {
        [SerializeField]
        private GameObject tilePrefab;

        [SerializeField]
        private MyJsonUtility json;

        [SerializeField]
        private Transform parentLetterTiles;

        [SerializeField]
        private List<Transform> letterAreas = new List<Transform>();

        [SerializeField]
        private TextMeshProUGUI titleTMP;

        [SerializeField]
        private ScrollViewLevelMenu scrollViewLevelMenu;

        [SerializeField]
        private WordChecker wordChecker;

        [SerializeField]
        private TextMeshProUGUI writtenWordsTMP;

        [SerializeField]
        private ScoreCalculator scoreCalculator;

        [SerializeField]
        private TextMeshProUGUI sumScoreTMP, wordScoreTMP;

        [SerializeField]
        private PanelEndLevel panelEndLevel;

        private List<MyTile> wordArea = new List<MyTile>();

        private List<MyTile> tileList = new List<MyTile>();

        private List<string> writtenWords = new List<string>();

        private List<MyTile> remainedTileList = new List<MyTile>();

        private Level level;
        private Save save;

        private int sumScore = 0;

        private bool gameEnded = true;

        //private void Start()
        //{
        //    int currentLevel = Int32.Parse(File.ReadAllText("Assets/meba/currentLevel.txt"));
        //    level = json.GetLevel(currentLevel);
        //    save = json.GetSave(currentLevel);

        //    foreach (Tile tile in level.tiles)
        //    {
        //        GameObject newTile = Instantiate(tilePrefab, parentLetterTiles);
        //        newTile.transform.position = tile.position;
        //        newTile.GetComponent<Tile>().id = tile.id;
        //        newTile.GetComponent<Tile>().character = tile.character;
        //        newTile.GetComponent<Tile>().children = tile.children;
        //    }
        //}

        public void OpenLevel()
        {
            if(gameEnded)
            {
                writtenWordsTMP.text = string.Empty;

                int currentLevel = Int32.Parse(File.ReadAllText("Assets/meba/currentLevel.txt"));
                level = json.GetLevel(currentLevel);
                save = json.GetSave(currentLevel);

                titleTMP.text = level.title;

                foreach (Tile tile in level.tiles)
                {
                    GameObject newTile = Instantiate(tilePrefab, parentLetterTiles);
                    newTile.transform.position = ChangePos(tile.position);
                    //newTile.AddComponent<MyTile>();
                    newTile.GetComponent<MyTile>().id = tile.id;
                    newTile.GetComponent<MyTile>().position = ChangePos(tile.position);
                    newTile.GetComponent<MyTile>().character = tile.character;
                    newTile.GetComponent<MyTile>().children = tile.children;

                    newTile.GetComponent<MyTile>().panelWord = this;

                    tileList.Add(newTile.GetComponent<MyTile>());
                    remainedTileList.Add(newTile.GetComponent<MyTile>());
                }

                foreach (MyTile tile in tileList)
                {
                    foreach (int childID in tile.children)
                    {
                        tileList[childID].GetComponent<Button>().interactable = false;
                    }
                }
                gameEnded = false;
            }
        }

        private Vector3 ChangePos(Vector3 pos)
        {
            Vector3 res;
            res = (pos.normalized * 2500f) + new Vector3(0, 1500, 0);
            res.z = pos.z;
            return res;
        }

        public void OnClickLetter(Transform obj)
        {
            if(wordArea.Count < 7)
            {
                int index = wordArea.Count;
                obj.DOMove(letterAreas[index].position, 0.75f);
                obj.GetComponent<Button>().interactable = false;
                wordArea.Add(obj.gameObject.GetComponent<MyTile>());

                foreach(int childID in obj.gameObject.GetComponent<MyTile>().children)
                {
                    if (!wordArea.Contains(tileList[childID]))
                    {
                        tileList[childID].GetComponent<Button>().interactable = true;
                    }
                }
            }
        }

        public void OnClickBackButton()
        {
            if(wordArea.Count > 0)
            {
                MyTile myTile = wordArea.Last<MyTile>();
                myTile.transform.DOMove(myTile.position, 0.5f);
                myTile.GetComponent<Button>().interactable = true;
                wordArea.Remove(myTile);

                foreach (int childID in myTile.children)
                {
                    tileList[childID].GetComponent<Button>().interactable = false;
                }
            }
        }

        public void OnClickExit()
        {
            scrollViewLevelMenu.CloseLevel();
        }

        public void OnClickOK()
        {
            string word = string.Empty;
            foreach(MyTile tile in wordArea)
            {
                word += tile.character;
            }
            word.Trim();
            word = word.ToLower();
            if(!writtenWords.Contains(word))
            {
                if (wordChecker.CheckWord(word))
                {
                    writtenWordsTMP.text += word.ToUpper() + Environment.NewLine;
                    writtenWords.Add(word);

                    int score = scoreCalculator.CalculateScore(word);
                    sumScore += score;
                    wordScoreTMP.text = "WORD SCORE: " + score;
                    sumScoreTMP.text = "SCORE: " + sumScore;

                    foreach (MyTile tile in wordArea)
                    {
                        remainedTileList.Remove(tile);
                        tile.gameObject.SetActive(false);
                    }
                    wordArea.Clear();
                    CheckGameState();
                }
            }
        }

        private void CheckGameState()
        {
            bool canBeMade = true;
            if(remainedTileList.Count == 0)
            {
                EndLevel();
            }
            else
            {
                Dictionary<char, int> availableLetters = new Dictionary<char, int>();

                foreach(MyTile tile in remainedTileList)
                {
                    if(availableLetters.ContainsKey(Char.Parse(tile.character.ToLower())))
                    {
                        availableLetters[Char.Parse(tile.character.ToLower())]++;
                    }
                    else
                    {
                        availableLetters.Add(Char.Parse(tile.character.ToLower()), 1);
                    }
                }

                string[] words = wordChecker.GetWordsArray();

                foreach (string word in words)
                {
                    Dictionary<char, int> wordLetters = new Dictionary<char, int>();
                    foreach(char  letter in word)
                    {
                        if(wordLetters.ContainsKey(letter))
                        {
                            wordLetters[letter]++;
                        }
                        else
                        {
                            wordLetters[letter] = 1;
                        }
                    }

                    canBeMade = true;

                    foreach (var letterCount in wordLetters)
                    {
                        if(!availableLetters.ContainsKey(letterCount.Key) || availableLetters[letterCount.Key] < letterCount.Value)
                        {
                            canBeMade = false;
                            break;
                        }
                    }

                    if(canBeMade)
                    {
                        //Debug.Log(word);
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                if(!canBeMade)
                {
                    EndLevel();
                }
            }
        }

        private void EndLevel()
        {
            sumScore -= remainedTileList.Count * 100;

            if(sumScore > save.highscore)
            {
                //more particles
                panelEndLevel.ExtraParticle();
                json.SaveHighscoreChanged(sumScore);
            }
            else
            {
                //particle
                panelEndLevel.Particle();
                json.SaveHighscoreChanged(save.highscore);
            }

            gameEnded = true;
            Invoke(nameof(scrollViewLevelMenu.CloseLevel), 5f);
        }
    }
}