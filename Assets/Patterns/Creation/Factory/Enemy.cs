using UnityEngine;

namespace Patterns.Creation.Factory
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyId _id;

        public string Id => _id.Value;
    }
}
