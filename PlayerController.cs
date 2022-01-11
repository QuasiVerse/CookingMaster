using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

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
    private bool playertwochoppingshift;
    private float playertwochoppinginitialtimer;
    private bool playertwochoppinginitialized;
    
    private Rigidbody playeronerigidbody;
    private Rigidbody playertworigidbody;
    
    private float movespeed = 15f;
    
    public string currentcollider;
    
    public InventoryManager playerinventory;
    
    private float pickuptimer;
    
    void Start(){
        playerone = PlayerGenerator.playerone;
        playertwo = PlayerGenerator.playertwo;
        
        playeronerigidbody = playerone.GetComponent<Rigidbody>();
        playertworigidbody = playertwo.GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    {
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
            if (Input.GetKey(KeyCode.E) && !playeronemoving)
            {
                playeronechopping = true;
            }
            if (!Input.GetKey(KeyCode.E) && !playeronemoving)
            {
                playeronechopping = false;
            }

            //Player One Chopping Anim
            if(playeronechopping && currentcollider == "Player One Chopping")
            {
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

            //Player One Standing Anim Double Check To Prevent Overlapping Animations
            if(!playeronemoving && !playeronechopping)
            {
                PlayerAnimator.AnimatePlayer("Stand", "", playeronerightarm, playeroneleftarm, playeronerightleg, playeroneleftleg);
            }
            
            //Player One Inventory Interactions
            
            pickuptimer += .1f;
            if(Input.GetKey(KeyCode.Q) && pickuptimer >= 1f)
            {
                pickuptimer = 0;
                if(currentcollider != "")
                {   
                    if(playerinventory.playerinventory.Count < 2)
                    {
                        if(currentcollider == "Eggplant" || currentcollider == "Tomato" || currentcollider == "Zuccini" || currentcollider == "Potato" || currentcollider == "Corn" || currentcollider == "Lettuce")
                        {
                            playerinventory.playerinventory.Add(currentcollider);
                        }
                    }
                    if(playerinventory.playerinventory.Count > 0)
                    {
                        if(currentcollider == "Player One Chopping")
                        {
                            playerinventory.playerchoppingtableinventory.Add(playerinventory.playerinventory[0]);
                            playerinventory.playerinventory.RemoveAt(0);
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
            if (Input.GetKey(KeyCode.O) && !playertwomoving)
            {
                playertwochopping = true;
            }
            if (!Input.GetKey(KeyCode.O) && !playertwomoving)
            {
                playertwochopping = false;
            }

            //Player Two Chopping Anim
            if(playertwochopping && currentcollider == "Player Two Chopping")
            {
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

            //Player Two Standing Anim Double Check To Prevent Overlapping Animations
            if(!playertwomoving && !playertwochopping){
                PlayerAnimator.AnimatePlayer("Stand", "", playertworightarm, playertwoleftarm, playertworightleg, playertwoleftleg);
            }
        }
    }
    
    void OnTriggerEnter(Collider collider)
    {
        currentcollider = collider.name;
    }
    
    void OnTriggerExit(Collider collider)
    {
        currentcollider = "";
    }
}
