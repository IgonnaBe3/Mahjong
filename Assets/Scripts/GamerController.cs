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
        Player.OnTileAdded.AddListener(AddTileListener);
    }

    void DiscardTileForPlayer(MahjongTile tile)
    {
        Player.DiscardTile(tile);
    }

    void AddTileListener(MahjongTile tile)
    {
        tile.OnClick.AddListener(() => { DiscardTileForPlayer(tile); });
    }


}
