using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavMesh : MonoBehaviour
{
   Transform player;
    UnityEngine.AI.NavMeshAgent agent;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
    void Start()
    {
       // rb.velocity = transform.position;
      //  agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
   void Update()
    {

        agent.SetDestination(player.transform.position);
        
    }
}
