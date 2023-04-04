using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class Inventory
    {
        private int potion;
        private int fruit;
        private int bitcoin;
        private int item;

        public Inventory()
        {
            SetPotion(3);
            SetFruit(2);
            SetItem(0);
            SetBitcoin(200);
        }

        public void SetPotion(int potion)
        {
            this.potion = potion;
        }

        public int GetPotion()
        {
            return potion;
        }

        public void SetFruit(int fruit)
        {
            this.fruit = fruit;
        }

        public int GetFruit()
        {
            return fruit;
        }

        public void SetItem(int item)
        {
            this.item = item;
        }

        public int GetItem()
        {
            return item;
        }

        public void SetBitcoin(int bitcoin)
        {
            this.bitcoin = bitcoin;
        }

        public int GetBitcoin()
        {
            return bitcoin;
        }

    }
}
