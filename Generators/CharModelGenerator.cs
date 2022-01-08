using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharModelGenerator : MonoBehaviour
{
    
    public static void GenerateCharModel(Color charmodelcolor, out GameObject charmodel, out CapsuleCollider charmodelcollider, out GameObject charmodelrightarm, out GameObject charmodelleftarm, out GameObject charmodelrightleg, out GameObject charmodelleftleg)
    {
    
        //Create Character Model
        charmodel = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        charmodel.transform.localScale = new Vector3(1, 1, 1);
        charmodel.GetComponent<Renderer>().material.color = charmodelcolor;
        charmodelcollider = charmodel.AddComponent<CapsuleCollider>();
        charmodelcollider.center = new Vector3(0, -1.78f, 0);
        charmodelcollider.radius = 0.65f;
        charmodelcollider.height = 4.5f;
        Destroy (charmodel.transform.GetComponent<SphereCollider>());
        
        GameObject charmodelneck = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        charmodelneck.transform.parent = charmodel.transform;
        charmodelneck.transform.localPosition = new Vector3(0, -.3f, 0);
        charmodelneck.transform.localScale = new Vector3(.5f, .5f, .5f);
        charmodelneck.GetComponent<Renderer>().material.color = charmodelcolor;
        Destroy (charmodelneck.transform.GetComponent<CapsuleCollider>());
        
        GameObject charmodelchest = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        charmodelchest.transform.parent = charmodelneck.transform;
        charmodelchest.transform.localPosition = new Vector3(0, -2.5f, 0);
        charmodelchest.transform.localScale = new Vector3(2.5f, 2f, 1.5f);
        charmodelchest.GetComponent<Renderer>().material.color = charmodelcolor;
        Destroy (charmodelchest.transform.GetComponent<CapsuleCollider>());
        
        charmodelrightarm = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        charmodelrightarm.transform.parent = charmodelchest.transform;
        charmodelrightarm.transform.localPosition = new Vector3(.55f, .75f, 0);
        charmodelrightarm.transform.localScale = new Vector3(.3f, .75f, .5f);
        charmodelrightarm.GetComponent<Renderer>().material.color = charmodelcolor;
        Destroy (charmodelrightarm.transform.GetComponent<CapsuleCollider>());
        
        charmodelleftarm = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        charmodelleftarm.transform.parent = charmodelchest.transform;
        charmodelleftarm.transform.localPosition = new Vector3(-.55f, .75f, 0);
        charmodelleftarm.transform.localScale = new Vector3(.3f, .75f, .5f);
        charmodelleftarm.GetComponent<Renderer>().material.color = charmodelcolor;
        Destroy (charmodelleftarm.transform.GetComponent<CapsuleCollider>());
        
        charmodelrightleg = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        charmodelrightleg.transform.parent = charmodelchest.transform;
        charmodelrightleg.transform.localPosition = new Vector3(.2f, -.75f, 0);
        charmodelrightleg.transform.localScale = new Vector3(.4f, 1, .5f);
        charmodelrightleg.GetComponent<Renderer>().material.color = charmodelcolor;
        Destroy (charmodelrightleg.transform.GetComponent<CapsuleCollider>());
        
        charmodelleftleg = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        charmodelleftleg.transform.parent = charmodelchest.transform;
        charmodelleftleg.transform.localPosition = new Vector3(-.2f, -.75f, 0);
        charmodelleftleg.transform.localScale = new Vector3(.4f, 1, .5f);
        charmodelleftleg.GetComponent<Renderer>().material.color = charmodelcolor;
        Destroy (charmodelleftleg.transform.GetComponent<CapsuleCollider>());
        
        charmodel.transform.localScale = new Vector3(.4f, .4f, .4f);        
        
        //Modify Vertex's to change pivot point allowing for boneless animations
        Mesh rightarmmesh = charmodelrightarm.GetComponent<MeshFilter>().mesh;
        List<Vector3> verts = new List<Vector3>(); 
        rightarmmesh.GetVertices(verts);
        for (int i = 0; i < verts.Count; ++i) 
        {
            verts[i] = new Vector3(verts[i].x, verts[i].y - 1, verts[i].z);
        }
        rightarmmesh.SetVertices(verts);
        
        Mesh charmodelleftarmmesh = charmodelleftarm.GetComponent<MeshFilter>().mesh;
        verts = new List<Vector3>(); 
        charmodelleftarmmesh.GetVertices(verts);
        for (int i = 0; i < verts.Count; ++i) 
        {
            verts[i] = new Vector3(verts[i].x, verts[i].y - 1, verts[i].z);
        }
        charmodelleftarmmesh.SetVertices(verts);
        
        Mesh charmodelrightlegmesh = charmodelrightleg.GetComponent<MeshFilter>().mesh;
        verts = new List<Vector3>(); 
        charmodelrightlegmesh.GetVertices(verts);
        for (int i = 0; i < verts.Count; ++i) 
        {
            verts[i] = new Vector3(verts[i].x, verts[i].y - 1, verts[i].z);
        }
        charmodelrightlegmesh.SetVertices(verts);
        
        Mesh charmodelleftlegmesh = charmodelleftleg.GetComponent<MeshFilter>().mesh;
        verts = new List<Vector3>(); 
        charmodelleftlegmesh.GetVertices(verts);
        for (int i = 0; i < verts.Count; ++i) 
        {
            verts[i] = new Vector3(verts[i].x, verts[i].y - 1, verts[i].z);
        }
        charmodelleftlegmesh.SetVertices(verts);
        
        
    }
}
