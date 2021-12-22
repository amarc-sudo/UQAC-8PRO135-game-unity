using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour, IPooledObject
{
    [SerializeField]
    private Rigidbody bulletRb;
    [SerializeField]
    private float forceProjection = 50;

    [SerializeField]
    private float lifeTime = 6f;

    private IEnumerator lifeDurationCoroutine;

    ObjectPooler objectPooler;

    public void OnObjectSpawn(Vector3 position, Quaternion rotation, Vector3 targetPoint)
    {
        this.gameObject.SetActive(true);
        this.transform.position = position;
        this.transform.rotation = rotation;
        lifeDurationCoroutine = BulletLifetime(lifeTime);
        Vector3 directionTowardTo = targetPoint - transform.position;
        bulletRb.AddForce(directionTowardTo.normalized * forceProjection, ForceMode.Impulse);
        StartCoroutine(lifeDurationCoroutine);
    }

    private void OnCollisionEnter(Collision collision)
    {
        StopCoroutine(lifeDurationCoroutine);
        OnDestruction();
    }

    private IEnumerator BulletLifetime(float lifeTime)
    {
        yield return new WaitForSeconds(lifeTime);
        OnDestruction();
    }

    private void OnDestruction()
    {
        bulletRb.velocity = Vector3.zero;
        bulletRb.angularVelocity = Vector3.zero;
        this.transform.position = new Vector3(0, 0, 0);
        objectPooler.poolDictionary[this.tag].Enqueue(this.gameObject);
        int count = objectPooler.poolDictionary[tag].Count;
        this.gameObject.SetActive(false);
    }
    void Start()
    {
        bulletRb = GetComponent<Rigidbody>();
        objectPooler = ObjectPooler.Instance;
    }
}
