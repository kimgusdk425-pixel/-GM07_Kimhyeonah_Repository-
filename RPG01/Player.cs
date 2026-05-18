using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RPG01
{
    public class Player
    {
        //위치
        public int X = 1;
        public int Y = 1;

        //기본 설정        
        public string Name;
        public int HP = 100;
        public int MaxHP = 100;
        public int Attack = 5;
        public int Defense = 0;

        //돈
        public int Gold = 500;

        //외부 접근 금지!
        private List<Item> inventory = new List<Item>();
        
        //읽기만 가능
        public List<Item> Inventory
        {
            get { return inventory; }
        }
        //목검추가
        public Player()
        {
            Inventory.Add(new Item
            {
                Name = "목검",
                Price = 0,
                Attack = 2,
                Type = ItemType.Weapon
            });
        }
        public void ShowInventory()
        {
            Console.WriteLine("====================");
            Console.WriteLine("======인벤토리======");
            if (Inventory.Count == 0)
            {
                Console.WriteLine("아이템이 없습니다.");
                return;
            }
            for (int i = 0; i < Inventory.Count; i++)
            {
                Item item = Inventory[i];
                Console.WriteLine($"{i + 1}. {item.Name}");
            }
            Console.WriteLine("====================");
        }
        public void UseItem(Item item)
        {
            if(item == null) return;

            switch (item.Type)
            {
                case ItemType.Potion:
                    HP += item.HealAmount;
                    Console.WriteLine($"HP가 {item.HealAmount} 회복됨!");
                    break;
                case ItemType.Weapon:
                    Attack = item.Attack;
                    Console.WriteLine($"무기 장착! 공격력 {Attack}");
                    break;
                case ItemType.Armor:
                    Defense = item.Defense;
                    Console.WriteLine($"방어구 장착! 방어력 {item.Defense}로 변경!");
                    break;
            }

            //소비 아이템일 때 인벤토리에서 삭제
            if (item.Type == ItemType.Potion)
            {
                Inventory.Remove(item);
            }
        }
        //private으로 추가는 함수로만 할 수 있게 해줌
        public void AddItem(Item item)
        {
            inventory.Add(item); //Inventory로 추가하면 getter 통해서 접근하는거라 헷갈림
            //inventory 직접 접근하지 않고 함수로 관리
        }

        // 아이템 삭제
        public void RemoveItem(Item item)
        {
            inventory.Remove(item);
        }

        public void TakeDamage(int damage)
        {

        }    
        public void PlayerInfo()
        {
            Console.WriteLine("===================");
            Console.WriteLine("=====내 정보=====");
            Console.WriteLine($"이름 : {Name}");
            Console.WriteLine($"레벨 : ");
            Console.WriteLine($"경험치 : ");
            Console.WriteLine($"");
            Console.WriteLine("===================");
        }
    }
}
