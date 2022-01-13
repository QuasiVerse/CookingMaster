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
    
    public static TextMesh guestonetext;
    public static TextMesh guesttwotext;
    public static TextMesh guestthreetext;
    public static TextMesh guestfourtext;
    public static TextMesh guestfivetext;
    
    public static CapsuleCollider emptycollider;
    public static GameObject emptyrightarm;
    public static GameObject emptyleftarm;
    public static GameObject emptyrightleg;
    public static GameObject emptyleftleg;
    
    public static BoxCollider emptyboxcollider;
    
    public static void GenerateGuest()
    {
        //Generate Guest One
        CharModelGenerator.GenerateCharModel(new Color(.6f, .6f, .6f, 0), out guestone, out emptycollider, out emptyrightarm, out emptyleftarm, out emptyrightleg, out emptyleftleg);
        guestone.transform.position = new Vector3(-1, 2.25f, LevelGenerator.floorwidth/2 - 3);
        guestone.transform.eulerAngles = new Vector3(0, 90, 0);
        Destroy (emptycollider.transform.GetComponent<CapsuleCollider>());
        guestone.SetActive (false);
        GameObject guestonetextobject = new GameObject("Text");
        guestonetextobject.transform.parent = guestone.transform;
        guestonetextobject.transform.localPosition = new Vector3(0, -2, 2.5f);
        guestonetextobject.transform.localEulerAngles = new Vector3(90, 90, -90);
        guestonetextobject.transform.localScale = new Vector3(.5f, .4f, .5f);
        guestonetext = guestonetextobject.AddComponent<TextMesh>();
        guestonetext.alignment = TextAlignment.Center; 
        guestonetext.anchor = TextAnchor.MiddleCenter;
        
        //Generate Guest Two
        CharModelGenerator.GenerateCharModel(new Color(.6f, .6f, .6f, 0), out guesttwo, out emptycollider, out emptyrightarm, out emptyleftarm, out emptyrightleg, out emptyleftleg);
        guesttwo.transform.position = new Vector3(-1, 2.25f, LevelGenerator.floorwidth/2 - 1.5f);
        guesttwo.transform.eulerAngles = new Vector3(0, 90, 0);
        Destroy (emptycollider.transform.GetComponent<CapsuleCollider>());
        guesttwo.SetActive (false);
        GameObject guesttwotextobject = new GameObject("Text");
        guesttwotextobject.transform.parent = guesttwo.transform;
        guesttwotextobject.transform.localPosition = new Vector3(0, -2, 2.5f);
        guesttwotextobject.transform.localEulerAngles = new Vector3(90, 90, -90);
        guesttwotextobject.transform.localScale = new Vector3(.5f, .4f, .5f);
        guesttwotext = guesttwotextobject.AddComponent<TextMesh>();
        guesttwotext.alignment = TextAlignment.Center; 
        guesttwotext.anchor = TextAnchor.MiddleCenter;
        
        //Generate Guest Three
        CharModelGenerator.GenerateCharModel(new Color(.6f, .6f, .6f, 0), out guestthree, out emptycollider, out emptyrightarm, out emptyleftarm, out emptyrightleg, out emptyleftleg);
        guestthree.transform.position = new Vector3(-1, 2.25f, LevelGenerator.floorwidth/2);
        guestthree.transform.eulerAngles = new Vector3(0, 90, 0);
        Destroy (emptycollider.transform.GetComponent<CapsuleCollider>());
        guestthree.SetActive (false);
        GameObject guestthreetextobject = new GameObject("Text");
        guestthreetextobject.transform.parent = guestthree.transform;
        guestthreetextobject.transform.localPosition = new Vector3(0, -2, 2.5f);
        guestthreetextobject.transform.localEulerAngles = new Vector3(90, 90, -90);
        guestthreetextobject.transform.localScale = new Vector3(.5f, .4f, .5f);
        guestthreetext = guestthreetextobject.AddComponent<TextMesh>();
        guestthreetext.alignment = TextAlignment.Center; 
        guestthreetext.anchor = TextAnchor.MiddleCenter;
        
        //Generate Guest Four
        CharModelGenerator.GenerateCharModel(new Color(.6f, .6f, .6f, 0), out guestfour, out emptycollider, out emptyrightarm, out emptyleftarm, out emptyrightleg, out emptyleftleg);
        guestfour.transform.position = new Vector3(-1, 2.25f, LevelGenerator.floorwidth/2 + 1.5f);
        guestfour.transform.eulerAngles = new Vector3(0, 90, 0);
        Destroy (emptycollider.transform.GetComponent<CapsuleCollider>());
        guestfour.SetActive (false);
        GameObject guestfourtextobject = new GameObject("Text");
        guestfourtextobject.transform.parent = guestfour.transform;
        guestfourtextobject.transform.localPosition = new Vector3(0, -2, 2.5f);
        guestfourtextobject.transform.localEulerAngles = new Vector3(90, 90, -90);
        guestfourtextobject.transform.localScale = new Vector3(.5f, .4f, .5f);
        guestfourtext = guestfourtextobject.AddComponent<TextMesh>();
        guestfourtext.alignment = TextAlignment.Center; 
        guestfourtext.anchor = TextAnchor.MiddleCenter;
        
        //Generate Guest Five
        CharModelGenerator.GenerateCharModel(new Color(.6f, .6f, .6f, 0), out guestfive, out emptycollider, out emptyrightarm, out emptyleftarm, out emptyrightleg, out emptyleftleg);
        guestfive.transform.position = new Vector3(-1, 2.25f, LevelGenerator.floorwidth/2 + 3);
        guestfive.transform.eulerAngles = new Vector3(0, 90, 0);
        Destroy (emptycollider.transform.GetComponent<CapsuleCollider>());
        guestfive.SetActive (false);
        GameObject guestfivetextobject = new GameObject("Text");
        guestfivetextobject.transform.parent = guestfive.transform;
        guestfivetextobject.transform.localPosition = new Vector3(0, -2, 2.5f);
        guestfivetextobject.transform.localEulerAngles = new Vector3(90, 90, -90);
        guestfivetextobject.transform.localScale = new Vector3(.5f, .4f, .5f);
        guestfivetext = guestfivetextobject.AddComponent<TextMesh>();
        guestfivetext.alignment = TextAlignment.Center; 
        guestfivetext.anchor = TextAnchor.MiddleCenter;
        
        
    }
}
