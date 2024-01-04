using System;
using System.Collections;
using Ships.Common;
using UnityEngine;

namespace Ships.Weapons.Projectiles
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Projectile : MonoBehaviour, Damageable
    {
        [SerializeField] protected Rigidbody2D _rigidbody2D;
        [SerializeField] private ProjectileId _id;
        public Teams Team { get; private set; }

        protected Transform MyTransform;

        public Action<Projectile> OnDestroyProjectile;

        public string Id => _id.Value;

        public void Configure(Teams team)
        {
            Team = team;
        }
        
        private void Start()
        {
            MyTransform = transform;
            DoStart();
            StartCoroutine(DestroyIn(5));
        }

        protected abstract void DoStart();

        private void FixedUpdate()
        {
            DoMove();
        }

        protected abstract void DoMove();

        private void OnTriggerEnter2D(Collider2D other)
        {
            var damageable = other.GetComponent<Damageable>();
            if (damageable.Team == Team)
            {
                return;
            }
            
            damageable.AddDamage(1);
        }

        private IEnumerator DestroyIn(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            DestroyProjectile();
        }

        private void DestroyProjectile()
        {
            DoDestroy();
            OnDestroyProjectile?.Invoke(this);
            Destroy(gameObject);
        }

        protected abstract void DoDestroy();
        public void AddDamage(int amount)
        {
            DestroyProjectile();
        }

    }
}
