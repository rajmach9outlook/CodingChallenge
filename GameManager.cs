using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenge
{
  public class GameManager
  {
    public string game;
    public GameManager(string game)
    {
      this.game = game;
    }

    public void Run()
    {
      if(game == "BlackJack")
      {
        BlackJack bj = new BlackJack();
        bj.NoOfPlayers = 2;
        bj.BeginRound();
        bj.AssessSuccess();
      }
    }
  }
}
