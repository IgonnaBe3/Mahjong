using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRenderer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSprite(Table table, TileData tileData)
    {
        for (int i = 0; i < table.Players.Count; i++)
        {
            for (int j=0;j < table.Players[i].Hand.Count; j++)
            {
                if (table.Players[i].IsMainPlayer)
                {
                        table.Players[i].Hand[j].SpriteRenderer.sprite = tileData.GetTileSprite(table.Players[i].Hand[j].Type, table.Players[i].Hand[j].Value, table.Players[i].Hand[j].IsRedDora, false);
                }
                else
                {
                        table.Players[i].Hand[j].SpriteRenderer.sprite = tileData.GetTileSprite((MahjongTile.TileType)0, 0, false, true);
                }
            }
            for (int k = 0; k < table.Players[i].Discards.Count; k++)
            {
                table.Players[i].Discards[k].SpriteRenderer.sprite = tileData.GetTileSprite(table.Players[i].Discards[k].Type, table.Players[i].Discards[k].Value, table.Players[i].Discards[k].IsRedDora, false);
            }
        }
    }
}
