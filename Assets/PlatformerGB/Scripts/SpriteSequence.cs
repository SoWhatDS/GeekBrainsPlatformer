using System;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    [Serializable]
    public class SpriteSequence 
    {    
        public Track Track;
        public List<Sprite> Sprites = new List<Sprite>();
    }
}
