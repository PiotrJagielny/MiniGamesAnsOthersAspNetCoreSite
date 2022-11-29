﻿using Enums;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using Models;
using Services.GamesServices.Battleships;
using System.Runtime.Serialization.Json;
using System.Text.Json.Serialization;

namespace BlazorClient.Components.MultiplayerGameComponents.BattleshipComponentFiles
{
    public class BattleshipGameBase : ComponentBase
    {
        [Inject]
        public NavigationManager NavManager { get; set; }

        [Inject]
        public BattleshipService BattleshipLogic { get; set; }

        [Parameter]
        public string LoggedUserName { get; set; }

        private HubConnection BattleshipHubConn;

        public string UserMessage { get; private set; }

        public bool IsEnemyFound { get; set; }
        public bool IsYourTurn { get; set; }

        protected override async Task OnInitializedAsync()
        {
            UserMessage = "";
            BattleshipHubConn = new HubConnectionBuilder().WithUrl(NavManager.ToAbsoluteUri($"{Constants.ServerURL}/battleshiphub")).WithAutomaticReconnect().Build();
            await BattleshipHubConn.StartAsync();

            BattleshipHubConn.On<bool, bool>("IsEnemyFound", (isEnemyFound, IsYourTurn) =>
            {
                IsEnemyFound = isEnemyFound;
                this.IsYourTurn = IsYourTurn;
                InvokeAsync(StateHasChanged);
            });

            BattleshipHubConn.On<Point2D>("EnemyAttack" ,(OnPoint) =>
            {
                BattleshipLogic.EnemyAttack(OnPoint);

                BattleshipCell AttackedCell = BattleshipLogic.GetUserBoardCell(OnPoint);
                bool IsShipDestroyed = BattleshipLogic.DoesEnemyDestroyedShip(OnPoint);
                BattleshipHubConn.SendAsync("SendAttackedCell",AttackedCell, IsShipDestroyed, LoggedUserName);
               

                ChangeTurnIfTrue(BattleshipLogic.IsShipHit(OnPoint) == false);
                InvokeAsync(StateHasChanged);                
            });

            BattleshipHubConn.On<BattleshipCell, bool>("RecieveAttackedCell", (AttackedCell, IsShipDestroyed) =>
            {
                BattleshipLogic.AttackOnEnemyBoard(AttackedCell, IsShipDestroyed);

                ChangeTurnIfTrue(AttackedCell.state != BattleshipCellState.DestroyedShip);
                InvokeAsync(StateHasChanged);
            });

            
            
        }

        private void ChangeTurnIfTrue(bool IsTurnChanged)
        {
            if (IsTurnChanged == true)
                IsYourTurn = !IsYourTurn;

            CheckIfGameIsOver();
        }
        private void CheckIfGameIsOver()
        {
            if (BattleshipLogic.IsGameOver())
            {
                IsYourTurn = false;
                UserMessage = "Game Has Ended!";
            }
        }

        protected bool IsGameStarted() { return IsEnemyFound == true; }


        protected async Task FindEnemy()
        {
            await BattleshipHubConn.SendAsync("OnUserConnected", LoggedUserName, BattleshipHubConn.ConnectionId);

            if (BattleshipLogic.IsUserBoardCorrect())
            {
                await BattleshipHubConn.SendAsync("FindEnemyForUser", LoggedUserName);
                UserMessage = "";
            }
            else
                UserMessage = "Ships distribution is not correct";
        }

        protected void UserBoardClicked(Point2D OnPoint)
        {
            BattleshipLogic.UserBoardClicked(OnPoint);
        }

        protected async Task EnemyBoardClicked(Point2D OnPoint)
        {
            await BattleshipHubConn.SendAsync("UserAttack", OnPoint, LoggedUserName);
        }
    }
}
