using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingManager : MonoBehaviour
{
    
    private Canvas managercanvas;
    private GenerateHUD canvasgenerator;
    void Start()
    {
        //Procedurally Generate Scene
        LevelGenerator.GenerateLevel();
        PlayerGenerator.GeneratePlayer();
        GuestGenerator.GenerateGuest();
        
        //Initialize Lights
        this.gameObject.AddComponent<CameraController>();
        GameObject light = GameObject.Find("Directional Light");
        light.transform.GetComponent<Light>().type = LightType.Point;
        light.transform.GetComponent<Light>().range = 200;
        light.transform.position = new Vector3(LevelGenerator.floorlength/2, 9, LevelGenerator.floorwidth/2);
        canvasgenerator = this.gameObject.AddComponent<GenerateHUD>();
        canvasgenerator.GenerateCanvas();
        managercanvas = canvasgenerator.managercanvas;
        
        PlayerGenerator.playerone.SetActive(true);
    }

    void Update()
    {
        
    }
}
