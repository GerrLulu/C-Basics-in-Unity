using System;
using Object = UnityEngine.Object;

namespace Geekbrains
{
    public sealed class CloneInteractiveObject
    {
        public CloneInteractiveObject()
        {
            var interactiveObjects = Object.FindObjectsOfType<InteractiveObject>();
            for (var i = 0; i < interactiveObjects.Length; i++)
            {
                if (interactiveObjects[i] is ICloneable clonableInteractiveObject)
                {
                    clonableInteractiveObject.Clone();
                }
            }
        }
    }
}