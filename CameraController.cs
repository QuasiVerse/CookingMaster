using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    private Transform playeronepos;
    private Transform playertwopos;
    
    private GameObject cam;
    
    private Vector3 midPoint;
    private float distance;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera");
        playeronepos = PlayerGenerator.playerone.transform;
        playertwopos = PlayerGenerator.playertwo.transform;
        cam.transform.localEulerAngles = new Vector3(90, -90, 0);
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance (playeronepos.transform.position, playertwopos.transform.position);
        midPoint = (playeronepos.position + playertwopos.position) * 0.5f;
        midPoint.y = .8f * distance + 4f;
        cam.transform.position = midPoint;
    }
}
