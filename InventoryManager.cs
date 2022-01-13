using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public List<string> playerinventory;
    public List<string> playerchoppedinventory;
    public List<string> playerchoppedtableinventory;
    public string playerchoppingtableitem = "";
    public string playerplateitem = "";
    public int playernumber;
    
    private List<Image> playeroneslotone;
    private List<Image> playeroneslottwo;
    private List<Image> playertwoslotone;
    private List<Image> playertwoslottwo;
    
    private List<GameObject> playeronechoppingmodels;
    private List<GameObject> playertwochoppingmodels;
    
    private List<GameObject> playeronechoppedinventoryslot;
    private List<GameObject> playertwochoppedinventoryslot;
    
    private List<GameObject> playeroneplatemodels;
    private List<GameObject> playertwoplatemodels;

    private GenerateHUD hud;
    
    void Start(){
        playerinventory = new List<string>();
        playerchoppedinventory = new List<string>();
        playerchoppedtableinventory = new List<string>();
        
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
        
        playeronechoppingmodels = new List<GameObject>();
        playeronechoppingmodels.Add(LevelGenerator.playeronechoppingeggplantmodel);
        playeronechoppingmodels.Add(LevelGenerator.playeronechoppingtomatomodel);
        playeronechoppingmodels.Add(LevelGenerator.playeronechoppingzuccinimodel);
        playeronechoppingmodels.Add(LevelGenerator.playeronechoppingpotatomodel);
        playeronechoppingmodels.Add(LevelGenerator.playeronechoppingcornmodel);
        playeronechoppingmodels.Add(LevelGenerator.playeronechoppinglettucemodel);
        
        playertwochoppingmodels = new List<GameObject>();
        playertwochoppingmodels.Add(LevelGenerator.playertwochoppingeggplantmodel);
        playertwochoppingmodels.Add(LevelGenerator.playertwochoppingtomatomodel);
        playertwochoppingmodels.Add(LevelGenerator.playertwochoppingzuccinimodel);
        playertwochoppingmodels.Add(LevelGenerator.playertwochoppingpotatomodel);
        playertwochoppingmodels.Add(LevelGenerator.playertwochoppingcornmodel);
        playertwochoppingmodels.Add(LevelGenerator.playertwochoppinglettucemodel);
        
        playeronechoppedinventoryslot = new List<GameObject>();
        playeronechoppedinventoryslot.Add(LevelGenerator.playeronefirstchoppedmodel);
        playeronechoppedinventoryslot.Add(LevelGenerator.playeronesecondchoppedmodel);
        playeronechoppedinventoryslot.Add(LevelGenerator.playeronethirdchoppedmodel);
        
        playertwochoppedinventoryslot = new List<GameObject>();
        playertwochoppedinventoryslot.Add(LevelGenerator.playertwofirstchoppedmodel);
        playertwochoppedinventoryslot.Add(LevelGenerator.playertwosecondchoppedmodel);
        playertwochoppedinventoryslot.Add(LevelGenerator.playertwothirdchoppedmodel);
        
        playeroneplatemodels = new List<GameObject>();
        playeroneplatemodels.Add(LevelGenerator.playeroneplateeggplantmodel);
        playeroneplatemodels.Add(LevelGenerator.playeroneplatetomatomodel);
        playeroneplatemodels.Add(LevelGenerator.playeroneplatezuccinimodel);
        playeroneplatemodels.Add(LevelGenerator.playeroneplatepotatomodel);
        playeroneplatemodels.Add(LevelGenerator.playeroneplatecornmodel);
        playeroneplatemodels.Add(LevelGenerator.playeroneplatelettucemodel);
        
        playertwoplatemodels = new List<GameObject>();
        playertwoplatemodels.Add(LevelGenerator.playertwoplateeggplantmodel);
        playertwoplatemodels.Add(LevelGenerator.playertwoplatetomatomodel);
        playertwoplatemodels.Add(LevelGenerator.playertwoplatezuccinimodel);
        playertwoplatemodels.Add(LevelGenerator.playertwoplatepotatomodel);
        playertwoplatemodels.Add(LevelGenerator.playertwoplatecornmodel);
        playertwoplatemodels.Add(LevelGenerator.playertwoplatelettucemodel);
    }
    
    void Update()
    {
        if(playernumber == 1)
        {
            //Player One Inventory UI
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
            //Player One Chopping Table Item
            for(int x = 0; x < playeronechoppingmodels.Count; x++)
            {
                if(playeronechoppingmodels[x].name == playerchoppingtableitem)
                {
                    playeronechoppingmodels[x].SetActive(true);
                }
                if(playeronechoppingmodels[x].name != playerchoppingtableitem)
                {
                    playeronechoppingmodels[x].SetActive(false);
                }
            }
            //Player One Chopped Items
            for(int x = 0; x < 3; x++)
            {
                if(playerchoppedtableinventory.Count > x)
                {
                    playeronechoppedinventoryslot[x].SetActive(true); 
                    if(playerchoppedtableinventory[x] == "Eggplant")
                    {
                        playeronechoppedinventoryslot[x].GetComponent<Renderer>().material.SetColor("_Color", LevelGenerator.eggplantcolor);
                    }
                    if(playerchoppedtableinventory[x] == "Tomato")
                    {
                        playeronechoppedinventoryslot[x].GetComponent<Renderer>().material.SetColor("_Color", LevelGenerator.tomatocolor);
                    }
                    if(playerchoppedtableinventory[x] == "Zuccini")
                    {
                        playeronechoppedinventoryslot[x].GetComponent<Renderer>().material.SetColor("_Color", LevelGenerator.zuccinicolor);
                    }
                    if(playerchoppedtableinventory[x] == "Potato")
                    {
                        playeronechoppedinventoryslot[x].GetComponent<Renderer>().material.SetColor("_Color", LevelGenerator.potatocolor);
                    }
                    if(playerchoppedtableinventory[x] == "Corn")
                    {
                        playeronechoppedinventoryslot[x].GetComponent<Renderer>().material.SetColor("_Color", LevelGenerator.corncolor);
                    }
                    if(playerchoppedtableinventory[x] == "Lettuce")
                    {
                        playeronechoppedinventoryslot[x].GetComponent<Renderer>().material.SetColor("_Color", LevelGenerator.lettucecolor);
                    }
                }
                if(playerchoppedtableinventory.Count <= x)
                {
                    playeronechoppedinventoryslot[x].SetActive(false); 
                }
            }
            //Player One Plate Item
            for(int x = 0; x < playeroneplatemodels.Count; x++)
            {
                if(playeroneplatemodels[x].name == playerplateitem)
                {
                    playeroneplatemodels[x].SetActive(true);
                }
                if(playeroneplatemodels[x].name != playerplateitem)
                {
                    playeroneplatemodels[x].SetActive(false);
                }
            }
        }
        if(playernumber == 2)
        {
            //Player Two Inventory UI
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
            //Player Two Chopping Table Item
            for(int x = 0; x < playertwochoppingmodels.Count; x++)
            {
                if(playertwochoppingmodels[x].name == playerchoppingtableitem)
                {
                    playertwochoppingmodels[x].SetActive(true);
                }
                if(playertwochoppingmodels[x].name != playerchoppingtableitem)
                {
                    playertwochoppingmodels[x].SetActive(false);
                }
            }
            //Player Two Chopped Item
            for(int x = 0; x < 3; x++)
            {
                if(playerchoppedtableinventory.Count > x)
                {
                    playertwochoppedinventoryslot[x].SetActive(true); 
                    if(playerchoppedtableinventory[x] == "Eggplant")
                    {
                        playertwochoppedinventoryslot[x].GetComponent<Renderer>().material.SetColor("_Color", LevelGenerator.eggplantcolor);
                    }
                    if(playerchoppedtableinventory[x] == "Tomato")
                    {
                        playertwochoppedinventoryslot[x].GetComponent<Renderer>().material.SetColor("_Color", LevelGenerator.tomatocolor);
                    }
                    if(playerchoppedtableinventory[x] == "Zuccini")
                    {
                        playertwochoppedinventoryslot[x].GetComponent<Renderer>().material.SetColor("_Color", LevelGenerator.zuccinicolor);
                    }
                    if(playerchoppedtableinventory[x] == "Potato")
                    {
                        playertwochoppedinventoryslot[x].GetComponent<Renderer>().material.SetColor("_Color", LevelGenerator.potatocolor);
                    }
                    if(playerchoppedtableinventory[x] == "Corn")
                    {
                        playertwochoppedinventoryslot[x].GetComponent<Renderer>().material.SetColor("_Color", LevelGenerator.corncolor);
                    }
                    if(playerchoppedtableinventory[x] == "Lettuce")
                    {
                        playertwochoppedinventoryslot[x].GetComponent<Renderer>().material.SetColor("_Color", LevelGenerator.lettucecolor);
                    }
                }
                if(playerchoppedtableinventory.Count <= x)
                {
                    playertwochoppedinventoryslot[x].SetActive(false); 
                }
            }
            //Player Two Plate Item
            for(int x = 0; x < playertwoplatemodels.Count; x++)
            {
                if(playertwoplatemodels[x].name == playerplateitem)
                {
                    playertwoplatemodels[x].SetActive(true);
                }
                if(playertwoplatemodels[x].name != playerplateitem)
                {
                    playertwoplatemodels[x].SetActive(false);
                }
            }
        }
    }
}
