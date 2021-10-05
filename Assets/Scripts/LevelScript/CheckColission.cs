using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CheckColission : MonoBehaviour
{
    
    public AudioSource audio ;
   

    void OnCollisionEnter()  //Plays Sound Whenever collision detected
    {
        audio.Play();
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
