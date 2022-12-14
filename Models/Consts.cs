using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public static class Consts
    {
        public static string MySQLConnectionString => "server=localhost;port=3306;database=bazaDanych;user=root;password=1234";
        public static string ServerURL => "https://localhost:7268";

        public static class Message
        {
            public static string ServerDown = "Server is down";
        }

        public static class HubUrl
        {
            public static string Monopoly => "/monopolyhub";
            public static string Battleship => "/battleshiphub";
            public static string DemoButtons => "/multihub";
        }
        public static class Battleship
        {
            public static Point2D BoardSize = new Point2D(10, 10);
        }
        public static class BlackJack
        {
            public static int MaxPoints = 31;
            public static int MinPoints = 27;
        }
        public static class TicTacToe
        {
            public static Point2D BoardSize = new Point2D(3, 3);
            public static char Player = 'X';
            public static char Enemy = 'O';
            public static char Empty = ' ';
            public static char Tie = '#';
        }
        public static class Monopoly
        {
            public static int IslandEscapeCost = 30;
            public static int StartMoneyAmount = 400;
            public static int OnStartCrossedMoneyGiven = 50;
            public static int StayCost = 100;
            public static int BuyCost = 200;
            public static float MonopolMultiplayer = 2.0f;

            public static string IslandDiaplsy = "Desert Island";

            public static float[] BeachesOwnedMultiplayer = new float[] { 0.0f, 1.0f, 2.0f, 3.0f, 4.0f };
        }
    }
}
