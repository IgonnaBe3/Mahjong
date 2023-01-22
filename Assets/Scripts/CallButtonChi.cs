using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallButtonChi : MonoBehaviour
{
    public Button button;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        button.interactable = false;
        player.OnChi.AddListener(ActivateButton);
        button.onClick.AddListener(TaskOnClick);
    }

    public void TaskOnClick()
    {
        button.interactable = false;
    }

    public void ActivateButton()
    {
        button.interactable = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
