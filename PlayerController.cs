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
    private bool playeroneshift;
    private float playeronemovingtimer;
    private float playeronemovinginitialtimer;
    private bool playeroneinitializingmove;
    private bool playeronemoveinitialized;
    private bool playeronechopping;
    
    private bool playertwomoved;
    private bool playertwomoving;
    private bool playertwoshift;
    private float playertwomovingtimer;
    private float playertwomovinginitialtimer;
    private bool playertwointiallymoved;
    private bool playertwomoveinitialized;
    private bool playertwochopping;
    
    private Rigidbody playeronerigidbody;
    private Rigidbody playertworigidbody;
    
    private float movespeed = 15f;
    
    void Start(){
        playerone = PlayerGenerator.playerone;
        playertwo = PlayerGenerator.playertwo;
        
        playeronerigidbody = playerone.GetComponent<Rigidbody>();
        playertworigidbody = playertwo.GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    {
        //Player One Movement
        playeronemoved = false;
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D) && playernumber == 1)
        {
            playerone.transform.localEulerAngles = new Vector3(0, -45, 0);
            playeronerigidbody.AddForce(playerone.transform.forward * movespeed);
            playeronemoved = true;
            playeronemoving = true;
		}
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D) && playernumber == 1)
        {
            playerone.transform.localEulerAngles = new Vector3(0, 45, 0);
            playeronerigidbody.AddForce(playerone.transform.forward * movespeed);
			playeronemoved = true;
            playeronemoving = true;
		}
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A) && playernumber == 1)
        {
            playerone.transform.localEulerAngles = new Vector3(0, 135, 0);
            playeronerigidbody.AddForce(playerone.transform.forward * movespeed);
			playeronemoved = true;
            playeronemoving = true;
		}
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W) && playernumber == 1)
        {
            playerone.transform.localEulerAngles = new Vector3(0, -135, 0);
            playeronerigidbody.AddForce(playerone.transform.forward * movespeed);
			playeronemoved = true;
            playeronemoving = true;
		}
		if (Input.GetKey(KeyCode.W) && playernumber == 1 && playeronemoved == false)
        {
            playerone.transform.localEulerAngles = new Vector3(0, -90, 0);
            playeronerigidbody.AddForce(playerone.transform.forward * movespeed);
            playeronemoved = true;
            playeronemoving = true;
		}
        if (Input.GetKey(KeyCode.S) && playernumber == 1 && playeronemoved == false)
        {
            playerone.transform.localEulerAngles = new Vector3(0, 90, 0);
            playeronerigidbody.AddForce(playerone.transform.forward * movespeed);
			playeronemoved = true;
            playeronemoving = true;
		}
        if (Input.GetKey(KeyCode.D) && playernumber == 1 && playeronemoved == false)
        {
            playerone.transform.localEulerAngles = new Vector3(0, 0, 0);
            playeronerigidbody.AddForce(playerone.transform.forward * movespeed);
			playeronemoved = true;
            playeronemoving = true;
		}
        if (Input.GetKey(KeyCode.A) && playernumber == 1 && playeronemoved == false)
        {
            playerone.transform.localEulerAngles = new Vector3(0, 180, 0);
            playeronerigidbody.AddForce(playerone.transform.forward * movespeed);
			playeronemoved = true;
            playeronemoving = true;
		}
        if (!Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A))
        {
            playeronemoving = false;
            playeronemovingtimer = 0;
            playeronemovinginitialtimer = 0;
            playeroneinitializingmove = false;
            playeronemoveinitialized = false;
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
                playeroneshift = !playeroneshift;
                playeronemovingtimer = 0f;
                playeronemoveinitialized = true;
            }
            if(playeroneshift)
            {
                PlayerAnimator.AnimatePlayer("Run", "Left", playeronerightarm, playeroneleftarm, playeronerightleg, playeroneleftleg);
            }
            if(!playeroneshift)
            {
                PlayerAnimator.AnimatePlayer("Run", "Right", playeronerightarm, playeroneleftarm, playeronerightleg, playeroneleftleg);
            }
        }
        if(!playeronemoving && !playeronechopping){
            PlayerAnimator.AnimatePlayer("Stand", "", playeronerightarm, playeroneleftarm, playeronerightleg, playeroneleftleg);
        }
        
        playeronerigidbody.angularVelocity = Vector3.Slerp (playeronerigidbody.angularVelocity, Vector3.zero,(Time.fixedDeltaTime * 8f));
        playeronerigidbody.velocity = Vector3.Slerp (playeronerigidbody.velocity, Vector3.zero,(Time.fixedDeltaTime * 2f));
        
    }
}
