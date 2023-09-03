using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace meba.menu
{
    public class PanelLevel : MonoBehaviour
    {
        [SerializeField]
        private ScrollViewLevelMenu scrollView;

        [SerializeField]
        private Sprite open, closed;

        [SerializeField]
        private TextMeshProUGUI titleTMP, levelTMP, highscoreTMP, buttonTMP;

        [SerializeField]
        private Button myButton;

        [SerializeField]
        private Image buttonImg;

        private string level;

        public void SetPanelLevel(string tit, string lvl, string hs)
        {
            titleTMP.text = tit;
            levelTMP.text = "LEVEL " + lvl;
            highscoreTMP.text = hs;

            level = lvl;
        }

        public void SetLevelOpen()
        {
            myButton.enabled = true;
            buttonImg.sprite = open;
            buttonTMP.enabled = true;
        }

        public void SetLevelClosed()
        {
            myButton.enabled = false;
            buttonImg.sprite = closed;
            buttonTMP.enabled = false;
        }

        public void OpenLevel()
        {
            scrollView.OpenLevel(level);
        }
    }
}