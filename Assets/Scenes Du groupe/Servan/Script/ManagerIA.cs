using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ManagerIA : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> ptsInt;

    [SerializeField]
    private List<GameObject> agentsGameobject;

    private GameObject currentAgent;
    private IaPnj currentIaPnj;
    private GameObject nextDestinationSalle;
    private GameObject nextDestinationPointInt;
    private Vector3 nextDest;

    private Animator currentAnimator;

    private int rng;
    [SerializeField]
    private int WaitingTime;

    void Start()
    {
        rng = 0;
        if (WaitingTime == 0)
        {
            WaitingTime = 5;
        }
        foreach (GameObject agent in agentsGameobject)
        {
            Debug.Log("rng  " + rng);
            Debug.Log("ptsint count  " + ptsInt.Count);
            agent.GetComponent<IaPnj>().Agent.destination = ptsInt[rng].transform.position;
            rng++;
            rng = rng % ptsInt.Count;
        }
    }

    void Update()
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
            if (currentIaPnj.Agent.hasPath && currentAnimator.GetBool("IsWalking") == false)
            {
                currentAnimator.SetBool("IsWalking", true);
            }
            if (currentIaPnj.Agent.remainingDistance < 1.5f)
            {
                VerificationEtatAgent();
                if (currentIaPnj.etat != IaPnj.Etat.Attente)
                {
                    currentIaPnj.etat = IaPnj.Etat.Attente;
                    currentIaPnj.Agent.destination = currentAgent.transform.position;
                    currentAnimator.SetBool("IsWalking", false);
                    Debug.Log("is Walking = false");
                    currentIaPnj.startWaitTime = Time.time;
                    currentIaPnj.canWait = false;
                }
                if (Time.time > currentIaPnj.startWaitTime + WaitingTime && currentIaPnj.etat == IaPnj.Etat.Attente)
                {
                    currentIaPnj.etat = IaPnj.Etat.PointInteretSalle;
                    currentAnimator.SetBool("IsWalking", true);
                    currentIaPnj.canWait = true;
                    SetDestinationAgent();
                    nextDestinationSalle = null;
                    nextDestinationPointInt = null;
                    return;
                }
                if (currentIaPnj.etat == IaPnj.Etat.Attente && currentAnimator.GetBool("IsWalking") == true)
                {
                    currentAnimator.SetBool("IsWalking", false);
                }
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
            default:
                break;
        }
    }

    void SelectPointInt()
    {
        Random.seed = System.DateTime.Now.Millisecond;
        rng = Random.Range(0, ptsInt.Count);
        nextDestinationPointInt = ptsInt[rng];
        nextDest = nextDestinationPointInt.transform.position;
        currentIaPnj.ptsInts = nextDestinationPointInt;
    }

    void SetDestinationAgent()
    {
        currentIaPnj.Agent.destination = nextDest;
    }
}
