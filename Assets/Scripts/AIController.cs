using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public Player Player;
    public GameReferee GameReferee;
    // Start is called before the first frame update
    void Awake()
    {
        Player.OnTileAdded.AddListener(DiscardRandomTileIfMyTurn);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DiscardRandomTileIfMyTurn(MahjongTile tile)
    {
        if (GameReferee.CurrentPlayer == Player)
        {
            MahjongTile SelectedTile = Player.Hand[RNG.rng.Next(0, Player.Hand.Count)];
            Player.DiscardTile(SelectedTile);
        }
    }
}
