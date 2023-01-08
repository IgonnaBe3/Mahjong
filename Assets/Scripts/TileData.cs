using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileData : MonoBehaviour
{

    [SerializeField]
    private List<TileComponents> TilesTemplates = new List<TileComponents>();

    public Sprite GetTileSprite(MahjongTile.TileType type, int Value, bool IsRedDora, bool BackTile)
    {

        foreach (var tile in TilesTemplates)
        {
            if (tile.type == type && tile.Value == Value && tile.IsRedDora == IsRedDora && tile.BackTile == BackTile)
            {
                return tile.sprite;
            }
        }
        return null;
    }    
}
[System.Serializable]
public struct TileComponents
{
    public Sprite sprite;
    public MahjongTile.TileType type;
    public int Value;
    public bool IsRedDora;
    public bool BackTile;
}