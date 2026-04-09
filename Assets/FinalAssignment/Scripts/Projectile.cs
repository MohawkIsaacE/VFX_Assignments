using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Transform target;
    public float speed = 10f;
    public GameObject impactPrefab;   // assign prefab
    public LayerMask groundMask;      // layers considered ground
    public float groundCheckDistance = 50f;

    public float projectileSpawnTimer = 0;
    public GameObject projectileSpawn;
    public GameObject environmentalPrefab;

    private Vector3 direction;

    private void Start()
    {
        if (target == null)
            target = GameObject.Find("Target")?.transform;

        if (target != null)
            direction = (target.position - transform.position).normalized;
    }

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        // Move in a straight line toward the initial target position
        transform.position += direction * speed * Time.deltaTime;

        // Check if reached target
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            SpawnEnvironmentalOnGround();
            Instantiate(impactPrefab, transform.position, Quaternion.identity);
            Camera.main.GetComponent<CameraShake>().Shake();
            Destroy(gameObject);
        }

        projectileSpawnTimer += Time.deltaTime;

        if (projectileSpawnTimer >= 0.3f)
        {
            Instantiate(projectileSpawn, transform.position, Quaternion.identity);
            projectileSpawnTimer = 0;
        }
    }

    private void SpawnEnvironmentalOnGround()
    {
        if (impactPrefab == null) return;

        RaycastHit hit;
        Vector3 rayStart = target.position + Vector3.up;

        if (Physics.Raycast(rayStart, Vector3.down, out hit, groundCheckDistance, groundMask))
            Instantiate(environmentalPrefab, hit.point, Quaternion.identity);
    }
}
