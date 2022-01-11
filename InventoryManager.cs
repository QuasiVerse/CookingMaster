using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public List<string> playerinventory;
    public List<string> playerchoppingtableinventory;
    public int playernumber;
    
    private List<Image> playeroneslotone;
    private List<Image> playeroneslottwo;
    private List<Image> playertwoslotone;
    private List<Image> playertwoslottwo;
    
    private GenerateHUD hud;
    
    void Start(){
        playerinventory = new List<string>();
        playerchoppingtableinventory = new List<string>();
        
        hud = GameObject.Find("Main Camera").GetComponent<GenerateHUD>();
        playeroneslotone = new List<Image>();
        playeroneslotone.Add(hud.playeroneslotoneeggplant);
        playeroneslotone.Add(hud.playeroneslotonetomato);
        playeroneslotone.Add(hud.playeroneslotonezuccini);
        playeroneslotone.Add(hud.playeroneslotonepotato);
        playeroneslotone.Add(hud.playeroneslotonecorn);
        playeroneslotone.Add(hud.playeroneslotonelettuce);
        
        playeroneslottwo = new List<Image>();
        playeroneslottwo.Add(hud.playeroneslottwoeggplant);
        playeroneslottwo.Add(hud.playeroneslottwotomato);
        playeroneslottwo.Add(hud.playeroneslottwozuccini);
        playeroneslottwo.Add(hud.playeroneslottwopotato);
        playeroneslottwo.Add(hud.playeroneslottwocorn);
        playeroneslottwo.Add(hud.playeroneslottwolettuce);
        
        playertwoslotone = new List<Image>();
        playertwoslotone.Add(hud.playertwoslotoneeggplant);
        playertwoslotone.Add(hud.playertwoslotonetomato);
        playertwoslotone.Add(hud.playertwoslotonezuccini);
        playertwoslotone.Add(hud.playertwoslotonepotato);
        playertwoslotone.Add(hud.playertwoslotonecorn);
        playertwoslotone.Add(hud.playertwoslotonelettuce);
        
        playertwoslottwo = new List<Image>();
        playertwoslottwo.Add(hud.playertwoslottwoeggplant);
        playertwoslottwo.Add(hud.playertwoslottwotomato);
        playertwoslottwo.Add(hud.playertwoslottwozuccini);
        playertwoslottwo.Add(hud.playertwoslottwopotato);
        playertwoslottwo.Add(hud.playertwoslottwocorn);
        playertwoslottwo.Add(hud.playertwoslottwolettuce);
    }
    
    void Update()
    {
        if(playernumber == 1)
        {
            for(int x = 0; x < playeroneslotone.Count; x++)
            {
                if(playerinventory.Count == 0)
                {
                    playeroneslotone[x].enabled = false;
                }
                if(playerinventory.Count > 0)
                {
                    if(playeroneslotone[x].name == playerinventory[0])
                    {
                        playeroneslotone[x].enabled = true;
                    }
                    if(playeroneslotone[x].name != playerinventory[0])
                    {
                        playeroneslotone[x].enabled = false;
                    }
                    if(playerinventory.Count == 1){
                        playeroneslottwo[x].enabled = false;
                    }
                }
                if(playerinventory.Count > 1)
                {
                    if(playeroneslottwo[x].name == playerinventory[1])
                    {
                        playeroneslottwo[x].enabled = true;
                    }
                    if(playeroneslottwo[x].name != playerinventory[1])
                    {
                        playeroneslottwo[x].enabled = false;
                    }
                }
            }
        }
        if(playernumber == 2)
        {
            for(int x = 0; x < playertwoslotone.Count; x++)
            {
                if(playerinventory.Count == 0)
                {
                    playertwoslotone[x].enabled = false;
                }
                if(playerinventory.Count > 0)
                {
                    if(playertwoslotone[x].name == playerinventory[0])
                    {
                        playertwoslotone[x].enabled = true;
                    }
                    if(playertwoslotone[x].name != playerinventory[0])
                    {
                        playertwoslotone[x].enabled = false;
                    }
                    if(playerinventory.Count == 1){
                        playertwoslottwo[x].enabled = false;
                    }
                }
                if(playerinventory.Count > 1)
                {
                    if(playertwoslottwo[x].name == playerinventory[1])
                    {
                        playertwoslottwo[x].enabled = true;
                    }
                    if(playertwoslottwo[x].name != playerinventory[1])
                    {
                        playertwoslottwo[x].enabled = false;
                    }
                }
            }
        }
    }
}
