using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private int life = 10;

     public void DealDamage()
    {
        life--;
        if(life <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
