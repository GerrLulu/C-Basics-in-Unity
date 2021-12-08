using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains
{
    public class Reference
    {
        private PlayerBall _playerBall;
        private PlayerCube _playerCube;
        private Camera _mainCamera;
        private Canvas _canvas;
        private GameObject _countBonus;
        private GameObject _endGameLable;
        private Button _restartButton;
        private BadBonus _badBonus;
        private GoodBonus _goodBonus;
        private SlowdownBonus _slowdownBonus;
        private SpeedBonus _speedBonus;

        public SpeedBonus SpeedBonus
        {
            get
            {
                if (_speedBonus = null)
                {
                    var gameObject = Resources.Load<SpeedBonus>("Prefabs/SpeedBonus");
                    _speedBonus = Object.Instantiate(gameObject, new Vector3(3.94f, 0.6f, -6.73f), gameObject.transform.rotation);
                }
                return _speedBonus;
            }
        }

        public SlowdownBonus SlowdownBonus
        {
            get
            {
                if (_slowdownBonus = null)
                {
                    var gameObject = Resources.Load<SlowdownBonus>("Prefabs/SlowdownBonus");
                    _slowdownBonus = Object.Instantiate(gameObject, new Vector3(1.54f, 0.6f, -5.26f), gameObject.transform.rotation);
                }
                return _slowdownBonus;
            }
        }

        public GoodBonus GoodBonus
        {
            get
            {
                if(_goodBonus = null)
                {
                    var gameObject = Resources.Load<GoodBonus>("Prefabs/GoodBonus");
                    _goodBonus = Object.Instantiate(gameObject, new Vector3(-6.5f, 0.6f, -6.7f), gameObject.transform.rotation);
                }
                return _goodBonus;
            }
        }
        
        public BadBonus BadBonus
        {
            get
            {
                if(_badBonus = null)
                {
                    var gameObject = Resources.Load<BadBonus>("Prefabs/BadBonus");
                    _badBonus = Object.Instantiate(gameObject, new Vector3(-6.88f, 0.6f, -0.92f), gameObject.transform.rotation);
                }
                return _badBonus;
            }
        }

        public Canvas Canvas
        {
            get
            {
                if(_canvas == null)
                {
                    _canvas = Object.FindObjectOfType<Canvas>();
                }
                return _canvas;
            }
        }

        public GameObject CountBonus
        {
            get
            {
                if(_countBonus == null)
                {
                    var gameObject = Resources.Load<GameObject>("UI/CountBonuse");
                    _countBonus = Object.Instantiate(gameObject, Canvas.transform);
                }
                return _countBonus;
            }
        }

        public GameObject EndGameLable
        {
            get
            {
                if (_endGameLable == null)
                {
                    var gameObject = Resources.Load<GameObject>("UI/EndGame");
                    _endGameLable = Object.Instantiate(gameObject, Canvas.transform);
                }
                return _endGameLable;
            }
        }

        public Button RestartButton
        {
            get
            {
                if (_restartButton = null)
                {
                    var gameObject = Resources.Load<Button>("UI/RestartButton");
                    _restartButton = Object.Instantiate(gameObject, Canvas.transform);
                }
                return _restartButton;
            }
        }

        public PlayerBall PlayerBall
        {
            get
            {
                if (_playerBall == null)
                {
                    var gameObject = Resources.Load<PlayerBall>("Prefabs/PlayerBall");
                    _playerBall = Object.Instantiate(gameObject, new Vector3(6.44f, 0.84f, -6.64f), gameObject.transform.rotation);
                }
                return _playerBall;
            }
        }

        public PlayerCube PlayerCube
        {
            get
            {
                if (_playerCube == null)
                {
                    var gameObject = Resources.Load<PlayerCube>("Prefabs/PlayerCube");
                    _playerCube = Object.Instantiate(gameObject, new Vector3(6.44f, 0.84f, -6.64f), gameObject.transform.rotation);
                }
                return _playerCube;
            }
        }

        public Camera MainCamera
        {
            get
            {
                if(_mainCamera == null)
                {
                    _mainCamera = Camera.main;
                }
                return _mainCamera;
            }
        }
    }
}