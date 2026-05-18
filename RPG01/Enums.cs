using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG01
{
    enum SceneType
    {
        Title,
        Town,
        Battle,
        Shop
    }
    public enum MonsterType
    {
        Monster,
        BossMonster
    }
    public enum ItemType
    {
        Potion,
        Weapon,
        Armor
           
    }
    enum GameState
    {
        Start,
        Playing,
        Exit
    }
    internal class Enums
    {
        
    }
}
