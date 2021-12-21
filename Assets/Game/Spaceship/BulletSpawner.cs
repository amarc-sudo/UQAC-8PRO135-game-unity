using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    ObjectPooler objectPooler;
    private IEnumerator bulletCooldownCoroutine;
    [SerializeField]
    private float bulletSpawnCooldown = 0.5f;

    private bool onCooldown = false;
    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (!onCooldown)
            {
                objectPooler.SpawnFromPool("Bullet", transform.position, Quaternion.identity);
                onCooldown = true;
                bulletCooldownCoroutine = BulletCooldown(bulletSpawnCooldown);
                StartCoroutine(bulletCooldownCoroutine);
            }
        }
    }

    private IEnumerator BulletCooldown(float bulletSpawnCooldown)
    {
        yield return new WaitForSeconds(bulletSpawnCooldown);
        onCooldown = false;
    }

}


