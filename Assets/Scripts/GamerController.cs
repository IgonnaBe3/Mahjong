using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GamerController : MonoBehaviour
{
    public Player Player;
    public Table Table;
    public GameReferee GameReferee;
    // Start is called before the first frame update
    void Awake()
    {
        Player.OnTileAdded.AddListener(AddDiscardTileListener);
    }

    void DiscardTileForPlayer(MahjongTile tile)
    {
        if (GameReferee.CurrentPlayer == Player && Player.Hand.Tiles.Contains(tile))
        {
            Player.DiscardTile(tile);
        }
            
    }

    void AddDiscardTileListener(MahjongTile tile)
    {
        tile.OnClick.AddListener(() => { DiscardTileForPlayer(tile); });
    }

}
