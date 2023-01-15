using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CallChecker : MonoBehaviour
{

    public bool CanChi(TileSet tileset, MahjongTile SearchedTile)
    {
        bool TwoLower = tileset.Tiles.Where(tile => tile.Value == SearchedTile.Value - 2 && tile.Type == SearchedTile.Type).Distinct().Count() > 0;
        bool OneLower = tileset.Tiles.Where(tile => tile.Value == SearchedTile.Value - 1 && tile.Type == SearchedTile.Type).Distinct().Count() > 0; ;
        bool OneHigher = tileset.Tiles.Where(tile => tile.Value == SearchedTile.Value + 1 && tile.Type == SearchedTile.Type).Distinct().Count() > 0; ;
        bool TwoHigher = tileset.Tiles.Where(tile => tile.Value == SearchedTile.Value + 2 && tile.Type == SearchedTile.Type).Distinct().Count() > 0; ;
        //tileset.Tiles.Where(tile => tile.IsRedDora);
        if(OneHigher && TwoHigher)
        {
            return true;
        }
        else if(OneLower && OneHigher)
        {
            return true;
        }
        else if(OneLower && TwoLower)
        {
            return true;
        }
        return false;
    }
    public bool CanPon(TileSet tileset, MahjongTile SearchedTile)
    {
        return tileset.Tiles.Where(tile=> tile.Value==SearchedTile.Value && tile.Type == SearchedTile.Type).Count() >= 2;
    }
    public bool CanKan(TileSet tileset, MahjongTile SearchedTile)
    {
        return tileset.Tiles.Where(tile => tile.Value == SearchedTile.Value && tile.Type == SearchedTile.Type).Count() >= 3;
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
