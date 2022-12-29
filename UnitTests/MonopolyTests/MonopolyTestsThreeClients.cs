﻿using Enums.Monopoly;
using Models.Monopoly;
using Models.MultiplayerConnection;
using Org.BouncyCastle.Crypto;
using Services.GamesServices.Monopoly;
using Services.GamesServices.Monopoly.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UnitTests.MonopolyTests
{
    [TestClass]
    public class MonopolyTestsThreeClients
    {
        [TestMethod]
        public void MoneyOwnedAfterTurn1()
        {
            MonopolyService FirstClient = new MonopolyGameLogic();
            MonopolyService SecoundClient = new MonopolyGameLogic();
            MonopolyService ThirdClient = new MonopolyGameLogic();


            List<MonopolyService> Clients = new List<MonopolyService>();
            Clients.Add(FirstClient);
            Clients.Add(SecoundClient);
            Clients.Add(ThirdClient);
            List<MoneyFlow> ClientsMoneyFlow = MonopolyDataPrepare.ExecuteTurnsNumber(1, ref Clients);

            List<PlayerUpdateData> ActualMoney = FirstClient.GetUpdatedData().PlayersData;

            Assert.IsTrue(ActualMoney[0].Money == MonopolyDataPrepare.GetExpectedMoney(ClientsMoneyFlow)[0]);
            Assert.IsTrue(ActualMoney[1].Money == MonopolyDataPrepare.GetExpectedMoney(ClientsMoneyFlow)[1]);
            Assert.IsTrue(ActualMoney[2].Money == MonopolyDataPrepare.GetExpectedMoney(ClientsMoneyFlow)[2]);
        }

        [TestMethod]
        public void MoneyOwnedAfterTurn2()
        {
            MonopolyService FirstClient = new MonopolyGameLogic();
            MonopolyService SecoundClient = new MonopolyGameLogic();
            MonopolyService ThirdClient = new MonopolyGameLogic();


            List<MonopolyService> Clients = new List<MonopolyService>();
            Clients.Add(FirstClient);
            Clients.Add(SecoundClient);
            Clients.Add(ThirdClient);
            List<MoneyFlow> ClientsMoneyFlow = MonopolyDataPrepare.ExecuteTurnsNumber(2, ref Clients);

            List<PlayerUpdateData> ActualMoney = FirstClient.GetUpdatedData().PlayersData;

            Assert.IsTrue(ActualMoney[0].Money == MonopolyDataPrepare.GetExpectedMoney(ClientsMoneyFlow)[0]);
            Assert.IsTrue(ActualMoney[1].Money == MonopolyDataPrepare.GetExpectedMoney(ClientsMoneyFlow)[1]);
            Assert.IsTrue(ActualMoney[2].Money == MonopolyDataPrepare.GetExpectedMoney(ClientsMoneyFlow)[2]);
        }

        [TestMethod]
        public void MoneyOwnedAfterTurn3()
        {
            MonopolyService FirstClient = new MonopolyGameLogic();
            MonopolyService SecoundClient = new MonopolyGameLogic();
            MonopolyService ThirdClient = new MonopolyGameLogic();


            List<MonopolyService> Clients = new List<MonopolyService>();
            Clients.Add(FirstClient);
            Clients.Add(SecoundClient);
            Clients.Add(ThirdClient);
            List<MoneyFlow> ClientsMoneyFlow = MonopolyDataPrepare.ExecuteTurnsNumber(3, ref Clients);

            List<PlayerUpdateData> ActualMoney = FirstClient.GetUpdatedData().PlayersData;

            Assert.IsTrue(ActualMoney[0].Money == MonopolyDataPrepare.GetExpectedMoney(ClientsMoneyFlow)[0]);
            Assert.IsTrue(ActualMoney[1].Money == MonopolyDataPrepare.GetExpectedMoney(ClientsMoneyFlow)[1]);
            Assert.IsTrue(ActualMoney[2].Money == MonopolyDataPrepare.GetExpectedMoney(ClientsMoneyFlow)[2]);
        }

        [TestMethod]
        public void MoneyOwnedAfterTurn4()
        {
            MonopolyService FirstClient = new MonopolyGameLogic();
            MonopolyService SecoundClient = new MonopolyGameLogic();
            MonopolyService ThirdClient = new MonopolyGameLogic();


            List<MonopolyService> Clients = new List<MonopolyService>();
            Clients.Add(FirstClient);
            Clients.Add(SecoundClient);
            Clients.Add(ThirdClient);
            List<MoneyFlow> ClientsMoneyFlow = MonopolyDataPrepare.ExecuteTurnsNumber(4, ref Clients);

            List<PlayerUpdateData> ActualMoney = FirstClient.GetUpdatedData().PlayersData;

            Assert.IsTrue(ActualMoney[0].Money == MonopolyDataPrepare.GetExpectedMoney(ClientsMoneyFlow)[0]);
            Assert.IsTrue(ActualMoney[1].Money == MonopolyDataPrepare.GetExpectedMoney(ClientsMoneyFlow)[1]);
            Assert.IsTrue(ActualMoney[2].Money == MonopolyDataPrepare.GetExpectedMoney(ClientsMoneyFlow)[2]);
        }

        [TestMethod]
        public void MoneyOwnedAfterTurn5()
        {
            MonopolyService FirstClient = new MonopolyGameLogic();
            MonopolyService SecoundClient = new MonopolyGameLogic();
            MonopolyService ThirdClient = new MonopolyGameLogic();


            List<MonopolyService> Clients = new List<MonopolyService>();
            Clients.Add(FirstClient);
            Clients.Add(SecoundClient);
            Clients.Add(ThirdClient);
            List<MoneyFlow> ClientsMoneyFlow = MonopolyDataPrepare.ExecuteTurnsNumber(5, ref Clients);

            List<PlayerUpdateData> ActualMoney = FirstClient.GetUpdatedData().PlayersData;
            List<int> ExpectedMoney = MonopolyDataPrepare.GetExpectedMoney(ClientsMoneyFlow);

            Assert.IsTrue(ActualMoney[0].Money == ExpectedMoney[0]);
            Assert.IsTrue(ActualMoney[1].Money == ExpectedMoney[1]);
            Assert.IsTrue(ActualMoney[2].Money == ExpectedMoney[2]);
        }

        [TestMethod]
        public void BankrupcyTest1()
        {

            MonopolyService FirstClient = null;
            MonopolyService SecoundClient = null;
            MonopolyService ThirdClient = null;
            List<MonopolyService> Clients = null;
            List<MoneyFlow> PlayersMoneyFlow = null;

            for (int i = 1; ; i++)
            {
                FirstClient = new MonopolyGameLogic();
                SecoundClient = new MonopolyGameLogic();
                ThirdClient = new MonopolyGameLogic();

                Clients = new List<MonopolyService>();
                Clients.Add(FirstClient);
                Clients.Add(SecoundClient);
                Clients.Add(ThirdClient);
                PlayersMoneyFlow = MonopolyDataPrepare.ExecuteTurnsNumber(i, ref Clients);

                if (PlayersMoneyFlow[2].Income + Consts.Monopoly.StartMoneyAmount < PlayersMoneyFlow[2].Loss)
                {
                    break;
                }
            }

            MonopolyUpdateMessage CheckBankrupcy = ThirdClient.GetUpdatedData();
            
            Assert.IsTrue(CheckBankrupcy.BankruptPlayer == PlayerKey.Third);
        }

        [TestMethod]
        public void BankrupcyTest2()
        {

            MonopolyService FirstClient = null;
            MonopolyService SecoundClient = null;
            MonopolyService ThirdClient = null;
            List<MonopolyService> Clients = null;
            List<MoneyFlow> PlayersMoneyFlow = null;

            for (int i = 1; ; i++)
            {
                FirstClient = new MonopolyGameLogic();
                SecoundClient = new MonopolyGameLogic();
                ThirdClient = new MonopolyGameLogic();

                Clients = new List<MonopolyService>();
                Clients.Add(FirstClient);
                Clients.Add(SecoundClient);
                Clients.Add(ThirdClient);
                PlayersMoneyFlow = MonopolyDataPrepare.ExecuteTurnsNumber(i, ref Clients);

                if (PlayersMoneyFlow[1].Income + Consts.Monopoly.StartMoneyAmount < PlayersMoneyFlow[1].Loss)
                {
                    break;
                }
            }

            MonopolyUpdateMessage CheckBankrupcy = SecoundClient.GetUpdatedData();

            Assert.IsTrue(CheckBankrupcy.BankruptPlayer == PlayerKey.Secound);
        }

        [TestMethod]
        public void WhosTurnTest()
        {
            MonopolyService FirstClient = null;
            MonopolyService SecoundClient = null;
            MonopolyService ThirdClient = null;
            List<MonopolyService> Clients = null;
            List<MoneyFlow> PlayersMoneyFlow = null;

            FirstClient = new MonopolyGameLogic();
            SecoundClient = new MonopolyGameLogic();
            ThirdClient = new MonopolyGameLogic();

            Clients = new List<MonopolyService>();
            Clients.Add(FirstClient);
            Clients.Add(SecoundClient);
            Clients.Add(ThirdClient);

            MonopolyDataPrepare.PrepareClientsData(ref Clients);

            while(true)
            {
                Clients[0].ExecuteTurn(1);
                Clients[0].BuyCellIfPossible();

                MonopolyService CurrentClient = Clients[0];
                MonopolyDataPrepare.UpdateOthers(ref Clients, ref CurrentClient);

                Clients[1].ExecuteTurn(1);

                CurrentClient = Clients[1];
                MonopolyDataPrepare.UpdateOthers(ref Clients, ref CurrentClient);

                if (Clients[0].GetUpdatedData().PlayersData.Count == 2)
                    break;

            }
            Clients[1].UpdateData(Clients[1].GetUpdatedData());

            Assert.IsTrue(Clients[2].IsYourTurn() == true);
            Assert.IsTrue(Clients[1].IsYourTurn() == false);
            Assert.IsTrue(Clients[0].IsYourTurn() == false);

            Clients[0].NextTurn();
            Clients[2].NextTurn();

            

            Assert.IsTrue(Clients[2].IsYourTurn() == false);
            Assert.IsTrue(Clients[1].IsYourTurn() == false);
            Assert.IsTrue(Clients[0].IsYourTurn() == true);
        }

        [TestMethod]
        public void WinnerTest()
        {
            MonopolyService FirstClient = null;
            MonopolyService SecoundClient = null;
            MonopolyService ThirdClient = null;
            List<MonopolyService> Clients = null;
            List<MoneyFlow> PlayersMoneyFlow = null;

            for (int i = 1; ; i++)
            {
                FirstClient = new MonopolyGameLogic();
                SecoundClient = new MonopolyGameLogic();
                ThirdClient = new MonopolyGameLogic();

                Clients = new List<MonopolyService>();
                Clients.Add(FirstClient);
                Clients.Add(SecoundClient);
                Clients.Add(ThirdClient);
                PlayersMoneyFlow = MonopolyDataPrepare.ExecuteTurnsNumber(i, ref Clients);

                if (PlayersMoneyFlow[2].Income + Consts.Monopoly.StartMoneyAmount < PlayersMoneyFlow[2].Loss &&
                    PlayersMoneyFlow[1].Income + Consts.Monopoly.StartMoneyAmount < PlayersMoneyFlow[1].Loss)
                {
                    break;
                }
            }

            SecoundClient.UpdateData(SecoundClient.GetUpdatedData());
            ThirdClient.UpdateData(ThirdClient.GetUpdatedData());

            Assert.IsTrue(FirstClient.WhoWon() == PlayerKey.First);
            Assert.IsTrue(SecoundClient.WhoWon() == PlayerKey.First);
            Assert.IsTrue(ThirdClient.WhoWon() == PlayerKey.First);
        }

        
    }
}
  
  