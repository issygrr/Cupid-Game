using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healer : MonoBehaviour
{

    // Travel to points variables
    public Transform[] movingPoints;

    private float moveSpeed = 10f;

    int randomPoint;

    bool moveCheck;

    // Player, distance and other variables
    public Transform player;

    // Healer details
    private  float healerHealth = 100f;

    private bool healerDown;

    // Healer revive
    private float revivingTime = 5f;

    // Slider for healthTime
    public Image slider;

    // Start is called before the first frame update
    void Start()
    {
        randomPoint = Random.Range(0, movingPoints.Length);

        moveCheck = true;

        healerDown = false;
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

        if (Vector3.Distance(transform.position, movingPoints[randomPoint].position) <= 0.1f)
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
        if (healerDown == false)
        {
            slider.fillAmount += Time.deltaTime * 0.2f;

            if (Vector3.Distance(transform.position, player.position) < 5.0f)
            {
                transform.LookAt(player);

                if (slider.fillAmount == 1f && PlayerHealth.numbOfHearts < 6)
                {

                    Player.healthbar += 10;

                    PlayerHealth.numbOfHearts++;

                    slider.fillAmount = 0f;
                }

            }
            else
            {
                transform.LookAt(movingPoints[randomPoint].position);
            }
        }
    }

    public void HealerHealth()
    {
        if(healerHealth == 0)
        {
            // Alert the player that the healer is down
            // Maybe a sound or something similar

            // Makes the healer stop healing
            moveCheck = false;

            healerDown = true;

            Debug.Log("Oh no i'm dying help me please!");
            

            if (Vector3.Distance(transform.position, player.position) < 5.0f)
            {
                if (Input.GetKey(KeyCode.R))
                {
                    revivingTime -= Time.deltaTime;

                    if(revivingTime <= 0f)
                    {
                        moveCheck = true;
                        healerDown = true;
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
