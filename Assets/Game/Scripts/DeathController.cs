using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathController : MonoBehaviour
{
    public int goldCount;
    // Start is called before the first frame update
    void Start()
    {
        goldCount = GameObject.FindGameObjectsWithTag("Coin").Length +1;
    }

    // Update is called once per frame
    void Update()
    {
        goldCount = GameObject.FindGameObjectsWithTag("Coin").Length;
        if(goldCount == 0)
            SceneManager.LoadScene("Level4");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ghost")
        {
            SceneManager.LoadScene("Level4");
        }
    }

}
