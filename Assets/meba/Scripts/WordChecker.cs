using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace meba
{
    public class WordChecker : MonoBehaviour
    {
        string path = "Assets/words/words.txt";

        private List<string> words = new List<string>();

        private void Start()
        {
            using(StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    words.Add(sr.ReadLine());
                }
            }
        }

        public bool CheckWord(string word)
        {
            if(words.Contains(word)) return true;
            else return false;
        }

        public string[] GetWordsArray()
        {
            return words.ToArray();
        }
    }
}