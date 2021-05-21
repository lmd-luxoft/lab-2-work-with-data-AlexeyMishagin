namespace Monopoly
{
    internal class FieldTravel : Field
    {
        public FieldTravel(string name, int player, bool sale) : base(name, player, sale)
        {
            base.setPrice(700);
            base.setRenta(300);
        }
    }
}