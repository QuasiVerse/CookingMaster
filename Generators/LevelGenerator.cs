using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public static int floorlength = 10;
    public static int floorwidth = 15;
    
    public static BoxCollider eggplantcollider;
    public static BoxCollider potatocollider;
    public static BoxCollider zuccinicollider;
    public static BoxCollider tomatocollider;
    public static BoxCollider corncollider;
    public static BoxCollider lettucecollider;
    public static BoxCollider leftchoppingcollider;
    public static BoxCollider rightchoppingcollider;
    
    public static BoxCollider guestonecollider;
    public static BoxCollider guesttwocollider;
    public static BoxCollider guestthreecollider;
    public static BoxCollider guestfourcollider;
    public static BoxCollider guestfivecollider;
    
    public static GameObject lefteggplantmodel;
    public static GameObject leftpotatomodel;
    public static GameObject leftzuccinimodel;
    public static GameObject lefttomatomodel;
    public static GameObject leftcornmodel;
    public static GameObject leftlettucemodel;
    
    public static GameObject righteggplantmodel;
    public static GameObject rightpotatomodel;
    public static GameObject rightzuccinimodel;
    public static GameObject righttomatomodel;
    public static GameObject rightcornmodel;
    public static GameObject rightlettucemodel;

    
    public static void GenerateLevel()
    {
        //Create Floor
        for(int x = 0; x < floorlength; x++)
        {
            for(int y = 0; y < floorwidth; y++)
            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.AddComponent(typeof(BoxCollider));
                if(x == 0 || x == floorlength - 1|| y == 0 || y == floorwidth - 1){
                    cube.GetComponent<Renderer>().material.color = new Color(.4f, .6f, .4f, 0);
                    cube.transform.position = new Vector3(x, .75f, y);
                }
                if(x != 0 && x != floorlength - 1 && y != 0 && y != floorwidth - 1){
                    cube.GetComponent<Renderer>().material.color = new Color(.8f, .8f, .8f, 0);
                    cube.transform.position = new Vector3(x, 0, y);
                }
                if(x == 0 && y > 0 && y < floorwidth - 1){
                    cube.GetComponent<Renderer>().material.color = new Color(.5f, .5f, .5f, 0);
                    cube.transform.position = new Vector3(x, .75f, y);
                }
            }
        }
        
        //Create Chopping Boards
        GameObject rightchoppingtable = GameObject.CreatePrimitive(PrimitiveType.Cube);
        rightchoppingtable.transform.position = new Vector3(floorlength - 1, 1, floorwidth/2 + 2);
        rightchoppingtable.transform.localScale = new Vector3(.8f, .8f, 1);
        rightchoppingtable.GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0);
        rightchoppingcollider = rightchoppingtable.transform.GetComponent<BoxCollider>();
        rightchoppingcollider.center = new Vector3(-.5f, 0, 0);
        rightchoppingcollider.isTrigger = true;
        
        GameObject leftchoppingtable = GameObject.CreatePrimitive(PrimitiveType.Cube);
        leftchoppingtable.transform.position = new Vector3(floorlength - 1, 1, floorwidth/2 - 2);
        leftchoppingtable.transform.localScale = new Vector3(.8f, .8f, 1);
        leftchoppingtable.GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0);
        leftchoppingcollider = leftchoppingtable.transform.GetComponent<BoxCollider>();
        leftchoppingcollider.center = new Vector3(-.5f, 0, 0);
        leftchoppingcollider.isTrigger = true;
        
        //Place Right Chopping Board Models
        righteggplantmodel = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        righteggplantmodel.transform.position = new Vector3(floorlength - 1, 1.55f, floorwidth/2 + 2);
        righteggplantmodel.transform.eulerAngles = new Vector3(0, 90, 90);
        righteggplantmodel.transform.localScale = new Vector3(.3f, .5f, .3f);
        righteggplantmodel.GetComponent<Renderer>().material.color = new Color(.6f, .2f, .6f, 0);
        
        righttomatomodel = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        righttomatomodel.transform.position = new Vector3(floorlength - 1, 1.55f, floorwidth/2 + 2);
        righttomatomodel.transform.eulerAngles = new Vector3(0, 0, 0);
        righttomatomodel.transform.localScale = new Vector3(.3f, .3f, .3f);
        righttomatomodel.GetComponent<Renderer>().material.color = new Color(1 ,0, 0, 0);
        
        rightzuccinimodel = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        rightzuccinimodel.transform.position = new Vector3(floorlength - 1, 1.55f, floorwidth/2 + 2);
        rightzuccinimodel.transform.eulerAngles = new Vector3(0, 90, 90);
        rightzuccinimodel.transform.localScale = new Vector3(.3f, .5f, .3f);
        rightzuccinimodel.GetComponent<Renderer>().material.color = new Color(.2f, .4f, .2f, 0);

        rightpotatomodel = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        rightpotatomodel.transform.position = new Vector3(floorlength - 1, 1.55f, floorwidth/2 + 2);
        rightpotatomodel.transform.eulerAngles = new Vector3(0, 0, 0);
        rightpotatomodel.transform.localScale = new Vector3(.3f, .3f, .3f);
        rightpotatomodel.GetComponent<Renderer>().material.color = new Color(.8f, .8f, .4f, 0);
        
        rightcornmodel = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        rightcornmodel.transform.position = new Vector3(floorlength - 1, 1.55f, floorwidth/2 + 2);
        rightcornmodel.transform.eulerAngles = new Vector3(0, 90, 90);
        rightcornmodel.transform.localScale = new Vector3(.3f, .5f, .3f);
        rightcornmodel.GetComponent<Renderer>().material.color = new Color(.9f, .9f, .1f, 0);
        
        rightlettucemodel = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        rightlettucemodel.transform.position = new Vector3(floorlength - 1, 1.6f, floorwidth/2 + 2);
        rightlettucemodel.transform.eulerAngles = new Vector3(0, 0, 0);
        rightlettucemodel.transform.localScale = new Vector3(.5f, .4f, .5f);
        rightlettucemodel.GetComponent<Renderer>().material.color = new Color(.22f, .5f, .22f, 0);
        
        righteggplantmodel.SetActive (false);
        righttomatomodel.SetActive (false);
        rightzuccinimodel.SetActive (false);
        rightpotatomodel.SetActive (false);
        rightcornmodel.SetActive (false);
        rightlettucemodel.SetActive (false);
        
        //Place Left Chopping Board Models
        lefteggplantmodel = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        lefteggplantmodel.transform.position = new Vector3(floorlength - 1, 1.55f, floorwidth/2 - 2);
        lefteggplantmodel.transform.eulerAngles = new Vector3(0, 90, 90);
        lefteggplantmodel.transform.localScale = new Vector3(.3f, .5f, .3f);
        lefteggplantmodel.GetComponent<Renderer>().material.color = new Color(.6f, .2f, .6f, 0);
        
        lefttomatomodel = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        lefttomatomodel.transform.position = new Vector3(floorlength - 1, 1.55f, floorwidth/2 - 2);
        lefttomatomodel.transform.eulerAngles = new Vector3(0, 0, 0);
        lefttomatomodel.transform.localScale = new Vector3(.3f, .3f, .3f);
        lefttomatomodel.GetComponent<Renderer>().material.color = new Color(1 ,0, 0, 0);
        
        leftzuccinimodel = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        leftzuccinimodel.transform.position = new Vector3(floorlength - 1, 1.55f, floorwidth/2 - 2);
        leftzuccinimodel.transform.eulerAngles = new Vector3(0, 90, 90);
        leftzuccinimodel.transform.localScale = new Vector3(.3f, .5f, .3f);
        leftzuccinimodel.GetComponent<Renderer>().material.color = new Color(.2f, .4f, .2f, 0);

        leftpotatomodel = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        leftpotatomodel.transform.position = new Vector3(floorlength - 1, 1.55f, floorwidth/2 - 2);
        leftpotatomodel.transform.eulerAngles = new Vector3(0, 0, 0);
        leftpotatomodel.transform.localScale = new Vector3(.3f, .3f, .3f);
        leftpotatomodel.GetComponent<Renderer>().material.color = new Color(.8f, .8f, .4f, 0);
        
        leftcornmodel = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        leftcornmodel.transform.position = new Vector3(floorlength - 1, 1.55f, floorwidth/2 - 2);
        leftcornmodel.transform.eulerAngles = new Vector3(0, 90, 90);
        leftcornmodel.transform.localScale = new Vector3(.3f, .5f, .3f);
        leftcornmodel.GetComponent<Renderer>().material.color = new Color(.9f, .9f, .1f, 0);
        
        leftlettucemodel = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        leftlettucemodel.transform.position = new Vector3(floorlength - 1, 1.6f, floorwidth/2 - 2);
        leftlettucemodel.transform.eulerAngles = new Vector3(0, 0, 0);
        leftlettucemodel.transform.localScale = new Vector3(.5f, .4f, .5f);
        leftlettucemodel.GetComponent<Renderer>().material.color = new Color(.22f, .5f, .22f, 0);
        
        lefteggplantmodel.SetActive (false);
        lefttomatomodel.SetActive (false);
        leftzuccinimodel.SetActive (false);
        leftpotatomodel.SetActive (false);
        leftcornmodel.SetActive (false);
        leftlettucemodel.SetActive (false);
        
        //Create Guest Tables
        GameObject guestonetable = GameObject.CreatePrimitive(PrimitiveType.Cube);
        guestonetable.transform.position = new Vector3(0, 1, floorwidth/2 - 3);
        guestonetable.transform.localScale = new Vector3(.8f, .8f, 1);
        guestonetable.GetComponent<Renderer>().material.color = new Color(.6f, .6f, .6f, 0);
        guestonecollider = guestonetable.transform.GetComponent<BoxCollider>();
        guestonecollider.center = new Vector3(.5f, 0, 0);
        guestonecollider.isTrigger = true;
        
        GameObject guesttwotable = GameObject.CreatePrimitive(PrimitiveType.Cube);
        guesttwotable.transform.position = new Vector3(0, 1, floorwidth/2 - 1.5f);
        guesttwotable.transform.localScale = new Vector3(.8f, .8f, 1);
        guesttwotable.GetComponent<Renderer>().material.color = new Color(.6f, .6f, .6f, 0);
        guesttwocollider = guesttwotable.transform.GetComponent<BoxCollider>();
        guesttwocollider.center = new Vector3(.5f, 0, 0);
        guesttwocollider.isTrigger = true;
        
        GameObject guestthreetable = GameObject.CreatePrimitive(PrimitiveType.Cube);
        guestthreetable.transform.position = new Vector3(0, 1, floorwidth/2);
        guestthreetable.transform.localScale = new Vector3(.8f, .8f, 1);
        guestthreetable.GetComponent<Renderer>().material.color = new Color(.6f, .6f, .6f, 0);
        guestthreecollider = guestthreetable.transform.GetComponent<BoxCollider>();
        guestthreecollider.center = new Vector3(.5f, 0, 0);
        guestthreecollider.isTrigger = true;
        
        GameObject guestfourtable = GameObject.CreatePrimitive(PrimitiveType.Cube);
        guestfourtable.transform.position = new Vector3(0, 1, floorwidth/2 + 1.5f);
        guestfourtable.transform.localScale = new Vector3(.8f, .8f, 1);
        guestfourtable.GetComponent<Renderer>().material.color = new Color(.6f, .6f, .6f, 0);
        guestfourcollider = guestfourtable.transform.GetComponent<BoxCollider>();
        guestfourcollider.center = new Vector3(.5f, 0, 0);
        guestfourcollider.isTrigger = true;
        
        GameObject guestfivetable = GameObject.CreatePrimitive(PrimitiveType.Cube);
        guestfivetable.transform.position = new Vector3(0, 1, floorwidth/2 + 3);
        guestfivetable.transform.localScale = new Vector3(.8f, .8f, 1);
        guestfivetable.GetComponent<Renderer>().material.color = new Color(.6f, .6f, .6f, 0);
        guestfivecollider = guestfivetable.transform.GetComponent<BoxCollider>();
        guestfivecollider.center = new Vector3(.5f, 0, 0);
        guestfivecollider.isTrigger = true;
        
        //Create Vegetable Tables
        GameObject eggplanttable = GameObject.CreatePrimitive(PrimitiveType.Cube);
        eggplanttable.transform.position = new Vector3(floorlength/2 - 2, 1, floorwidth - 1);
        eggplanttable.transform.localScale = new Vector3(1, .8f, .8f);
        eggplanttable.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 0);
        eggplantcollider = eggplanttable.transform.GetComponent<BoxCollider>();
        eggplantcollider.center = new Vector3(0, 0, -.5f);
        eggplantcollider.isTrigger = true;
        
        GameObject potatotable = GameObject.CreatePrimitive(PrimitiveType.Cube);
        potatotable.transform.position = new Vector3(floorlength/2, 1, floorwidth - 1);
        potatotable.transform.localScale = new Vector3(1, .8f, .8f);
        potatotable.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 0);
        potatocollider = potatotable.transform.GetComponent<BoxCollider>();
        potatocollider.center = new Vector3(0, 0, -.5f);
        potatocollider.isTrigger = true;
        
        GameObject zuccinitable = GameObject.CreatePrimitive(PrimitiveType.Cube);
        zuccinitable.transform.position = new Vector3(floorlength/2 + 2, 1, floorwidth - 1);
        zuccinitable.transform.localScale = new Vector3(1, .8f, .8f);
        zuccinitable.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 0);
        zuccinicollider = zuccinitable.transform.GetComponent<BoxCollider>();
        zuccinicollider.center = new Vector3(0, 0, -.5f);
        zuccinicollider.isTrigger = true;
        
        GameObject tomatotable = GameObject.CreatePrimitive(PrimitiveType.Cube);
        tomatotable.transform.position = new Vector3(floorlength/2 - 2, 1, 0);
        tomatotable.transform.localScale = new Vector3(1, .8f, .8f);
        tomatotable.GetComponent<Renderer>().material.color = new Color(0, 0, 1, 0);
        tomatocollider = tomatotable.transform.GetComponent<BoxCollider>();
        tomatocollider.center = new Vector3(0, 0, .5f);
        tomatocollider.isTrigger = true;
        
        GameObject corntable = GameObject.CreatePrimitive(PrimitiveType.Cube);
        corntable.transform.position = new Vector3(floorlength/2, 1, 0);
        corntable.transform.localScale = new Vector3(1, .8f, .8f);
        corntable.GetComponent<Renderer>().material.color = new Color(0, 0, 1, 0);
        corncollider = corntable.transform.GetComponent<BoxCollider>();
        corncollider.center = new Vector3(0, 0, .5f);
        corncollider.isTrigger = true;
        
        GameObject lettucetable = GameObject.CreatePrimitive(PrimitiveType.Cube);
        lettucetable.transform.position = new Vector3(floorlength/2 + 2, 1, 0);
        lettucetable.transform.localScale = new Vector3(1, .8f, .8f);
        lettucetable.GetComponent<Renderer>().material.color = new Color(0, 0, 1, 0);
        lettucecollider = lettucetable.transform.GetComponent<BoxCollider>();
        lettucecollider.center = new Vector3(0, 0, .5f);
        lettucecollider.isTrigger = true;
        
        //Place Tables
        GameObject eggplanttablemodel = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        eggplanttablemodel.transform.position = new Vector3(floorlength/2 - 2, 1.55f, floorwidth - 1);
        eggplanttablemodel.transform.eulerAngles = new Vector3(0, 25, 90);
        eggplanttablemodel.transform.localScale = new Vector3(.3f, .5f, .3f);
        eggplanttablemodel.GetComponent<Renderer>().material.color = new Color(.6f, .2f, .6f, 0);
        
        GameObject tomatotablemodel = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        tomatotablemodel.transform.position = new Vector3(floorlength/2, 1.55f, floorwidth - 1);
        tomatotablemodel.transform.eulerAngles = new Vector3(0, 0, 0);
        tomatotablemodel.transform.localScale = new Vector3(.3f, .3f, .3f);
        tomatotablemodel.GetComponent<Renderer>().material.color = new Color(1 ,0, 0, 0);
        
        GameObject zuccinitablemodel = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        zuccinitablemodel.transform.position = new Vector3(floorlength/2 + 2, 1.55f, floorwidth - 1);
        zuccinitablemodel.transform.eulerAngles = new Vector3(0, 25, 90);
        zuccinitablemodel.transform.localScale = new Vector3(.3f, .5f, .3f);
        zuccinitablemodel.GetComponent<Renderer>().material.color = new Color(.2f, .4f, .2f, 0);

        GameObject potatotablemodel = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        potatotablemodel.transform.position = new Vector3(floorlength/2 - 2, 1.55f, 0);
        potatotablemodel.transform.eulerAngles = new Vector3(0, 0, 0);
        potatotablemodel.transform.localScale = new Vector3(.3f, .3f, .3f);
        potatotablemodel.GetComponent<Renderer>().material.color = new Color(.8f, .8f, .4f, 0);
        
        GameObject corntablemodel = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        corntablemodel.transform.position = new Vector3(floorlength/2, 1.55f, 0);
        corntablemodel.transform.eulerAngles = new Vector3(0, 25, 90);
        corntablemodel.transform.localScale = new Vector3(.3f, .5f, .3f);
        corntablemodel.GetComponent<Renderer>().material.color = new Color(.9f, .9f, .1f, 0);
        
        GameObject lettucetablemodel = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        lettucetablemodel.transform.position = new Vector3(floorlength/2 + 2, 1.6f, 0);
        lettucetablemodel.transform.eulerAngles = new Vector3(0, 0, 0);
        lettucetablemodel.transform.localScale = new Vector3(.5f, .4f, .5f);
        lettucetablemodel.GetComponent<Renderer>().material.color = new Color(.22f, .5f, .22f, 0);
        
    }
}
