using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using UnityEngine;

namespace Assets.Scripts.Models
{
    public class Deck
    {
        public Deck()
        {
            Cards = new List<Card>();
        }

        [XmlAttribute]
        public string Name { get; set; }

        public List<Card> Cards { get; set; }
        
        public static Deck Merge(List<Deck> availableDecks)
        {
            Deck deck = new Deck
            {
                Cards = new List<Card>()
            };

            foreach (var availableDeck in availableDecks)
            {
                deck.Cards.AddRange(availableDeck.Cards);
            }

            return deck;
        }

        public void Shuffle()
        {
            Cards = Cards.OrderBy(c => Random.Range(0f, 1f)).ToList();
        }
    }
}