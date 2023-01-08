using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSet : MonoBehaviour
{

    public List<MahjongTile> Tiles;// = new List<MahjongTile>();

    public void Add(MahjongTile tile)
    {
        Tiles.Add(tile);
    }

    public void Remove(MahjongTile tile)
    {
        Tiles.Remove(tile);
    }

    public void RemoveAt(int TileNumber)
    {
        Tiles.RemoveAt(TileNumber);
    }

    public void Shuffle()
    {
        Tiles.Shuffle();
    }

    public int Count
    {
        get => Tiles.Count;
    }

    public static implicit operator TileSet(List<MahjongTile> tileset)
    {
        return new TileSet(tileset);
    }

    public TileSet(List<MahjongTile> tiles)
    {
        Tiles = tiles;
    }

    public TileSet()
    {
        Tiles = new List<MahjongTile>();
    }

    public MahjongTile this[int i]
    {
        get { return Tiles[i]; }
        set { Tiles[i] = value; }
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
