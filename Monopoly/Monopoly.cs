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

            fields.Add(new FieldAuto("Ford", 0, false));
            fields.Add(new FieldFood("MCDonald", 0, false));
            fields.Add(new FieldClother("Lamoda", 0, false));
            fields.Add(new FieldTravel("Air Baltic", 0, false));
            fields.Add(new FieldTravel("Nordavia", 0, false));
            fields.Add(new FieldPrison("Prison", 0, false));
            fields.Add(new FieldFood("MCDonald", 0, false));
            fields.Add(new FieldAuto("TESLA", 0, false));
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
            var player = GetPlayerInfo(numPlayer);

            if (field.getNumPlayer() != 0)
                return false;

            players[numPlayer - 1].MinusCash(field.getPrice());

            //switch (field.getTypeField())
            //{
            //    case Type.AUTO:
            //        //cash = player.getCash() - field.getPrice();
            //        //cash = x.getCash() - 500;
            //        //players[v - 1].MinusCash(GetPriceOfField(k.getTypeField()));
            //        //players[numPlayer - 1] = new Player(player.getName(), cash);
            //        players[numPlayer - 1].MinusCash(field.getPrice());
            //        break;
            //    case Type.FOOD:
            //        cash = player.getCash() - 250;
            //        players[numPlayer - 1] = new Player(player.getName(), cash);
            //        break;
            //    case Type.TRAVEL:
            //        cash = player.getCash() - 700;
            //        players[numPlayer - 1] = new Player(player.getName(), cash);
            //        break;
            //    case Type.CLOTHER:
            //        cash = player.getCash() - 100;
            //        players[numPlayer - 1] = new Player(player.getName(), cash);
            //        break;
            //    default:
            //        return false;
            //}
            int i = fields.Select((item, index) => new { name = item.getName(), index })
                .Where(n => n.name == player.getName())
                .Select(p => p.index).FirstOrDefault();
            fields[i] = new Field(field.getName(), field.getTypeField(), numPlayer, field.getSale());
            //field.setPlayer(numPlayer);
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
