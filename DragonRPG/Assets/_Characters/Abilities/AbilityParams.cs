﻿using _Core;

namespace _Characters.Abilities
{
    public class AbilityParams
    {
        public IDamageable Target { get; set; }
        public float PlayerBaseDamage { get; set; }

        public AbilityParams(IDamageable target, float playerBaseDamage)
        {
            Target = target;
            PlayerBaseDamage = playerBaseDamage;
        }
    }
}
