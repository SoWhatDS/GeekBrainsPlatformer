using UnityEngine;

namespace Platformer2D
{
    internal sealed class ParalaxManager 
    {
        private Camera _mainCamera;
        private Transform _backTransform;
        private Vector3 _cameraStartPos;
        private Vector3 _backGroundStartPos;

        public ParalaxManager(Camera mainCamera, Transform backTransform)
        {
            _mainCamera = mainCamera;
            _backTransform = backTransform;
            _cameraStartPos = _mainCamera.transform.position;
            _backGroundStartPos = backTransform.position;
        }

        public void Update()
        {
            _backTransform.position = _backGroundStartPos + (_mainCamera.transform.position - _cameraStartPos) * ConstantForProject.CoefForParalax;
        }
        
    }
}
