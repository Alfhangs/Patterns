using Ships;
using Ships.Enemies;
using UI;
using UnityEngine;

namespace Battle
{
    public class GameFacade : MonoBehaviour
    {
        [SerializeField] private ScreenFade screenFade;
        [SerializeField] private ShipInstaller shipInstaller;
        [SerializeField] private EnemySpawner enemySpawner;
        [SerializeField] private GameState gameState;
        public void StartBattle()
        {
            gameState.Reset();
            ScoreView.Instance.Reset();
            enemySpawner.StartSpawn();
            shipInstaller.SpawnUserShip();
            screenFade.Hide();
        }

        public void StopBattle()
        {
            screenFade.Show();
            enemySpawner.StopAndReset();
        }
    }
}
