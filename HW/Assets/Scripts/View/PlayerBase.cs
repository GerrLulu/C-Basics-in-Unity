using System.Collections;
using UnityEngine;
using static UnityEngine.Debug;

namespace Geekbrains
{
    public abstract class PlayerBase : MonoBehaviour
    {
        public float Speed;

        public abstract void Move(float x, float y, float z);

        public void Booster(float value)
        {
            StartCoroutine(BoostSpeed(value));
        }

        public void Slowdowner(float value)
        {
            StartCoroutine(Deceleration(value));
        }

        private IEnumerator BoostSpeed(float boost)
        {
            Speed = Speed * boost;
            Log("�������� �����������");
            yield return new WaitForSeconds(10.0f);
            Speed = Speed / boost;
            Log("�������� ��������� � �����");
        }

        private IEnumerator Deceleration(float slow)
        {
            Speed = Speed * slow;
            Log("�������� �����������");
            yield return new WaitForSeconds(10.0f);
            Speed = Speed * slow;
            Log("�������� ��������� � �����");
        }
    }
}