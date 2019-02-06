using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ManagerIA : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> salles;
    private List<GameObject> pointsInteret;
    [SerializeField]
    private List<GameObject> ptsIntSalle0;
    [SerializeField]
    private List<GameObject> ptsIntSalle1;
    [SerializeField]
    private List<GameObject> ptsIntSalle2;
    [SerializeField]
    private List<GameObject> ptsIntSalle3;
    [SerializeField]
    private List<GameObject> listAgent;

    private GameObject currentAgent;
    private IaPnj currentIaPnj;
    private GameObject nextDestinationSalle;
    private GameObject nextDestinationPointInt;
    private Vector3 nextObj;

    public List<GameObject> pointIntPris;

    private int rng;
    private int startRng;
    private int rngSalle;
    private int compteurPtsInt;

    void Start ()
    {
        pointIntPris = new List<GameObject>();
        rngSalle = 0;
    }

	void Update ()
    {
        ParcourirAgent();
    }

    void ParcourirAgent()
    {
        foreach (GameObject agent in listAgent)
        {
            currentAgent = agent;
            currentIaPnj = currentAgent.GetComponent<IaPnj>();
            if (!currentIaPnj.Agent.hasPath)
            {
                VerificationEtatAgent();
                SetDestinationAgent();
                nextDestinationSalle = null;
                nextDestinationPointInt = null;
            }
        }
    }

    void VerificationEtatAgent()
    {
        switch (currentIaPnj.etat)
        {
            case IaPnj.Etat.Attente:
                break;
            case IaPnj.Etat.PointInteretSalle:
                SelectPointInt();
                break;
            case IaPnj.Etat.SelectSalle:
                SelectSalle();
                break;
            default:
                break;
        }
    }

    void SelectSalle()
    {
        nextObj = salles[rngSalle].transform.position;
        currentIaPnj.currentSalle = salles[rngSalle];
        rngSalle += 1;
        if (rngSalle > salles.Count - 1)
        {
            rngSalle = 0;
        }
        currentIaPnj.etat = IaPnj.Etat.PointInteretSalle;
    }

    void SelectPointInt()
    {
        DetectionSalle();
        rng = Random.Range(0, pointsInteret.Count);
        startRng = rng;
        VerificationPtsPris();
        nextDestinationPointInt = pointsInteret[rng];
        nextObj = nextDestinationPointInt.transform.position;
        pointIntPris.Add(nextDestinationPointInt);
        currentIaPnj.ptsInts = nextDestinationPointInt;
    }

    void VerificationPtsPris()
    {
        compteurPtsInt = 0;
        foreach (GameObject ptsPris in pointsInteret)
        {
            if(!pointIntPris.Contains(ptsPris))
            {
                compteurPtsInt += 1;
                Debug.Log(currentIaPnj.currentSalle);
            }
        }
        if(compteurPtsInt == pointsInteret.Count)
        {
            currentIaPnj.etat = IaPnj.Etat.SelectSalle;
        }
        else
        {
            Debug.Log(compteurPtsInt);
            Debug.Log(pointsInteret.Count);
            VerificationPointLibre();
        }
    }

    void VerificationPointLibre()
    {
        foreach (GameObject ptsPris in pointIntPris)
        {
            if(pointsInteret[rng] != ptsPris)
            {
                nextDestinationPointInt = pointsInteret[rng];
                currentIaPnj.etat = IaPnj.Etat.SelectSalle;
            }
            else
            {
                rng = Random.Range(0, pointsInteret.Count);
            }
        }
    }

    void SetDestinationAgent()
    {
        currentIaPnj.Agent.destination = nextObj;
    }

    void DetectionSalle()
    {
        Debug.Log(currentIaPnj.currentSalle);
        if (currentIaPnj.currentSalle == salles[0])
        {
            pointsInteret = ptsIntSalle0;
            Debug.Log("salle0");
        }
        if (currentIaPnj.currentSalle == salles[1])
        {
            pointsInteret = ptsIntSalle1;
            Debug.Log("salle1");
        }
        if (currentIaPnj.currentSalle == salles[2])
        {
            pointsInteret = ptsIntSalle2;
            Debug.Log("salle2");
        }
        if (currentIaPnj.currentSalle == salles[3])
        {
            pointsInteret = ptsIntSalle3;
            Debug.Log("salle3");
        }
    }
}
