using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MahjongTile : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    public enum TileType 
    { 
        man,
        sou,
        pin,
        east_wind,
        south_wind,
        west_wind,
        north_wind,
        white_dragon,
        green_dragon,
        red_dragon
    }
    public TileType Type;
    public int Value;
    public bool IsRedDora;
    public Sprite sprite;
    public void Initialize(TileType Type, int Value, bool IsRedDora, Sprite sprite)
    {
        this.Type = Type;
        this.Value = Value;
        this.IsRedDora = IsRedDora;
        this.sprite = sprite;
        SpriteRenderer.sprite = sprite;
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
