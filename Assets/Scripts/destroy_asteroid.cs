using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_asteroid : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Hit");
        if (col.gameObject.name == "Asteroid 1")
        {
            Destroy(col.gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
