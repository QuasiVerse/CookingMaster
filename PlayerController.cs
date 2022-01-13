using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CookingManager manager;
    private GuestManager guestmanager;

    public int playernumber;
    
    public GameObject playerone;
    public GameObject playertwo;
    
    public GameObject playeronerightarm;
    public GameObject playeroneleftarm;
    public GameObject playeronerightleg;
    public GameObject playeroneleftleg;
    
    public GameObject playertworightarm;
    public GameObject playertwoleftarm;
    public GameObject playertworightleg;
    public GameObject playertwoleftleg;
    
    private bool playeronemoved;
    private bool playeronemoving;
    private bool playeronemovingshift;
    private float playeronemovingtimer;
    private float playeronemovinginitialtimer;
    private bool playeroneinitializingmove;
    private bool playeronemoveinitialized;
    private bool playeronechopping;
    private float playeronechoppingtimer;
    private float playeronechoppingdurationtimer;
    private bool playeronechoppingshift;
    private float playeronechoppinginitialtimer;
    private bool playeronechoppinginitialized;
    
    private bool playertwomoved;
    private bool playertwomoving;
    private bool playertwomovingshift;
    private float playertwomovingtimer;
    private float playertwomovinginitialtimer;
    private bool playertwoinitializingmove;
    private bool playertwomoveinitialized;
    private bool playertwochopping;
    private float playertwochoppingtimer;
    private float playertwochoppingdurationtimer;
    private bool playertwochoppingshift;
    private float playertwochoppinginitialtimer;
    private bool playertwochoppinginitialized;
    
    private Rigidbody playeronerigidbody;
    private Rigidbody playertworigidbody;
    
    private float movespeed = 15f;
    private float origmovespeed;
    
    public string currentcollider;
    
    public InventoryManager playerinventory;
    
    private float pickuptimer;
    
    public float speedboosttimer;
    
    private bool playerplateswapped;
    
    private bool ordercorrect;
    
    private List<bool> listused;
    
    void Start(){
        manager = GameObject.Find("Main Camera").GetComponent<CookingManager>();
        guestmanager = GameObject.Find("Main Camera").GetComponent<GuestManager>();
        playerone = PlayerGenerator.playerone;
        playertwo = PlayerGenerator.playertwo;
        
        playeronerigidbody = playerone.GetComponent<Rigidbody>();
        playertworigidbody = playertwo.GetComponent<Rigidbody>();
        
        origmovespeed = movespeed;
    }
    
    void FixedUpdate()
    {
        speedboosttimer -= .1f;
        if(speedboosttimer > 0)
        {
            movespeed = origmovespeed * 2;
        }
        if(speedboosttimer <= 0)
        {
            movespeed = origmovespeed;
        }
        if(playernumber == 1)
        {
            //Player One Movement
            playeronemoved = false;
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D) && !playeronechopping)
            {
                playerone.transform.localEulerAngles = new Vector3(0, -45, 0);
                playeronerigidbody.AddForce(playerone.transform.forward * movespeed);
                playeronemoved = true;
                playeronemoving = true;
            }
            if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D) && !playeronechopping)
            {
                playerone.transform.localEulerAngles = new Vector3(0, 45, 0);
                playeronerigidbody.AddForce(playerone.transform.forward * movespeed);
                playeronemoved = true;
                playeronemoving = true;
            }
            if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A) && !playeronechopping)
            {
                playerone.transform.localEulerAngles = new Vector3(0, 135, 0);
                playeronerigidbody.AddForce(playerone.transform.forward * movespeed);
                playeronemoved = true;
                playeronemoving = true;
            }
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W) && !playeronechopping)
            {
                playerone.transform.localEulerAngles = new Vector3(0, -135, 0);
                playeronerigidbody.AddForce(playerone.transform.forward * movespeed);
                playeronemoved = true;
                playeronemoving = true;
            }
            if (Input.GetKey(KeyCode.W) && playeronemoved == false && !playeronechopping)
            {
                playerone.transform.localEulerAngles = new Vector3(0, -90, 0);
                playeronerigidbody.AddForce(playerone.transform.forward * movespeed);
                playeronemoved = true;
                playeronemoving = true;
            }
            if (Input.GetKey(KeyCode.S) && playeronemoved == false && !playeronechopping)
            {
                playerone.transform.localEulerAngles = new Vector3(0, 90, 0);
                playeronerigidbody.AddForce(playerone.transform.forward * movespeed);
                playeronemoved = true;
                playeronemoving = true;
            }
            if (Input.GetKey(KeyCode.D) && playeronemoved == false && !playeronechopping)
            {
                playerone.transform.localEulerAngles = new Vector3(0, 0, 0);
                playeronerigidbody.AddForce(playerone.transform.forward * movespeed);
                playeronemoved = true;
                playeronemoving = true;
            }
            if (Input.GetKey(KeyCode.A) && playeronemoved == false && !playeronechopping)
            {
                playerone.transform.localEulerAngles = new Vector3(0, 180, 0);
                playeronerigidbody.AddForce(playerone.transform.forward * movespeed);
                playeronemoved = true;
                playeronemoving = true;
            }
            if (!Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A))
            {
                playeronemoving = false;
            }

            //Player One Movement Anim
            if(playeronemoving)
            {
                playeronemovingtimer += .1f;
                playeronemovinginitialtimer += .1f;
                if(playeronemovinginitialtimer > 1f && playeroneinitializingmove == false)
                {
                    playeroneinitializingmove = true;
                }
                if(playeronemovingtimer > 2 || (playeroneinitializingmove && !playeronemoveinitialized)){
                    playeronemovingshift = !playeronemovingshift;
                    playeronemovingtimer = 0f;
                    playeronemoveinitialized = true;
                }
                if(playeronemovingshift)
                {
                    PlayerAnimator.AnimatePlayer("Run", "Left", playeronerightarm, playeroneleftarm, playeronerightleg, playeroneleftleg);
                }
                if(!playeronemovingshift)
                {
                    PlayerAnimator.AnimatePlayer("Run", "Right", playeronerightarm, playeroneleftarm, playeronerightleg, playeroneleftleg);
                }
            }

            if (!playeronemoving)
            {
                playeronemovingtimer = 0;
                playeronemovinginitialtimer = 0;
                playeroneinitializingmove = false;
                playeronemoveinitialized = false;
            }

            playeronerigidbody.angularVelocity = Vector3.Slerp (playeronerigidbody.angularVelocity, Vector3.zero,(Time.fixedDeltaTime * 8f));
            playeronerigidbody.velocity = Vector3.Slerp (playeronerigidbody.velocity, Vector3.zero,(Time.fixedDeltaTime * 2f));

            //Player One Standing Anim
            if(!playeronemoving && !playeronechopping){
                PlayerAnimator.AnimatePlayer("Stand", "", playeronerightarm, playeroneleftarm, playeronerightleg, playeroneleftleg);
            }

            //Player One Chopping
            playeronechopping = false;
            if (Input.GetKey(KeyCode.E) && !playeronemoving && playerinventory.playerchoppingtableitem != "")
            {
                playeronechopping = true;
            }
            if (!Input.GetKey(KeyCode.E) && !playeronemoving)
            {
                playeronechopping = false;
            }

            if(playeronechopping && currentcollider == "Player One Chopping Table")
            {
                //Player One Chopping Interactions
                playeronechoppingdurationtimer += .1f;
                if(playeronechoppingdurationtimer > 10){
                    playerinventory.playerchoppedtableinventory.Add(playerinventory.playerchoppingtableitem);
                    playerinventory.playerchoppingtableitem = "";
                    playeronechoppingdurationtimer = 0;
                }
                
                //Player One Chopping Anim
                playerone.transform.localEulerAngles = new Vector3(0, 90, 0);
                playeronechoppingtimer += .1f;
                playeronechoppinginitialtimer += .1f;
                if(playeronechoppinginitialtimer > 1.5f && playeronechoppinginitialized == false)
                {
                    playeronechoppinginitialized = true;
                }
                if(playeronechoppingtimer > 1f && playeronechoppinginitialized == true)
                {
                    playeronechoppingshift = !playeronechoppingshift;
                    playeronechoppingtimer = 0f;
                }
                if(playeronechoppingshift)
                {
                    PlayerAnimator.AnimatePlayer("Chop", "Up", playeronerightarm, playeroneleftarm, playeronerightleg, playeroneleftleg);
                }
                if(!playeronechoppingshift)
                {
                    PlayerAnimator.AnimatePlayer("Chop", "Down", playeronerightarm, playeroneleftarm, playeronerightleg, playeroneleftleg);
                }
            }
            if(!playeronechopping)
            {
                playeronechoppingtimer = 0f;
                playeronechoppinginitialtimer = 0f;
                playeronechoppinginitialtimer = 0f;
                playeronechoppinginitialized = false;
                playeronechoppingshift = false;
            } 
            
            if(playeronechopping)

            //Player One Standing Anim Double Check To Prevent Overlapping Animations
            if(!playeronemoving && !playeronechopping)
            {
                PlayerAnimator.AnimatePlayer("Stand", "", playeronerightarm, playeroneleftarm, playeronerightleg, playeroneleftleg);
            }
            
            //Player One Inventory Interactions
            playerplateswapped = false;
            pickuptimer += .1f;
            if(Input.GetKey(KeyCode.Q) && pickuptimer >= 1f)
            {
                pickuptimer = 0;
                if(currentcollider != "")
                {   
                
                    if(currentcollider == "Eggplant" || currentcollider == "Tomato" || currentcollider == "Zuccini" || currentcollider == "Potato" || currentcollider == "Corn" || currentcollider == "Lettuce")
                    {
                         if(playerinventory.playerinventory.Count < 2)
                         {   
                            playerinventory.playerinventory.Add(currentcollider);
                         }
                    }
                    if(currentcollider == "Player One Chopping Table" && playerinventory.playerchoppingtableitem == "" && playerinventory.playerchoppedtableinventory.Count < 3 && playerinventory.playerinventory.Count != 0)
                    {
                        playerinventory.playerchoppingtableitem = playerinventory.playerinventory[0];
                        playerinventory.playerinventory.RemoveAt(0);
                    }
                    if(currentcollider == "Player One Chopping Table" && playerinventory.playerplateitem != "" && playerinventory.playerchoppedtableinventory.Count != 0 && playerinventory.playerchoppedinventory.Count == 0)
                    {
                        playerinventory.playerchoppedinventory = playerinventory.playerchoppedtableinventory;
                        playerinventory.playerchoppedtableinventory = new List<string>();
                    }
                    if(currentcollider == "Player One Plate")
                    {
                        if(playerinventory.playerplateitem == "" && playerinventory.playerinventory.Count > 0)
                        {
                            playerinventory.playerplateitem = playerinventory.playerinventory[0];
                            playerinventory.playerinventory.RemoveAt(0);
                            playerplateswapped = true;
                        }
                        if(playerinventory.playerplateitem != "" && playerinventory.playerinventory.Count < 2 && playerplateswapped == false)
                        {
                            playerinventory.playerinventory.Add(playerinventory.playerplateitem);
                            playerinventory.playerplateitem = "";
                        }
                    }
                    if(currentcollider == "Trash Can")
                    {
                        manager.Report(-1, 1, playerinventory.playerchoppedinventory.Count * 5);
                        playerinventory.playerchoppedinventory = new List<string>();
                    }
                    if(currentcollider == "Guest One")
                    {   
                        ordercorrect = CompareIngredients(playerinventory.playerchoppedinventory, guestmanager.guestorders[0]);
                        if(ordercorrect == true)
                        {
                            playerinventory.playerchoppedinventory = new List<string>();
                            guestmanager.FulfillOrder(1, 0);
                        }
                        if(ordercorrect == false)
                        {
                            playerinventory.playerchoppedinventory = new List<string>();
                            guestmanager.MixedOrder(1, 0);
                        }
                    }
                    if(currentcollider == "Guest Two")
                    {
                        ordercorrect = CompareIngredients(playerinventory.playerchoppedinventory, guestmanager.guestorders[1]);
                        if(ordercorrect == true)
                        {
                            playerinventory.playerchoppedinventory = new List<string>();
                            guestmanager.FulfillOrder(1, 1);
                        }
                        if(ordercorrect == false)
                        {
                            playerinventory.playerchoppedinventory = new List<string>();
                            guestmanager.MixedOrder(1, 1);
                        }
                    }
                    if(currentcollider == "Guest Three")
                    {
                        ordercorrect = CompareIngredients(playerinventory.playerchoppedinventory, guestmanager.guestorders[2]);
                        if(ordercorrect == true)
                        {
                            playerinventory.playerchoppedinventory = new List<string>();
                            guestmanager.FulfillOrder(1, 2);
                        }
                        if(ordercorrect == false)
                        {
                            playerinventory.playerchoppedinventory = new List<string>();
                            guestmanager.MixedOrder(1, 2);
                        }
                    }
                    if(currentcollider == "Guest Four")
                    {
                        ordercorrect = CompareIngredients(playerinventory.playerchoppedinventory, guestmanager.guestorders[3]);
                        if(ordercorrect == true)
                        {
                            playerinventory.playerchoppedinventory = new List<string>();
                            guestmanager.FulfillOrder(1, 3);
                        }
                        if(ordercorrect == false)
                        {
                            playerinventory.playerchoppedinventory = new List<string>();
                            guestmanager.MixedOrder(1, 3);
                        }
                    }
                    if(currentcollider == "Guest Five")
                    {
                        ordercorrect = CompareIngredients(playerinventory.playerchoppedinventory, guestmanager.guestorders[4]);
                        if(ordercorrect == true)
                        {
                            playerinventory.playerchoppedinventory = new List<string>();
                            guestmanager.FulfillOrder(1, 4);
                        }
                        if(ordercorrect == false)
                        {
                            playerinventory.playerchoppedinventory = new List<string>();
                            guestmanager.MixedOrder(1, 4);
                        }
                    }
                }
            }
        }
        
        if(playernumber == 2)
        {
            //Player Two Movement
            playertwomoved = false;
            if (Input.GetKey(KeyCode.I) && Input.GetKey(KeyCode.L) && !playertwochopping)
            {
                playertwo.transform.localEulerAngles = new Vector3(0, -45, 0);
                playertworigidbody.AddForce(playertwo.transform.forward * movespeed);
                playertwomoved = true;
                playertwomoving = true;
            }
            if (Input.GetKey(KeyCode.K) && Input.GetKey(KeyCode.L) && !playertwochopping)
            {
                playertwo.transform.localEulerAngles = new Vector3(0, 45, 0);
                playertworigidbody.AddForce(playertwo.transform.forward * movespeed);
                playertwomoved = true;
                playertwomoving = true;
            }
            if (Input.GetKey(KeyCode.K) && Input.GetKey(KeyCode.J) && !playertwochopping)
            {
                playertwo.transform.localEulerAngles = new Vector3(0, 135, 0);
                playertworigidbody.AddForce(playertwo.transform.forward * movespeed);
                playertwomoved = true;
                playertwomoving = true;
            }
            if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.I) && !playertwochopping)
            {
                playertwo.transform.localEulerAngles = new Vector3(0, -135, 0);
                playertworigidbody.AddForce(playertwo.transform.forward * movespeed);
                playertwomoved = true;
                playertwomoving = true;
            }
            if (Input.GetKey(KeyCode.I) && playertwomoved == false && !playertwochopping)
            {
                playertwo.transform.localEulerAngles = new Vector3(0, -90, 0);
                playertworigidbody.AddForce(playertwo.transform.forward * movespeed);
                playertwomoved = true;
                playertwomoving = true;
            }
            if (Input.GetKey(KeyCode.K) && playertwomoved == false && !playertwochopping)
            {
                playertwo.transform.localEulerAngles = new Vector3(0, 90, 0);
                playertworigidbody.AddForce(playertwo.transform.forward * movespeed);
                playertwomoved = true;
                playertwomoving = true;
            }
            if (Input.GetKey(KeyCode.L) && playertwomoved == false && !playertwochopping)
            {
                playertwo.transform.localEulerAngles = new Vector3(0, 0, 0);
                playertworigidbody.AddForce(playertwo.transform.forward * movespeed);
                playertwomoved = true;
                playertwomoving = true;
            }
            if (Input.GetKey(KeyCode.J) && playertwomoved == false && !playertwochopping)
            {
                playertwo.transform.localEulerAngles = new Vector3(0, 180, 0);
                playertworigidbody.AddForce(playertwo.transform.forward * movespeed);
                playertwomoved = true;
                playertwomoving = true;
            }
            if (!Input.GetKey(KeyCode.K) && !Input.GetKey(KeyCode.L) && !Input.GetKey(KeyCode.I) && !Input.GetKey(KeyCode.J))
            {
                playertwomoving = false;
            }

            //Player Two Movement Anim
            if(playertwomoving)
            {
                playertwomovingtimer += .1f;
                playertwomovinginitialtimer += .1f;
                if(playertwomovinginitialtimer > 1f && playertwoinitializingmove == false)
                {
                    playertwoinitializingmove = true;
                }
                if(playertwomovingtimer > 2 || (playertwoinitializingmove && !playertwomoveinitialized)){
                    playertwomovingshift = !playertwomovingshift;
                    playertwomovingtimer = 0f;
                    playertwomoveinitialized = true;
                }
                if(playertwomovingshift)
                {
                    PlayerAnimator.AnimatePlayer("Run", "Left", playertworightarm, playertwoleftarm, playertworightleg, playertwoleftleg);
                }
                if(!playertwomovingshift)
                {
                    PlayerAnimator.AnimatePlayer("Run", "Right", playertworightarm, playertwoleftarm, playertworightleg, playertwoleftleg);
                }
            }

            if (!playertwomoving)
            {
                playertwomovingtimer = 0;
                playertwomovinginitialtimer = 0;
                playertwoinitializingmove = false;
                playertwomoveinitialized = false;
            }

            playertworigidbody.angularVelocity = Vector3.Slerp (playertworigidbody.angularVelocity, Vector3.zero,(Time.fixedDeltaTime * 8f));
            playertworigidbody.velocity = Vector3.Slerp (playertworigidbody.velocity, Vector3.zero,(Time.fixedDeltaTime * 2f));

            //Player Two Standing Anim
            if(!playertwomoving && !playertwochopping){
                PlayerAnimator.AnimatePlayer("Stand", "", playertworightarm, playertwoleftarm, playertworightleg, playertwoleftleg);
            }

            //Player Two Chopping
            playertwochopping = false;
            if (Input.GetKey(KeyCode.O) && !playertwomoving && playerinventory.playerchoppingtableitem != "")
            {
                playertwochopping = true;
            }
            if (!Input.GetKey(KeyCode.O) && !playertwomoving)
            {
                playertwochopping = false;
            }

            if(playertwochopping && currentcollider == "Player Two Chopping Table")
            {
                //Player Two Chopping Interactions
                playertwochoppingdurationtimer += .1f;
                if(playertwochoppingdurationtimer > 10){
                    playerinventory.playerchoppedtableinventory.Add(playerinventory.playerchoppingtableitem);
                    playerinventory.playerchoppingtableitem = "";
                    playertwochoppingdurationtimer = 0;
                }
                
                //Player Two Chopping Anim
                playertwo.transform.localEulerAngles = new Vector3(0, 90, 0);
                playertwochoppingtimer += .1f;
                playertwochoppinginitialtimer += .1f;
                if(playertwochoppinginitialtimer > 1.5f && playertwochoppinginitialized == false)
                {
                    playertwochoppinginitialized = true;
                }
                if(playertwochoppingtimer > 1f && playertwochoppinginitialized == true)
                {
                    playertwochoppingshift = !playertwochoppingshift;
                    playertwochoppingtimer = 0f;
                }
                if(playertwochoppingshift)
                {
                    PlayerAnimator.AnimatePlayer("Chop", "Up", playertworightarm, playertwoleftarm, playertworightleg, playertwoleftleg);
                }
                if(!playertwochoppingshift)
                {
                    PlayerAnimator.AnimatePlayer("Chop", "Down", playertworightarm, playertwoleftarm, playertworightleg, playertwoleftleg);
                }
            }
            if(!playertwochopping)
            {
                playertwochoppingtimer = 0f;
                playertwochoppinginitialtimer = 0f;
                playertwochoppinginitialtimer = 0f;
                playertwochoppinginitialized = false;
                playertwochoppingshift = false;
            } 
            
            if(playertwochopping)

            //Player Two Standing Anim Double Check To Prevent Overlapping Animations
            if(!playertwomoving && !playertwochopping)
            {
                PlayerAnimator.AnimatePlayer("Stand", "", playertworightarm, playertwoleftarm, playertworightleg, playertwoleftleg);
            }
            
            //Player Two Inventory Interactions
            playerplateswapped = false;
            pickuptimer += .1f;
            if(Input.GetKey(KeyCode.U) && pickuptimer >= 1f)
            {
                pickuptimer = 0;
                if(currentcollider != "")
                {   
                
                    if(currentcollider == "Eggplant" || currentcollider == "Tomato" || currentcollider == "Zuccini" || currentcollider == "Potato" || currentcollider == "Corn" || currentcollider == "Lettuce")
                    {
                         if(playerinventory.playerinventory.Count < 2)
                         {   
                            playerinventory.playerinventory.Add(currentcollider);
                         }
                    }
                    if(currentcollider == "Player Two Chopping Table" && playerinventory.playerchoppingtableitem == "" && playerinventory.playerchoppedtableinventory.Count < 3 && playerinventory.playerinventory.Count != 0)
                    {
                        playerinventory.playerchoppingtableitem = playerinventory.playerinventory[0];
                        playerinventory.playerinventory.RemoveAt(0);
                    }
                    if(currentcollider == "Player Two Chopping Table" && playerinventory.playerplateitem != "" && playerinventory.playerchoppedtableinventory.Count != 0 && playerinventory.playerchoppedinventory.Count == 0)
                    {
                        playerinventory.playerchoppedinventory = playerinventory.playerchoppedtableinventory;
                        playerinventory.playerchoppedtableinventory = new List<string>();
                    }
                    if(currentcollider == "Player Two Plate")
                    {
                        if(playerinventory.playerplateitem == "" && playerinventory.playerinventory.Count > 0)
                        {
                            playerinventory.playerplateitem = playerinventory.playerinventory[0];
                            playerinventory.playerinventory.RemoveAt(0);
                            playerplateswapped = true;
                        }
                        if(playerinventory.playerplateitem != "" && playerinventory.playerinventory.Count < 2 && playerplateswapped == false)
                        {
                            playerinventory.playerinventory.Add(playerinventory.playerplateitem);
                            playerinventory.playerplateitem = "";
                        }
                    }
                    if(currentcollider == "Trash Can")
                    {
                        manager.Report(-1, 2, playerinventory.playerchoppedinventory.Count * 5);
                        playerinventory.playerchoppedinventory = new List<string>();
                    }
                    if(currentcollider == "Guest One")
                    {   
                        ordercorrect = CompareIngredients(playerinventory.playerchoppedinventory, guestmanager.guestorders[0]);
                        if(ordercorrect == true)
                        {
                            playerinventory.playerchoppedinventory = new List<string>();
                            guestmanager.FulfillOrder(2, 0);
                        }
                        if(ordercorrect == false)
                        {
                            playerinventory.playerchoppedinventory = new List<string>();
                            guestmanager.MixedOrder(2, 0);
                        }
                    }
                    if(currentcollider == "Guest Two")
                    {
                        ordercorrect = CompareIngredients(playerinventory.playerchoppedinventory, guestmanager.guestorders[1]);
                        if(ordercorrect == true)
                        {
                            playerinventory.playerchoppedinventory = new List<string>();
                            guestmanager.FulfillOrder(2, 1);
                        }
                        if(ordercorrect == false)
                        {
                            playerinventory.playerchoppedinventory = new List<string>();
                            guestmanager.MixedOrder(2, 1);
                        }
                    }
                    if(currentcollider == "Guest Three")
                    {
                        ordercorrect = CompareIngredients(playerinventory.playerchoppedinventory, guestmanager.guestorders[2]);
                        if(ordercorrect == true)
                        {
                            playerinventory.playerchoppedinventory = new List<string>();
                            guestmanager.FulfillOrder(2, 2);
                        }
                        if(ordercorrect == false)
                        {
                            playerinventory.playerchoppedinventory = new List<string>();
                            guestmanager.MixedOrder(2, 2);
                        }
                    }
                    if(currentcollider == "Guest Four")
                    {
                        ordercorrect = CompareIngredients(playerinventory.playerchoppedinventory, guestmanager.guestorders[3]);
                        if(ordercorrect == true)
                        {
                            playerinventory.playerchoppedinventory = new List<string>();
                            guestmanager.FulfillOrder(2, 3);
                        }
                        if(ordercorrect == false)
                        {
                            playerinventory.playerchoppedinventory = new List<string>();
                            guestmanager.MixedOrder(2, 3);
                        }
                    }
                    if(currentcollider == "Guest Five")
                    {
                        ordercorrect = CompareIngredients(playerinventory.playerchoppedinventory, guestmanager.guestorders[4]);
                        if(ordercorrect == true)
                        {
                            playerinventory.playerchoppedinventory = new List<string>();
                            guestmanager.FulfillOrder(2, 4);
                        }
                        if(ordercorrect == false)
                        {
                            playerinventory.playerchoppedinventory = new List<string>();
                            guestmanager.MixedOrder(2, 4);
                        }
                    }
                }
            }
        }
    }
    
    public bool CompareIngredients(List<string> listone, List<string> listtwo) 
    {
    
        if(listone.Count != listtwo.Count)
        {
            return false;
        }
        listused = new List<bool>();
        for(int x = 0; x < listtwo.Count; x++)
        {
            listused.Add(false);
        }
        for(int n = 0; n < listone.Count; n++) 
        {
            bool found = false;
            for(int m = 0; m < listtwo.Count; m++) 
            {
                if(listone[n] == listtwo[m] && listused[m] != true) 
                {
                    listused[m] = true;
                    found = true;
                    break;
                }
            }
            if(!found){
                return false;
            }
        }

        return true;
    }
    
    void OnTriggerEnter(Collider collider)
    {
        currentcollider = collider.name;
        
        if(collider.name == "Player One Pickup" && playernumber == 1)
        {
            collider.transform.GetComponent<Pickup>().UsePickup(1, this);
        }
        if(collider.name == "Player Two Pickup" && playernumber == 2)
        {
            collider.transform.GetComponent<Pickup>().UsePickup(2, this);
        }
    }
    
    void OnTriggerExit(Collider collider)
    {
        currentcollider = "";
    }
}
