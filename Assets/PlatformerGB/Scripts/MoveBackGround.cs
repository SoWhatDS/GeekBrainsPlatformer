using UnityEngine;

namespace Platformer2D
{
    public class MoveBackGround 
    {
        private float speed = 5f;
        private Transform _backTransform;
        private float _backSize;
        private float _backPos;
        

        public MoveBackGround(Transform backTransform)
        {           
            _backTransform = backTransform;
            _backSize = _backTransform.GetComponent<SpriteRenderer>().bounds.size.x;
        }

        public void Update()
        {            
            MoveBackGroun();
        }

        private void MoveBackGroun()
        {
            _backPos += speed * Time.deltaTime;
            _backPos = Mathf.Repeat(_backPos, _backSize);
            _backTransform.position = new Vector3(-_backPos, 0, 0);

        }
    }
}
