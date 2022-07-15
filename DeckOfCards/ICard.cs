using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckOfCards
{
    internal interface ICard
    {
        void Shuffle();
        void CompareCards();
        void SortCards();
        void SelectedSuit();
        void CardsinHand();
    }
}
