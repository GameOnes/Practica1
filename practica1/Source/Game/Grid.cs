using SFML.Graphics;
using SFML.Window;
using System.Collections.Generic;
using SFML.System;
using System;
using System.Diagnostics;
using System.Linq;
using TCEngine;

namespace TCGame
{
    public class Grid : Drawable
    {

        //
        // Members
        //  
        private const int NUM_COLUMNS = 4;
        private const int NUM_ROWS = 3;

        private LineDrawer m_Lines;
        private List<Item> m_Items;
        private Texture m_BackgroundTexture;
        private Sprite m_BackgroundSprite;


        //
        // Accessors
        //
        public float SlotWidth
        {
            get { return TecnoCampusEngine.WINDOW_WIDTH / (float)NUM_COLUMNS; }
        }

        public float SlotHeight
        {
            get { return TecnoCampusEngine.WINDOW_HEIGHT / (float)NUM_ROWS; }
        }

        public int MaxItems
        {
            get { return NUM_COLUMNS * NUM_ROWS; }
        }


        // 
        // Methods
        //
        public void Init()
        {
            m_BackgroundTexture = new Texture("Data/Textures/Background.jpg");
            m_BackgroundSprite = new Sprite(m_BackgroundTexture);

            m_Items = new List<Item>();

            FillGridLines();
        }

        public void DeInit()
        {
            m_BackgroundTexture.Dispose();
        }
        
        public void HandleKeyPressed(object _sender, KeyEventArgs _keyEvent,MouseButtonEvent _mouseEvent)
        {


            if (_keyEvent.Code == Keyboard.Key.Num1)
            {
                if (HasNullSlot())
                {
                    AddItemAtIndex(NewRandomItem(), GetFirstNullSlot());
                }
                else
                {
                    AddItemAtEnd(NewRandomItem());
                }
            }
            else if (_keyEvent.Code == Keyboard.Key.Num2)
            {
                RemoveLastItem();
            }
            else if (_keyEvent.Code == Keyboard.Key.Num3)
            {
                NullAllCoins();
            }
            else if (_keyEvent.Code == Keyboard.Key.Num4)
            {
                ReverseItems();
            }
            else if (_keyEvent.Code == Keyboard.Key.Num5)
            {
                RemoveNullSlots();
            }
            else if (_keyEvent.Code == Keyboard.Key.Num6)
            {
                RemoveAllItems();
            }
            else if (_keyEvent.Code == Keyboard.Key.Num7)
            {
                NullAllWeapons();
            }
            else if (_keyEvent.Code == Keyboard.Key.Num8)
            {
                OrderItems();
            }
            else if (_mouseEvent.Button == Mouse.Button.Right)
            {
                Item bomb = new Bomb();
                for (int i = 0; i < m_Items.Count; i++)
                {
                    if (m_Items[i]==bomb)
                    {
                        ClickedBomb();
                    }
                    else
                    {
                        NullClickedObjects();
                    }



                }
            }
            
        }

        private void FillGridLines()
        {
            m_Lines = new LineDrawer(NUM_COLUMNS + NUM_ROWS + 2);

            for (int i = 0; i <= NUM_COLUMNS; ++i)
            {
                m_Lines.AddLine(new Vector2f(i * SlotWidth, 0.0f), new Vector2f(i * SlotWidth, TecnoCampusEngine.WINDOW_HEIGHT), 2.0f, new Color(0, 0, 0, 150));
            }

            for (int i = 0; i <= NUM_ROWS; ++i)
            {
                m_Lines.AddLine(new Vector2f(0.0f, i * SlotHeight), new Vector2f(TecnoCampusEngine.WINDOW_WIDTH, i * SlotHeight), 2.0f, new Color(0, 0, 0, 150));
            }
        }

        public void Update(float _dt)
        {
            for (int i = 0; i < m_Items.Count; ++i)
            {
                int row = i / NUM_COLUMNS;
                int column = i % NUM_COLUMNS;

                Vector2f position = new Vector2f(SlotWidth / 2.0f + SlotWidth * column, SlotHeight / 2.0f + SlotHeight * row);
                Item item = m_Items[i];
                if (item != null)
                {
                    item.Position = position;
                }
            }
        }

        public void Draw(RenderTarget _renderTarget, RenderStates _renderState)
        {
            _renderTarget.Draw(m_BackgroundSprite, _renderState);
            _renderTarget.Draw(m_Lines, _renderState);

            foreach (Item item in m_Items)
            {
                if (item != null)
                {
                    _renderTarget.Draw(item, _renderState);
                }
            }
        }


