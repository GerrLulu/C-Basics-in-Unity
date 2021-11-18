using UnityEngine;

namespace Geekbrains
{
    public sealed class CameraController : IExecute
    {
        private Transform _player;
        private Transform _mainCamera;

        public CameraController(Transform player, Transform mainCamera)
        {
            _player = player;
            _mainCamera = mainCamera;
            _mainCamera.Rotate(Vector3.right, 90.0f);
        }

        public void Execute()
        {
            _mainCamera.position = _player.position + Vector3.up * 18;
        }
    }
}