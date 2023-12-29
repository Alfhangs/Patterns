using UnityEngine;

namespace Patterns.Structural.Facade
{
    public class PlayerSpawner : MonoBehaviour
    {
        public Player Player = new Player(100, 100);
    }
}
