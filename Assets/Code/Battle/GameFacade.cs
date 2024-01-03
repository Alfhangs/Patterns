using Patterns.Decoupling.ServiceLocator;
using Ships;
using Ships.Enemies;
using UI;
using UnityEngine;

namespace Battle
{
    public class GameFacade : MonoBehaviour, IGameFacade
    {
    
        public void StopBattle()
        {
            ServiceLocator.Instance.GetService<LoadingScreen>().Show();
            ServiceLocator.Instance.GetService<EnemySpawner>().StopAndReset();
        }
    }
}
