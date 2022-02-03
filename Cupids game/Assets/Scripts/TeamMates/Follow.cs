using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject player;
    public float targetDisc;
    public float limitDisc = 5f;
    public float speed;
    public RaycastHit shot;
    // Start is called before the first frame update
    public void Update()
    {
        transform.LookAt(player.transform);
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),out shot))
        {
            targetDisc = shot.distance;
            if(targetDisc >= limitDisc)
            {
                speed = 0.3f;
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed);
            }
        }
        else
        {
            speed = 0f;
        }

        /*
         * 
         * distance between player and healer
         * 
         * if the distance is < 10f then healer will follow
         * if distance is higher then healer stops
         * 
         * distance < 10f = movetowards
         */
    }

    // Update is called once per frame
   
}
