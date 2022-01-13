using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    
    private CookingManager manager;
    
    public int pickuptype;
    
    void Start()
    {
        manager = GameObject.Find("Main Camera").GetComponent<CookingManager>();
    }
    
    public void UsePickup(int playernumber, PlayerController playercontroller)
    {
        if(pickuptype == 1)
        {
            playercontroller.speedboosttimer = 50f;
        }
        if(pickuptype == 2)
        {
            if(playernumber == 1)
            {
                manager.playeronetimer = manager.playeronetimer + 25;
            }
            if(playernumber == 2)
            {
                manager.playertwotimer = manager.playertwotimer + 25;
            }
        }
        if(pickuptype == 3)
        {
            manager.Report(1, playernumber, 15);
        }
        Destroy(this.gameObject);
    }
}
