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
    
    public static void GeneratePlayer()
    {
        CharModelGenerator.GenerateCharModel(new Color(.3f, .8f, 1, 0), out playerone, out playeronecollider, out playeronerightarm, out playeroneleftarm, out playeronerightleg, out playeroneleftleg);
        playerone.transform.position = new Vector3(LevelGenerator.floorlength/2, 2.25f, LevelGenerator.floorwidth/2 - 2);
        playerone.transform.eulerAngles = new Vector3(0, -90, 0);
        playerone.AddComponent<Rigidbody>();
        playeronecontroller = playerone.AddComponent<PlayerController>();
        playeronecontroller.playernumber = 1;
        playerone.SetActive(false);
        
        CharModelGenerator.GenerateCharModel(new Color(.3f, .3f, 1, 0), out playertwo, out playertwocollider, out playertworightarm, out playertwoleftarm, out playertworightleg, out playertwoleftleg);
        playertwo.transform.position = new Vector3(LevelGenerator.floorlength/2, 2.25f, LevelGenerator.floorwidth/2 + 2);
        playertwo.transform.eulerAngles = new Vector3(0, -90, 0);
        playertwo.AddComponent<Rigidbody>();
        playertwocontroller = playertwo.AddComponent<PlayerController>();
        playertwocontroller.playernumber = 2;
        playertwo.SetActive(false);
    }
}
