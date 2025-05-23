using Actors.Enemy.Data.Scripts;
using DefaultNamespace.Enums;

namespace Enemy.StatSystems.Armour
{
    public class EnemyArmour
    {
        private float _physicArmour;
        private float _magicArmour;

        public EnemyArmour(EnemyScrObj enemyData)
        {
            _physicArmour = enemyData.PhysicArmour;
            _magicArmour = enemyData.MagicArmour;
        }

        public float GetArmour(DamageType damageType)
        {
            switch (damageType)
            {
                case DamageType.Physic:
                    return _physicArmour;
                case DamageType.Magic:
                    return _magicArmour;
            }

            return 0;
        }
    }
}