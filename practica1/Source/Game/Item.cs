using SFML.Graphics;
using SFML.System;

namespace TCGame
{
    public abstract class Item : Sprite
    {
        
    }
    public class Bomb : Item
    {
        Item texture=new Item()
    }
    public class Heart: Item
    {

    }
    public abstract class  Weapon: Item
    {

    }
    public class Sword : Weapon
    {

    }
    public class Axe : Weapon
    {

    }
    public class Coin: Item
    {

    }
    public class Clyde: Item
    {

    }
    public class Blinky : Item
    {

    }
}
