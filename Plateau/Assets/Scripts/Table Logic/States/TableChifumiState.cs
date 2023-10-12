using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Chifumi { Rock, Paper, Scissors }

public class TableChifumiState : TableState
{
    private List<Player> _players;
    private List<Player> _losers;

    public TableChifumiState(TableManager tableManager, TableSubstate subState) : base(tableManager, subState)
    {
    }

    public override void Enter()
    {
        _players = new();
        foreach (Player player in TableManager.CurrentPlayer.CurrentTile.PlayersOnTheTile)
        {
            _players.Add(player);
        }
        _losers = new();

        PlayChifumi();
    }

    public override void Exit()
    {
    }

    public override void UpdateLogic()
    {
    }

    public void PlayChifumi()
    {
        Dictionary<Player, Chifumi> chifumi = new();
        int rock = 0;
        int paper = 0;
        int scissors = 0;
        foreach (Player player in _players)
        {
            int i = Random.Range(1, 4);

            switch (i)
            {
                case 1:
                    chifumi.Add(player, Chifumi.Rock);
                    rock++;
                    Debug.Log(player.PlayerName + " " + Chifumi.Rock.ToString());
                    break;

                case 2:
                    chifumi.Add(player, Chifumi.Paper);
                    paper++;
                    Debug.Log(player.PlayerName + " " + Chifumi.Paper.ToString());
                    break;

                case 3:
                    chifumi.Add(player, Chifumi.Scissors);
                    scissors++;
                    Debug.Log(player.PlayerName + " " + Chifumi.Scissors.ToString());
                    break;
            }
        }

        if (rock == paper && paper == scissors)
        {
            PlayChifumi();
            return;
        } else if ((rock == 0 && paper == 0) || (paper == 0 && scissors == 0) || (rock == 0 && scissors == 0))
        {
            PlayChifumi();
            return;
        }

        if (rock == 0)
        {
            foreach (KeyValuePair<Player, Chifumi> entry in chifumi)
            {
                if (entry.Value == Chifumi.Paper)
                {
                    _players.Remove(entry.Key);
                    _losers.Add(entry.Key);
                }
            }
        } else if (paper == 0)
        {
            foreach (KeyValuePair<Player, Chifumi> entry in chifumi)
            {
                if (entry.Value == Chifumi.Scissors)
                {
                    _players.Remove(entry.Key);
                    _losers.Add(entry.Key);
                }
            }
        } else if (scissors == 0)
        {
            foreach (KeyValuePair<Player, Chifumi> entry in chifumi)
            {
                if (entry.Value == Chifumi.Rock)
                {
                    _players.Remove(entry.Key);
                    _losers.Add(entry.Key);
                }
            }
        } else
        {
            int highestSign = 0;
            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                {
                    highestSign = rock;
                } else if (i == 1)
                {
                    if (paper > highestSign)
                    {
                        highestSign = paper;
                    }
                } else if (i == 2)
                {
                    if (scissors > highestSign)
                    {
                        highestSign = scissors;
                    }
                }
            }

            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                {
                    if (rock != highestSign)
                    {
                        foreach (KeyValuePair<Player, Chifumi> entry in chifumi)
                        {
                            if (entry.Value == Chifumi.Rock)
                            {
                                _players.Remove(entry.Key);
                                _losers.Add(entry.Key);
                            }
                        }
                    }
                }
                else if (i == 1)
                {
                    if (paper != highestSign)
                    {
                        foreach (KeyValuePair<Player, Chifumi> entry in chifumi)
                        {
                            if (entry.Value == Chifumi.Paper)
                            {
                                _players.Remove(entry.Key);
                                _losers.Add(entry.Key);
                            }
                        }
                    }
                }
                else if (i == 2)
                {
                    if (scissors != highestSign)
                    {
                        foreach (KeyValuePair<Player, Chifumi> entry in chifumi)
                        {
                            if (entry.Value == Chifumi.Scissors)
                            {
                                _players.Remove(entry.Key);
                                _losers.Add(entry.Key);
                            }
                        }
                    }
                }
            }
        }

        if (_players.Count > 1)
        {
            PlayChifumi();
            return;
        } else
        {
            int goldAmount = 0;
            foreach (Player loser in _losers)
            {
                if (loser.Gold < 3)
                {
                    goldAmount += loser.Gold;
                    loser.LoseGold(loser.Gold);
                }
                else
                {
                    loser.LoseGold(3);
                    goldAmount += 3;
                }
            }
            _players[0].EarnGold(goldAmount);
            TableManager.ChangeState(new TableTileAbilityState(TableManager, CurrentSubstate));
        }
    }
}
