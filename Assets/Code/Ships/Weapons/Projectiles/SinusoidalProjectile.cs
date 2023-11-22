using UnityEngine;

namespace Ships.Weapons.Projectiles
{
    public class SinusoidalProjectile : Projectile
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _amplitude;
        [SerializeField] private float _frequency;

        private float _currentTime;
        private Vector3 _currentPosition;

        protected override void DoStart()
        {
            _currentTime = 0;
            _currentPosition = MyTransform.position;
        }

        protected override void DoMove()
        {
            _currentPosition += MyTransform.up * (_speed * Time.deltaTime);
            // horizontalPosition = amplitude * sin (x * frequency)
            var horizontalPosition = MyTransform.right * (_amplitude * Mathf.Sin(_currentTime * _frequency));

            _rigidbody2D.MovePosition(_currentPosition + horizontalPosition);

            _currentTime += Time.deltaTime;
        }

        protected override void DoDestroy()
        {
        }
    }
}
