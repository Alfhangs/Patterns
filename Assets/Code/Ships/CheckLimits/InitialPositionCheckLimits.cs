using UnityEngine;

namespace Ships.CheckLimits
{
    public class InitialPositionCheckLimits : CheckLimits
    {
        private readonly Transform _transform;
        private readonly Vector3 _initialPosition;
        private readonly float _maxDistance;

        public InitialPositionCheckLimits(Transform transform, float maxDistance)
        {
            _transform = transform;
            _maxDistance = maxDistance;
            _initialPosition = _transform.position;
        }
        
        public Vector2 ClampFinalPosition(Vector2 currentPosition)
        {
            var finalPosition = currentPosition;
            var distance = Mathf.Abs(currentPosition.x - _initialPosition.x);
            if (distance <= _maxDistance) 
                return currentPosition;
            
            if (currentPosition.x > _initialPosition.x)
            {
                finalPosition.x = _initialPosition.x + _maxDistance;
            }
            else
            {
                finalPosition.x = _initialPosition.x - _maxDistance;
            }

            return finalPosition;
        }
    }
}
