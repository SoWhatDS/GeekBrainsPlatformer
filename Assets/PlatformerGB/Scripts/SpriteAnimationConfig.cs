using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    [CreateAssetMenu(fileName = "SpriteAnimationConfig", menuName = "Config/SpritesAnim",order = 1)]
    public class SpriteAnimationConfig : ScriptableObject
    {
        [SerializeField] private List<SpriteSequence> _sequences;

        public List<SpriteSequence> Sequences => _sequences;
    }
}
