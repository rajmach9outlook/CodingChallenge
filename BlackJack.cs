using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenge
{
  public enum Rank
  {
    Ace,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Jack,
    Queen,
    King
  }

  public enum Suit
  {
    Clubs,
    Spades,
    Diamonds,
    Hearts
  }

  public enum Action
  {
    Hit,
    Stand
  }

  public class BlackJack
  {
    public int NoOfPlayers { get; set; }
    public List<Card> cards { get; set; }

    private List<Player> players;

    public BlackJack()
    {
      players = new List<Player>();

      Setup();

      for(int p = 0; p <NoOfPlayers; p++)
      {
        players.Add(new Player() { cards = DistributeCards()});
      }      
    }

    public void BeginRound()
    {
      foreach(Player p in players)
      {
        p.action = Console.ReadLine();
        p.PerformAction();
      }
    }

    public void AssessSuccess()
    {
      int counter = 1;
      foreach (Player p in players)
      {
        int val = p.GetTotalValue();
        if (val == 21)
        {
          p.result = "BlacJack";
        }
        else if (val > 21)
        {
          p.result = "Busted";
        }
        else if (val < 21 && val > 17)
        {
          p.result = "Awaiting Dealer Card total";
        }

        Console.WriteLine($"Player {counter} - { p.result}");
        counter++;
      }
    }

    public void Setup()
    {
      cards = new List<Card>();

      for (int i = 0; i < 13; i++)
      {
        for (int j = 0; j < 4; j++)
        {
          cards.Add(new Card((Rank)i, (Suit)j ));
        }
      }

      Random ran = new Random();

      for (int counter = 1; counter <= cards.Count; counter++)
      {
        int cardNo = ran.Next(counter + 1);
        Card card = cards[cardNo];
        cards[cardNo] = cards[counter];
        cards[counter] = card;
      }
    }

    public List<Card> DistributeCards()
    {
      List<Card> set = new List<Card>();
      set.Add(cards[0]);
      set.Add(cards[1]);

      cards.Remove(cards[0]);
      cards.Remove(cards[1]);

      return set;
    }

    public Card GiveNextCard()
    {
      Card card = cards[0];
      cards.Remove(card);

      return card;
    }
  }

  public class Card
  {
    public int Number { get; set; }
    public Rank card { get; set; }
    public Suit suit { get; set; }
    public string Type { get; set; }

    public Card( Rank card, Suit suit)
    {
      this.card = card;
      this.suit = suit;

      switch (card)
      {
        case Rank.Ten:
        case Rank.Jack:
        case Rank.Queen:
        case Rank.King:
          Number = 10;
          break;
        case Rank.Ace:
          Number = 11;
          break;
        default:
          Number = (int)card + 1;
          break;
      }

      switch(suit)
      {
        case Suit.Clubs:
          Type = "CLUB";
          break;
        case Suit.Spades:
          Type = "SPADE";
          break;
        case Suit.Diamonds:
          Type = "DIAMOND";
          break;
        case Suit.Hearts:
          Type = "HEART";
          break;
      }
    }
  }

  public class Player
  {
    public List<Card> cards;
    public string action { get; set; }

    public BlackJack game = new BlackJack();

    public string result { get; set; }

    public void PerformAction()
    {
      switch (action)
      {
        case "HIT":
          cards.Add(game.GiveNextCard());
          break;
        case "STAND":
          //Do nothing
          break;
      }
    }

    public int GetTotalValue()
    {
      int total = 0;
      foreach(Card card in cards)
      {
        total = total + card.Number;
      }
      return total;
    }

  }
}
