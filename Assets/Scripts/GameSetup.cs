using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetup : MonoBehaviour
{
    public void CreateValidWallTileSet(TileSet Tiles, MahjongTile Prefab, TileData tileData)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 1; j < 10; j++)
            {
                for (int k = 0; k < 4; k++)
                {
                    bool IsRedDora = false;
                    if (k == 0 && j == 5)
                    {
                        IsRedDora = true;
                    }
                    
                    MahjongTile tile = Instantiate(Prefab, transform);
                    var sprite = tileData.GetTileSprite((MahjongTile.TileType)i, j, IsRedDora, false);
                    tile.Initialize((MahjongTile.TileType)i, j, IsRedDora, sprite);
                    Tiles.Add(tile);
                    tile.transform.SetParent(Tiles.transform, false);
                }
            }
        }
        for (int i = 3; i < 10; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                

                MahjongTile tile = Instantiate(Prefab, transform);
                var sprite = tileData.GetTileSprite((MahjongTile.TileType)i, 0, false, false);
                tile.Initialize((MahjongTile.TileType)i, 0, false, sprite);
                Tiles.Add(tile);
                tile.transform.SetParent(Tiles.transform, false);
            }
        }
        Tiles.Shuffle();
    }

    public void DealToPlayersDrawingFrom(TileSet tileset, List<Player> players)
    {
        foreach (var mahjongPlayer in players)
        {
            for (int i = 0; i < 13; i++)
            {
                MahjongTile Tile = DrawTileFromWall(tileset);
                mahjongPlayer.AddTileToHand(Tile);
                /*mahjongPlayer.Hand.Add(tileset[tileset.Count - 1]);
                tileset[tileset.Count - 1].transform.SetParent(mahjongPlayer.Hand.transform, false);
                tileset.RemoveAt(tileset.Count - 1);*/
            }
        }
    }

    public MahjongTile DrawTileFromWall(TileSet tileset)
    {
        MahjongTile Tile = tileset[tileset.Count - 1];
        tileset.RemoveAt(tileset.Count - 1);
        return Tile;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
