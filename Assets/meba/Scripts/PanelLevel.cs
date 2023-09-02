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
        private Color activeColor, inactiveColor;

        [SerializeField]
        private Image open, closed;

        [SerializeField]
        private TextMeshProUGUI titleTMP, levelTMP, highscoreTMP, buttonTMP;

        public void SetPanelLevel(string tit, string lvl, string hs)
        {
            titleTMP.text = tit;
            levelTMP.text = lvl;
            highscoreTMP.text = hs;
        }

        public void SetLevelOpen()
        {

        }

        public void SetLevelClosed()
        {

        }
    }
}