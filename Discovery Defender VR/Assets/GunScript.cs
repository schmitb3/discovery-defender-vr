using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;
using Oculus;

public class GunScript : MonoBehaviour
{
    // ================================= Variables
    public OVRInput.RawButton fireButton = OVRInput.RawButton.LIndexTrigger;
    float timeUntilFire = 0;
    public float fireTime = 1;
    public GameObject firePosition;

    public AudioSource audioSource;

    public GameObject bulletPrefab;

    public ParticleSystem fireParticles;

    // ================================= Methods
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Update the time until fire
        if (timeUntilFire > 0)
            timeUntilFire -= Time.deltaTime;

        if (OVRInput.GetDown(fireButton) && timeUntilFire <= 0 && bulletPrefab != null)
        {
            // Instatiate a bullet prefab
            GameObject bullet = Instantiate(bulletPrefab, firePosition.transform.position, firePosition.transform.rotation);

            // Destroy the bullet after 10 seconds
            Destroy(bullet, 10);

            // Play a pew
            audioSource.Play();

            // Play the particle effect
            fireParticles.Play();
        }
    }
}
