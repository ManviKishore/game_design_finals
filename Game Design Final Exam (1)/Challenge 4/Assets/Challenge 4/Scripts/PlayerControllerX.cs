using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private Rigidbody playerRb;
    private float speed = 500f;
    private GameObject focalPoint;

    public bool hasPowerup = false;
    public GameObject powerupIndicator;
    public int powerUpDuration = 10;


    private float normalStrength = 10f; 
    private float powerupStrength = 25f;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    void Update()
    {

        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * verticalInput * speed * Time.deltaTime);


        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.6f, 0);
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            hasPowerup = true;
            powerupIndicator.SetActive(true);
            StartCoroutine(PowerupCooldown());
        }
    }


    IEnumerator PowerupCooldown()
    {
        yield return new WaitForSeconds(powerUpDuration);
        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRb = other.gameObject.GetComponent<Rigidbody>();

            Vector3 awayFromPlayer = (other.transform.position - transform.position).normalized; // Normalize the direction

            if (enemyRb != null)
            {
                if (hasPowerup)
                {
                    enemyRb.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
                }
                else
                {
                    enemyRb.AddForce(awayFromPlayer * normalStrength, ForceMode.Impulse);
                }
            }
        }
    }
}