using System.Net.Http;
using System.Threading;

namespace JokenpoGame
{

    public class Jokenpo
    {
        public PlayerChoice playerChoice { get; set; }
        public List<PlayerChoice> winsAgains { get; set; }
        public List<PlayerChoice> losesAgainst { get; set; }

        public Jokenpo() { }

        public Jokenpo(PlayerChoice playerChoice, List<PlayerChoice> winsAgainst, List<PlayerChoice> losesAgainst)
        {
            this.playerChoice = playerChoice;
            this.winsAgains = winsAgainst;
            this.losesAgainst = losesAgainst;
        }

        public GameResult Play(Jokenpo player1, Jokenpo player2)
        {
            if (player1.playerChoice == player2.playerChoice)
            {
                return GameResult.Draw;
            }

            return player1.winsAgains.Contains(player2.playerChoice)
                ? GameResult.Player1Wins
                : GameResult.Player2Wins;
        }
    }

    public enum PlayerChoice
    {
        Rock,
        Paper,
        Scissors
    }

    public enum GameResult
    {
        Player1Wins,
        Player2Wins,
        Draw
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var player1 = new Jokenpo(PlayerChoice.Rock, new List<PlayerChoice>() { PlayerChoice.Scissors }, new List<PlayerChoice>() { PlayerChoice.Paper });
            var player2 = new Jokenpo(PlayerChoice.Scissors, new List<PlayerChoice>() { PlayerChoice.Paper }, new List<PlayerChoice>() { PlayerChoice.Rock });

            var result = new Jokenpo().Play(player1, player2);

            Console.WriteLine($"Result: {result}");
        }
    }
}
