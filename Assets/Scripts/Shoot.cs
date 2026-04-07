using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject chargeUpPrefab;     
    public Transform hand; 
    public GameObject projectilePrefab;
    public Transform target;              
    public float chargeDuration = 2f;

    private void Start()
    {
        target = GameObject.Find("Target").transform;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(FireWithCharge());
        }
    }

    private IEnumerator FireWithCharge()
    {
       
        GameObject charge = Instantiate(chargeUpPrefab, hand.position, Quaternion.identity);

        
        charge.transform.parent = hand;

       
        yield return new WaitForSeconds(chargeDuration);

        GameObject proj = Instantiate(projectilePrefab, hand.position, Quaternion.identity);

        Projectile projectileScript = proj.GetComponent<Projectile>();
        if (projectileScript != null)
        {
            projectileScript.target = target;
        }
    }
}
