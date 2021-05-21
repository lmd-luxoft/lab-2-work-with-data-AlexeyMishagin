namespace Monopoly
{
    internal class FieldFood : Field
    {
        public FieldFood(string name, int player, bool sale) : base(name, player, sale)
        {
            base.setPrice(250);
            base.setRenta(250);
        }
    }
}