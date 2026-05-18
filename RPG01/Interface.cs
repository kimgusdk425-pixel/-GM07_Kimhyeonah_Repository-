using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG01
{
    interface IAttackable
    {
        void Attack();
    }
    interface IDefenseable
    {
        void TakeDamage(int damage);
    }
    internal class Interface
    {
    }
}
