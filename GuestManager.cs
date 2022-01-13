using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestManager : MonoBehaviour
{
    
    private CookingManager manager;
    private GenerateHUD hud;
    
    private bool hudinitiated;
    
    public Dictionary<int, List<string>> guestorders;
    public List<string> guestoptions;
    public List<GameObject> guestspots;
    public List<bool> guestvacancy;
    public List<float> guesttimers;
    public List<TextMesh> guesttexts;
    public List<bool> guestmood;
    public List<bool> guestonecomplaints;
    public List<bool> guesttwocomplaints;
    
    private string guesttextorder;
    
    private float addguesttimer;
    private int guestsinitialized;
    private bool guestspotvacancy;
    
    public float guestmaxtimer = 500f;
    
    void Start()
    {
        manager = GameObject.Find("Main Camera").GetComponent<CookingManager>();
        guestorders = new Dictionary<int, List<string>>();
        guestorders[0] = new List<string>();
        guestorders[1] = new List<string>();
        guestorders[2] = new List<string>();
        guestorders[3] = new List<string>();
        guestorders[4] = new List<string>();
        
        guestoptions = new List<string>();
        guestoptions.Add("Eggplant");
        guestoptions.Add("Tomato");
        guestoptions.Add("Zuccini");
        guestoptions.Add("Potato");
        guestoptions.Add("Corn");
        guestoptions.Add("Lettuce");        
        
        guestspots = new List<GameObject>();
        guestspots.Add(GuestGenerator.guestone);
        guestspots.Add(GuestGenerator.guesttwo);
        guestspots.Add(GuestGenerator.guestthree);
        guestspots.Add(GuestGenerator.guestfour);
        guestspots.Add(GuestGenerator.guestfive);
                
        guestvacancy = new List<bool>();
        guestvacancy.Add(true);
        guestvacancy.Add(true);
        guestvacancy.Add(true);
        guestvacancy.Add(true);
        guestvacancy.Add(true);
        
        guesttimers = new List<float>();
        guesttimers.Add(0);
        guesttimers.Add(0);
        guesttimers.Add(0);
        guesttimers.Add(0);
        guesttimers.Add(0);
        
        guesttexts = new List<TextMesh>();
        guesttexts.Add(GuestGenerator.guestonetext);
        guesttexts.Add(GuestGenerator.guesttwotext);
        guesttexts.Add(GuestGenerator.guestthreetext);
        guesttexts.Add(GuestGenerator.guestfourtext);
        guesttexts.Add(GuestGenerator.guestfivetext);
        
        guestmood = new List<bool>();
        guestmood.Add(true);
        guestmood.Add(true);
        guestmood.Add(true);
        guestmood.Add(true);
        guestmood.Add(true);
        
        guestonecomplaints = new List<bool>();
        guestonecomplaints.Add(false);
        guestonecomplaints.Add(false);
        guestonecomplaints.Add(false);
        guestonecomplaints.Add(false);
        guestonecomplaints.Add(false);
        
        guesttwocomplaints = new List<bool>();
        guesttwocomplaints.Add(false);
        guesttwocomplaints.Add(false);
        guesttwocomplaints.Add(false);
        guesttwocomplaints.Add(false);
        guesttwocomplaints.Add(false);
    }

    void Update()
    {
        //Initiate HUD
        if(hudinitiated == false)
        {
            hud = GameObject.Find("Main Camera").GetComponent<GenerateHUD>();
            hudinitiated = true;
        }
        //Add Guest
        addguesttimer += .1f;
        if(addguesttimer > guestmaxtimer || guestsinitialized < 2)
        {
            guestsinitialized += 1;
            guestspotvacancy = false;
            for(int x = 0; x < 10; x++)
            {
                if(x < 9)
                {
                    int y = Random.Range(0, 4);
                    if(guestvacancy[y] == true && guestspotvacancy == false){
                        int m = Random.Range(0, 10);
                        if(m <= 2)
                        {
                            guestmood[y] = false;
                        }
                        if(m > 2)
                        {
                            guestmood[y] = true;
                        }
                        guesttimers[y] = guestmaxtimer;
                        guestspotvacancy = true;
                        guestvacancy[y] = false;
                        guestspots[y].SetActive(true);
                        hud.guesttimers[y].SetActive(true);
                        guestonecomplaints[y] = false;
                        guesttwocomplaints[y] = false;
                        for(int z = 0; z < Random.Range(2, 4); z++)
                        {
                            guestorders[y].Add(guestoptions[Random.Range(0, 5)]);
                        }
                        addguesttimer = 0;
                    }
                }
                if(x == 9)
                {
                    for(int y = 0; y < guestspots.Count; y++)
                    {
                        if(guestvacancy[y] == true && guestspotvacancy == false)
                        {
                            int m = Random.Range(0, 10);
                            if(m <= 2)
                            {
                                guestmood[y] = false;
                            }
                            if(m > 2)
                            {
                                guestmood[y] = true;
                            }
                            guesttimers[y] = guestmaxtimer;
                            guestspotvacancy = true;
                            guestvacancy[y] = false;
                            guestspots[y].SetActive(true);
                            hud.guesttimers[y].SetActive(true);
                            guestonecomplaints[y] = false;
                            guesttwocomplaints[y] = false;
                            for(int z = 0; z < Random.Range(2, 4); z++)
                            {
                                guestorders[y].Add(guestoptions[Random.Range(0, 5)]);
                            }
                            addguesttimer = 0;
                        }
                    }
                }
            }
        }
        
        //Guest Timers
        for(int x = 0; x < guestspots.Count; x++)
        {
            if(guestvacancy[x] == false)
            {
                if(guestmood[x] == true)
                {
                    guesttimers[x] -= .1f;
                }
                if(guestmood[x] == false)
                {
                    guesttimers[x] -= .2f;
                }
                
            }
            hud.ChangeGuestLocations(x, guesttimers[x], guestspots[x]);            
        }
        
        //Guest Orders
        for(int x = 0; x < guestspots.Count; x++)
        {
            guesttextorder = "";
            for(int y = 0; y < guestorders[x].Count; y++)
            {
                guesttextorder += guestorders[x][y] + "\n";
            }
            guesttexts[x].text = guesttextorder;
        }
        
        //Timed Out Guests
        for(int x = 0; x < guestspots.Count; x++)
        {
            if(guestvacancy[x] == false && guesttimers[x] < 0f)
            {
                manager.Report(-1, 1, guestorders[x].Count * 5);
                manager.Report(-1, 2, guestorders[x].Count * 5);
                if(guestmood[x] == false)
                {
                    if(guestonecomplaints[x] == true)
                    {
                        manager.Report(-1, 1, guestorders[x].Count * 5);
                    }
                    if(guesttwocomplaints[x] == true)
                    {
                        manager.Report(-1, 2, guestorders[x].Count * 5);
                    }
                    if(guestonecomplaints[x] == true && guesttwocomplaints[x] == true)
                    {
                        manager.Report(-1, 1, guestorders[x].Count * 5);
                        manager.Report(-1, 2, guestorders[x].Count * 5);
                    }
                }
                guestvacancy[x] = true;
                guesttimers[x] = 1;
                guestorders[x] = new List<string>();
                guestspots[x].SetActive(false);
                guestsinitialized -= 1;
                hud.guesttimers[x].SetActive(false);
            }
        }
    }
    
    //Clear Lists and Decative Guest
    public void FulfillOrder(int playernumber, int guestnumber)
    {
        manager.Report(1, playernumber, guestorders[guestnumber].Count * 5);
        if(guesttimers[guestnumber] >= guestmaxtimer/3 * 2)
        {
            GameObject pickup = GameObject.CreatePrimitive(PrimitiveType.Cube);
            if(playernumber == 1)
            {
                pickup.name = "Player One Pickup";
            }
            if(playernumber == 2)
            {
                pickup.name = "Player Two Pickup";
            }
            Pickup pickupcomponent = pickup.AddComponent<Pickup>();
            pickupcomponent.pickuptype = Random.Range(1, 3);
            pickup.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
            pickup.transform.GetComponent<BoxCollider>().isTrigger = true;
            pickup.transform.position = new Vector3(Random.Range(1, LevelGenerator.floorlength - 1), 1.55f, Random.Range(1, LevelGenerator.floorwidth - 1));
        }
        hud.guesttimers[guestnumber].SetActive(false);
        guestvacancy[guestnumber] = true;
        guesttimers[guestnumber] = 1;
        guestorders[guestnumber] = new List<string>();
        guestspots[guestnumber].SetActive(false);
        guestsinitialized -= 1;
    }
    
    public void MixedOrder(int playernumber, int guestnumber)
    {
        if(playernumber == 1)
        {
            guestonecomplaints[guestnumber] = true;
        }
        if(playernumber == 2)
        {
            guesttwocomplaints[guestnumber] = true;
        }
    }
}
