using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Geekbrains
{
    public sealed class SlowdownBonus : InteractiveObject, IFly, IRotation, ICloneable
    {
        private float RediceSpeed;
        public event Action<float> OnChangeSpeed = delegate (float i) { };
        private float _lengthFly;
        private float _speedRotation;

        private void Awake()
        {
            _lengthFly = Random.Range(1.0f, 2.0f);
            _speedRotation = Random.Range(10.0f, 50.0f);
        }

        protected override void Interaction()
        {
            OnChangeSpeed?.Invoke(RediceSpeed);
        }

        public override void Execute()
        {
            if (!IsInteractable) { return; }
            Fly();
            Rotation();
        }

        public void Fly()
        {
            transform.localPosition = new Vector3(transform.localPosition.x,
                Mathf.PingPong(Time.time, _lengthFly),
                transform.localPosition.z);
        }

        public void Rotation()
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * _speedRotation), Space.World);
        }

        public object Clone()
        {
            return Instantiate(gameObject, new Vector3(-6.79f, 0.6f, 0.53f),
                transform.rotation, transform.parent);
        }
    }
}