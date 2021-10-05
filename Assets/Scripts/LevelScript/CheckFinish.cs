using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckFinish : MonoBehaviour
{
    void OnCollisionEnter()  //Plays Sound Whenever collision detected
    {
        SceneManager.LoadScene("Level4");

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
