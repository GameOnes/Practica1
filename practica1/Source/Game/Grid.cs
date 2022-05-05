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
        
        public void HandleKeyPressed(object _sender, KeyEventArgs _keyEvent)
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

            return itemslist[alea.Next(1, itemslist.Count)];
        }

        private void RemoveLastItem()
        {
            m_Items.RemoveAt(m_Items.Count-1 );

        }

        private void NullAllCoins()
        {
            Item coin = new Coin();
            for (int i = 0; i < m_Items.Count; i++)
            {
                if (m_Items[i] == coin)
                {
                   m_Items.Remove(m_Items[i]);
                   m_Items[i] = null;
                }
            }

            
        }

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

        private void RemoveAllItems()
        {
            m_Items.Clear();

        }

        private void NullAllWeapons()
        {
            Weapon sword = new Sword();
            Weapon axe = new Axe();
            for (int i = 0; i < m_Items.Count; i++)
            {
                if (m_Items[i] == sword || m_Items[i]==axe)
                {
                    m_Items.Remove(m_Items[i]);
                    m_Items[i] = null;
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
            m_Items.Insert(_index, _item);

        }

        private void AddItemAtEnd(Item _item)
        {
            m_Items.Insert(m_Items.Count , _item);
        }

        private void OrderItems()
        {
            int Heart, Sword, Axe, Bomb, Coin, Clyde, Blinky;



            for (int i = 0; i < m_Items.Count; i++)
            {
                if (m_Items[i] == new Heart())
                {
                    
                }
                else if (m_Items[i] == new Sword())
                {

                }
                else if(m_Items[i]== new Axe())
                {

                }
                else if (m_Items[i] == new Bomb())
                {

                }
                else if(m_Items[i]== new Coin())
                {

                }
                else if(m_Items[i]== new Clyde())
                {

                }
                else
                {

                }
            }
        }

        private void ReverseItems()
        {
            m_Items.Reverse();
        }
    }
}
