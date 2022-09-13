using System;

namespace CodingChallenge
{
  /*********************************************************************************************
   * You will have 1 hour to take this test.  The purpose of this test to see how you would 
   * think threw a problem and the approach you would take.  It's not expected that you will
   * have a tested and functional program at the end of the time.
 *
   * Create a program that can shuffle the cards, and then deal out a hand of blackjack(2 cards 
   * to each player) with a standard deck of cards (52 cards) with the goal of being the closest
   * player to 21 without going over.  Players can then hit (get another card) or hold (stay with 
   * what they have).  Players should hit if they have less than 17.  Numbered cards are worth 
   * their value; Jack, Queen, King are worth 10; Ace is worth 11 for the first and 1 for any 
   * others. Keep in mind that the company will want to support other card games in the future.
   * 
   * You can use the internet for searching for syntax.  Creating a well structured program is
 * preferred over interfaces, unit tests or a fully working program.
   * 
   * Ranks:
      Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace

  * Suits:
      Hearts, Diamonds, Spades, Clubs
  *********************************************************************************************/
  class Program
  {
    static void Main(string[] args)
    {
      GameManager manager = new GameManager("BlackJack");
      manager.Run();
    }
  }
}
