using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallButtonKan : MonoBehaviour
{
    public Button button;
    public Player player;
    public CallChecker checker = new CallChecker();
    public MahjongTile LastDiscardedTile;
    // Start is called before the first frame update
    void Start()
    {
        button.interactable = false;
        player.OnCanKan.AddListener(ActivateButton);
        button.onClick.AddListener(TaskOnClick);
    }

    public void TaskOnClick()
    {

        button.interactable = false;
        List<TileSet> possiblleKan = checker.GetPossibleKan(player.Hand, LastDiscardedTile);
        player.CallKan(possiblleKan[0]);
    }

    public void ActivateButton(MahjongTile LastDiscardedTile)
    {
        button.interactable = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
