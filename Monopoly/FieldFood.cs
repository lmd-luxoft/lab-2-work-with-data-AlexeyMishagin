namespace Monopoly
{
    internal class FieldFood : Field
    {
        public FieldFood(string name, int player, bool sale) : base(name, player, sale)
        {
            setType(Monopoly.Type.FOOD);
            base.setPrice(250);
            base.setRenta(250);
        }
    }
}