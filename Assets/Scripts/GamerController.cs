using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GamerController : MonoBehaviour, PlayerController
{
    public Player Player;
    public Table Table;
    public GameReferee GameReferee;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameReferee.CurrentPlayer==Player && GameReferee.state == TurnState.WAIT_FOR_MOVE)
        {
            PlayerMove();
        }
        else if(GameReferee.CurrentPlayer == Player && GameReferee.state == TurnState.START)
        {
            DrawTile();
        }
    }

    public void PlayerMove()
    {
        if (Input.anyKeyDown)
        {
            MahjongTile SelectedTile = Player.Hand[RNG.rng.Next(0, Player.Hand.Count)];
            SelectedTile.SelectedTileEvent.RemoveListener(PlayerMove); 
            Player.DiscardTile(SelectedTile);
            GameReferee.state = TurnState.END;
        }
    }

    public void DrawTile()
    {
        /*Player.Hand.Add(Table.Wall[Table.Wall.Count - 1]);
        Table.Wall[Table.Wall.Count - 1].transform.SetParent(Player.Hand.transform, false);
        Table.Wall.RemoveAt(Table.Wall.Count - 1);
        GameReferee.state = TurnState.WAIT_FOR_MOVE;*/
    }

}
