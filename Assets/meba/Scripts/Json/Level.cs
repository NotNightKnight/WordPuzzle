using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace meba.json
{
    public class Level
    {
        public string title { get; set; }
        public Tile[] tiles { get; set; }
    }
}