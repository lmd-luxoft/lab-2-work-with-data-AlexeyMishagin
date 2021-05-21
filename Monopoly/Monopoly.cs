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
            foreach(string pl in p)
            {
                players.Add(new Player(pl, 6000));
            }

            fields.Add(new FieldAuto("Ford", 0, true));
            fields.Add(new FieldFood("MCDonald", 0, true));
            fields.Add(new FieldClother("Lamoda", 0, true));
            fields.Add(new FieldTravel("Air Baltic", 0, true));
            fields.Add(new FieldTravel("Nordavia", 0, true));
            fields.Add(new FieldPrison("Prison", 0, false));
            fields.Add(new FieldFood("MCDonald", 0, true));
            fields.Add(new FieldAuto("TESLA", 0, true));
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

        internal List<Field> GetFieldsList()
        {
            return fields;
        }

        internal Player GetPlayerByName(string v)
        {
            return (from p in players where p.getName() == v select p).FirstOrDefault();
        }

        internal Field GetFieldByName(string v)
        {
            return (from p in fields where p.getName() == v select p).FirstOrDefault();
        }

        internal bool Buy(int numPlayer, Field field)
        {
            if (!field.IsCanBuyField())
                return false;

            players[numPlayer - 1].MinusCash(field.getPrice());

            field.setNumPlayer(numPlayer);
            return true;
        }

        internal Player GetPlayerInfo(int v)
        {
            return players[v - 1];
        }

        internal bool Renta(int numPlayer, Field field)
        {
            var z = GetPlayerInfo(numPlayer);
            Player o = null;
            switch(field.getTypeField())
            {
                case Type.AUTO:
                    if (field.getNumPlayer() == 0)
                        return false;
                    o =  GetPlayerInfo(field.getNumPlayer());
                    z = new Player(z.getName(), z.getCash() - 250);
                    o = new Player(o.getName(),o.getCash() + 250);
                    break;
                case Type.FOOD:
                    if (field.getNumPlayer() == 0)
                        return false;
                    o = GetPlayerInfo(field.getNumPlayer());
                    z = new Player(z.getName(), z.getCash() - 250);
                    o = new Player(o.getName(), o.getCash() + 250);

                    break;
                case Type.TRAVEL:
                    if (field.getNumPlayer() == 0)
                        return false;
                    o = GetPlayerInfo(field.getNumPlayer());
                    z = new Player(z.getName(), z.getCash() - 300);
                    o = new Player(o.getName(), o.getCash() + 300);
                    break;
                case Type.CLOTHER:
                    if (field.getNumPlayer() == 0)
                        return false;
                    o = GetPlayerInfo(field.getNumPlayer());
                    z = new Player(z.getName(), z.getCash() - 100);
                    o = new Player(o.getName(), o.getCash() + 100);
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
            players[numPlayer - 1] = z;
            if(o != null)
                players[field.getNumPlayer() - 1] = o;
            return true;
        }
    }
}
