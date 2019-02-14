using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IaManagerSoft : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> rooms;
    private List<GameObject> ptsInt;
    [SerializeField]
    private List<GameObject> ptsIntSalle0;
    [SerializeField]
    private List<GameObject> ptsIntSalle1;
    [SerializeField]
    private List<GameObject> ptsIntSalle2;
    [SerializeField]
    private List<GameObject> ptsIntSalle3;
    [SerializeField]
    private List<GameObject> ptsIntSalle4;
    [SerializeField]
    private List<GameObject> agentsGameobject;

    private GameObject currentAgent;
    private IaPnj currentIaPnj;
    private GameObject nextDestinationSalle;
    private GameObject nextDestinationPointInt;
    private Vector3 nextDest;

    private Animator currentAnimator;

    private int rng;
    private int rngSalle;
    [SerializeField]
    private int WaitingTime;

    void Start ()
    {
        rngSalle = 0;
        if (WaitingTime == 0)
        {
            WaitingTime = 5;
        }
    }

	void Update ()
    {
        ParcourirAgent();
    }

    void ParcourirAgent()
    {
        foreach (GameObject agent in agentsGameobject)
        {
            currentAgent = agent;
            currentIaPnj = currentAgent.GetComponent<IaPnj>();
            currentAnimator = currentAgent.GetComponent<Animator>();
            if (!currentIaPnj.Agent.hasPath && currentIaPnj.canWait == true)
            {
                currentAnimator.SetBool("IsWalking", false);
                Debug.Log("is Walking = false");
                currentIaPnj.startWaitTime = Time.time;
                currentIaPnj.canWait = false;
            }
            if (!currentIaPnj.Agent.hasPath && Time.time > currentIaPnj.startWaitTime + WaitingTime)
            {
                currentAnimator.SetBool("IsWalking", true);
                Debug.Log("is Walking = true");
                currentIaPnj.canWait = true;
                VerificationEtatAgent();
                SetDestinationAgent();
                Debug.Log("hasPath  " + currentIaPnj.Agent.hasPath);
                Debug.Log("canWait  " + currentIaPnj.canWait);
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
            //case IaPnj.Etat.SelectSalle:
                //SelectSalle();
                //break;
            default:
                break;
        }
    }

    void SelectSalle()
    {
        nextDest = rooms[rngSalle].transform.position;
        currentIaPnj.currentSalle = rooms[rngSalle];
        rngSalle += 1;
        if (rngSalle > rooms.Count - 1)
        {
            rngSalle = 0;
        }
        currentIaPnj.etat = IaPnj.Etat.PointInteretSalle;
    }

    void SelectPointInt()
    {
        rng = Random.Range(0, 10);
        if (rng >= 8)
        {
            //currentIaPnj.etat = IaPnj.Etat.SelectSalle;
            return;
        }
        DetectionSalle();
        rng = Random.Range(0, ptsInt.Count);
        nextDestinationPointInt = ptsInt[rng];
        nextDest = nextDestinationPointInt.transform.position;
        currentIaPnj.ptsInts = nextDestinationPointInt;
    }

    void SetDestinationAgent()
    {
        currentIaPnj.Agent.destination = nextDest;
    }

    void DetectionSalle()
    {
        if (currentIaPnj.currentSalle == rooms[0])
        {
            ptsInt = ptsIntSalle0;
        }
        if (currentIaPnj.currentSalle == rooms[1])
        {
            ptsInt = ptsIntSalle1;
        }
        if (currentIaPnj.currentSalle == rooms[2])
        {
            ptsInt = ptsIntSalle2;
        }
        if (currentIaPnj.currentSalle == rooms[3])
        {
            ptsInt = ptsIntSalle3;
        }
        if (currentIaPnj.currentSalle == rooms[4])
        {
            ptsInt = ptsIntSalle4;
        }
    }
}
