using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CheckDestroyLimit
{
    public class DoNotCheckDestroyLimitStrategy : ICheckDestroyLimit
    {
        public bool IsInsideLimits(Vector3 position)
        {
            return true;
        }
    }
}