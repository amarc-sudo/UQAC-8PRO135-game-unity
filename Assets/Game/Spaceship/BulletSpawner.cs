using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    ObjectPooler objectPooler;
    private IEnumerator bulletCooldownCoroutine;
    [SerializeField]
    private float bulletSpawnCooldown = 0.2f;

    private bool isShooting = false;
    private bool isContinouslyShooting = true;

    [SerializeField]
    private Camera camera;

    private bool onCooldown = false;
    private void Start()
    {
        camera = camera.GetComponent<Camera>();
        objectPooler = ObjectPooler.Instance;
    }

    private void Update()
    {
        if (isContinouslyShooting) isShooting = Input.GetKey(KeyCode.Mouse0);
        else isShooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (isShooting && !onCooldown)
        {
            Shoot();
            onCooldown = true;
            bulletCooldownCoroutine = BulletCooldown(bulletSpawnCooldown);
            StartCoroutine(bulletCooldownCoroutine);
        }
    }
    private void Shoot()
    {
        Ray ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); 
        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(200);

        objectPooler.SpawnFromPool("Bullet", transform.position, Quaternion.identity, targetPoint);

    }

    private IEnumerator BulletCooldown(float bulletSpawnCooldown)
    {
        yield return new WaitForSeconds(bulletSpawnCooldown);
        onCooldown = false;
    }
}


