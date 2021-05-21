namespace Monopoly
{
    internal class FieldClother : Field
    {
        public FieldClother(string name, int player, bool sale) : base(name, player, sale)
        {
            base.setPrice(100);
            base.setRenta(100);
        }
    }
}