        private Item NewRandomItem()
        {
            Random alea = new Random();
            List<Item> itemslist = new List<Item> { new Bomb(), new Heart(), new Sword(), new Axe(), new Coin(), new Clyde(), new Blinky() };

            return itemslist[alea.Next(0, itemslist.Count)];
        }

        private void RemoveLastItem()
        {
            if (m_Items.Count > 0)
            {
                m_Items.RemoveAt(m_Items.Count - 1);
            }
        }

        private void NullAllCoins()
        {
            Item coin = new Coin();
            for (int i = 0; i < m_Items.Count; i++)
            {
                
                if (m_Items[i].GetType() == coin.GetType())
                {
                    m_Items.Remove(coin);
                }
            }
            
            
        }
        /*private void NullAllCoins()
        {
            foreach (Item a in m_Items)
            {
                Item coin = new Coin();
                if (a.GetType() == coin.GetType())
                {
                    int index = m_Items.IndexOf(a);
                    m_Items[index] = null;
                }
            }
        }*/

        private void RemoveNullSlots()
        {
            for (int i = 0; i < m_Items.Count; i++)
            {
                if (m_Items[i] == null)
                {
                    m_Items.Remove(m_Items[i]);
                }
            }

        }
        private void NullClickedObjects()
        {
            
            for (int i = 0; i < m_Items.Count; i++)
            {
                m_Items.Remove(m_Items[i]);
            }
        }

        private void RemoveAllItems()
        {
            m_Items.Clear();
        }
        private void ClickedBomb()
        {
            Item bomb = new Bomb();

            for (int i = 0; i < m_Items.Count; i++)
            {
                if (m_Items[i].GetType() == bomb.GetType())
                {
                    m_Items.Remove( bomb);
                }
            }
        }
        private void NullAllWeapons()
        {
            Item sword = new Sword();
            Item axe = new Axe();
            /*for (int i = 0; i < m_Items.Count; i++)
              {
                  if (m_Items[i] == sword || m_Items[i]==axe)
                  {
                      m_Items.Remove(m_Items[i]);
                      m_Items[i] = null;
                  }
              }
            */
            for (int i = 0; i < m_Items.Count; i++)
            {
                if (m_Items[i].GetType() == axe.GetType())
                {
                    m_Items.Remove(m_Items[i]);
                }
                else if ((m_Items[i].GetType() == sword.GetType()))
                {
                    m_Items.Remove(sword);
                }
            }
        }

        private bool HasNullSlot()
        {
            for (int i = 0; i < m_Items.Count; i++)
            {
                if (m_Items[i] == null)
                {
                    return true;
                }
            }
            return false;
        }

        private int GetFirstNullSlot()
        {
            for (int i = 0; i < m_Items.Count; i++)
            {
                if (m_Items[i] == null)
                {
                    return i;
                }
            }
            return -1;
        }

        private void AddItemAtIndex(Item _item, int _index)
        {
            if (m_Items.Count < 12)
            {
                m_Items.Insert(_index, _item);
            }
        }

        private void AddItemAtEnd(Item _item)
        {
            if (m_Items.Count < 12)
            {
                m_Items.Insert(m_Items.Count, _item);
            }
        }
        

        private void OrderItems()
        {
            m_Items.Clear();
             Item heart = new Heart();
             Item bomb = new Bomb();
             Item coin = new Coin();
             Item clyde = new Clyde();
             Item blinky = new Blinky();
             Weapon axe = new Axe();
             Weapon sword = new Sword();

            m_Items.Add(heart);
            m_Items.Add(axe);
            m_Items.Add(sword);
            m_Items.Add(bomb);
            m_Items.Add(coin);
            m_Items.Add(blinky);
            m_Items.Add(clyde);



            /*for (int i = 0; i < m_Items.Count; i++)
             {
                 if (m_Items[i] == heart)
                 {
                     
                 }
                 else if (m_Items[i] == bomb)
                 {
                     Item first=m_Items[i];
                 }
                 else if(m_Items[i] == coin)
                 {
                     Item fourth;
                 }
                 else if (m_Items[i] == clyde)
                 {
                     Item fifth;
                 }
                 else if(m_Items[i] == blinky)
                 {
                     Item sisth;
                 }
                 else if(m_Items[i] == axe)
                 {
                     Item second;
                 }
                 else
                 {
                     Item third;
                 }
                
            }
            */
           
            
           
        }

        private void ReverseItems()
        {
            m_Items.Reverse();
        }
    }
}
