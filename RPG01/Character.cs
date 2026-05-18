using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG01
{
    public class Character
    {
        public string Name;
        public int HP;
        public int Level;
        public float DefenseRate = 1.0f;
        public int MaxHp;
        public int Attack;

        public int Hp
        {
            get { return HP; }
            set
            {
                if (value < 0)
                    HP = 0;
                else if (value > MaxHp)
                    HP = MaxHp;
                else
                    HP = value;
            }
        }
        private void Die()
        {
            Console.WriteLine($"{Name}이 죽었습니다.");
        }

        public void ShowInfo()
        {
            Console.WriteLine($"이름: {Name}");
            Console.WriteLine($"체력: {HP}/{MaxHp}");
            Console.WriteLine($"레벨: {Level}");
            Console.WriteLine($"공격력: {Attack}");
        }

        public void TakeDamage(int damage)
        {
            HP -= damage;
            Console.WriteLine($"{Name}이 {damage}만큼의 데미지를 공격받았다!");
            if (HP <= 0)
            {
                Die();
            }
        }
    }
}
