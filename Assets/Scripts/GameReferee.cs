using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameReferee : MonoBehaviour
{
    public Table table;
    public Player CurrentPlayer; 
    public void StartGame()
    {
        CurrentPlayer = table.Players[0];
        for(int i = 0; i < 4; i++)
        {
            table.Players[i].OnDiscard.AddListener(SwitchToNextPlayer);
        }
        CurrentPlayer.AddTileToHand(DrawTileFromWall(table.Wall));
    }

    void SwitchToNextPlayer(MahjongTile tile)
    {
        int nextIndex = table.Players.IndexOf(CurrentPlayer) + 1;

        if (nextIndex >= table.Players.Count)
            nextIndex = 0;
        CurrentPlayer = table.Players[nextIndex];
        MahjongTile NextTile = DrawTileFromWall(table.Wall);
        if (NextTile != null)
            CurrentPlayer.AddTileToHand(NextTile);
        //else
            // koniec gry
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
