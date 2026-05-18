using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RPG01
{
    internal class Battle
    {
        public void ShowBattle(Player player, Monster monster)
        {
            while (player.HP > 0 && monster.HP > 0)
            {
                Console.Clear();
                Console.WriteLine("====전투 시작!!====");
                Console.WriteLine($"{player.Name} Hp : {player.HP} / {player.MaxHP}");
                Console.WriteLine($"{monster.Name} Hp : {monster.HP} / {monster.MaxHP}");

                Console.WriteLine();
                Console.WriteLine("1. 공격");
                Console.WriteLine("2. 아이템 사용");
                Console.WriteLine("3. 도망");

                Console.Write("입력 : ");
                string input = Console.ReadLine();

                bool playerActed = false; 
                switch (input) //이번엔 문자열로 받아봄..
                {
                    case "1":
                        PlayerAttack(player, monster);
                        playerActed = true;
                        break;

                    case "2":
                        UseItem(player);
                        playerActed = true;
                        break;
                    case "3": Console.WriteLine("도망쳤습니다!"); return;
                    default: Console.WriteLine("잘못 입력했습니다."); break;
                }

                //몬스터 살아있으면 공격
                if (playerActed && monster.HP > 0)
                {
                    MonsterAttack(player, monster);
                }

                Console.WriteLine();
                Console.WriteLine("계속하려면 엔터...");
                Console.ReadLine();
            }

            //승패 판정
            if (player.HP <= 0)
            {
                Console.WriteLine("패배...");
                player.HP = player.MaxHP; // 리셋
            }
            else
            {
                Console.WriteLine("승리!");
            }
        }
        private void PlayerAttack(Player player, Monster monster)
        {
            int damage = player.Attack;
            monster.TakeDamage(damage);

            Console.WriteLine($"{player.Name}이(가) {damage}데미지를 입혔다!");
        }
        private void MonsterAttack(Player player, Monster monster)
        {
            int damage = monster.Attack - player.Defense;

            if (damage < 0)
                damage = 0;

            player.TakeDamage(damage);

            Console.WriteLine($"{monster.Name}이(가) {damage} 데미지를 입혔다!");
        }

        //아이템 사용하기!!
        private void UseItem(Player player)
        {

            Console.WriteLine("\n==== 인벤토리 ====");
            // 아이템 출력
            for (int i = 0; i < player.Inventory.Count; i++)
            {
                Item item = player.Inventory[i];

                Console.WriteLine($"{i + 1}. {item.Name}");
            }
            Console.WriteLine("===================");
            Console.WriteLine("0. 뒤로가기");

            Console.Write("사용할 아이템 번호 입력 : ");
            if (!int.TryParse(Console.ReadLine(), out int input))
            {
                Console.WriteLine("숫자를 입력하세요!");
                return;
            }

            if (input == 0)
            {
                Console.WriteLine("취소했습니다.");
                return;
            }

            // 범위 검사
            if (input < 1 || input > player.Inventory.Count)
            {
                Console.WriteLine("잘못된 입력!");
                return;
            }
            // 선택 아이템
            Item selected = player.Inventory[input - 1];

            // 플레이어 아이템 사용
            player.UseItem(selected);
        }
    }
}
