using System;
using Ships.Common;
using Ships.Weapons;
using UI;
using UnityEngine;

namespace Ships
{
    [RequireComponent(typeof(MovementController))]
    [RequireComponent(typeof(WeaponController))]
    public class ShipMediator : MonoBehaviour, Ship
    {
        [SerializeField] private MovementController _movementController;
        [SerializeField] private WeaponController _weaponController;
        [SerializeField] private HealthController _healthController;

        [SerializeField] private ShipId _shipId;
        public string Id => _shipId.Value;

        private Input.Input _input;
        private Teams _team;
        private int _score;

        public void Configure(ShipConfiguration configuration)
        {
            _input = configuration.Input;
            _movementController.Configure(this, configuration.CheckLimits, configuration.Speed);
            _weaponController.Configure(this, configuration.FireRate, configuration.DefaultProjectileId, configuration.Team);
            _healthController.Configure(this, configuration.Health, configuration.Team);
            _team = configuration.Team;
            _score = configuration.Score;
        }

        private void FixedUpdate()
        {
            var direction = _input.GetDirection();
            _movementController.Move(direction);
        }

        private void Update()
        {
            TryShoot();
        }

        private void TryShoot()
        {
            if (_input.IsFireActionPressed())
            {
                _weaponController.TryShoot();
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var damageable = other.GetComponent<Damageable>();
            if (damageable.Team == _team)
            {
                return;
            }
            
            damageable.AddDamage(1);
        }

        public void OnDamageReceived(bool isDeath)
        {
            if (isDeath)
            {
                Destroy(gameObject);
                var shipDestroyEventData = new ShipDestroyedEventData(_score, _team);
                EventQueue.Instance.EnqueueEvent(shipDestroyEventData);                
            }
        }
    }
}
