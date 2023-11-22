using Ships.Common;
using Ships.Weapons.Projectiles;
using UnityEngine;

namespace Ships.Weapons
{
    public class ProjectileFactory
    {
        private readonly ProjectilesConfiguration _configuration;

        public ProjectileFactory(ProjectilesConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Projectile Create(string id, Vector3 position, Quaternion rotation, Teams team)
        {
            var prefab = _configuration.GetProjectileById(id);

            var projectile = Object.Instantiate(prefab, position, rotation);
            projectile.Configure(team);
            
            return projectile;
        }
    }
}
