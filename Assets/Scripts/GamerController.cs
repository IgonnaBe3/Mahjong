using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamerController : MonoBehaviour
{
    public Player Player;
    public GameReferee GameReferee;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameReferee.CurrentPlayer==Player && GameReferee.state == TurnState.WAIT_FOR_MOVE)
        {
            PlayerMove();
        }
    }

    public void PlayerMove()
    {
        if (Input.anyKeyDown)
        {
            MahjongTile SelectedTile = Player.Hand[RNG.rng.Next(0, Player.Hand.Count)];
            Player.DiscardTile(SelectedTile);
            GameReferee.state = TurnState.END;
        }
    }

}
