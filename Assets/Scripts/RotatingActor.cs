using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RotatingActor : MonoBehaviour
{
    private float z;
    private float x;
    private float y;
  
   
    
    
    void Start () {
        z = Random.Range(-1.0f, 1.0f);  //velocity
        x = Random.Range(-1.0f, 1.0f);
        y = Random.Range(-1.0f, 1.0f);
    }
     
    void Update () {
        transform.Rotate(new Vector3(x,y,z)); //applying rotation
    }
}
