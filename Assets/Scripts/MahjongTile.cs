using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;
using System;

public class MahjongTile : MonoBehaviour, IEquatable<MahjongTile>
{
    public Image image;
    public UnityEvent OnClick = new UnityEvent();
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

    public void InvokeOnClickEvent()
    {
        OnClick.Invoke();
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

    public bool Equals(MahjongTile other)
    {
        if(this.Type==other.Type && this.Value==other.Value && this.IsRedDora==other.IsRedDora )
            return true;
        return false;
    }
    public override int GetHashCode()
    {
        return Type.GetHashCode()+ Value.GetHashCode() + IsRedDora.GetHashCode();
    }

}
