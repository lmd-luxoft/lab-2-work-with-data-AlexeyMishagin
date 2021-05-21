﻿using System;

namespace Monopoly
{
    internal class Field
    {
        private string name;
        private Monopoly.Type type;
        private int numplayer;
        private bool sale;
        private int price = 0;
        private int renta = 0;

        public Field (string name, Monopoly.Type type, int numplayer, bool sale)
        {
            this.name = name;
            this.type = type;
            this.numplayer = numplayer;
            this.sale = sale;
        }

        public Field(string name, int numplayer, bool sale)
        {
            this.name = name;
            this.numplayer = numplayer;
            this.sale = sale;
        }

        public string getName()
        {
            return name;
        }

        public Monopoly.Type getTypeField()
        {
            return type;
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
            return sale;
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

        public override bool Equals(object other)
        {
            if (!(other is Field toCompareWith))
                return false;
            return this.name == toCompareWith.name 
                && this.type == toCompareWith.type
                && this.numplayer == toCompareWith.numplayer
                && this.sale == toCompareWith.sale;
        }
    }
}
