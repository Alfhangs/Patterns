using Patterns.Creation.Builder.Armors;
using Patterns.Creation.Builder.Weapons;
using UnityEngine;

namespace Patterns.Creation.Builder
{
    public class Hero : MonoBehaviour
    {
        [SerializeField] private Transform _weaponPosition;
        [SerializeField] private Transform _armorPosition;

        public void SetComponents(Weapon weapon, Armor armor)
        {
            weapon.transform.position = _weaponPosition.position;
            armor.transform.position = _armorPosition.position;
        }
    }
}
