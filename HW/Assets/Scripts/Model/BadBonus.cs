using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Geekbrains
{
    public sealed class BadBonus : InteractiveObject, IFly, IRotation, ICloneable
    {
        private int MinusScore;
        public event Action<int> OnScoreChange = delegate (int i) { };
        private float _lengthFly;
        private float _speedRotation;

        private void Awake()
        {
            _lengthFly = Random.Range(1.0f, 2.0f);
            _speedRotation = Random.Range(10.0f, 50.0f);
        }

        protected override void Interaction()
        {
            OnScoreChange?.Invoke(MinusScore);
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
            return Instantiate(gameObject, new Vector3(6.84f, 0.6f, 0.44f),
                transform.rotation, transform.parent);
        }
    }
}