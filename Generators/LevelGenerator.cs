using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public static int floorlength = 10;
    public static int floorwidth = 15;
    
    public static Color eggplantcolor;
    public static Color tomatocolor;
    public static Color zuccinicolor;
    public static Color potatocolor;
    public static Color corncolor;
    public static Color lettucecolor;

    public static BoxCollider eggplantcollider;
    public static BoxCollider tomatocollider;
    public static BoxCollider zuccinicollider;
    public static BoxCollider potatocollider;
    public static BoxCollider corncollider;
    public static BoxCollider lettucecollider;
    public static BoxCollider playeronechoppingcollider;
    public static BoxCollider playertwochoppingcollider;
    public static BoxCollider playeroneplatecollider;
    public static BoxCollider playertwoplatecollider;
    public static BoxCollider trashcancollider;
    
    public static BoxCollider guestonecollider;
    public static BoxCollider guesttwocollider;
    public static BoxCollider guestthreecollider;
    public static BoxCollider guestfourcollider;
    public static BoxCollider guestfivecollider;
    
    public static GameObject playeronechoppingeggplantmodel;
    public static GameObject playeronechoppingtomatomodel;
    public static GameObject playeronechoppingzuccinimodel;
    public static GameObject playeronechoppingpotatomodel;
    public static GameObject playeronechoppingcornmodel;
    public static GameObject playeronechoppinglettucemodel;
    
    public static GameObject playertwochoppingeggplantmodel;
    public static GameObject playertwochoppingtomatomodel;
    public static GameObject playertwochoppingzuccinimodel;
    public static GameObject playertwochoppingpotatomodel;
    public static GameObject playertwochoppingcornmodel;
    public static GameObject playertwochoppinglettucemodel;
    
    public static GameObject playeroneplateeggplantmodel;
    public static GameObject playeroneplatetomatomodel;
    public static GameObject playeroneplatezuccinimodel;
    public static GameObject playeroneplatepotatomodel;
    public static GameObject playeroneplatecornmodel;
    public static GameObject playeroneplatelettucemodel;
    
    public static GameObject playertwoplateeggplantmodel;
    public static GameObject playertwoplatetomatomodel;
    public static GameObject playertwoplatezuccinimodel;
    public static GameObject playertwoplatepotatomodel;
    public static GameObject playertwoplatecornmodel;
    public static GameObject playertwoplatelettucemodel;
    
    public static GameObject playeronefirstchoppedmodel;
    public static GameObject playeronesecondchoppedmodel;
    public static GameObject playeronethirdchoppedmodel;

    public static GameObject playertwofirstchoppedmodel;
    public static GameObject playertwosecondchoppedmodel;
    public static GameObject playertwothirdchoppedmodel;
    
    private static Material newmaterial;
    
    public static void GenerateLevel()
    {
        //Generate Vegetable Color
        eggplantcolor = new Color(.6f, .2f, .6f, .5f);
        tomatocolor = new Color(1 ,0, 0, .5f);
        zuccinicolor = new Color(.2f, .4f, .2f, .5f);
        potatocolor = new Color(.8f, .8f, .4f, .5f);
        corncolor = new Color(.9f, .9f, .1f, .5f);
        lettucecolor = new Color(.22f, .5f, .22f, .5f);
        
        
        //Create Floor
        for(int x = 0; x < floorlength; x++)
        {
            for(int y = 0; y < floorwidth; y++)
            {
                GameObject floordesign = GameObject.CreatePrimitive(PrimitiveType.Cube);
                floordesign.AddComponent(typeof(BoxCollider));
                if(x%2 == 0 || y%2 == 1){
                    floordesign.GetComponent<Renderer>().material.color = new Color(.6f, .6f, .6f, 0);
                    floordesign.transform.position = new Vector3(x, 0, y);
                }
                if(x == 0 || x == floorlength - 1|| y == 0 || y == floorwidth - 1){
                    floordesign.GetComponent<Renderer>().material.color = new Color(.4f, .6f, .4f, 0);
                    floordesign.transform.position = new Vector3(x, .75f, y);
                }
                if(x != 0 && x != floorlength - 1 && y != 0 && y != floorwidth - 1){
                    if(x%2 == 0 && y%2 == 1){
                        floordesign.GetComponent<Renderer>().material.color = new Color(.6f, .6f, .6f, 0);
                        floordesign.transform.position = new Vector3(x * 1.05f, 0, y * 1.05f);
                    }
                    if(x%2 == 1 && y%2 == 1){
                        floordesign.GetComponent<Renderer>().material.color = new Color(.8f, .8f, .8f, 0);
                        floordesign.transform.position = new Vector3(x * 1.05f, 0, y * 1.05f);
                    }
                    if(x%2 == 0 && y%2 == 0){
                        floordesign.GetComponent<Renderer>().material.color = new Color(.8f, .8f, .8f, 0);
                        floordesign.transform.position = new Vector3(x * 1.05f, 0, y * 1.05f);
                    }
                    if(x%2 == 1 && y%2 == 0){
                        floordesign.GetComponent<Renderer>().material.color = new Color(.6f, .6f, .6f, 0);
                        floordesign.transform.position = new Vector3(x * 1.05f, 0, y * 1.05f);
                    }
                }
                if(x == 0 && y > 0 && y < floorwidth - 1){
                    floordesign.GetComponent<Renderer>().material.color = new Color(.5f, .5f, .5f, 0);
                    floordesign.transform.position = new Vector3(x, .75f, y);
                }
            }
        }
        GameObject floor = GameObject.CreatePrimitive(PrimitiveType.Plane);
        floor.transform.position = new Vector3(floorlength/2, .55f, floorwidth/2);
        floor.transform.localScale = new Vector3(floorlength * .1f, 1, floorwidth * .1f);
        Destroy (floor.GetComponent<Renderer>());
        
        GameObject grout = GameObject.CreatePrimitive(PrimitiveType.Plane);
        grout.transform.position = new Vector3(floorlength/2, .42f, floorwidth/2);
        grout.transform.GetComponent<Renderer>().material.color = new Color(0f, 0f, 0f, 0);
        grout.transform.localScale = new Vector3(floorlength * .1f, 1, floorwidth * .1f);
        Destroy (grout.GetComponent<MeshCollider>());

        
        //Create Chopping Boards
        GameObject playeronechoppingtable = GameObject.CreatePrimitive(PrimitiveType.Cube);
        playeronechoppingtable.name = "Player One Chopping Table";
        playeronechoppingtable.transform.position = new Vector3(floorlength - 1, 1, floorwidth/2 - 1.5f);
        playeronechoppingtable.transform.localScale = new Vector3(.8f, .8f, 1);
        playeronechoppingtable.GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0);
        playeronechoppingcollider = playeronechoppingtable.transform.GetComponent<BoxCollider>();
        playeronechoppingcollider.center = new Vector3(-.5f, 0, 0);
        playeronechoppingcollider.isTrigger = true;
        
        GameObject playertwochoppingtable = GameObject.CreatePrimitive(PrimitiveType.Cube);
        playertwochoppingtable.name = "Player Two Chopping Table";
        playertwochoppingtable.transform.position = new Vector3(floorlength - 1, 1, floorwidth/2 + 1.5f);
        playertwochoppingtable.transform.localScale = new Vector3(.8f, .8f, 1);
        playertwochoppingtable.GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0);
        playertwochoppingcollider = playertwochoppingtable.transform.GetComponent<BoxCollider>();
        playertwochoppingcollider.center = new Vector3(-.5f, 0, 0);
        playertwochoppingcollider.isTrigger = true;
                
        //Place Player One Chopping Board Models
        playeronechoppingeggplantmodel = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        playeronechoppingeggplantmodel.name = "Eggplant";
        playeronechoppingeggplantmodel.transform.position = new Vector3(floorlength - 1, 1.55f, floorwidth/2 - 1.5f);
        playeronechoppingeggplantmodel.transform.localEulerAngles = new Vector3(0, 90, 90);
        playeronechoppingeggplantmodel.transform.localScale = new Vector3(.3f, .5f, .3f);
        playeronechoppingeggplantmodel.GetComponent<Renderer>().material.color = eggplantcolor;
        
        playeronechoppingtomatomodel = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        playeronechoppingtomatomodel.name = "Tomato";
        playeronechoppingtomatomodel.transform.position = new Vector3(floorlength - 1, 1.55f, floorwidth/2 - 1.5f);
        playeronechoppingtomatomodel.transform.localEulerAngles = new Vector3(0, 0, 0);
        playeronechoppingtomatomodel.transform.localScale = new Vector3(.3f, .3f, .3f);
        playeronechoppingtomatomodel.GetComponent<Renderer>().material.color = tomatocolor;
        
        playeronechoppingzuccinimodel = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        playeronechoppingzuccinimodel.name = "Zuccini";
        playeronechoppingzuccinimodel.transform.position = new Vector3(floorlength - 1, 1.55f, floorwidth/2 - 1.5f);
        playeronechoppingzuccinimodel.transform.localEulerAngles = new Vector3(0, 90, 90);
        playeronechoppingzuccinimodel.transform.localScale = new Vector3(.3f, .5f, .3f);
        playeronechoppingzuccinimodel.GetComponent<Renderer>().material.color = zuccinicolor;

        playeronechoppingpotatomodel = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        playeronechoppingpotatomodel.name = "Potato";
        playeronechoppingpotatomodel.transform.position = new Vector3(floorlength - 1, 1.55f, floorwidth/2 - 1.5f);
        playeronechoppingpotatomodel.transform.localEulerAngles = new Vector3(0, 0, 0);
        playeronechoppingpotatomodel.transform.localScale = new Vector3(.3f, .3f, .3f);
        playeronechoppingpotatomodel.GetComponent<Renderer>().material.color = potatocolor;
        
        playeronechoppingcornmodel = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        playeronechoppingcornmodel.name = "Corn";
        playeronechoppingcornmodel.transform.position = new Vector3(floorlength - 1, 1.55f, floorwidth/2 - 1.5f);
        playeronechoppingcornmodel.transform.localEulerAngles = new Vector3(0, 90, 90);
        playeronechoppingcornmodel.transform.localScale = new Vector3(.3f, .5f, .3f);
        playeronechoppingcornmodel.GetComponent<Renderer>().material.color = corncolor;
        
        playeronechoppinglettucemodel = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        playeronechoppinglettucemodel.name = "Lettuce";
        playeronechoppinglettucemodel.transform.position = new Vector3(floorlength - 1, 1.6f, floorwidth/2 - 1.5f);
        playeronechoppinglettucemodel.transform.localEulerAngles = new Vector3(0, 0, 0);
        playeronechoppinglettucemodel.transform.localScale = new Vector3(.5f, .4f, .5f);
        playeronechoppinglettucemodel.GetComponent<Renderer>().material.color = lettucecolor;
        
        playeronechoppingeggplantmodel.SetActive (false);
        playeronechoppingtomatomodel.SetActive (false);
        playeronechoppingzuccinimodel.SetActive (false);
        playeronechoppingpotatomodel.SetActive (false);
        playeronechoppingcornmodel.SetActive (false);
        playeronechoppinglettucemodel.SetActive (false);
        
        //Place Player Two Chopping Board Models
        playertwochoppingeggplantmodel = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        playertwochoppingeggplantmodel.name = "Eggplant";
        playertwochoppingeggplantmodel.transform.position = new Vector3(floorlength - 1, 1.55f, floorwidth/2 + 1.5f);
        playertwochoppingeggplantmodel.transform.localEulerAngles = new Vector3(0, 90, 90);
        playertwochoppingeggplantmodel.transform.localScale = new Vector3(.3f, .5f, .3f);
        playertwochoppingeggplantmodel.GetComponent<Renderer>().material.color = eggplantcolor;
        
        playertwochoppingtomatomodel = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        playertwochoppingtomatomodel.name = "Tomato";
        playertwochoppingtomatomodel.transform.position = new Vector3(floorlength - 1, 1.55f, floorwidth/2 + 1.5f);
        playertwochoppingtomatomodel.transform.localEulerAngles = new Vector3(0, 0, 0);
        playertwochoppingtomatomodel.transform.localScale = new Vector3(.3f, .3f, .3f);
        playertwochoppingtomatomodel.GetComponent<Renderer>().material.color = tomatocolor;
        
        playertwochoppingzuccinimodel = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        playertwochoppingzuccinimodel.name = "Zuccini";
        playertwochoppingzuccinimodel.transform.position = new Vector3(floorlength - 1, 1.55f, floorwidth/2 + 1.5f);
        playertwochoppingzuccinimodel.transform.localEulerAngles = new Vector3(0, 90, 90);
        playertwochoppingzuccinimodel.transform.localScale = new Vector3(.3f, .5f, .3f);
        playertwochoppingzuccinimodel.GetComponent<Renderer>().material.color = zuccinicolor;

        playertwochoppingpotatomodel = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        playertwochoppingpotatomodel.name = "Potato";
        playertwochoppingpotatomodel.transform.position = new Vector3(floorlength - 1, 1.55f, floorwidth/2 + 1.5f);
        playertwochoppingpotatomodel.transform.localEulerAngles = new Vector3(0, 0, 0);
        playertwochoppingpotatomodel.transform.localScale = new Vector3(.3f, .3f, .3f);
        playertwochoppingpotatomodel.GetComponent<Renderer>().material.color = potatocolor;
        
        playertwochoppingcornmodel = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        playertwochoppingcornmodel.name = "Corn";
        playertwochoppingcornmodel.transform.position = new Vector3(floorlength - 1, 1.55f, floorwidth/2 + 1.5f);
        playertwochoppingcornmodel.transform.localEulerAngles = new Vector3(0, 90, 90);
        playertwochoppingcornmodel.transform.localScale = new Vector3(.3f, .5f, .3f);
        playertwochoppingcornmodel.GetComponent<Renderer>().material.color = corncolor;
        
        playertwochoppinglettucemodel = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        playertwochoppinglettucemodel.name = "Lettuce";
        playertwochoppinglettucemodel.transform.position = new Vector3(floorlength - 1, 1.6f, floorwidth/2 + 1.5f);
        playertwochoppinglettucemodel.transform.localEulerAngles = new Vector3(0, 0, 0);
        playertwochoppinglettucemodel.transform.localScale = new Vector3(.5f, .4f, .5f);
        playertwochoppinglettucemodel.GetComponent<Renderer>().material.color = lettucecolor;
        
        playertwochoppingeggplantmodel.SetActive (false);
        playertwochoppingtomatomodel.SetActive (false);
        playertwochoppingzuccinimodel.SetActive (false);
        playertwochoppingpotatomodel.SetActive (false);
        playertwochoppingcornmodel.SetActive (false);
        playertwochoppinglettucemodel.SetActive (false);
        
        //Place Player One Chopped Models
        playeronefirstchoppedmodel = new GameObject("First");
        playeronefirstchoppedmodel.transform.position = new Vector3(floorlength - 1, 1.46f, floorwidth/2 - 1.5f);
        playeronefirstchoppedmodel.transform.localEulerAngles = new Vector3(90, 145, 0);
        playeronefirstchoppedmodel.transform.localScale = new Vector3(.15f, .15f, .18f);
        TextMesh playeronefirsttextmesh = playeronefirstchoppedmodel.AddComponent<TextMesh>();
        playeronefirsttextmesh.alignment = TextAlignment.Center; 
        playeronefirsttextmesh.anchor = TextAnchor.MiddleCenter;
        playeronefirsttextmesh.text = ".  .  .  ." + "\n" + " .  .  . " + "\n" + ".  .  .  .";
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        playeronefirstchoppedmodel.GetComponent<Renderer>().material = newmaterial;
        
        playeronesecondchoppedmodel = new GameObject("Second");
        playeronesecondchoppedmodel.transform.position = new Vector3(floorlength - 1, 1.46f, floorwidth/2 - 1.5f);
        playeronesecondchoppedmodel.transform.localEulerAngles = new Vector3(90, 90, 0);
        playeronesecondchoppedmodel.transform.localScale = new Vector3(.15f, .15f, .18f);
        TextMesh playeronesecondtextmesh = playeronesecondchoppedmodel.AddComponent<TextMesh>();
        playeronesecondtextmesh.alignment = TextAlignment.Center; 
        playeronesecondtextmesh.anchor = TextAnchor.MiddleCenter;
        playeronesecondtextmesh.text = ".  .  .  ." + "\n" + " .  .  . " + "\n" + ".  .  .  .";
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        playeronesecondchoppedmodel.GetComponent<Renderer>().material = newmaterial;
        
        playeronethirdchoppedmodel = new GameObject("Third");
        playeronethirdchoppedmodel.transform.position = new Vector3(floorlength - 1, 1.46f, floorwidth/2 - 1.5f);
        playeronethirdchoppedmodel.transform.localEulerAngles = new Vector3(90, 45, 0);
        playeronethirdchoppedmodel.transform.localScale = new Vector3(.15f, .15f, .18f);
        TextMesh playeronethirdtextmesh = playeronethirdchoppedmodel.AddComponent<TextMesh>();
        playeronethirdtextmesh.alignment = TextAlignment.Center; 
        playeronethirdtextmesh.anchor = TextAnchor.MiddleCenter;
        playeronethirdtextmesh.text = ".  .  .  ." + "\n" + " .  .  . " + "\n" + ".  .  .  .";
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        playeronethirdchoppedmodel.GetComponent<Renderer>().material = newmaterial;
                
        playeronefirstchoppedmodel.SetActive (false);
        playeronesecondchoppedmodel.SetActive (false);
        playeronethirdchoppedmodel.SetActive (false);

        
        //Place Player Two Chopped Models
        playertwofirstchoppedmodel = new GameObject("First");
        playertwofirstchoppedmodel.transform.position = new Vector3(floorlength - 1, 1.46f, floorwidth/2 + 1.5f);
        playertwofirstchoppedmodel.transform.localEulerAngles = new Vector3(90, 145, 0);
        playertwofirstchoppedmodel.transform.localScale = new Vector3(.15f, .15f, .18f);
        TextMesh playertwofirsttextmesh = playertwofirstchoppedmodel.AddComponent<TextMesh>();
        playertwofirsttextmesh.alignment = TextAlignment.Center; 
        playertwofirsttextmesh.anchor = TextAnchor.MiddleCenter;
        playertwofirsttextmesh.text = ".  .  .  ." + "\n" + " .  .  . " + "\n" + ".  .  .  .";
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        playertwofirstchoppedmodel.GetComponent<Renderer>().material = newmaterial;
        
        playertwosecondchoppedmodel = new GameObject("Second");
        playertwosecondchoppedmodel.transform.position = new Vector3(floorlength - 1, 1.46f, floorwidth/2 + 1.5f);
        playertwosecondchoppedmodel.transform.localEulerAngles = new Vector3(90, 90, 0);
        playertwosecondchoppedmodel.transform.localScale = new Vector3(.15f, .15f, .18f);
        TextMesh playertwosecondtextmesh = playertwosecondchoppedmodel.AddComponent<TextMesh>();
        playertwosecondtextmesh.alignment = TextAlignment.Center; 
        playertwosecondtextmesh.anchor = TextAnchor.MiddleCenter;
        playertwosecondtextmesh.text = ".  .  .  ." + "\n" + " .  .  . " + "\n" + ".  .  .  .";
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        playertwosecondchoppedmodel.GetComponent<Renderer>().material = newmaterial;
        
        playertwothirdchoppedmodel = new GameObject("Third");
        playertwothirdchoppedmodel.transform.position = new Vector3(floorlength - 1, 1.46f, floorwidth/2 + 1.5f);
        playertwothirdchoppedmodel.transform.localEulerAngles = new Vector3(90, 45, 0);
        playertwothirdchoppedmodel.transform.localScale = new Vector3(.15f, .15f, .18f);
        TextMesh playertwothirdtextmesh = playertwothirdchoppedmodel.AddComponent<TextMesh>();
        playertwothirdtextmesh.alignment = TextAlignment.Center; 
        playertwothirdtextmesh.anchor = TextAnchor.MiddleCenter;
        playertwothirdtextmesh.text = ".  .  .  ." + "\n" + " .  .  . " + "\n" + ".  .  .  .";
        newmaterial = new Material(Shader.Find("Legacy Shaders/Transparent/Cutout/Soft Edge Unlit"));
        playertwothirdchoppedmodel.GetComponent<Renderer>().material = newmaterial;

        playertwofirstchoppedmodel.SetActive (false);
        playertwosecondchoppedmodel.SetActive (false);
        playertwothirdchoppedmodel.SetActive (false);
        
        //Create Plates
        GameObject playeroneplate = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        Destroy (playeroneplate.GetComponent<CapsuleCollider>());
        playeroneplate.name = "Player One Plate";
        playeroneplate.transform.position = new Vector3(floorlength - 1, 1.262f, floorwidth/2 - 3);
        playeroneplate.transform.localScale = new Vector3(.7f, .1f, .7f);
        playeroneplate.GetComponent<Renderer>().material.color = new Color(.8f, .8f, .8f, 0);
        playeroneplatecollider = playeroneplate.AddComponent<BoxCollider>();
        playeroneplatecollider.center = new Vector3(-.5f, 0, 0);
        playeroneplatecollider.isTrigger = true;
        
        GameObject playertwoplate = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        Destroy (playertwoplate.GetComponent<CapsuleCollider>());
        playertwoplate.name = "Player Two Plate";
        playertwoplate.transform.position = new Vector3(floorlength - 1, 1.262f, floorwidth/2 + 3);
        playertwoplate.transform.localScale = new Vector3(.7f, .1f, .7f);
        playertwoplate.GetComponent<Renderer>().material.color = new Color(.8f, .8f, .8f, 0);
        playertwoplatecollider = playertwoplate.AddComponent<BoxCollider>();
        playertwoplatecollider.center = new Vector3(-.5f, 0, 0);
        playertwoplatecollider.isTrigger = true;
        
        //Place Player One Plate Models
        playeroneplateeggplantmodel = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        playeroneplateeggplantmodel.name = "Eggplant";
        playeroneplateeggplantmodel.transform.position = new Vector3(floorlength - 1, 1.55f, floorwidth/2 - 3f);
        playeroneplateeggplantmodel.transform.localEulerAngles = new Vector3(0, 90, 90);
        playeroneplateeggplantmodel.transform.localScale = new Vector3(.3f, .5f, .3f);
        playeroneplateeggplantmodel.GetComponent<Renderer>().material.color = eggplantcolor;
        
        playeroneplatetomatomodel = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        playeroneplatetomatomodel.name = "Tomato";
        playeroneplatetomatomodel.transform.position = new Vector3(floorlength - 1, 1.55f, floorwidth/2 - 3f);
        playeroneplatetomatomodel.transform.localEulerAngles = new Vector3(0, 0, 0);
        playeroneplatetomatomodel.transform.localScale = new Vector3(.3f, .3f, .3f);
        playeroneplatetomatomodel.GetComponent<Renderer>().material.color = tomatocolor;
        
        playeroneplatezuccinimodel = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        playeroneplatezuccinimodel.name = "Zuccini";
        playeroneplatezuccinimodel.transform.position = new Vector3(floorlength - 1, 1.55f, floorwidth/2 - 3f);
        playeroneplatezuccinimodel.transform.localEulerAngles = new Vector3(0, 90, 90);
        playeroneplatezuccinimodel.transform.localScale = new Vector3(.3f, .5f, .3f);
        playeroneplatezuccinimodel.GetComponent<Renderer>().material.color = zuccinicolor;

        playeroneplatepotatomodel = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        playeroneplatepotatomodel.name = "Potato";
        playeroneplatepotatomodel.transform.position = new Vector3(floorlength - 1, 1.55f, floorwidth/2 - 3f);
        playeroneplatepotatomodel.transform.localEulerAngles = new Vector3(0, 0, 0);
        playeroneplatepotatomodel.transform.localScale = new Vector3(.3f, .3f, .3f);
        playeroneplatepotatomodel.GetComponent<Renderer>().material.color = potatocolor;
        
        playeroneplatecornmodel = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        playeroneplatecornmodel.name = "Corn";
        playeroneplatecornmodel.transform.position = new Vector3(floorlength - 1, 1.55f, floorwidth/2 - 3f);
        playeroneplatecornmodel.transform.localEulerAngles = new Vector3(0, 90, 90);
        playeroneplatecornmodel.transform.localScale = new Vector3(.3f, .5f, .3f);
        playeroneplatecornmodel.GetComponent<Renderer>().material.color = corncolor;
        
        playeroneplatelettucemodel = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        playeroneplatelettucemodel.name = "Lettuce";
        playeroneplatelettucemodel.transform.position = new Vector3(floorlength - 1, 1.6f, floorwidth/2 - 3f);
        playeroneplatelettucemodel.transform.localEulerAngles = new Vector3(0, 0, 0);
        playeroneplatelettucemodel.transform.localScale = new Vector3(.5f, .4f, .5f);
        playeroneplatelettucemodel.GetComponent<Renderer>().material.color = lettucecolor;
        
        playeroneplateeggplantmodel.SetActive (false);
        playeroneplatetomatomodel.SetActive (false);
        playeroneplatezuccinimodel.SetActive (false);
        playeroneplatepotatomodel.SetActive (false);
        playeroneplatecornmodel.SetActive (false);
        playeroneplatelettucemodel.SetActive (false);
        
        //Place Player Two Plate Models
        playertwoplateeggplantmodel = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        playertwoplateeggplantmodel.name = "Eggplant";
        playertwoplateeggplantmodel.transform.position = new Vector3(floorlength - 1, 1.55f, floorwidth/2 + 3f);
        playertwoplateeggplantmodel.transform.localEulerAngles = new Vector3(0, 90, 90);
        playertwoplateeggplantmodel.transform.localScale = new Vector3(.3f, .5f, .3f);
        playertwoplateeggplantmodel.GetComponent<Renderer>().material.color = eggplantcolor;
        
        playertwoplatetomatomodel = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        playertwoplatetomatomodel.name = "Tomato";
        playertwoplatetomatomodel.transform.position = new Vector3(floorlength - 1, 1.55f, floorwidth/2 + 3f);
        playertwoplatetomatomodel.transform.localEulerAngles = new Vector3(0, 0, 0);
        playertwoplatetomatomodel.transform.localScale = new Vector3(.3f, .3f, .3f);
        playertwoplatetomatomodel.GetComponent<Renderer>().material.color = tomatocolor;
        
        playertwoplatezuccinimodel = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        playertwoplatezuccinimodel.name = "Zuccini";
        playertwoplatezuccinimodel.transform.position = new Vector3(floorlength - 1, 1.55f, floorwidth/2 + 3f);
        playertwoplatezuccinimodel.transform.localEulerAngles = new Vector3(0, 90, 90);
        playertwoplatezuccinimodel.transform.localScale = new Vector3(.3f, .5f, .3f);
        playertwoplatezuccinimodel.GetComponent<Renderer>().material.color = zuccinicolor;

        playertwoplatepotatomodel = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        playertwoplatepotatomodel.name = "Potato";
        playertwoplatepotatomodel.transform.position = new Vector3(floorlength - 1, 1.55f, floorwidth/2 + 3f);
        playertwoplatepotatomodel.transform.localEulerAngles = new Vector3(0, 0, 0);
        playertwoplatepotatomodel.transform.localScale = new Vector3(.3f, .3f, .3f);
        playertwoplatepotatomodel.GetComponent<Renderer>().material.color = potatocolor;
        
        playertwoplatecornmodel = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        playertwoplatecornmodel.name = "Corn";
        playertwoplatecornmodel.transform.position = new Vector3(floorlength - 1, 1.55f, floorwidth/2 + 3f);
        playertwoplatecornmodel.transform.localEulerAngles = new Vector3(0, 90, 90);
        playertwoplatecornmodel.transform.localScale = new Vector3(.3f, .5f, .3f);
        playertwoplatecornmodel.GetComponent<Renderer>().material.color = corncolor;
        
        playertwoplatelettucemodel = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        playertwoplatelettucemodel.name = "Lettuce";
        playertwoplatelettucemodel.transform.position = new Vector3(floorlength - 1, 1.6f, floorwidth/2 + 3f);
        playertwoplatelettucemodel.transform.localEulerAngles = new Vector3(0, 0, 0);
        playertwoplatelettucemodel.transform.localScale = new Vector3(.5f, .4f, .5f);
        playertwoplatelettucemodel.GetComponent<Renderer>().material.color = lettucecolor;
        
        playertwoplateeggplantmodel.SetActive (false);
        playertwoplatetomatomodel.SetActive (false);
        playertwoplatezuccinimodel.SetActive (false);
        playertwoplatepotatomodel.SetActive (false);
        playertwoplatecornmodel.SetActive (false);
        playertwoplatelettucemodel.SetActive (false);
    
        //Create Trash Can
        GameObject trashcan = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        Destroy (trashcan.GetComponent<CapsuleCollider>());
        trashcan.name = "Trash Can";
        trashcan.transform.position = new Vector3(floorlength - 1, 1.3f, floorwidth/2);
        trashcan.transform.localScale = new Vector3(.8f, .1f, .8f);
        trashcan.GetComponent<Renderer>().material.color = new Color(.6f, .6f, .9f, 0);
        trashcancollider = trashcan.AddComponent<BoxCollider>();
        trashcancollider.center = new Vector3(-.5f, 0, 0);
        trashcancollider.isTrigger = true;
        
        //Create Guest Tables
        GameObject guestonetable = GameObject.CreatePrimitive(PrimitiveType.Cube);
        guestonetable.name = "Guest One";
        guestonetable.transform.position = new Vector3(0, 1, floorwidth/2 - 3);
        guestonetable.transform.localScale = new Vector3(.8f, .8f, 1);
        guestonetable.GetComponent<Renderer>().material.color = new Color(.6f, .6f, .6f, 0);
        guestonecollider = guestonetable.transform.GetComponent<BoxCollider>();
        guestonecollider.center = new Vector3(.5f, 0, 0);
        guestonecollider.isTrigger = true;
        
        GameObject guesttwotable = GameObject.CreatePrimitive(PrimitiveType.Cube);
        guesttwotable.name = "Guest Two";
        guesttwotable.transform.position = new Vector3(0, 1, floorwidth/2 - 1.5f);
        guesttwotable.transform.localScale = new Vector3(.8f, .8f, 1);
        guesttwotable.GetComponent<Renderer>().material.color = new Color(.6f, .6f, .6f, 0);
        guesttwocollider = guesttwotable.transform.GetComponent<BoxCollider>();
        guesttwocollider.center = new Vector3(.5f, 0, 0);
        guesttwocollider.isTrigger = true;
        
        GameObject guestthreetable = GameObject.CreatePrimitive(PrimitiveType.Cube);
        guestthreetable.name = "Guest Three";
        guestthreetable.transform.position = new Vector3(0, 1, floorwidth/2);
        guestthreetable.transform.localScale = new Vector3(.8f, .8f, 1);
        guestthreetable.GetComponent<Renderer>().material.color = new Color(.6f, .6f, .6f, 0);
        guestthreecollider = guestthreetable.transform.GetComponent<BoxCollider>();
        guestthreecollider.center = new Vector3(.5f, 0, 0);
        guestthreecollider.isTrigger = true;
        
        GameObject guestfourtable = GameObject.CreatePrimitive(PrimitiveType.Cube);
        guestfourtable.name = "Guest Four";
        guestfourtable.transform.position = new Vector3(0, 1, floorwidth/2 + 1.5f);
        guestfourtable.transform.localScale = new Vector3(.8f, .8f, 1);
        guestfourtable.GetComponent<Renderer>().material.color = new Color(.6f, .6f, .6f, 0);
        guestfourcollider = guestfourtable.transform.GetComponent<BoxCollider>();
        guestfourcollider.center = new Vector3(.5f, 0, 0);
        guestfourcollider.isTrigger = true;
        
        GameObject guestfivetable = GameObject.CreatePrimitive(PrimitiveType.Cube);
        guestfivetable.name = "Guest Five";
        guestfivetable.transform.position = new Vector3(0, 1, floorwidth/2 + 3);
        guestfivetable.transform.localScale = new Vector3(.8f, .8f, 1);
        guestfivetable.GetComponent<Renderer>().material.color = new Color(.6f, .6f, .6f, 0);
        guestfivecollider = guestfivetable.transform.GetComponent<BoxCollider>();
        guestfivecollider.center = new Vector3(.5f, 0, 0);
        guestfivecollider.isTrigger = true;
        
        //Create Vegetable Tables
        GameObject eggplanttable = GameObject.CreatePrimitive(PrimitiveType.Cube);
        eggplanttable.name = "Eggplant";
        eggplanttable.transform.position = new Vector3(floorlength/2 - 2, 1, floorwidth - 1);
        eggplanttable.transform.localScale = new Vector3(1, .8f, .8f);
        eggplanttable.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 0);
        eggplantcollider = eggplanttable.transform.GetComponent<BoxCollider>();
        eggplantcollider.center = new Vector3(0, 0, -.5f);
        eggplantcollider.isTrigger = true;

        GameObject tomatotable = GameObject.CreatePrimitive(PrimitiveType.Cube);
        tomatotable.name = "Tomato";
        tomatotable.transform.position = new Vector3(floorlength/2, 1, floorwidth - 1);
        tomatotable.transform.localScale = new Vector3(1, .8f, .8f);
        tomatotable.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 0);
        tomatocollider = tomatotable.transform.GetComponent<BoxCollider>();
        tomatocollider.center = new Vector3(0, 0, -.5f);
        tomatocollider.isTrigger = true;
        
        GameObject zuccinitable = GameObject.CreatePrimitive(PrimitiveType.Cube);
        zuccinitable.name = "Zuccini";
        zuccinitable.transform.position = new Vector3(floorlength/2 + 2, 1, floorwidth - 1);
        zuccinitable.transform.localScale = new Vector3(1, .8f, .8f);
        zuccinitable.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 0);
        zuccinicollider = zuccinitable.transform.GetComponent<BoxCollider>();
        zuccinicollider.center = new Vector3(0, 0, -.5f);
        zuccinicollider.isTrigger = true;
        
        GameObject potatotable = GameObject.CreatePrimitive(PrimitiveType.Cube);
        potatotable.name = "Potato";
        potatotable.transform.position = new Vector3(floorlength/2 - 2, 1, 0);
        potatotable.transform.localScale = new Vector3(1, .8f, .8f);
        potatotable.GetComponent<Renderer>().material.color = new Color(0, 0, 1, 0);
        potatocollider = potatotable.transform.GetComponent<BoxCollider>();
        potatocollider.center = new Vector3(0, 0, .5f);
        potatocollider.isTrigger = true;
        
        GameObject corntable = GameObject.CreatePrimitive(PrimitiveType.Cube);
        corntable.name = "Corn";
        corntable.transform.position = new Vector3(floorlength/2, 1, 0);
        corntable.transform.localScale = new Vector3(1, .8f, .8f);
        corntable.GetComponent<Renderer>().material.color = new Color(0, 0, 1, 0);
        corncollider = corntable.transform.GetComponent<BoxCollider>();
        corncollider.center = new Vector3(0, 0, .5f);
        corncollider.isTrigger = true;
        
        GameObject lettucetable = GameObject.CreatePrimitive(PrimitiveType.Cube);
        lettucetable.name = "Lettuce";
        lettucetable.transform.position = new Vector3(floorlength/2 + 2, 1, 0);
        lettucetable.transform.localScale = new Vector3(1, .8f, .8f);
        lettucetable.GetComponent<Renderer>().material.color = new Color(0, 0, 1, 0);
        lettucecollider = lettucetable.transform.GetComponent<BoxCollider>();
        lettucecollider.center = new Vector3(0, 0, .5f);
        lettucecollider.isTrigger = true;
        
        //Place Tables
        GameObject eggplanttablemodel = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        eggplanttablemodel.transform.position = new Vector3(floorlength/2 - 2, 1.55f, floorwidth - 1);
        eggplanttablemodel.transform.localEulerAngles = new Vector3(0, 25, 90);
        eggplanttablemodel.transform.localScale = new Vector3(.3f, .5f, .3f);
        eggplanttablemodel.GetComponent<Renderer>().material.color = eggplantcolor;
        
        GameObject tomatotablemodel = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        tomatotablemodel.transform.position = new Vector3(floorlength/2, 1.55f, floorwidth - 1);
        tomatotablemodel.transform.localEulerAngles = new Vector3(0, 0, 0);
        tomatotablemodel.transform.localScale = new Vector3(.3f, .3f, .3f);
        tomatotablemodel.GetComponent<Renderer>().material.color = tomatocolor;
        
        GameObject zuccinitablemodel = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        zuccinitablemodel.transform.position = new Vector3(floorlength/2 + 2, 1.55f, floorwidth - 1);
        zuccinitablemodel.transform.localEulerAngles = new Vector3(0, 25, 90);
        zuccinitablemodel.transform.localScale = new Vector3(.3f, .5f, .3f);
        zuccinitablemodel.GetComponent<Renderer>().material.color = zuccinicolor;

        GameObject potatotablemodel = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        potatotablemodel.transform.position = new Vector3(floorlength/2 - 2, 1.55f, 0);
        potatotablemodel.transform.localEulerAngles = new Vector3(0, 0, 0);
        potatotablemodel.transform.localScale = new Vector3(.3f, .3f, .3f);
        potatotablemodel.GetComponent<Renderer>().material.color = potatocolor;
        
        GameObject corntablemodel = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        corntablemodel.transform.position = new Vector3(floorlength/2, 1.55f, 0);
        corntablemodel.transform.localEulerAngles = new Vector3(0, 25, 90);
        corntablemodel.transform.localScale = new Vector3(.3f, .5f, .3f);
        corntablemodel.GetComponent<Renderer>().material.color = corncolor;
        
        GameObject lettucetablemodel = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        lettucetablemodel.transform.position = new Vector3(floorlength/2 + 2, 1.6f, 0);
        lettucetablemodel.transform.localEulerAngles = new Vector3(0, 0, 0);
        lettucetablemodel.transform.localScale = new Vector3(.5f, .4f, .5f);
        lettucetablemodel.GetComponent<Renderer>().material.color = lettucecolor;
        
    }
}
