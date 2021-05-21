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

        internal Field GetFieldByName(string v)
        {
            return (from p in fields where p.getName() == v select p).First();
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
            var player = GetPlayerInfo(numPlayer);

            if (!field.IsCanRentaField())
                return false;

            player.MinusCash(field.getRenta());

            if (field.IsRentaOwned())
            {
                Player ownField = GetPlayerInfo(field.getNumPlayer());
                ownField.PlusCash(field.getRenta());
            }
                
            return true;
        }
    }
}
