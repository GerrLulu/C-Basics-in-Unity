using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Geekbrains
{
    public sealed class GameController : MonoBehaviour, IDisposable
    {
        [Header ("Выбор вида фигуры")]
        public PlayerType PlayerType = PlayerType.Ball;
        [Header("Кол-во очков, который отнимает BadBonus")]
        public int MinusScore;
        [Header("Кол-во очков, который добовляет GoodBonus")]
        public int PlusScore;
        [Header("Необходимое кол-во очков для победы")]
        public int RequiredValue;
        [Space(20)]
        [Header("Скорость игрока")]
        public float SpeedPlayer;
        [Header("Ускорение в n раз")]
        [Range (2.0f, 10.0f)]
        public float BoostSpeedPlayer;
        [Header("Замедление в n раз")]
        [Range(0.1f, 0.9f)]
        public float RediceSpeedPlayer;

        private PlayerBase _player;
        private CloneInteractiveObject _cloneInteractiveObject;
        private ListExecuteObject _interactiveObject;
        private EndGame _endGame;
        private DisplayBonuses _displayBonuses;
        private DisplayEndGame _displayEndGame;
        private Reference _reference;
        private CameraController _cameraController;
        private InputController _inputController;
        private int _countBonuses = 0;
        

        private void Awake()
        {
            _cloneInteractiveObject = new CloneInteractiveObject();

            _interactiveObject = new ListExecuteObject();

            _reference = new Reference();

            _player = null;
            if(PlayerType == PlayerType.Ball)
            {
                _player = _reference.PlayerBall;
            }
            else if(PlayerType == PlayerType.Cube)
            {
                _player = _reference.PlayerCube;
            }

            SpeedPlayer = _player.Speed;

            _cameraController = new CameraController(_player.transform, _reference.MainCamera.transform);
            _interactiveObject.AddExecuteObject(_cameraController);

            if(Application.platform == RuntimePlatform.WindowsEditor)
            {
                _inputController = new InputController(_player, _interactiveObject);
                _interactiveObject.AddExecuteObject(_inputController);
            }

            _displayBonuses = new DisplayBonuses(_reference.CountBonus);
            _displayEndGame = new DisplayEndGame(_reference.EndGameLable);
            
            foreach(var o in _interactiveObject)
            {
                if (o is GoodBonus goodBonus)
                {
                    goodBonus.OnScoreChange += PlusBonus;
                }
                if (o is BadBonus badBonus)
                {
                    badBonus.OnScoreChange += MinusBonus;
                }
                if(o is SpeedBonus speedBonus)
                {
                    speedBonus.OnSpeedChange += BoostSpeed;
                }
                if(o is SlowdownBonus slowdownBonus)
                {
                    slowdownBonus.OnChangeSpeed += SlowdownSpeed;
                }
            }

            _endGame = FindObjectOfType<EndGame>();
            _endGame.OnGameChange += GameEnd;

            //_reference.RestartButton.onClick.AddListener(RestartGame);
            //_reference.RestartButton.gameObject.SetActive(false);
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1.0f;
        }

        private void GameEnd()
        {
            if(_countBonuses >= RequiredValue)
            {
                _displayEndGame.WinGame(_countBonuses);
            }
            else
            {
                _displayEndGame.LoseGame(_countBonuses);
            }
            //_reference.RestartButton.gameObject.SetActive(true);
            Time.timeScale = 0.0f;
        }

        private void PlusBonus(int value)
        {
            value = PlusScore;
            _countBonuses += value;
            _displayBonuses.Display(_countBonuses);
        }

        private void MinusBonus(int value)
        {
            value = MinusScore;
            _countBonuses -= value;
            _displayBonuses.Display(_countBonuses);
        }

        private void BoostSpeed(float value)
        {
            value = BoostSpeedPlayer;
            _player.Booster(value);
        }

        private void SlowdownSpeed(float value)
        {
            value = RediceSpeedPlayer;
            _player.Slowdowner(value);
        }

        private void Update()
        {
            for (var i = 0; i < +_interactiveObject.Length; i++)
            {
                var interactiveObject = _interactiveObject[i];
                if(interactiveObject == null)
                {
                    continue;
                }
                interactiveObject.Execute();
            }
        }

        public void Dispose()
        {
            foreach(var o in _interactiveObject)
            {
                if (o is GoodBonus goodBonus)
                {
                    goodBonus.OnScoreChange -= PlusBonus;
                }
                if (o is BadBonus badBonus)
                {
                    badBonus.OnScoreChange -= MinusBonus;
                }
                if (o is SpeedBonus speedBonus)
                {
                    speedBonus.OnSpeedChange -= BoostSpeed;
                }
                if (o is SlowdownBonus slowdownBonus)
                {
                    slowdownBonus.OnChangeSpeed -= SlowdownSpeed;
                }
            }
        }
    }
}