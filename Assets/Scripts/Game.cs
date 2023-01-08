using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Game : MonoBehaviour
{
    public Table table;
    public MahjongTile prefab;
    public TileData tileData;
    public GameSetup gameSetup;
    public GameReferee gameReferee;
    public GameRenderer gameRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        gameSetup.CreateValidWallTileSet(table.Wall,prefab,tileData);
        gameSetup.DealToPlayersDrawingFrom(table.Wall, table.Players);
        table.Players[0].IsMainPlayer = true;
    }
    // Update is called once per frame
    void Update()
    {
        gameRenderer.ChangeSprite(table, tileData);
        gameReferee.CheckTurn();
    }
}
