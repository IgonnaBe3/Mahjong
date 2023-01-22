using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class GameReferee : MonoBehaviour
{
    public Table table;
    public Player CurrentPlayer;
    //public Player PreviousPlayer;
    Timer timer;
    public CallChecker CallChecker = new CallChecker();
    float CallWaitTimeMax = 2;
    public void StartGame()
    {
        timer = new Timer(CallWaitTimeMax * 1000);
        timer.AutoReset = false;
        timer.Elapsed += HandleCalls;

        CurrentPlayer = table.Players[0];
        for(int i = 0; i < 4; i++)
        {
            table.Players[i].OnDiscard.AddListener(SwitchToNextPlayer);
        }
        CurrentPlayer.AddTileToHand(DrawTileFromWall(table.Wall));
    }

    void SwitchToNextPlayer(MahjongTile LastDiscardedTile)
    {
        int nextIndex = table.Players.IndexOf(CurrentPlayer) + 1;

        if (nextIndex >= table.Players.Count)
            nextIndex = 0;
        bool SomeoneHasCall=false;
        if (CallChecker.CanChi(table.Players[nextIndex].Hand, LastDiscardedTile))
        {
            Debug.Log($"Player {table.Players.IndexOf(table.Players[nextIndex])} can chi on {LastDiscardedTile.Value} of {LastDiscardedTile.Type}");
            SomeoneHasCall = true;
        }

        foreach (Player player in table.Players)
        {
            if(CurrentPlayer != player)
            {
                if(CallChecker.CanPon(player.Hand, LastDiscardedTile))
                {
                    Debug.Log($"Player {table.Players.IndexOf(player)} can pon on {LastDiscardedTile.Value} of {LastDiscardedTile.Type}");
                    SomeoneHasCall=true;
                }

                if(CallChecker.CanKan(player.Hand, LastDiscardedTile))
                {
                    Debug.Log($"Player {table.Players.IndexOf(player)} can kan on {LastDiscardedTile.Value} of {LastDiscardedTile.Type}");
                    SomeoneHasCall = true;
                }

            }

            //canRon
            //canTsumo
        }
        if(SomeoneHasCall)
        {
            timer.Start();
            Debug.Log("SOMEONE HAS CALLL BOIIIIS");
        }
        else
        {
            CurrentPlayer = table.Players[nextIndex];
            MahjongTile NextTile = DrawTileFromWall(table.Wall);
            if (NextTile != null)
                CurrentPlayer.AddTileToHand(NextTile);
            //else
            // koniec gry
        }
    }

    private void HandleCalls(object sender, ElapsedEventArgs e)
    {
        Debug.Log("DUPAA");
        if(e != null)
        {

        }

    }

    public MahjongTile DrawTileFromWall(TileSet tileset)
    {
        MahjongTile Tile = null;
        if (tileset.Tiles.Count > 0)
        {
            Tile = tileset[tileset.Count - 1];
            tileset.RemoveAt(tileset.Count - 1);
        }
        return Tile;
    }

    
 
}
