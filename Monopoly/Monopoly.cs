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
        private List<Tuple<string, Monopoly.Type, int, bool>> fields = new List<Tuple<string, Type, int, bool>>();
        public Monopoly(string[] p, int v)
        {
            //for (int i = 0; i < p.Length; i++)
            //{
            //    players.Add(new Tuple<string,int>(p[i], 6000));     
            //}

            foreach(string pl in p)
            {
                players.Add(new Player(pl, 6000));
            }

            fields.Add(new Tuple<string, Monopoly.Type, int, bool>("Ford", Monopoly.Type.AUTO, 0, false));
            fields.Add(new Tuple<string, Monopoly.Type, int, bool>("MCDonald", Monopoly.Type.FOOD, 0, false));
            fields.Add(new Tuple<string, Monopoly.Type, int, bool>("Lamoda", Monopoly.Type.CLOTHER, 0, false));
            fields.Add(new Tuple<string, Monopoly.Type, int, bool>("Air Baltic", Monopoly.Type.TRAVEL, 0, false));
            fields.Add(new Tuple<string, Monopoly.Type, int, bool>("Nordavia", Monopoly.Type.TRAVEL, 0, false));
            fields.Add(new Tuple<string, Monopoly.Type, int, bool>("Prison", Monopoly.Type.PRISON, 0, false));
            fields.Add(new Tuple<string, Monopoly.Type, int, bool>("MCDonald", Monopoly.Type.FOOD, 0, false));
            fields.Add(new Tuple<string, Monopoly.Type, int, bool>("TESLA", Monopoly.Type.AUTO, 0, false));
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

        internal List<Tuple<string, Monopoly.Type, int, bool>> GetFieldsList()
        {
            return fields;
        }

        internal Tuple<string, Type, int, bool> GetFieldByName(string v)
        {
            return (from p in fields where p.Item1 == v select p).FirstOrDefault();
        }

        internal bool Buy(int v, Tuple<string, Type, int, bool> k)
        {
            var x = GetPlayerInfo(v);
            int cash = 0;
            switch(k.Item2)
            {
                case Type.AUTO:
                    if (k.Item3 != 0)
                        return false;
                    cash = x.getCash() - 500;
                    players[v - 1] = new Player(x.getName(), cash);
                    break;
                case Type.FOOD:
                    if (k.Item3 != 0)
                        return false;
                    cash = x.getCash() - 250;
                    players[v - 1] = new Player(x.getName(), cash);
                    break;
                case Type.TRAVEL:
                    if (k.Item3 != 0)
                        return false;
                    cash = x.getCash() - 700;
                    players[v - 1] = new Player(x.getName(), cash);
                    break;
                case Type.CLOTHER:
                    if (k.Item3 != 0)
                        return false;
                    cash = x.getCash() - 100;
                    players[v - 1] = new Player(x.getName(), cash);
                    break;
                default:
                    return false;
            }
            int i = players.Select((item, index) => new { name = item.getName(), index = index })
                .Where(n => n.name == x.getName())
                .Select(p => p.index).FirstOrDefault();
            fields[i] = new Tuple<string, Type, int, bool>(k.Item1, k.Item2, v, k.Item4);
             return true;
        }

        internal Player GetPlayerInfo(int v)
        {
            return players[v - 1];
        }

        internal bool Renta(int v, Tuple<string, Type, int, bool> k)
        {
            var z = GetPlayerInfo(v);
            Player o = null;
            switch(k.Item2)
            {
                case Type.AUTO:
                    if (k.Item3 == 0)
                        return false;
                    o =  GetPlayerInfo(k.Item3);
                    z = new Player(z.getName(), z.getCash() - 250);
                    o = new Player(o.getName(),o.getCash() + 250);
                    break;
                case Type.FOOD:
                    if (k.Item3 == 0)
                        return false;
                    o = GetPlayerInfo(k.Item3);
                    z = new Player(z.getName(), z.getCash() - 250);
                    o = new Player(o.getName(), o.getCash() + 250);

                    break;
                case Type.TRAVEL:
                    if (k.Item3 == 0)
                        return false;
                    o = GetPlayerInfo(k.Item3);
                    z = new Player(z.getName(), z.getCash() - 300);
                    o = new Player(o.getName(), o.getCash() + 300);
                    break;
                case Type.CLOTHER:
                    if (k.Item3 == 0)
                        return false;
                    o = GetPlayerInfo(k.Item3);
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
                players[k.Item3 - 1] = o;
            return true;
        }
    }
}
