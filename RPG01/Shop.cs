using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RPG01
{
    public class Shop
    {       
        public List<Item> ShopItems = new List<Item>();

        public Shop()
        {//생성자에 넣는 이유 : Shop 만들자마자 자동으로 아이템 생성
            ShopItems.Add(new Item
            {
                Name = "포션",
                Price = 10,
                HealAmount = 20,
                Type = ItemType.Potion
            });
            ShopItems.Add(new Item
            {
                Name = "검",
                Price = 50,
                Attack = 5,
                Type = ItemType.Weapon
            });

            ShopItems.Add(new Item
            {
                Name = "방어구",
                Price = 40,
                Defense = 3,
                Type = ItemType.Armor
            });
        }
        public void ShowItems(Player player)
        {
            while (true)
            {
                Console.WriteLine("어서오세요!!");
                Console.WriteLine("명령하지마라 천천히 간다");
                Console.WriteLine();


                Console.WriteLine("===== 상점 =====");

                Console.WriteLine("뭘 원하시져 번호를 눌러주쇼");
                Console.WriteLine("1. [구매] 2. [판매] 3. [나가기]");
                Console.Write("선택 : ");

                if (!int.TryParse(Console.ReadLine(), out int input))
                {
                    Console.WriteLine("숫자를 입력하세요!");
                    continue; //while 안
                }

                if (input == 1)
                {
                    BuyMenu(player);
                }
                else if (input == 2)
                {
                    SellMenu(player);
                }
                else if (input == 3)
                {
                    Console.WriteLine("상점을 나갑니다.");
                    break;//나중에 마을로 이동하는걸로 바꾸자
                }
            }           
        }
        //구매 
        public void BuyMenu(Player player)
        {
            Console.WriteLine("뭘 살려고??");
            Console.WriteLine("=== 구매 목록 ===");

            for (int i = 0; i < ShopItems.Count; i++)
            {
                Item item = ShopItems[i];
                Console.WriteLine($"{i + 1}. {item.Name} ({item.Price}G)");
            }

            Console.WriteLine("번호 입력 : ");
            if (!int.TryParse(Console.ReadLine(), out int input))
            {
                Console.WriteLine("숫자를 입력하세요!");
                return;
            }
            if (input < 1 || input > ShopItems.Count)
            {
                return;
            }

            Item selected = GetItem(input - 1); //0부터 시작하기때문에 -1
            Buy(player, selected);
        }
        

        public void Buy(Player player, Item item)
        {
            if(item == null) return;
            if (player.Gold < item.Price)
            {
                Console.WriteLine("돈이 부족합니다!");
                return;
            }

            player.Gold -= item.Price;
            player.AddItem(item);

            Console.WriteLine($"{item.Name} 구매 완료!");
        }                  

        //판매
        public void SellMenu(Player player)
        {
            Console.WriteLine();

            Console.WriteLine("=== 인벤토리 ===");

            for(int i =0; i<player.Inventory.Count; i++)
            {
                Item item=player.Inventory[i];
                Console.WriteLine($"{i + 1}. {item.Name} {item.Price/2}");
            }
            Console.Write("번호 입력 : ");
            if (!int.TryParse(Console.ReadLine(), out int input))
            {
                Console.WriteLine("숫자를 입력하세요!");
                return;
            }
            if ( input < 1 || input > player.Inventory.Count)
            {
                return;
            }
            Item selected = player.Inventory[input - 1];
            Sell(player, selected);
        }
        public void Sell(Player player, Item item)
        {           
            player.Gold += item.Price / 2; //판매 아이템은 반값으로 받는다
            player.RemoveItem(item);

            Console.WriteLine($"{item.Name} 판매 완료!");
        }

        //번호를 눌러 활동한다

        //아이템 선택 함수
        public Item GetItem(int index)
        {
            if (index < 0 || index >= ShopItems.Count)
                return null;

            return ShopItems[index];
        }        
    }
}
