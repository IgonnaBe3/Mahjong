using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Table Table;
    public TileSet Hand;
    public TileSet Discards;
    public bool IsMainPlayer=false;
    public void Initialize()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DiscardTile(MahjongTile Tile)
    {
        this.Discards.Tiles.Add(Tile);
        Tile.transform.SetParent(this.Discards.transform, false);
        this.Hand.Tiles.Remove(Tile);
    }

    public void AddTileToHand(MahjongTile Tile)
    {
        this.Hand.Tiles.Add(Tile);
        Tile.transform.SetParent(this.Hand.transform, false);

    }
}
