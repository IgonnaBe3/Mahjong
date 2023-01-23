using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallButtonChi : MonoBehaviour
{
    public Button button;
    public Player player;
    public CallChecker checker = new CallChecker();
    public MahjongTile LastDiscardedTile;
    public ChiOptionButton ChiPrefab;
    public GridLayoutGroup grid;

    // Start is called before the first frame update
    void Start()
    {
        button.interactable = false;
        player.OnCanChi.AddListener(ActivateButton);
        button.onClick.AddListener(TaskOnClick);
    }

    public void TaskOnClick()
    {
        button.interactable = false;
        List<TileSet> possiblleChi = checker.GetPossibleChi(player.Hand, LastDiscardedTile);
        for (int i = 0; i < possiblleChi.Count; i++)
        {
            ChiOptionButton ChiButton = Instantiate(ChiPrefab, transform);
            for(int j = 0; j < possiblleChi[i].Count; j++)
            {
                ChiButton.tileset.Add(possiblleChi[i][j]);
                MahjongTile tile = new MahjongTile();
                tile = possiblleChi[i][j];
                tile.transform.SetParent(ChiButton.tileset.transform, false);
            }
            ChiButton.player = player;
            ChiButton.transform.SetParent(grid.transform, false);
        }
    }

    public void ActivateButton(MahjongTile LastDiscardedTile)
    {
        this.LastDiscardedTile = LastDiscardedTile;
        button.interactable = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
