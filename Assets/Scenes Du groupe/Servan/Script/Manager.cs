using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Manager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> salles;
    [SerializeField]
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

    private IaPnj iaPnj;

    private int s;

    private void Start()
    {
        pointIntPris = new List<GameObject>();
    }

    private void Update()
    {
        SelectEtat();
        RecupDestination();
    }

    protected void ChangementSalle()
    {
        foreach (GameObject a in listAgent)
        {
            s = Random.Range(0, salles.Count);
            a.GetComponent<NavMeshAgent>().destination = salles[s].transform.position;
            a.GetComponent<IaPnj>().currentSalle = salles[s];
            a.GetComponent<IaPnj>().etat = IaPnj.Etat.PointInteretSalle;
        }
    }

    protected void ChangementPtsInt()
    {
        
    }

    private void Attente()
    {

    }

    private void SelectEtat()
    {
        foreach (GameObject a in listAgent)
        {
            if(a.GetComponent<IaPnj>().etat == IaPnj.Etat.PointInteretSalle)
            {
                ChangementPtsInt();
            }
            if(a.GetComponent<IaPnj>().etat == IaPnj.Etat.SelectSalle)
            {
                ChangementSalle();
            }
            if(a.GetComponent<IaPnj>().etat == IaPnj.Etat.Attente)
            {
                Attente();
            }
        }
    }

    private void RecupDestination()
    {
        pointIntPris.Clear();
        foreach (GameObject a in listAgent)
        {
            pointIntPris.Add(a.GetComponent<IaPnj>().ptsInts);
        }
    }
}
