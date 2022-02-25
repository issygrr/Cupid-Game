using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavMesh : MonoBehaviour
{
   Transform player;
    UnityEngine.AI.NavMeshAgent agent;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
    void Start()
    {
       
    }
   void Update()
    {

        agent.SetDestination(player.transform.position);
        
    }
}
