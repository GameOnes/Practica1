using SFML.Graphics;
using SFML.System;

namespace TCGame
{
    public abstract class Item : Sprite
    {
        
    }
    public class Bomb : Item
    {
        Texture texture1 = new Texture("Data/Textures/Bomb.png");
        public Bomb()
        {
            Texture = texture1;
            Origin = new Vector2f(0.0f, 0.0f);

        }
    }
    public class Heart: Item
    {
        Texture texture2 = new Texture("Data/Textures/Heart.png");
        public Heart()
        {
            Texture = texture2;
            Origin = new Vector2f(0.0f, 0.0f);
        }
    }
    public abstract class  Weapon: Item
    {
        
    }
    public class Sword : Weapon
    {
        Texture texture3 = new Texture("Data/Textures/Sword.png");
        public Sword()
        {
            Texture = texture3;
            Origin = new Vector2f(0.0f,0.0f);
        }
       
    }
    public class Axe : Weapon
    {
        Texture texture4 = new Texture("Data/Textures/Axe.png");
        public Axe()
        {
            Texture =texture4;
            Origin = new Vector2f(0.0f, 0.0f);
        }
    }
    public class Coin: Item
    {
        Texture texture5 = new Texture("Data/Textures/Coin.png");
        public Coin()
        {
            Texture = texture5;
            Origin = new Vector2f(0.0f, 0.0f);
        }
    }
    public class Clyde: Item
    {
        Texture texture6 = new Texture("Data/Textures/Clyde.png");
        public Clyde()
        {
            Texture = texture6;
            Origin = new Vector2f(0.0f, 0.0f);
        }
    }
    public class Blinky : Item
    {
        Texture texture7 = new Texture("Data/Textures/Blinky.png");
        public Blinky()
        {
            Texture = texture7;
            Origin = new Vector2f(0.0f, 0.0f);
        }
    }
    
}
