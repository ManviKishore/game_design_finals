using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX : MonoBehaviour
{
    public float speed = 200f; 
    private Rigidbody enemyRb; 
    private GameObject playerGoal;

    void Start()
    {

        enemyRb = GetComponent<Rigidbody>();

        playerGoal = GameObject.Find("player Goal");

        if (playerGoal == null)
        {
            Debug.LogError("Player Goal not found. Make sure it's named 'Player Goal' and exists in the scene.");
        }
    }

    void Update()
    {
        
        if (playerGoal != null)
        {
         
            Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;

     
            enemyRb.AddForce(lookDirection * speed * Time.deltaTime, ForceMode.Force);
        }
        else
        {
            Debug.LogWarning("Player Goal reference is missing. Ensure the object is correctly initialized.");
        }
    }

    private void OnCollisionEnter(Collision other)
    {
    
        if (other.gameObject.CompareTag("Enemy Goal"))
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Player Goal"))
        {
            Destroy(gameObject);
        }
    }
}