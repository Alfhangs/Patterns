using Patterns.Decoupling.ServiceLocator;
using Ships;
using Ships.Enemies;
using UI;
using UnityEngine;

namespace Battle
{
    public class GameFacade : MonoBehaviour, IGameFacade
    {
        [SerializeField] private ShipInstaller shipInstaller;
        [SerializeField] private EnemySpawner enemySpawner;
        [SerializeField] private GameStateController gameState;

        public void StartBattle()
        {
            gameState.Reset();
            ScoreView.Instance.Reset();
            enemySpawner.StartSpawn();
            shipInstaller.SpawnUserShip();
            ServiceLocator.Instance.GetService<LoadingScreen>().Hide();
        }

        public void StopBattle()
        {
            ServiceLocator.Instance.GetService<LoadingScreen>().Show();
            enemySpawner.StopAndReset();
        }
    }
}
