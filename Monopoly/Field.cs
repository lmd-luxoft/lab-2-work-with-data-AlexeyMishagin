using System;

namespace Monopoly
{
    class Field
    {
        private string name;
        private Monopoly.Type type;
        private Player player;
        private bool sale;

        public Field (string name, Monopoly.Type type, Player player, bool sale)
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
