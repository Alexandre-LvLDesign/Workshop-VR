using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IA : MonoBehaviour
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

    private List<GameObject> pointIntPris;

    private int rng;

    void Start ()
    {
        pointIntPris = new List<GameObject>();
    }
	
	void Update ()
    {
        foreach (GameObject agent in listAgent)
        {
            if (!pointIntPris.Contains(agent.GetComponent<IaPnj>().ptsInts))
            {
                pointIntPris.Add(agent.GetComponent<IaPnj>().ptsInts);
            }
            if(agent.GetComponent<IaPnj>().etat == IaPnj.Etat.SelectSalle)
            {
                SelectionSalle();
            }
            if (agent.GetComponent<IaPnj>().etat == IaPnj.Etat.PointInteretSalle)
            {
                SelectionPointInteret();
            }
            switch (agent.GetComponent<IaPnj>().etat)
            {
                case IaPnj.Etat.PointInteretSalle:
                    SelectionPointInteret();
                    break;
                default:
                    break;
            }
        }
    }

    private void SelectionSalle()
    {
        foreach (GameObject a in listAgent)
        {
            rng = Random.Range(0, salles.Count);
            a.GetComponent<NavMeshAgent>().destination = salles[rng].transform.position;
            a.GetComponent<IaPnj>().currentSalle = salles[rng];
            a.GetComponent<IaPnj>().etat = IaPnj.Etat.PointInteretSalle;
        }
    }

    private void SelectionPointInteret()
    {
        foreach (GameObject a in listAgent)
        {
            if (a.GetComponent<IaPnj>().currentSalle = salles[0])
            {
                pointsInteret = ptsIntSalle0;
            }
            if (a.GetComponent<IaPnj>().currentSalle = salles[1])
            {
                pointsInteret = ptsIntSalle1;
            }
            if (a.GetComponent<IaPnj>().currentSalle = salles[2])
            {
                pointsInteret = ptsIntSalle2;
            }
            if (a.GetComponent<IaPnj>().currentSalle = salles[3])
            {
                pointsInteret = ptsIntSalle3;
            }
            
            foreach (GameObject p in pointsInteret)
            {
                if (!pointIntPris.Contains(p))
                {
                    Debug.Log(a);
                    a.GetComponent<NavMeshAgent>().destination = p.transform.position;
                    a.GetComponent<IaPnj>().ptsInts = p;
                    pointIntPris.Add(p);
                }
            }
            if (!a.GetComponent<NavMeshAgent>().hasPath)
            {
                a.GetComponent<IaPnj>().etat = IaPnj.Etat.SelectSalle;
            }
        }
    }
}
