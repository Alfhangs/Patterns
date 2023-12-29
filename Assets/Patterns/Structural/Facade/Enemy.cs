using System;

namespace Patterns.Structural.Facade
{
    [Serializable]
    public class Enemy : Hero
    {
        public int Stamina;

        public Enemy(int health, int stamina) : base(health)
        {
            Stamina = stamina;
        }
    }
}
