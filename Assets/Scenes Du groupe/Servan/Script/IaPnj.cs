using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IaPnj : MonoBehaviour
{
    [SerializeField]
    protected int stopdist;

    public GameObject nextSalle;
    public GameObject ptsInts;

    private NavMeshAgent Agent;

    void Start ()
    {
        Agent = GetComponent<NavMeshAgent>();
        nextSalle = null;
        ptsInts = null;
}
	
	void Update ()
    {
        
	}
}
