using System;
using UnityEngine;

namespace Geekbrains
{
    public sealed class InputController : IExecute
    {
        private readonly PlayerBase _playerBase;
        private readonly ListExecuteObject _interactiveObject;
        private readonly ISaveDataRepository _saveDataRepository;
        private readonly KeyCode _save = KeyCode.F5;
        private readonly KeyCode _load = KeyCode.F9;

        public InputController (PlayerBase player, ListExecuteObject interactiveObject)
        {
            _playerBase = player;
            _interactiveObject = interactiveObject;
            _saveDataRepository = new SaveDataRepository();
        }

        public void Execute()
        {
            _playerBase.Move(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

            if (Input.GetKeyDown(_save))
            {
                _saveDataRepository.Save(_playerBase, _interactiveObject);
            }
            if (Input.GetKeyDown(_load))
            {
                _saveDataRepository.Load(_playerBase, _interactiveObject);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _playerBase.StartCoroutine(new PhotoController().DoTapExampleAsync());
            }
        }
    }
}