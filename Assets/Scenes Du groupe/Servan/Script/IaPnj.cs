using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IaPnj : MonoBehaviour
{
    [SerializeField]
    protected int stopdist;

    public GameObject currentSalle;
    public GameObject ptsInts;

    public NavMeshAgent Agent;
    [SerializeField]
    private ManagerIA managerIA;

    public float startWaitTime;
    public bool canWait;

    public enum Etat
    {
        Attente,
        PointInteretSalle,
    }
    public Etat etat;

    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        currentSalle = null;
        ptsInts = null;
        canWait = true;
    }
}