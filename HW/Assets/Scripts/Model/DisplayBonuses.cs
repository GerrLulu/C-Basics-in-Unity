using System;
using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains
{
    public sealed class DisplayBonuses
    {
        private Text _sumBonusesLable;
        public DisplayBonuses(GameObject bonus)
        {
            _sumBonusesLable = bonus.GetComponentInChildren<Text>();
            _sumBonusesLable.text = String.Empty;
        }

        public void Display(int value)
        {
            _sumBonusesLable.text = $"Вы набрали {value}";
        }
    }
}