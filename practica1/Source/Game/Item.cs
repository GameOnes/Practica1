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
            
        }
    }
    public class Heart: Item
    {
        Texture texture2 = new Texture("Data/Textures/Heart.png");
        public Heart()
        {
            Texture = texture2;
            Sprite heart = new Sprite();
            heart.Texture = texture2;
            heart.Scale = new Vector2f(1.0f, 1.0f);
            heart.Origin = new Vector2f(0.0f, 0.0f);
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
            Sprite sword = new Sprite();
            sword.Texture = texture3;
            sword.Scale = new Vector2f(1.0f,1.0f);
            sword.Origin = new Vector2f(0.0f, 0.0f);
            
        }
       
    }
    public class Axe : Weapon
    {
        Texture texture4 = new Texture("Data/Textures/Axe.png");
        public Axe()
        {
            Texture =texture4;
        }
    }
    public class Coin: Item
    {
        Texture texture5 = new Texture("Data/Textures/Coin.png");
        public Coin()
        {
            Texture = texture5;
        }
    }
    public class Clyde: Item
    {
        Texture texture6 = new Texture("Data/Textures/Clyde.png");
        public Clyde()
        {
            Texture = texture6;
        }
    }
    public class Blinky : Item
    {
        Texture texture7 = new Texture("Data/Textures/Blinky.png");
        public Blinky()
        {
            Texture = texture7;
        }
    }
    
}
