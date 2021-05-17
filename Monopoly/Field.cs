using System;

namespace Monopoly
{
    internal class Field
    {
        private string name;
        private Monopoly.Type type;
        private int player;
        private bool sale;

        public enum TypeField
        {
            AUTO,
            FOOD,
            CLOTHER,
            TRAVEL,
            PRISON,
            BANK
        }

        public Field (string name, Monopoly.Type type, int player, bool sale)
        {
            this.name = name;
            this.type = type;
            this.player = player;
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

        public int getPlayer()
        {
            return player;
        }

        public bool getSale()
        {
            return sale;
        }

        public override bool Equals(object other)
        {
            Field toCompareWith = other as Field;
            if (toCompareWith == null)
                return false;
            return this.name == toCompareWith.name 
                && this.type == toCompareWith.type
                && this.player == toCompareWith.player
                && this.sale == toCompareWith.sale;
        }
    }
}
