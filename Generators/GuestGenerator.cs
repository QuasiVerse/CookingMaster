using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestGenerator : MonoBehaviour
{

    public static GameObject guestone;
    public static GameObject guesttwo;
    public static GameObject guestthree;
    public static GameObject guestfour;
    public static GameObject guestfive;
    
    public static CapsuleCollider emptycollider;
    public static GameObject emptyrightarm;
    public static GameObject emptyleftarm;
    public static GameObject emptyrightleg;
    public static GameObject emptyleftleg;
    
    public static BoxCollider emptyboxcollider;
    
    public static void GenerateGuest()
    {
        CharModelGenerator.GenerateCharModel(new Color(.6f, .6f, .6f, 0), out guestone, out emptycollider, out emptyrightarm, out emptyleftarm, out emptyrightleg, out emptyleftleg);
        guestone.transform.position = new Vector3(-1, 2.25f, LevelGenerator.floorwidth/2 - 3);
        guestone.transform.eulerAngles = new Vector3(0, 90, 0);
        Destroy (emptycollider.transform.GetComponent<CapsuleCollider>());
        guestone.SetActive (false);
        
        CharModelGenerator.GenerateCharModel(new Color(.6f, .6f, .6f, 0), out guesttwo, out emptycollider, out emptyrightarm, out emptyleftarm, out emptyrightleg, out emptyleftleg);
        guesttwo.transform.position = new Vector3(-1, 2.25f, LevelGenerator.floorwidth/2 - 1.5f);
        guesttwo.transform.eulerAngles = new Vector3(0, 90, 0);
        Destroy (emptycollider.transform.GetComponent<CapsuleCollider>());
        guesttwo.SetActive (false);
        
        CharModelGenerator.GenerateCharModel(new Color(.6f, .6f, .6f, 0), out guestthree, out emptycollider, out emptyrightarm, out emptyleftarm, out emptyrightleg, out emptyleftleg);
        guestthree.transform.position = new Vector3(-1, 2.25f, LevelGenerator.floorwidth/2);
        guestthree.transform.eulerAngles = new Vector3(0, 90, 0);
        Destroy (emptycollider.transform.GetComponent<CapsuleCollider>());
        guestthree.SetActive (false);
        
        CharModelGenerator.GenerateCharModel(new Color(.6f, .6f, .6f, 0), out guestfour, out emptycollider, out emptyrightarm, out emptyleftarm, out emptyrightleg, out emptyleftleg);
        guestfour.transform.position = new Vector3(-1, 2.25f, LevelGenerator.floorwidth/2 + 1.5f);
        guestfour.transform.eulerAngles = new Vector3(0, 90, 0);
        Destroy (emptycollider.transform.GetComponent<CapsuleCollider>());
        guestfour.SetActive (false);
        
        CharModelGenerator.GenerateCharModel(new Color(.6f, .6f, .6f, 0), out guestfive, out emptycollider, out emptyrightarm, out emptyleftarm, out emptyrightleg, out emptyleftleg);
        guestfive.transform.position = new Vector3(-1, 2.25f, LevelGenerator.floorwidth/2 + 3);
        guestfive.transform.eulerAngles = new Vector3(0, 90, 0);
        Destroy (emptycollider.transform.GetComponent<CapsuleCollider>());
        guestfive.SetActive (false);
        
        
    }
}
