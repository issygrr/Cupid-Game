using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerBall : MonoBehaviour

{
    
    public GameObject sphere1;
    
    public float range = 100f;
    public Camera fpscam;
    public float shootForce, upwardForce;
    public Transform attackPoint;
    public float spread;
    public float damage = 10f;
    public float impactForce = 30f;
    public float health = 50f;
    
    public Rigidbody rb;
    public GameObject explosion;
    public int explosionDamage;
    public float explosionRange;
    public float explosionForce;
    public bool explodeOnTouch = true;
   
    public LayerMask whatIsEnemies;
    public Transform enemy;
    
    public GameObject one;
    public GameObject two;

    void Start()
    {
       
    }
    public void Shoot()
    {
        Ray ray = fpscam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75); //Just a point far away from the player

        //Calculate direction from attackPoint to targetPoint
        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        //Calculate spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //Calculate new direction with spread
        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0); //Just add spread to last direction

        //Instantiate bullet/ projectile
        GameObject currentBullet = Instantiate(sphere1, attackPoint.position, Quaternion.identity); //store instantiated bullet in currentBullet
        //Rotate bullet to shoot direction
        currentBullet.transform.forward = directionWithSpread.normalized;
        Destroy(currentBullet, 4f);

      
        ////Add forces to bullet
        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(fpscam.transform.up * upwardForce, ForceMode.Impulse);

    }
   
   
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }

        Debug.DrawLine(transform.position, fpscam.transform.position);
    }
}
