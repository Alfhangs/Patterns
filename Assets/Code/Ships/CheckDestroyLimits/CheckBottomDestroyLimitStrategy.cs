using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CheckDestroyLimit
{
    public class CheckBottomDestroyLimitStrategy : ICheckDestroyLimit
    {
        private Camera _camera;

        public CheckBottomDestroyLimitStrategy(Camera camera)
        {
            _camera = camera;
        }
        public bool IsInsideLimits(Vector3 position)
        {
            var viewportPoint = _camera.WorldToViewportPoint(position);
            return viewportPoint.y > 0;
        }
    }
}