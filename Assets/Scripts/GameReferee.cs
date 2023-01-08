using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TurnState { START, WAIT_FOR_MOVE, END }
public class GameReferee : MonoBehaviour
{
    public TurnState state;
    public Table table;
    //private MahjongTile SelectedTile;
    public Player CurrentPlayer;
    private void Start()
    {
        CurrentPlayer = table.Players[0];
        state = TurnState.START;
        
    }

    public void StartTurn()
    {
        if(table.Wall.Count > 0)
        {
            DrawTile();
        }
        state = TurnState.WAIT_FOR_MOVE;
    }

    public void DrawTile()
    {
        CurrentPlayer.Hand.Add(table.Wall[table.Wall.Count - 1]);
        table.Wall[table.Wall.Count - 1].transform.SetParent(CurrentPlayer.Hand.transform, false);
        table.Wall.RemoveAt(table.Wall.Count - 1);
    }

    public void EndTurn()
    {
        CurrentPlayer = NextPlayer();
        //chi(); and pon(); and ron(); and kan(); check that changes NextPlayer
        state = TurnState.START;
    }

    public Player NextPlayer()
    {
        int nextIndex = table.Players.IndexOf(CurrentPlayer) + 1;

        if (nextIndex >= table.Players.Count)
            nextIndex = 0;

        return table.Players[nextIndex];
    }

    public void CheckTurn()
    {
        if (state == TurnState.START)
        {
            StartTurn();
        }
        else if (state == TurnState.END)
        {
            EndTurn();
        }
    }
}
