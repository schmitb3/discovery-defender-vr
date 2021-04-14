using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // ================================= Variables
    public float bulletSpeed = 10.0f;
    public GameObject sparkPrefab;

    // ================================= Methods
    void Update()
    {
        // Make a forward vector
        Vector3 forwardVector = (Vector3.forward * Time.deltaTime * bulletSpeed);

        Debug.DrawRay(transform.position, transform.forward * forwardVector.magnitude, Color.green);

        // Do raycasting to see if we will hit something
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.forward, out hit, forwardVector.magnitude))
        {
            // Instantiate a spark
            GameObject spark = Instantiate(sparkPrefab, transform.position, transform.rotation);
            spark.GetComponent<ParticleSystem>().Play();
            Destroy(spark, 1);
            Destroy(gameObject);
        }

        // Move the bullet
        transform.Translate(forwardVector);
    }
}
