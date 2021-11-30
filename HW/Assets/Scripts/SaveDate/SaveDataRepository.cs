using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEngine;

namespace Geekbrains
{
    public sealed class SaveDataRepository : ISaveDataRepository
    {
        private readonly IData<SavedData> _data;

        private const string _folderName = "quickSave";
        private const string _fileName = "QuickSaveData.bat";
        private readonly string _path;

        public SaveDataRepository()
        {
            _data = new SerializableXMLData<SavedData>();
            _path = Path.Combine(Application.dataPath, _folderName);
        }

        public void Save(PlayerBase player, ListExecuteObject interactiveObject)
        {
            if (!Directory.Exists(Path.Combine(_path)))
            {
                Directory.CreateDirectory(_path);
            }
            var saveGame = new SavedData
            {
                SaveObject = new List<SaveObject>(),
            };

            saveGame.SaveObject.Add(new SaveObject()
            {
                Position = player.transform.position,
                Name = player.name,
                IsEnabled = true
            });

            foreach (var o in interactiveObject)
            {
                if (o is GoodBonus goodBonus)
                {
                    saveGame.SaveObject.Add(new SaveObject()
                    {
                        Position = goodBonus.transform.position,
                        Name = goodBonus.name,
                        IsEnabled = goodBonus.IsInteractable
                    });
                }
                if (o is BadBonus badBonus)
                {
                    saveGame.SaveObject.Add(new SaveObject()
                    {
                        Position = badBonus.transform.position,
                        Name = badBonus.name,
                        IsEnabled = badBonus.IsInteractable
                    });
                }
                if (o is SpeedBonus speedBonus)
                {
                    saveGame.SaveObject.Add(new SaveObject()
                    {
                        Position = speedBonus.transform.position,
                        Name = speedBonus.name,
                        IsEnabled = speedBonus.IsInteractable
                    });
                }
                if (o is SlowdownBonus slowdownBonus)
                {
                    saveGame.SaveObject.Add(new SaveObject()
                    {
                        Position = slowdownBonus.transform.position,
                        Name = slowdownBonus.name,
                        IsEnabled = slowdownBonus.IsInteractable
                    });
                }
            }

            _data.Save(saveGame, Path.Combine(_path, _fileName));
            Debug.Log("Save");
        }

        public void Load(PlayerBase player, ListExecuteObject interactiveObject)
        {
            var file = Path.Combine(_path, _fileName);
            if (!File.Exists(file))
            {
                throw new DataException($"File {file} not found.");
            }
            var loadGame = _data.Load(file);

            foreach (var saveObject in loadGame.SaveObject)
            {
                if(saveObject.Name == player.name)
                {
                    player.transform.position = saveObject.Position;
                    player.gameObject.SetActive(saveObject.IsEnabled);
                }
          
                foreach (var o in interactiveObject)
                {


                    if(o is GoodBonus goodBonus)
                    {
                        if(saveObject.Name == goodBonus.name)
                        {
                            goodBonus.transform.position = saveObject.Position;
                            goodBonus.gameObject.SetActive(saveObject.IsEnabled);
                        }
                    }
                    if (o is BadBonus badBonus)
                    {
                        if (saveObject.Name == badBonus.name)
                        {
                            badBonus.transform.position = saveObject.Position;
                            badBonus.gameObject.SetActive(saveObject.IsEnabled);
                        }
                    }
                    if (o is SpeedBonus speedBonus)
                    {
                        if (saveObject.Name == speedBonus.name)
                        {
                            speedBonus.transform.position = saveObject.Position;
                            speedBonus.gameObject.SetActive(saveObject.IsEnabled);
                        }
                    }
                    if (o is SlowdownBonus slowdownBonus )
                    {
                        if (saveObject.Name == slowdownBonus.name)
                        {
                            slowdownBonus.transform.position = saveObject.Position;
                            slowdownBonus.gameObject.SetActive(saveObject.IsEnabled);
                        }
                    }
                }
            }

            Debug.Log("Load");
        }
    }
}