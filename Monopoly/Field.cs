using System;

namespace Monopoly
{
    internal class Field
    {
        private string name;
        private Monopoly.Type type;
        private int numplayer;
        private bool forsale;
        private int price = 0;
        private int renta = 0;

        public Field(string name, int numplayer, bool forsale)
        {
            this.name = name;
            this.numplayer = numplayer;
            this.forsale = forsale;
        }

        public string getName()
        {
            return name;
        }

        public Monopoly.Type getTypeField()
        {
            return type;
        }

        protected void setType(Monopoly.Type type)
        {
            this.type = type;
        }

        public int getNumPlayer()
        {
            return numplayer;
        }

        public void setNumPlayer(int numplayer)
        {
            this.numplayer = numplayer;
        }

        public bool getSale()
        {
            return forsale;
        }

        public int getPrice()
        {
            return price;
        }

        public int getRenta()
        {
            return renta;
        }

        protected void setPrice(int price)
        {
            this.price = price;
        }

        protected void setRenta(int renta)
        {
            this.renta = renta;
        }

        public bool IsCanBuyField()
        {
            if (forsale == true && numplayer == 0)
                return true;
            return false;
        }

        public bool IsCanRentaField()
        {
            if (forsale == false)
                return true;
            if (forsale == true && numplayer != 0)
                return true;
            return false;
        }

        public bool IsRentaOwned()
        {
            if (forsale == true && numplayer > 0)
                return true;
            return false;
        }

        public override bool Equals(object other)
        {
            if (!(other is Field toCompareWith))
                return false;
            return this.name == toCompareWith.name 
                && this.type == toCompareWith.type
                && this.numplayer == toCompareWith.numplayer
                && this.forsale == toCompareWith.forsale;
        }
    }
}
