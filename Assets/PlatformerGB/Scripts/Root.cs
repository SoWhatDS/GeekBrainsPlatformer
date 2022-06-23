using UnityEngine;

namespace Platformer2D
{

    internal sealed class Root : MonoBehaviour
    {
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private SpriteRenderer _backGround;
        [SerializeField] private SpriteAnimationConfig _spriteAnimationConfig;
        [SerializeField] private CharacterView _characterView;
        [SerializeField] private MoveBackGround _backGroundMove;


        private SpriteAnimator _spriteAnimator;
        private MainHeroWalker _mainHeroWalker;

        private ParalaxManager _paralaxManager;


        private void Start()
        {
            _paralaxManager = new ParalaxManager(_mainCamera,_backGround.transform);
            _spriteAnimator = new SpriteAnimator(_spriteAnimationConfig);
            _mainHeroWalker = new MainHeroWalker(_spriteAnimator,_characterView);
           _backGroundMove = new MoveBackGround(_backGround.transform);
        }

        private void Update()
        {
            _paralaxManager.Update();
            _spriteAnimator.Update();
            _mainHeroWalker.Update();
            _backGroundMove.Update();
        }

        private void FixedUpdate()
        {
            
        }

        private void OnDestroy()
        {
            
        }
    }
}

