using System;
using UnityEngine;

namespace Geekbrains
{
    public sealed class EndGame : MonoBehaviour
    {
        public event Action OnGameChange = delegate () { };

        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag("Player"))
            {
                return;
            }
            Debug.Log("!!!!");
            FinishGame();
        }

        private void FinishGame()
        {
            OnGameChange?.Invoke();
        }
    }
}