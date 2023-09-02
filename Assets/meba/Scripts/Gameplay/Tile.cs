using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace meba.game
{
    public class Tile : MonoBehaviour
    {
        public int id;
        public Vector3 position;
        public string character;
        public List<int> children;
    }
}