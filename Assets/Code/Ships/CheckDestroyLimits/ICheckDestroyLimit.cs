using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CheckDestroyLimit
{
    public interface ICheckDestroyLimit
    {
        bool IsInsideLimits(Vector3 position);
    }
}