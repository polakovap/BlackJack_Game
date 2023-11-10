using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //create a list of players
            List<Player> players = new List<Player>();

            //get the players info
            for (int i = 0; i < 2; i++)
            {
                //Console.Write("Enter your name: ");
                //string name = Console.ReadLine();
                //Console.Write("Enter your age: ");
                //int age = int.Parse(Console.ReadLine());
                //Console.Write("Enter your bet: ");
                //int bet = int.Parse(Console.ReadLine());
                string name = "Petra";
                int age = 20;
                int bet = 45;
                Player player = new Player(name, age, bet);
                players.Add(player);
            }

            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Players, welcome to the game of BLACK JACK!");
            Console.WriteLine("-----------------------------------------------");

            //rules book
            Console.Write("Display rules (y/n)? ");
            string rules = Console.ReadLine().ToLower();
            if (rules == "y")
            {
                Console.WriteLine("");
                RulesBook();
            }

            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("GAME ON");
            Console.WriteLine("-----------------------------------------------");

            playersTurn(players);
            int dealersScore = dealersTurn();
            payOut(players, dealersScore);
        }

        public static void playersTurn(List<Player> players)
        {
            //random instance to get random cards for dealing
            var random = new Random();

            for (int i = 0; i < players.Count; i++)
            {
                //deal the cards to the player
                Console.WriteLine($"It is {players[i].name}’s turn.");
                Card card1 = CardDealt(random);
                Console.WriteLine($"Card dealt is {card1.cardName} of {card1.cardSuit} with a value of {card1.cardValue}");
                Card card2 = CardDealt(random);
                Console.WriteLine($"Card dealt is {card2.cardValue} of {card2.cardSuit} with a value of {card2.cardValue}");

                //count the value of the cards
                int total = card1.cardValue + card2.cardValue;
                Console.WriteLine($"Your score is {total}");

                //ask the player for the next move
                Console.Write($"\nDo you wish to stand or hit (s/h)?");
                string choice = Console.ReadLine().ToLower();
                bool nextPlayer = false;

                while (choice == "h" && !nextPlayer)
                {
                    total = hit(total, random);
                    Console.WriteLine($"\nYour score is {total}");
                    
                    //in case of a bust or BJ
                    if (total > 21)
                    {
                        Console.WriteLine("\nIt’s a BUST!");
                        nextPlayer = true;
                    }
                    else if (total == 21)
                    {
                        Console.WriteLine("\nIt’s a BLACKJACK!");
                        nextPlayer= true;
                    }

                    if(!nextPlayer)
                    {
                        Console.Write($"\nDo you wish to stand or hit (s/h)?");
                        choice = Console.ReadLine().ToLower();
                    }
                    
                }

                players[i].score = total;
                Console.WriteLine("-----------------------------------------------");
            }
        }

        public static int dealersTurn()
        {
            //random instance to get random cards for dealing
            var random = new Random();

            Console.WriteLine("It’s the Dealer’s turn!");

            Card card1 = CardDealt(random);
            Console.WriteLine($"Card dealt is {card1.cardName} of {card1.cardSuit} with a value of {card1.cardValue}");
            Card card2 = CardDealt(random);
            Console.WriteLine($"Card dealt is {card2.cardValue} of {card2.cardSuit} with a value of {card2.cardValue}");

            //count the value of the cards
            int total = card1.cardValue + card2.cardValue;
            Console.WriteLine($"Dealer’s score is {total}\n");

            while (total < 17)
            {
                total = hit(total, random);
                Console.WriteLine($"Dealer’s score is {total}");
            }
            //in case of a bust or BJ
            if (total > 21)
            {
                Console.WriteLine("\nDealer’s gotten a BUST!");
            }
            else if (total == 21)
            {
                Console.WriteLine("\nDealer’s gotten a BLACKJACK!");
            }

            return total;

            Console.WriteLine("-----------------------------------------------");
        }

        public static int hit(int total, Random random)
        {
            //deal another card
            Card card3 = CardDealt(random);
            Console.WriteLine($"Card dealt is {card3.cardName} of {card3.cardSuit} with a value of {card3.cardValue}");

            //count the total score
            total += card3.cardValue;

            return total;
        }

        public static Card CardDealt(Random random)
        {
            //get the list of all cards
            List<Card> cards = Card.AllCards();

            //get the random index of a card that will be dealt

            int index = random.Next(0, cards.Count);

            //find the randomly generated card
            Card cardDealt = cards[index];

            return cardDealt;
        }

        public static void payOut(List<Player> players, int dealersScore)
        {
            Console.WriteLine("-----------------------------------------------");

            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].score > dealersScore && players[i].score < 21)
                {
                    int win = 2 * players[i].bet;
                    Console.WriteLine($"Congratulations! {players[i].name} wins over the dealer, you won {win:c}.");
                }
                else if (players[i].score == 21)
                {
                    int win = 3 * players[i].bet;
                    Console.WriteLine($"Congratulations! {players[i].name} got a BLACKJACK and wins over the dealer, you won {win:c}");
                }
                else if (players[i].score > 21)
                {
                    Console.WriteLine($"{players[i].name}, it’s a bust! Dealer takes your money.");
                }
                else if (players[i].score < dealersScore && dealersScore < 21)
                {
                    Console.WriteLine($"{players[i].name}, you lost to the Dealer. Dealer takes your money.");
                }
                else if (dealersScore > 21)
                {
                    int win = 2 * players[i].bet;
                    Console.WriteLine($"Congratulations! Dealer’s busted, {players[i].name} wins, you won {win:c}.");
                }
            }
        }

        public static void RulesBook()
        {
            string path = @"../../../BlackJack_rules.txt";

            //read in all lines
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }

    }
}
