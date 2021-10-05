using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckColission : MonoBehaviour
{
    
    public AudioSource audio ;
    public bool end ;
    public bool level2 ;
    public float timeLeft = 3.0f;

    void OnCollisionEnter()  //Plays Sound Whenever collision detected
    {
        audio.Play();
        if(level2)
            end = true;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (end)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                SceneManager.LoadScene("Level3");
            }
        }
    }
}
