using Ships.Common;
using Ships.Weapons.Projectiles;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Ships.Weapons
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private ProjectilesConfiguration _projectilesConfiguration;
        private float _fireRateInSeconds;
        [SerializeField] private Transform _projectileSpawnPosition;
        private float _remainingSecondsToBeAbleToShoot;
        private ProjectileFactory _projectileFactory;

        private string _activeProjectileId;
        private Ship _ship;
        private Teams _team;

        private List<Projectile> _aliveProjectiles;
        private void Awake()
        {
            var instance = Instantiate(_projectilesConfiguration);
            _projectileFactory = new ProjectileFactory(instance);
            _aliveProjectiles = new List<Projectile>();
        }

        public void Configure(Ship ship, float fireRate, ProjectileId defaultProjectileId, Teams team)
        {
            _ship = ship;
            _activeProjectileId = defaultProjectileId.Value;
            _fireRateInSeconds = fireRate;
            _team = team;
        }

        public void TryShoot()
        {
            _remainingSecondsToBeAbleToShoot -= Time.deltaTime;
            if (_remainingSecondsToBeAbleToShoot > 0)
            {
                return;
            }

            Shoot();
        }

        private void Shoot()
        {
            var projectile = _projectileFactory
               .Create(_activeProjectileId,
                       _projectileSpawnPosition.position,
                       _projectileSpawnPosition.rotation,
                       _team
                       );
            _aliveProjectiles.Add(projectile);
            projectile.OnDestroyProjectile += OnProjectileDestroy;
            _remainingSecondsToBeAbleToShoot = _fireRateInSeconds;
        }

        private void OnProjectileDestroy(Projectile projectile)
        {
            _aliveProjectiles.Remove(projectile);
            projectile.OnDestroyProjectile -= OnProjectileDestroy;
        }

        internal void Restart()
        {
            foreach (var projectile in _aliveProjectiles)
            {
                Destroy(projectile.gameObject);
            }
            _aliveProjectiles.Clear();
        }
    }
}
