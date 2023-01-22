using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
        gameReferee.StartGame();

        TileSet tileset = table.Players[0].Hand.Tiles.Select(tile => tile).Distinct().ToList();
        for (int i = 0; i < tileset.Count; i++)
        {
            Debug.Log($"tile {tileset[i].Value} of {tileset[i].Type} of player {this}");
        }
    }
    // Update is called once per frame
    void Update()
    {
        gameRenderer.ChangeSprite(table, tileData);
    }
}
