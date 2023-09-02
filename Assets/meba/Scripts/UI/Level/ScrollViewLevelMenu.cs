using meba.json;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Serialization;
using UnityEngine;

namespace meba.UI.LevelMenu
{
    public class ScrollViewLevelMenu : MonoBehaviour
    {
        [SerializeField]
        private List<PanelLevel> panelLevelList;
        [SerializeField]
        private JsonParser parser;

        private List<Level> levelList = new List<Level>();
        private List<LevelInfo> levelInfoList = new List<LevelInfo> ();

        private void Start()
        {
            levelList = parser.GetLevelList();
            levelInfoList = parser.GetLevelInfoList();

            for (int i = 0; i < levelList.Count; i++)
            {
                panelLevelList[i].SetTitle(levelList[i].title);
                panelLevelList[i].SetLevel((i+1).ToString());

                panelLevelList[i].SetHighScore(levelInfoList[i].highscore.ToString());

                if (levelInfoList[i].unlocked)
                {
                    panelLevelList[i].SetButtonOpen();
                }
                else
                {
                    panelLevelList[i].SetButtonLocked();
                }
            }
        }
    }
}