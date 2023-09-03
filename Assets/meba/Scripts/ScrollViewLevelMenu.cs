using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace meba.menu
{
    public class ScrollViewLevelMenu : MonoBehaviour
    {
        [SerializeField]
        private MyJsonUtility json;

        [SerializeField]
        private GameObject parentPanelLevel;

        [SerializeField]
        private CanvasGroup levelMenu, game;

        [SerializeField]
        private PanelWordArea wordArea;

        private List<PanelLevel> panelLevelList = new List<PanelLevel>();

        private List<Level> levelList = new List<Level>();

        private List<Save> saveList = new List<Save>();

        private void Start()
        {
            foreach(PanelLevel panelLevel in parentPanelLevel.GetComponentsInChildren<PanelLevel>())
            {
                panelLevelList.Add(panelLevel);
            }

            json.LoadFromJson();
            levelList = json.GetLevelList();
            saveList = json.GetSaveList();

            for(int i = 0; i < levelList.Count; i++)
            {
                bool unlocked;
                string title, level, highscore;
                title = levelList[i].title;
                level = (i + 1).ToString();
                highscore = saveList[i].highscore.ToString();
                unlocked = saveList[i].open;

                panelLevelList[i].SetPanelLevel(title, level, highscore);

                if(unlocked)
                {
                    panelLevelList[i].SetLevelOpen();
                }
                else
                {
                    panelLevelList[i].SetLevelClosed();
                }
            }
        }

        public void OpenLevel(string lvl)
        {
            File.WriteAllText("Assets/meba/currentLevel.txt", lvl);
            levelMenu.alpha = 0;
            levelMenu.interactable = false;
            levelMenu.blocksRaycasts = false;
            game.alpha = 1;
            game.interactable = true;
            game.blocksRaycasts = true;

            wordArea.OpenLevel();
        }

        public void CloseLevel()
        {
            levelMenu.alpha = 1;
            levelMenu.interactable = true;
            levelMenu.blocksRaycasts= true;
            game.alpha = 0;
            game.interactable = false;
            game.blocksRaycasts = false;
        }
    }
}