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

    public enum Etat
    {
        Attente,
        SelectSalle,
        PointInteretSalle,
    }
    public Etat etat;

    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        currentSalle = null;
        ptsInts = null;
        etat = Etat.SelectSalle;
    }
}