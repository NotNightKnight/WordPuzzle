using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace meba.menu
{
    public class PanelMainMenu : MonoBehaviour
    {
        public void OnClickPlay()
        {
            SceneManager.LoadScene("LevelMenu");
        }
        public void OnClickQuit()
        {
            Application.Quit();
        }
    }
}