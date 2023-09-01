using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace meba.gameplay
{
    public class Letter : MonoBehaviour
    {
        [SerializeField]
        private char letter;

        [SerializeField]
        private List<Letter> upLetters, downLetters;

        [SerializeField]
        Color activeColor, inactiveColor;

        [SerializeField]
        private Image letterImg;
        [SerializeField]
        private TextMeshProUGUI letterTMP;

        private bool canClick = false;

        private void Start()
        {
            if (!letter.IsUnityNull())
            {
                letterTMP.text = letter.ToString();
            }
            else
            {
                Debug.Log("ERROR: LETTER EMPTY!");
                Application.Quit();
            }

            if (canClick)
            {
                letterImg.color = activeColor;
            }
            else
            {
                letterImg.color = inactiveColor;
            }
        }
    }
}