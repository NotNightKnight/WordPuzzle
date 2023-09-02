using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace meba.json
{
    public class Tile : MonoBehaviour
    {
        public int id { get; set; }
        public Vector3 position { get; set; }
        public string character { get; set; }
        public int[] children { get; set; }
    }
}