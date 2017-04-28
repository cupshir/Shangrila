﻿using ShangriLa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShangriLa.Classes
{
    public class DataRepository
    {
        public static Player GetPlayer(int id)
        {
            using (ShangriLaContext db = new ShangriLaContext())
            {
                return db.Players.Single(p => p.Id == id);
            }
        }

        public static Player GetPlayer(string name)
        {
            using (ShangriLaContext db = new ShangriLaContext())
            {
                return db.Players.Single(p => p.Name == name);
            }
        }

        public static List<Player> GetAllPlayers()
        {
            using (ShangriLaContext db = new ShangriLaContext())
            {
                return db.Players.ToList();
            }
        }

        public static GamePlayer GetGamePlayer(int gameId, int playerId)
        {
            using (ShangriLaContext db = new ShangriLaContext())
            {
                return db.GamePlayers.Where(p => p.GameId == gameId).Single(x => x.PlayerId == playerId);
            }
        }

        public static bool IsPlayerInGame(int gameId, int playerId)
        {
            using (ShangriLaContext db = new ShangriLaContext())
            {
                if (db.GamePlayers.Any(p => p.GameId == gameId && p.PlayerId == playerId))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }   
        }

        public static List<GamePlayer> GetGamePlayers(int gameId)
        {
            using (ShangriLaContext db = new ShangriLaContext())
            {
                return db.GamePlayers.Where(p => p.GameId == gameId).ToList();
            }
        }

        public static void CreateNewPlayer(string name, string email)
        {
            using (ShangriLaContext db = new ShangriLaContext())
            {
                db.Players.Add(new Player { Name = name, Email = email });
                db.SaveChanges();
            }
        }

        public static Game GetGame(int gameId)
        {
            using (ShangriLaContext db = new ShangriLaContext())
            {
                return db.Games.Single(p => p.Id == gameId);
            }
        }

        public static List<Game> GetActiveGames()
        {
            using (ShangriLaContext db = new ShangriLaContext())
            {
                return db.Games.Where(p => p.IsComplete == false).OrderBy(x => x.CreatedDateTime).ToList();
            }
        }

        public static Game CreateNewGame()
        {
            Game newGame = new Game() { CreatedDateTime = DateTime.Now, IsComplete = false };
            using (ShangriLaContext db = new ShangriLaContext())
            {
                db.Games.Add(newGame);
                db.SaveChanges();
            }
            return newGame;
        }

        public static void AddPlayerToGame(int gameId, int playerId)
        {
            using (ShangriLaContext db = new ShangriLaContext())
            {
                GamePlayer newGamePlayer = new GamePlayer()
                {
                    GameId = gameId,
                    PlayerId = playerId,
                    TwoSetsOneRun = 0,
                    TwoRunsOneSet = 0,
                    ThreeSets = 0,
                    ThreeRuns = 0,
                    ThreeSetsOneRun = 0,
                    TwoSetsTwoRuns = 0,
                    FourSets = 0,
                    TotalScore = 0
                };
                db.GamePlayers.Add(newGamePlayer);
                db.SaveChanges();
            }
        }
    }
}