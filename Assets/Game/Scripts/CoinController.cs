using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinController : MonoBehaviour
{
    public AudioSource audio ;
    public Material touchColli;
    public bool end = false;
    public float timeleft = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (end)
        {
            this.gameObject.tag = "Untagged";
            this.timeleft -= Time.deltaTime;
            if (timeleft < 0)
            {
                Object.Destroy(this.gameObject);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audio.Play();
            this.gameObject.GetComponent<MeshRenderer>().material = touchColli;
            Object.Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            audio.Play();
            this.gameObject.GetComponent<Renderer>().enabled = false;
            end = true;
        }
    }
}
