using ShangriLa.Models;
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

        public static Player CreateNewPlayer(string name, string email)
        {
            using (ShangriLaContext db = new ShangriLaContext())
            {
                Player newPlayer = new Player() { Name = name, Email = email };
                db.Players.Add(newPlayer);
                db.SaveChanges();
                return newPlayer;
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
                Player player = db.Players.Single(p => p.Id == playerId);
                GamePlayer newGamePlayer = new GamePlayer()
                {
                    GameId = gameId,
                    PlayerId = playerId,
                    PlayerName = player.Name,
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

        public static void UpdatePlayerScore(int gameId, int playerId, string hand, int score)
        {
            using (ShangriLaContext db = new ShangriLaContext())
            {
                GamePlayer gamePlayer = db.GamePlayers.Single(p => p.GameId == gameId && p.PlayerId == playerId);
                switch (hand)
                {
                    case "2 Sets 1 Run":
                        gamePlayer.TwoSetsOneRun = score;
                        break;
                    case "2 Runs 1 Set":
                        gamePlayer.TwoRunsOneSet = score;
                        break;
                    case "3 Sets":
                        gamePlayer.ThreeSets = score;
                        break;
                    case "3 Runs":
                        gamePlayer.ThreeRuns = score;
                        break;
                    case "3 Sets 1 Run":
                        gamePlayer.ThreeSetsOneRun = score;
                        break;
                    case "2 Sets 2 Runs":
                        gamePlayer.TwoSetsTwoRuns = score;
                        break;
                    case "4 Sets":
                        gamePlayer.FourSets = score;
                        break;
                    default:
                        break;
                }
                db.SaveChanges();
            }
        }

        public static void UpdatePlayerTotalScore(int gameId, int playerId, int totalScore)
        {
            using(ShangriLaContext db = new ShangriLaContext())
            {
                GamePlayer gamePlayer = db.GamePlayers.Single(p => p.GameId == gameId && p.PlayerId == playerId);

                gamePlayer.TotalScore = totalScore;

                db.SaveChanges();
            }
        }

        public static void CompleteGame(int gameId)
        {
            using (ShangriLaContext db = new ShangriLaContext())
            {
                Game game = db.Games.Single(p => p.Id == gameId);

                game.IsComplete = true;

                db.SaveChanges();
            }
        }

    }
}