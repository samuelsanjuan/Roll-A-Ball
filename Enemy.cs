using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private UnityEngine.AI.NavMeshAgent pathFinder;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
    pathFinder= GetComponent<UnityEngine.AI.NavMeshAgent>();
    target= GameObject.Find("Player").transform;    
    }

    // Update is called once per frame
    void Update()
    {
        pathFinder.SetDestination(target.position);
    }
}
