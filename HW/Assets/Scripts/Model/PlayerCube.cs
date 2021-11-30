using UnityEngine;

namespace Geekbrains
{
    public sealed class PlayerCube : PlayerBase
    {
        public override void Move(float x, float y, float z)
        {
            transform.Translate(x * Speed * Time.deltaTime, y, z * Speed * Time.deltaTime);
        }
    }
}