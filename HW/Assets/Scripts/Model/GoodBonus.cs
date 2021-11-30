using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Geekbrains
{
    public sealed class GoodBonus : InteractiveObject, IFly, IFlicker, ICloneable
    {
        public int PlusScore;
        public event Action<int> OnScoreChange = delegate (int i) { };
        private Material _material;
        private float _lengthFly;

        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
            _lengthFly = Random.Range(1.0f, 2.0f);
        }

        protected override void Interaction()
        {
            OnScoreChange.Invoke(PlusScore);
        }

        public override void Execute()
        {
            if (!IsInteractable) { return; }
            Fly();
            Flicker();
        }

        public void Fly()
        {
            transform.localPosition = new Vector3(transform.localPosition.x,
                Mathf.PingPong(Time.time, _lengthFly),
                transform.localPosition.z);
        }

        public void Flicker()
        {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b,
                Mathf.PingPong(Time.time, 1.0f));
        }

        public object Clone()
        {
            return Instantiate(gameObject, new Vector3(6.77f, 0.6f, -5.38f),
                transform.rotation,transform.parent);
        }
    }
}