using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_asteroid : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<Asteroid>().DealDamage();
        }
    }
}
