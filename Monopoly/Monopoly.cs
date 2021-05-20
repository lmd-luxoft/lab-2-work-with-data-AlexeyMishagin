using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Monopoly
    {
        private List<Player> players = new List<Player>();
        private List<Field> fields = new List<Field>();
        public Monopoly(string[] p)
        {
            //for (int i = 0; i < p.Length; i++)
            //{
            //    players.Add(new Tuple<string,int>(p[i], 6000));     
            //}

            foreach(string pl in p)
            {
                players.Add(new Player(pl, 6000));
            }

            fields.Add(new Field("Ford", Monopoly.Type.AUTO, 0, false));
            fields.Add(new Field("MCDonald", Monopoly.Type.FOOD, 0, false));
            fields.Add(new Field("Lamoda", Monopoly.Type.CLOTHER, 0, false));
            fields.Add(new Field("Air Baltic", Monopoly.Type.TRAVEL, 0, false));
            fields.Add(new Field("Nordavia", Monopoly.Type.TRAVEL, 0, false));
            fields.Add(new Field("Prison", Monopoly.Type.PRISON, 0, false));
            fields.Add(new Field("MCDonald", Monopoly.Type.FOOD, 0, false));
            fields.Add(new Field("TESLA", Monopoly.Type.AUTO, 0, false));
        }

        internal List<Player> GetPlayersList()
        {
            return players;
        }

        internal enum Type
        {
            AUTO,
            FOOD,
            CLOTHER,
            TRAVEL,
            PRISON,
            BANK
        }

        internal int GetPriceOfField(Monopoly.Type type)
        {
            switch (type)
            {
                case Monopoly.Type.AUTO: return 500;
                case Monopoly.Type.FOOD: return 250;
                case Monopoly.Type.TRAVEL: return 700;
                case Monopoly.Type.CLOTHER: return 100;
                case Monopoly.Type.PRISON: return 1000;
                case Monopoly.Type.BANK: return 700;
            }
            return 0;
        }

        internal List<Field> GetFieldsList()
        {
            return fields;
        }

        internal Field GetFieldByName(string v)
        {
            return (from p in fields where p.getName() == v select p).FirstOrDefault();
        }

        internal bool Buy(int v, Field k)
        {
            var x = GetPlayerInfo(v);
            int cash = 0;
            switch(k.getTypeField())
            {
                case Type.AUTO:
                    if (k.getPlayer() != 0)
                        return false;
                    cash = x.getCash() - 500;
                    //players[v - 1].MinusCash(GetPriceOfField(k.getTypeField()));
                    players[v - 1] = new Player(x.getName(), cash);
                    break;
                case Type.FOOD:
                    if (k.getPlayer() != 0)
                        return false;
                    cash = x.getCash() - 250;
                    players[v - 1] = new Player(x.getName(), cash);
                    break;
                case Type.TRAVEL:
                    if (k.getPlayer() != 0)
                        return false;
                    cash = x.getCash() - 700;
                    players[v - 1] = new Player(x.getName(), cash);
                    break;
                case Type.CLOTHER:
                    if (k.getPlayer() != 0)
                        return false;
                    cash = x.getCash() - 100;
                    players[v - 1] = new Player(x.getName(), cash);
                    break;
                default:
                    return false;
            }
            int i = players.Select((item, index) => new { name = item.getName(), index })
                .Where(n => n.name == x.getName())
                .Select(p => p.index).FirstOrDefault();
            fields[i] = new Field(k.getName(), k.getTypeField(), v, k.getSale());
             return true;
        }

        internal Player GetPlayerInfo(int v)
        {
            return players[v - 1];
        }

        internal bool Renta(int v, Field k)
        {
            var z = GetPlayerInfo(v);
            Player o = null;
            switch(k.getTypeField())
            {
                case Type.AUTO:
                    if (k.getPlayer() == 0)
                        return false;
                    o =  GetPlayerInfo(k.getPlayer());
                    z = new Player(z.getName(), z.getCash() - 250);
                    o = new Player(o.getName(),o.getCash() + 250);
                    break;
                case Type.FOOD:
                    if (k.getPlayer() == 0)
                        return false;
                    o = GetPlayerInfo(k.getPlayer());
                    z = new Player(z.getName(), z.getCash() - 250);
                    o = new Player(o.getName(), o.getCash() + 250);

                    break;
                case Type.TRAVEL:
                    if (k.getPlayer() == 0)
                        return false;
                    o = GetPlayerInfo(k.getPlayer());
                    z = new Player(z.getName(), z.getCash() - 300);
                    o = new Player(o.getName(), o.getCash() + 300);
                    break;
                case Type.CLOTHER:
                    if (k.getPlayer() == 0)
                        return false;
                    o = GetPlayerInfo(k.getPlayer());
                    z = new Player(z.getName(), z.getCash() - 100);
                    o = new Player(o.getName(), o.getCash() + 1000);

                    break;
                case Type.PRISON:
                    z = new Player(z.getName(), z.getCash() - 1000);
                    break;
                case Type.BANK:
                    z = new Player(z.getName(), z.getCash() - 700);
                    break;
                default:
                    return false;
            }
            players[v - 1] = z;
            if(o != null)
                players[k.getPlayer() - 1] = o;
            return true;
        }
    }
}
