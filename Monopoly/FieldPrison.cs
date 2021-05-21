namespace Monopoly
{
    internal class FieldPrison : Field
    {
        public FieldPrison(string name, int player, bool sale) : base(name, player, sale)
        {
            //setType(Monopoly.Type.PRISON);
            base.setRenta(1000);
        }
    }
}