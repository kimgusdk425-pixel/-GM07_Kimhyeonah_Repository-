using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*****************************************
 item에서 사용되는 상속 클래스와 enum List는 역할이 다르게 사용된다
상속 클래스 = 아이템 구조
enum = 아이템 종류 표시
List = 아이템 저장

 *****************************************/

namespace RPG01
{
    //1. 부모 클래스 Item을 만든다.
    public class Item
    {
        public string Name { get; set; }
        public int Price;

        public ItemType Type;
        public int HealAmount;
        public int Attack;
        public int Defense;

    }
    //2.자식 클래스를 만든다 -> 양이 많아지면 cs 따로 만들어도 좋을 것 같다
    class Potion : Item
    {
        public int HealAmount;
    }
    class Weapon : Item
    {
        public int Attack;

        //3.사용하기
        static void UsePotion()
        {
            Potion potion = new Potion();

            potion.Name = "빨간 포션";
            potion.Price = 100;
            potion.HealAmount = 50;
        }
    }
}
