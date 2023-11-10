using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Card
    {
        public string cardName { get; set; }
        public int cardValue { get; set; }
        public string cardSuit { get; set; }
        public Card(string type, int value, string suit)
        { 
            cardName = type;
            cardValue = value;
            cardSuit = suit;
        }

        //a method to create a list of all possible cards and their values
        public static List<Card> AllCards()
        {
            List<Card> cards = new List<Card>();
            cards.Add(new Card("2", 2, "Clubs"));
            cards.Add(new Card("3", 3, "Clubs"));
            cards.Add(new Card("4", 4, "Clubs"));
            cards.Add(new Card("5", 5, "Clubs"));
            cards.Add(new Card("6", 6, "Clubs"));
            cards.Add(new Card("7", 7, "Clubs"));
            cards.Add(new Card("8", 8, "Clubs"));
            cards.Add(new Card("9", 9, "Clubs"));
            cards.Add(new Card("10", 10, "Clubs"));
            cards.Add(new Card("Jack", 10, "Clubs"));
            cards.Add(new Card("Queen", 10, "Clubs"));
            cards.Add(new Card("King", 10, "Clubs"));
            cards.Add(new Card("Ace", 11, "Clubs"));
            cards.Add(new Card("2", 2, "Diamonds"));
            cards.Add(new Card("3", 3, "Diamonds"));
            cards.Add(new Card("4", 4, "Diamonds"));
            cards.Add(new Card("5", 5, "Diamonds"));
            cards.Add(new Card("6", 6, "Diamonds"));
            cards.Add(new Card("7", 7, "Diamonds"));
            cards.Add(new Card("8", 8, "Diamonds"));
            cards.Add(new Card("9", 9, "Diamonds"));
            cards.Add(new Card("10", 10, "Diamonds"));
            cards.Add(new Card("Jack", 10, "Diamonds"));
            cards.Add(new Card("Queen", 10, "Diamonds"));
            cards.Add(new Card("King", 10, "Diamonds"));
            cards.Add(new Card("Ace", 11, "Diamonds"));
            cards.Add(new Card("2", 2, "Hearts"));
            cards.Add(new Card("3", 3, "Hearts"));
            cards.Add(new Card("4", 4, "Hearts"));
            cards.Add(new Card("5", 5, "Hearts"));
            cards.Add(new Card("6", 6, "Hearts"));
            cards.Add(new Card("7", 7, "Hearts"));
            cards.Add(new Card("8", 8, "Hearts"));
            cards.Add(new Card("9", 9, "Hearts"));
            cards.Add(new Card("10", 10, "Hearts"));
            cards.Add(new Card("Jack", 10, "Hearts"));
            cards.Add(new Card("Queen", 10, "Hearts"));
            cards.Add(new Card("King", 10, "Hearts"));
            cards.Add(new Card("Ace", 11, "Hearts"));
            cards.Add(new Card("2", 2, "Spades"));
            cards.Add(new Card("3", 3, "Spades"));
            cards.Add(new Card("4", 4, "Spades"));
            cards.Add(new Card("5", 5, "Spades"));
            cards.Add(new Card("6", 6, "Spades"));
            cards.Add(new Card("7", 7, "Spades"));
            cards.Add(new Card("8", 8, "Spades"));
            cards.Add(new Card("9", 9, "Spades"));
            cards.Add(new Card("10", 10, "Spades"));
            cards.Add(new Card("Jack", 10, "Spades"));
            cards.Add(new Card("Queen", 10, "Spades"));
            cards.Add(new Card("King", 10, "Spades"));
            cards.Add(new Card("Ace", 11, "Spades"));

            return cards;
        }
    }
}
