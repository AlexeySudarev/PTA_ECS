using Game.View.Shared;
using UnityEngine;

namespace Game.Characters
{
    public class CharacterView : MonoBehaviour, ICharacterView
    {
        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }
    }
}