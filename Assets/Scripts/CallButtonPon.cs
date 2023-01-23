using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallButtonPon : MonoBehaviour
{
    public Button button;
    public Player player;
    public CallChecker checker = new CallChecker();
    public MahjongTile LastDiscardedTile;
    public PonOptionButton PonPrefab;
    public GridLayoutGroup grid;
    // Start is called before the first frame update
    void Start()
    {
        button.interactable = false;
        player.OnCanPon.AddListener(ActivateButton);
        button.onClick.AddListener(TaskOnClick);
    }

    public void TaskOnClick()
    {
        button.interactable = false;
        List<TileSet> possibllePon = checker.GetPossiblePon(player.Hand, LastDiscardedTile);
        for (int i = 0; i < possibllePon.Count; i++)
        {
            PonOptionButton PonButton = Instantiate(PonPrefab, transform);
            for (int j = 0; j < possibllePon[i].Count; j++)
            {
                PonButton.tileset.Add(possibllePon[i][j]);
                MahjongTile tile = new MahjongTile();
                tile = possibllePon[i][j];
                tile.transform.SetParent(PonButton.tileset.transform, false);
            }
            PonButton.player = player;
            PonButton.transform.SetParent(grid.transform, false);
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
