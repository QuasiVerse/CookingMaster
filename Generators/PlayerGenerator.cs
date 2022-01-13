using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGenerator : MonoBehaviour
{

    public static GameObject playerone;
    public static PlayerController playeronecontroller;
    public static CapsuleCollider playeronecollider;
    public static GameObject playeronerightarm;
    public static GameObject playeroneleftarm;
    public static GameObject playeronerightleg;
    public static GameObject playeroneleftleg;
    

    public static GameObject playertwo;
    public static PlayerController playertwocontroller;
    public static CapsuleCollider playertwocollider;
    public static GameObject playertworightarm;
    public static GameObject playertwoleftarm;
    public static GameObject playertworightleg;
    public static GameObject playertwoleftleg;
    
    private static InventoryManager playeroneinventory;
    private static InventoryManager playertwoinventory;
    
    public static void GeneratePlayer()
    {
        CharModelGenerator.GenerateCharModel(new Color(.3f, .8f, 1, 0), out playerone, out playeronecollider, out playeronerightarm, out playeroneleftarm, out playeronerightleg, out playeroneleftleg);
        playerone.name = "Player One";
        playerone.transform.position = new Vector3(LevelGenerator.floorlength/2, 2.25f, LevelGenerator.floorwidth/2 - 2);
        playerone.transform.eulerAngles = new Vector3(0, -90, 0);
        Rigidbody playeronerigidbody = playerone.AddComponent<Rigidbody>();
        playeronerigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        playeroneinventory = playerone.AddComponent<InventoryManager>();
        playeronecontroller = playerone.AddComponent<PlayerController>();
        playeronecontroller.playeronerightarm = playeronerightarm;
        playeronecontroller.playeroneleftarm = playeroneleftarm;
        playeronecontroller.playeronerightleg = playeronerightleg;
        playeronecontroller.playeroneleftleg = playeroneleftleg;
        playeronecontroller.playernumber = 1;
        playeroneinventory.playernumber = 1;
        playeronecontroller.playerinventory = playeroneinventory;
        GameObject playeronechefhat = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        playeronechefhat.transform.parent = playerone.transform;
        playeronechefhat.transform.localPosition = new Vector3(-.12f, .43f, -.17f);
        playeronechefhat.transform.localScale = new Vector3(.8f, .5f, .8f);
        playeronechefhat.transform.localEulerAngles = new Vector3(0, -45, 33);
        playeronechefhat.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 0);
        Destroy (playeronechefhat.transform.GetComponent<CapsuleCollider>());
        GameObject playeronechefknife = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        playeronechefknife.transform.parent = playeronerightarm.transform;
        playeronechefknife.transform.localPosition = new Vector3(-.12f, -1.65f, 1.1f);
        playeronechefknife.transform.localScale = new Vector3(.1f, 1.4f, .8f);
        playeronechefknife.transform.localEulerAngles = new Vector3(90, 0, 0);
        playeronechefknife.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 0);
        Destroy (playeronechefknife.transform.GetComponent<CapsuleCollider>());
        playerone.SetActive(false);
        
        CharModelGenerator.GenerateCharModel(new Color(.3f, .3f, 1, 0), out playertwo, out playertwocollider, out playertworightarm, out playertwoleftarm, out playertworightleg, out playertwoleftleg);
        playertwo.name = "Player Two";
        playertwo.transform.position = new Vector3(LevelGenerator.floorlength/2, 2.25f, LevelGenerator.floorwidth/2 + 2);
        playertwo.transform.eulerAngles = new Vector3(0, -90, 0);
        Rigidbody playertworigidbody = playertwo.AddComponent<Rigidbody>();
        playertworigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        playertwoinventory = playertwo.AddComponent<InventoryManager>();
        playertwocontroller = playertwo.AddComponent<PlayerController>();
        playertwocontroller.playertworightarm = playertworightarm;
        playertwocontroller.playertwoleftarm = playertwoleftarm;
        playertwocontroller.playertworightleg = playertworightleg;
        playertwocontroller.playertwoleftleg = playertwoleftleg;
        playertwocontroller.playernumber = 2;
        playertwoinventory.playernumber = 2;
        playertwocontroller.playerinventory = playertwoinventory;
        GameObject playertwochefhat = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        playertwochefhat.transform.parent = playertwo.transform;
        playertwochefhat.transform.localPosition = new Vector3(-.12f, .43f, -.17f);
        playertwochefhat.transform.localScale = new Vector3(.8f, .5f, .8f);
        playertwochefhat.transform.localEulerAngles = new Vector3(0, -45, 33);
        playertwochefhat.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 0);
        Destroy (playertwochefhat.transform.GetComponent<CapsuleCollider>());
        GameObject playertwochefknife = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        playertwochefknife.transform.parent = playertworightarm.transform;
        playertwochefknife.transform.localPosition = new Vector3(-.12f, -1.65f, 1.1f);
        playertwochefknife.transform.localScale = new Vector3(.1f, 1.4f, .8f);
        playertwochefknife.transform.localEulerAngles = new Vector3(90, 0, 0);
        playertwochefknife.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 0);
        Destroy (playertwochefknife.transform.GetComponent<CapsuleCollider>());
        playertwo.SetActive(false);
    }
}

