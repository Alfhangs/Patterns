using UnityEngine;

namespace Patterns.Behaviour.TemplateMethod
{
    [CreateAssetMenu(menuName = "TemplateMethod/Create HealSkill", fileName = "HealSkill", order = 0)]
    public class HealSkill : ActiveSkill
    {
        [SerializeField] private int healthToAdd;

        protected override void DoUpdate()
        {
        }

        protected override void DoActivate(Hero hero)
        {
            healthToAdd = 10;
            hero.AddHealth(healthToAdd);
        }
    }
}
