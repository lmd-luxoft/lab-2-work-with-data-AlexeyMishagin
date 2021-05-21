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

            Monopoly monopoly = new Monopoly(players);
            Player[] actualPlayers = monopoly.GetPlayersList().ToArray();

            //Assert.AreEqual()
            Assert.AreEqual(expectedPlayers, actualPlayers);
        }
        [Test]
        public void GetFieldsListReturnCorrectList()
        {
            Field[] expectedCompanies = 
                new Field[]{
                new FieldAuto("Ford",0,true),
                new FieldFood("MCDonald", 0, true),
                new FieldClother("Lamoda", 0, true),
                new FieldTravel("Air Baltic",0,true),
                new FieldTravel("Nordavia",0,true),
                new FieldPrison("Prison",0,false),
                new FieldFood("MCDonald",0,true),
                new FieldAuto("TESLA",0,true)
            };
            string[] players = new string[] { "Peter", "Ekaterina", "Alexander" };
            Monopoly monopoly = new Monopoly(players);
            Field[] actualCompanies = monopoly.GetFieldsList().ToArray();
            Assert.AreEqual(expectedCompanies, actualCompanies);
        }
        [Test]
        public void PlayerBuyAutoNoOwnedCompanies()
        {
            string[] players = new string[] { "Peter", "Ekaterina", "Alexander" };
            Monopoly monopoly = new Monopoly(players);
            Field x = monopoly.GetFieldByName("Ford");
            monopoly.Buy(1, x);
            Player actualPlayer = monopoly.GetPlayerInfo(1);
            Player expectedPlayer = new Player("Peter", 5500);
            Assert.AreEqual(expectedPlayer, actualPlayer);
            Field actualField = monopoly.GetFieldByName("Ford");
            Assert.AreEqual(1, actualField.getNumPlayer());
        }

        [Test]
        public void PlayerBuyClotherNoOwnedCompanies()
        {
            string[] players = new string[] { "Peter", "Ekaterina", "Alexander" };
            Monopoly monopoly = new Monopoly(players);
            Field x = monopoly.GetFieldByName("Lamoda");
            monopoly.Buy(1, x);
            Player actualPlayer = monopoly.GetPlayerInfo(1);
            Player expectedPlayer = new Player("Peter", 5900);
            Assert.AreEqual(expectedPlayer, actualPlayer);
            Field actualField = monopoly.GetFieldByName("Lamoda");
            Assert.AreEqual(1, actualField.getNumPlayer());
        }

        [Test]
        public void AnotherPlayerBuyAutoNoOwnedCompanies()
        {
            string[] players = new string[] { "Peter", "Ekaterina", "Alexander" };
            Monopoly monopoly = new Monopoly(players);
            Field x = monopoly.GetFieldByName("Ford");
            monopoly.Buy(2, x);
            Player actualPlayer = monopoly.GetPlayerInfo(2);
            Player expectedPlayer = new Player("Ekaterina", 5500);
            Assert.AreEqual(expectedPlayer, actualPlayer);
            Field actualField = monopoly.GetFieldByName("Ford");
            Assert.AreEqual(2, actualField.getNumPlayer());
        }

        [Test]
        public void AnotherPlayerBuyFoodNoOwnedCompanies()
        {
            string[] players = new string[] { "Peter", "Ekaterina", "Alexander" };
            Monopoly monopoly = new Monopoly(players);
            Field x = monopoly.GetFieldByName("MCDonald");
            monopoly.Buy(3, x);
            Player actualPlayer = monopoly.GetPlayerInfo(3);
            Player expectedPlayer = new Player("Alexander", 5750);
            Assert.AreEqual(expectedPlayer, actualPlayer);
            Field actualField = monopoly.GetFieldByName("MCDonald");
            Assert.AreEqual(3, actualField.getNumPlayer());
        }

        [Test]
        public void RentaShouldBeCorrectTransferMoney()
        {
            string[] players = new string[] { "Peter", "Ekaterina", "Alexander" };
            Monopoly monopoly = new Monopoly(players);
            Field  x = monopoly.GetFieldByName("Ford");
            monopoly.Buy(1, x);
            x = monopoly.GetFieldByName("Ford");
            monopoly.Renta(2, x);
            Player player1 = monopoly.GetPlayerInfo(1);
            Assert.AreEqual(5750, player1.getCash());
            Player player2 = monopoly.GetPlayerInfo(2);
            Assert.AreEqual(5750, player2.getCash());
        }

        [Test]
        public void TestValidValueOfPrice()
        {
            string[] players = new string[] { "Peter", "Ekaterina", "Alexander" };
            Monopoly monopoly = new Monopoly(players);
            Field actualField = monopoly.GetFieldByName("Ford");
            Assert.That(actualField.getPrice(), Is.EqualTo(500));
        }

        [Test]
        public void TestValidValueOfRenta()
        {
            string[] players = new string[] { "Peter", "Ekaterina", "Alexander" };
            Monopoly monopoly = new Monopoly(players);
            Field actualField = monopoly.GetFieldByName("Ford");
            Assert.That(actualField.getRenta(), Is.EqualTo(250));
        }
    }
}
