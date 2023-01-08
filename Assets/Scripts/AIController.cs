using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public Player Player;
    public GameReferee GameReferee;
    public float ThinkingTime = 0;
    private float ThinkingTimeLeft = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameReferee.CurrentPlayer == Player && ThinkingTimeLeft <= 0 && GameReferee.state == TurnState.WAIT_FOR_MOVE)
        {
            PlayerMove();
            ThinkingTimeLeft = ThinkingTime;
        }

        ThinkingTimeLeft -= Time.deltaTime;
    }

    public void PlayerMove()
    {
        MahjongTile SelectedTile = Player.Hand[RNG.rng.Next(0, Player.Hand.Count)];
        Player.DiscardTile(SelectedTile);
        GameReferee.state = TurnState.END;
    }
}
