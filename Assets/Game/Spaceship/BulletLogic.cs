using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour, IPooledObject
{
    [SerializeField]
    private float bulletSpeed;
    [SerializeField]
    private Rigidbody bulletRb;

    ObjectPooler objectPooler;

    public void OnObjectSpawn()
    {

    }

    private void OnDestruction()
    {
        objectPooler.poolDictionary[this.tag].Enqueue(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
