using UnityEngine;

namespace Platformer2D
{
    public class MainHeroWalker 
    {
        private float _yVelocity;
        private SpriteAnimator _spriteAnimator;
        private CharacterView _characterView;

        public MainHeroWalker(SpriteAnimator spriteAnimator, CharacterView characterView)
        {
            _spriteAnimator = spriteAnimator;
            _characterView = characterView;
        }

        public void Update()
        {
            var doJump = Input.GetAxis(ConstantForProject.Vertical) > 0;
            var xAxisInput = Input.GetAxis(ConstantForProject.Horizontal);
            var isGoSideWay = Mathf.Abs(xAxisInput) > _characterView.MoveTresh;

            if (isGoSideWay)
                GoSideWay(xAxisInput);

            if (isGrounded())
            {
                _spriteAnimator.StartAnimation(_characterView.SpriteRenderer,isGoSideWay ? Track.Run : Track.Idle, true,_characterView.AnimationsSpeed);

                if (doJump && Mathf.Approximately(_yVelocity, 0))
                {
                    _yVelocity = _characterView.JumpSpeed;
                }
                else if(_yVelocity < 0)
                {
                    _yVelocity = 0;
                    MovementCharacter();
                }
            }
            else 
            {
                LandingCharacter();
            }

        }

        private void LandingCharacter()
        {
            _yVelocity += _characterView.Acceleration * Time.deltaTime;
            if (Mathf.Abs(_yVelocity) > _characterView.FlyTresh)
            {
                _spriteAnimator.StartAnimation(_characterView.SpriteRenderer, Track.Jump, true, _characterView.AnimationsSpeed);
            }

            _characterView.transform.position += Vector3.up * (Time.deltaTime * _yVelocity);
        }

        private void MovementCharacter()
        {
            _characterView.transform.position = _characterView.transform.position.Change(y:_characterView.GroundLevel);
        }

        private bool isGrounded()
        {
            return _characterView.transform.position.y <= _characterView.GroundLevel && _yVelocity <= 0;
        }

        private void GoSideWay(float xAxisInput)
        {
            _characterView.transform.position += Vector3.right * (Time.deltaTime * _characterView.WalkSpeed * (xAxisInput < 0 ? -1 : 1));
            _characterView.SpriteRenderer.flipX = xAxisInput < 0;
        }
    }
}
