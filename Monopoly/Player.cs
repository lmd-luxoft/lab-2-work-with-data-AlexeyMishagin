namespace Monopoly
{
    internal class Player
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

        public void setCash(int cash)
        {
            this.cash = cash;
        }

        public void MinusCash(int cash)
        {
            this.cash -= cash;
        }

        public void PlusCash(int cash)
        {
            this.cash += cash;
        }

        public override bool Equals(object other)
        {
            if (!(other is Player toCompareWith))
                return false;
            return this.name == toCompareWith.name &&
                this.cash == toCompareWith.cash;
        }
    }
}
