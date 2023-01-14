using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;

public class MahjongTile : MonoBehaviour
{
    public Image image;
    public UnityEvent SelectedTileEvent= new UnityEvent();
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

    public void test()
    {
        Debug.Log("clicked"+Type+" "+Value);
        SelectedTileEvent.Invoke();
    }
    public void Initialize(TileType Type, int Value, bool IsRedDora, Sprite sprite)
    {
        this.Type = Type;
        this.Value = Value;
        this.IsRedDora = IsRedDora;
        this.sprite = sprite;
        image.sprite = sprite;
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
