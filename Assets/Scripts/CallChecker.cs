using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CallChecker
{

    public bool CanChi(TileSet tileset, MahjongTile SearchedTile)
    {
        bool TwoLower = tileset.Tiles.Where(tile => tile.Value == SearchedTile.Value - 2 && tile.Type == SearchedTile.Type).Distinct().Count() > 0;
        bool OneLower = tileset.Tiles.Where(tile => tile.Value == SearchedTile.Value - 1 && tile.Type == SearchedTile.Type).Distinct().Count() > 0; 
        bool OneHigher = tileset.Tiles.Where(tile => tile.Value == SearchedTile.Value + 1 && tile.Type == SearchedTile.Type).Distinct().Count() > 0; 
        bool TwoHigher = tileset.Tiles.Where(tile => tile.Value == SearchedTile.Value + 2 && tile.Type == SearchedTile.Type).Distinct().Count() > 0; 
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
    public TileSet GetSpecificChiTiles(MahjongTile tile1, MahjongTile tile2)
    {
        TileSet tileset = new TileSet();
        tileset.Add(tile2);
        tileset.Add(tile1);
        return tileset;
    }
    public List<TileSet> GetPossibleChi(TileSet tileset, MahjongTile SearchedTile)
    {
        List<TileSet> possibleChi = new List<TileSet>();
        bool TwoLower = tileset.Tiles.Where(tile => tile.Value == SearchedTile.Value - 2 && tile.Type == SearchedTile.Type).Distinct().Count() > 0;
        bool OneLower = tileset.Tiles.Where(tile => tile.Value == SearchedTile.Value - 1 && tile.Type == SearchedTile.Type).Distinct().Count() > 0;
        bool OneHigher = tileset.Tiles.Where(tile => tile.Value == SearchedTile.Value + 1 && tile.Type == SearchedTile.Type).Distinct().Count() > 0;
        bool TwoHigher = tileset.Tiles.Where(tile => tile.Value == SearchedTile.Value + 2 && tile.Type == SearchedTile.Type).Distinct().Count() > 0;
        TileSet TwoLowerTile = tileset.Tiles.Where(tile => tile.Value == SearchedTile.Value - 2 && tile.Type == SearchedTile.Type).Distinct().ToList();
        TileSet OneLowerTile = tileset.Tiles.Where(tile => tile.Value == SearchedTile.Value - 1 && tile.Type == SearchedTile.Type).Distinct().ToList();
        TileSet OneHigherTile = tileset.Tiles.Where(tile => tile.Value == SearchedTile.Value + 1 && tile.Type == SearchedTile.Type).Distinct().ToList();
        TileSet TwoHigherTile = tileset.Tiles.Where(tile => tile.Value == SearchedTile.Value + 2 && tile.Type == SearchedTile.Type).Distinct().ToList();
        if (OneHigher && TwoHigher)
        {
            possibleChi.Add(GetSpecificChiTiles(OneHigherTile[0], TwoHigherTile[0]));
            if (OneHigherTile.Count>1)
            {
                possibleChi.Add(GetSpecificChiTiles(OneHigherTile[1], TwoHigherTile[0]));
            }
            else if (TwoHigherTile.Count > 1)
            {
                possibleChi.Add(GetSpecificChiTiles(OneHigherTile[0], TwoHigherTile[1]));
            }
        }
        else if (OneLower && OneHigher)
        {
            possibleChi.Add(GetSpecificChiTiles(OneHigherTile[0], OneLowerTile[0]));
            if (OneHigherTile.Count > 1)
            {
                possibleChi.Add(GetSpecificChiTiles(OneHigherTile[1], OneLowerTile[0]));
            }
            else if(OneLowerTile.Count > 1)
            {
                possibleChi.Add(GetSpecificChiTiles(OneHigherTile[0], OneLowerTile[1]));
            }
        }
        else if (OneLower && TwoLower)
        {
            possibleChi.Add(GetSpecificChiTiles(TwoLowerTile[0], OneLowerTile[0]));
            if (OneLowerTile.Count > 1)
            {
                possibleChi.Add(GetSpecificChiTiles(TwoLowerTile[0], OneLowerTile[1]));
            }
            else if (TwoLowerTile.Count > 1)
            {
                possibleChi.Add(GetSpecificChiTiles(TwoLowerTile[1], OneLowerTile[0]));
            }
        }
        return possibleChi;
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
