using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavMesh : MonoBehaviour
{
    public Transform Playerpos;
    UnityEngine.AI.NavMeshAgent agent;
    // Start is called before the first frame update
    public void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
   public void Update()
    {

        agent.destination = Playerpos.position;

    }
}
