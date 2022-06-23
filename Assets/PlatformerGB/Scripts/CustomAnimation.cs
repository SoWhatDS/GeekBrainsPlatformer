using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public class CustomAnimation 
    {
        public List<Sprite> Sprites;
        public float Counter;
        public bool Loop;
        public bool Sleep;
        public Track Track;
        public float SpeedAnimation = 30.0f; 

        public void Update()
        {
            if (Sleep)
                return;

            Counter += Time.deltaTime * SpeedAnimation;

            if (Loop)
            {              
                while (Counter > Sprites.Count)
                {
                    Counter -= Sprites.Count;
                    
                }
            }
            else if (Counter > Sprites.Count)
            {
              
                Counter = Sprites.Count - 1;        
                Sleep = true;
            }
            
        }
    }
}
