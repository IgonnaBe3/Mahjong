using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChiOptionButton : MonoBehaviour
{
    public Button button;
    public Player player;
    public TileSet tileset;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(()=>player.CallChi(tileset));
        button.onClick.AddListener(onclick);
    }
    public void onclick()
    {
        Debug.Log("klik");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
