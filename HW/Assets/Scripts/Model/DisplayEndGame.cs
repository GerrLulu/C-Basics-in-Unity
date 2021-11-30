using System;
using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains
{
    public sealed class DisplayEndGame
    {
        private Text _finishGameLable;

        public DisplayEndGame(GameObject endGame)
        {
            _finishGameLable = endGame.GetComponentInChildren<Text>();
            _finishGameLable.text = String.Empty;
        }

        public void WinGame(int value)
        {
            _finishGameLable.text = $"�� �������� � ������� {value} �����";
        }

        public void LoseGame(int value)
        {
            _finishGameLable.text = $"�� ���������, ������ ��� ������� {value} �����";
        }
    }
}