using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public Table Table;
    [field: SerializeField]
    public TileSet Hand { get; set; }
    public List<TileSet> OpenHandMelds { get; set; }
    [field: SerializeField]
    public TileSet OpenHand { get; set; }
    public TileSet Discards;
    public bool IsMainPlayer=false;
    public MahjongTileEvent OnDiscard = new MahjongTileEvent();
    public MahjongTileEvent OnTileAdded = new MahjongTileEvent();
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
        OnDiscard.Invoke(Tile);
    }

    public void AddTileToHand(MahjongTile Tile)
    {
        this.Hand.Tiles.Add(Tile);
        Tile.transform.SetParent(this.Hand.transform, false);
        OnTileAdded.Invoke(Tile);
    }
}
