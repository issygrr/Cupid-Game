using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : MonoBehaviour
{

    // Travel to points variables
    public Transform[] movingPoints;

    private float moveSpeed = 10f;

    int randomPoint;

    bool moveCheck;

    // Player, distance and other variables
    public Transform player;

    bool delayHealth;

    // Healer details
    private  float healerHealth = 100f;

    // Healer revive
    private float revivingTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        randomPoint = Random.Range(0, movingPoints.Length);

        moveCheck = true;

        delayHealth = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        LookAndHeal();

        MoveToPoint();

        HealerHealth();
    }

    public void MoveToPoint()
    {

        transform.position = Vector3.MoveTowards(transform.position, movingPoints[randomPoint].position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movingPoints[randomPoint].position) < 0.1f)
        {


            if (moveCheck)
            {
                StartCoroutine(DelayMovement());
                randomPoint = Random.Range(0, movingPoints.Length);
                transform.position = Vector3.MoveTowards(transform.position, movingPoints[randomPoint].position, moveSpeed * Time.deltaTime);
            }

        }

    }

    IEnumerator DelayMovement()
    {

        moveCheck = false;

        yield return new WaitForSeconds(6f);

        moveCheck = true;

    }

    public void LookAndHeal()
    {
        if (Vector3.Distance(transform.position, player.position) < 20.0f)
        {
            transform.LookAt(player);

            if (delayHealth && PlayerHealth.numbOfHearts < 6)
            {

                StartCoroutine(DelayHealth());

            }

        }
    }

    IEnumerator DelayHealth()
    {

        delayHealth = false;

        yield return new WaitForSeconds(5f);

        Player.healthbar += 10;

        PlayerHealth.numbOfHearts++;

        delayHealth = true;
    }

    public void HealerHealth()
    {
        if(healerHealth == 0)
        {
            // Alert the player that the healer is down
            // Maybe a sound or something similar

            // Makes the healer stop healing
            moveCheck = false;
            delayHealth = false;

            Debug.Log("Oh no i'm dying help me please!");
            

            if (Vector3.Distance(transform.position, player.position) < 5.0f)
            {
                if (Input.GetKey(KeyCode.R))
                {
                    revivingTime -= Time.deltaTime;

                    if(revivingTime <= 0f)
                    {
                        moveCheck = true;
                        delayHealth = true;
                        healerHealth = 100f;
                        Debug.Log("Yey I'm alive! Thank you.");
                        revivingTime = 5f;
                    }
                }
                else
                {
                    revivingTime = 5f;
                }
                
            }

        }
    }


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("EnemyBullet"))
        {
            healerHealth -= 10;
        }
    }

}
