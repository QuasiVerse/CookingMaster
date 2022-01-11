using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public static void AnimatePlayer(string animtype, string cycle, GameObject rightarm, GameObject leftarm, GameObject rightleg, GameObject leftleg){
        if(animtype == "Run"){
            if(cycle == "Left"){
                rightarm.transform.Rotate(new Vector3(-10, 0, 0), Space.Self);
                leftarm.transform.Rotate(new Vector3(10, 0, 0), Space.Self);
                rightleg.transform.Rotate(new Vector3(10, 0, 0), Space.Self);
                leftleg.transform.Rotate(new Vector3(-10, 0, 0), Space.Self);
            }
            if(cycle == "Right"){
                rightarm.transform.Rotate(new Vector3(10, 0, 0), Space.Self);
                leftarm.transform.Rotate(new Vector3(-10, 0, 0), Space.Self);
                rightleg.transform.Rotate(new Vector3(-10, 0, 0), Space.Self);
                leftleg.transform.Rotate(new Vector3(10, 0, 0), Space.Self);
            }
        }
        if(animtype == "Stand"){
            rightarm.transform.localEulerAngles = new Vector3(0, 0, 0);
            leftarm.transform.localEulerAngles = new Vector3(0, 0, 0);
            rightleg.transform.localEulerAngles = new Vector3(0, 0, 0);
            leftleg.transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        if(animtype == "Chop"){
            if(cycle == "Up"){
                rightarm.transform.Rotate(new Vector3(13, 0, 0), Space.Self);
            }
            if(cycle == "Down"){
                rightarm.transform.Rotate(new Vector3(-13, 0, 0), Space.Self);
            }
        }
    }
}
