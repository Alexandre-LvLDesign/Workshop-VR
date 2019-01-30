using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : Manager
{
    [SerializeField]
    protected LayerMask myLayerMask;

    [SerializeField]
    private GameObject[] pointInteret;
    private List<GameObject> myPointsInt;
    private int pointInt;

    [SerializeField]
    protected int stopDist;

    private bool tempo;
    private float temp;
    [SerializeField]
    private float t;

    #region Metrics IA
    [SerializeField]
    private float Vitesse;
    #endregion

    private enum Etat
    {
        Attente,
        SelectSalle,
        PointInteretSalle,
    }

    private Etat etat;

    [SerializeField]
    private List<GameObject> Objectif;
    private int O;

    private Vector3 nextSalle;
    private NavMeshAgent Agent;

    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();

        StartEtat();

        myPointsInt = new List<GameObject>();
        if (t == 0)
        {
            t = 2;
        }
    }

    void Update()
    {
        GestionEtat();
        Debug.DrawLine(transform.position, Agent.destination, Color.black);
    }

    void ChangeSalle()
    {
        if(Vector3.Distance(Agent.pathEndPosition, transform.position) < 1.1f)
        {
            etat = Etat.PointInteretSalle;
            return;
        }
        O = O = Random.Range(0, Objectif.Count - 1);
        if (nextSalle != Objectif[O].transform.position)
        {
            nextSalle = Objectif[O].transform.position;
        }
        Agent.destination = nextSalle;
    }

    void PointInteretSalle()
    {
        if (Vector3.Distance(Agent.pathEndPosition, transform.position) < 1.1f)
        {
            if (tempo == true)
            {
                temp = Time.time;
                tempo = false;
            }
            if (Time.time > temp + 2)
            {
                if (myPointsInt.Count == 0)
                {
                    etat = Etat.SelectSalle;
                    tempo = true;
                }
                else
                {
                    if (Vector3.Distance(Agent.pathEndPosition, transform.position) < 1.1f)
                    {
                        pointInt += 1;
                        if (pointInt >= myPointsInt.Count)
                        {
                            etat = Etat.SelectSalle;
                            tempo = true;
                            myPointsInt.Clear();
                            return;
                        }
                        Agent.destination = myPointsInt[pointInt].transform.position;
                    }
                }
            }
        }
    }

    void GestionEtat()
    {
        if (etat == Etat.SelectSalle)
        {
            ChangeSalle();
        }
        if (etat == Etat.PointInteretSalle)
        {
            PointInteretSalle();
        }
    }

    void StartEtat()
    {
        etat = Etat.PointInteretSalle;
    }
}
