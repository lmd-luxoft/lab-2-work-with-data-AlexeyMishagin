namespace Monopoly
{
    class Player
    {
        private string name;
        private int cash;

        public Player(string name, int cash)
        {
            this.name = name;
            this.cash = cash;
        }

        public string getName()
        {
            return name;
        }

        public int getCash()
        {
            return cash;
        }

        public override bool Equals(object other)
        {
            Player toCompareWith = other as Player;
            if (toCompareWith == null)
                return false;
            return this.name == toCompareWith.name &&
                this.cash == toCompareWith.cash;
        }
    }
}
