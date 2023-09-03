using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace meba
{
    public class MyTile : MonoBehaviour
    {
        public PanelWordArea panelWord;

        [SerializeField]
        private TextMeshProUGUI charTMP;

        public int id;
        public Vector3 position;
        public string character;
        public List<int> children;

        private void Start()
        {
            charTMP.text = character;
        }

        public void OnClick()
        {
            panelWord.OnClickLetter(transform);
        }
    }
}