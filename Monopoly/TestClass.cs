// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace Monopoly
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void GetPlayersListReturnCorrectList()
        {
            string[] players = new string[]{ "Peter","Ekaterina","Alexander" };
            Player[] expectedPlayers = new Player[]
            {
                new Player("Peter",6000),
                new Player("Ekaterina",6000),
                new Player("Alexander",6000)
            };

            Monopoly monopoly = new Monopoly(players,3);
            Player[] actualPlayers = monopoly.GetPlayersList().ToArray();

            //Assert.AreEqual()
            Assert.AreEqual(expectedPlayers, actualPlayers);
        }
        [Test]
        public void GetFieldsListReturnCorrectList()
        {
            Tuple<string, Monopoly.Type, int, bool>[] expectedCompanies = 
                new Tuple<string, Monopoly.Type, int, bool>[]{
                new Tuple<string,Monopoly.Type,int,bool>("Ford",Monopoly.Type.AUTO,0,false),
                new Tuple<string,Monopoly.Type,int,bool>("MCDonald", Monopoly.Type.FOOD, 0, false),
                new Tuple<string,Monopoly.Type,int,bool>("Lamoda", Monopoly.Type.CLOTHER, 0, false),
                new Tuple<string, Monopoly.Type, int, bool>("Air Baltic",Monopoly.Type.TRAVEL,0,false),
                new Tuple<string, Monopoly.Type, int, bool>("Nordavia",Monopoly.Type.TRAVEL,0,false),
                new Tuple<string, Monopoly.Type, int, bool>("Prison",Monopoly.Type.PRISON,0,false),
                new Tuple<string, Monopoly.Type, int, bool>("MCDonald",Monopoly.Type.FOOD,0,false),
                new Tuple<string, Monopoly.Type, int, bool>("TESLA",Monopoly.Type.AUTO,0,false)
            };
            string[] players = new string[] { "Peter", "Ekaterina", "Alexander" };
            Monopoly monopoly = new Monopoly(players, 3);
            Tuple<string, Monopoly.Type, int, bool>[] actualCompanies = monopoly.GetFieldsList().ToArray();
            Assert.AreEqual(expectedCompanies, actualCompanies);
        }
        [Test]
        public void PlayerBuyNoOwnedCompanies()
        {
            string[] players = new string[] { "Peter", "Ekaterina", "Alexander" };
            Monopoly monopoly = new Monopoly(players, 3);
            Tuple<string, Monopoly.Type, int, bool> x = monopoly.GetFieldByName("Ford");
            monopoly.Buy(1, x);
            Player actualPlayer = monopoly.GetPlayerInfo(1);
            Player expectedPlayer = new Player("Peter", 5500);
            Assert.AreEqual(expectedPlayer, actualPlayer);
            Tuple<string, Monopoly.Type, int, bool> actualField = monopoly.GetFieldByName("Ford");
            Assert.AreEqual(1, actualField.Item3);
        }
        [Test]
        public void RentaShouldBeCorrectTransferMoney()
        {
            string[] players = new string[] { "Peter", "Ekaterina", "Alexander" };
            Monopoly monopoly = new Monopoly(players, 3);
            Tuple<string, Monopoly.Type, int, bool>  x = monopoly.GetFieldByName("Ford");
            monopoly.Buy(1, x);
            x = monopoly.GetFieldByName("Ford");
            monopoly.Renta(2, x);
            Player player1 = monopoly.GetPlayerInfo(1);
            Assert.AreEqual(5750, player1.getCash());
            Player player2 = monopoly.GetPlayerInfo(2);
            Assert.AreEqual(5750, player2.getCash());
        }
    }
}
