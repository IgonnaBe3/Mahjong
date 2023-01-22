using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;
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
    public CallChecker CallChecker = new CallChecker();
    public MahjongTileEvent OnDiscard = new MahjongTileEvent();
    public MahjongTileEvent OnTileAdded = new MahjongTileEvent();
    public UnityEvent OnChi = new UnityEvent();
    public UnityEvent OnPon = new UnityEvent();
    public UnityEvent OnKan = new UnityEvent();
    public UnityEvent OnCallChi = new UnityEvent();
    public UnityEvent OnCallPon = new UnityEvent();
    public UnityEvent OnCallKan = new UnityEvent();
    public void Initialize()
    {

    }

    public void CheckCallStatus(MahjongTile LastDiscardedTile)
    {
        if (CallChecker.CanChi(Hand, LastDiscardedTile))
        {
            Debug.Log($"I can chi on {LastDiscardedTile.Value} of {LastDiscardedTile.Type}");
            OnChi.Invoke();
        }
        else if(CallChecker.CanPon(Hand, LastDiscardedTile))
        {
            Debug.Log($"I can pon on {LastDiscardedTile.Value} of {LastDiscardedTile.Type}");
            OnPon.Invoke();
        }
        else if (CallChecker.CanKan(Hand, LastDiscardedTile))
        {
            Debug.Log($"I can kan on {LastDiscardedTile.Value} of {LastDiscardedTile.Type}");
            OnKan.Invoke();
        }
    }

    public void CallChi()
    {
        OnCallChi.Invoke();
    }

    public void CallPon()
    {
        OnCallPon.Invoke();
    }
    public void CallKan()
    {
        OnCallKan.Invoke();
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            if(Table.Players[i] != this)
            {
                Table.Players[i].OnDiscard.AddListener(CheckCallStatus);
            }
        }
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
