using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace meba.UI.LevelMenu
{
    public class PanelLevel : MonoBehaviour
    {
        [SerializeField]
        private Sprite open, locked;

        [SerializeField]
        private Image myImage;

        [SerializeField]
        private Button myButton;

        [SerializeField]
        private TextMeshProUGUI titleTMP, levelTMP, highTMP, buttonTMP;

        public void SetTitle(string title)
        {
            titleTMP.text = title;
        }

        public void SetLevel(string level)
        {
            levelTMP.text = "LEVEL " + level;
        }

        public void SetHighScore(string score)
        {
            highTMP.text = "HIGHSCORE: " + score;
        }

        public void SetButtonOpen()
        {
            myImage.sprite = open;
            buttonTMP.enabled = true;
            myButton.enabled = true;
        }

        public void SetButtonLocked() 
        {
            myImage.sprite = locked;
            buttonTMP.enabled = false;
            myButton.enabled = false;
        }
    }
}