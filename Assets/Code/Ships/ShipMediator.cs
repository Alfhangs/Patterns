using System;
using Patterns.Decoupling.ServiceLocator;
using Ships.Common;
using Ships.Weapons;
using UI;
using UnityEngine;

namespace Ships
{
    [RequireComponent(typeof(MovementController))]
    [RequireComponent(typeof(WeaponController))]
    public class ShipMediator : MonoBehaviour, Ship, EventObserver
    {
        [SerializeField] private MovementController _movementController;
        [SerializeField] private WeaponController _weaponController;
        [SerializeField] private HealthController _healthController;

        [SerializeField] private ShipId _shipId;
        public string Id => _shipId.Value;

        private CheckDestroyLimit.ICheckDestroyLimit _checkDestroyLimit;
        private Input.Input _input;
        private Teams _team;
        private int _score;

        private void Start()
        {
            ServiceLocator.Instance.GetService<IEventQueue>().Subscribe(EventIds.Restart, this);
            ServiceLocator.Instance.GetService<IEventQueue>().Subscribe(EventIds.GameOver, this);
            ServiceLocator.Instance.GetService<IEventQueue>().Subscribe(EventIds.Victory, this);
        }

        private void OnDestroy()
        {
            ServiceLocator.Instance.GetService<IEventQueue>().UnSubscribe(EventIds.Restart, this);
            ServiceLocator.Instance.GetService<IEventQueue>().UnSubscribe(EventIds.GameOver, this);
            ServiceLocator.Instance.GetService<IEventQueue>().UnSubscribe(EventIds.Victory, this);
        }

        public void Configure(ShipConfiguration configuration)
        {
            _checkDestroyLimit = configuration.CheckDestroyLimit;
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
            CheckDestroyLimits();
        }
        private void CheckDestroyLimits()
        {
            if (_checkDestroyLimit.IsInsideLimits(transform.position))
            {
                return;
            }
            Destroy(gameObject);
            var shipDestroyEventData = new ShipDestroyedEventData(0, _team, GetInstanceID());
            ServiceLocator.Instance.GetService<IEventQueue>().EnqueueEvent(shipDestroyEventData);
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
                var shipDestroyEventData = new ShipDestroyedEventData(_score, _team, GetInstanceID());
                ServiceLocator.Instance.GetService<IEventQueue>().EnqueueEvent(shipDestroyEventData);
            }
        }

        public void Process(EventData eventData)
        {
            if (eventData.EventId != EventIds.GameOver && eventData.EventId != EventIds.Victory && eventData.EventId != EventIds.Restart)
                return;

            _weaponController.Restart();
            Destroy(gameObject);
        }
    }
}
