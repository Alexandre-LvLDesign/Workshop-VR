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

    private enum Etat
    {
        Attente,
        SelectSalle,
        PointInteretSalle,
    }
    private Etat etat;

    private int s;

    private void Start()
    {
        foreach (GameObject a in listAgent)
        {
            if (!a.GetComponent<NavMeshAgent>().hasPath)
            {
                ChangementSalle();
            }
        }
    }


    private void Update()
    {
        ChangementPtsInt();
    }

    protected void ChangementSalle()
    {
        foreach (GameObject a in listAgent)
        {
            s = Random.Range(0, salles.Count);
            Debug.Log(s);
            a.GetComponent<NavMeshAgent>().destination = salles[s].transform.position;
            a.GetComponent<IaPnj>().nextSalle = salles[s];
        }
    }

    protected void ChangementPtsInt()
    {
        foreach (GameObject a in listAgent)
        {
            if (a.GetComponent<IaPnj>().nextSalle = salles[0])
            {
                pointsInteret = ptsIntSalle0;
            }
            if (a.GetComponent<IaPnj>().nextSalle = salles[1])
            {
                pointsInteret = ptsIntSalle1;
            }
            if (a.GetComponent<IaPnj>().nextSalle = salles[2])
            {
                pointsInteret = ptsIntSalle2;
            }
            if (a.GetComponent<IaPnj>().nextSalle = salles[3])
            {
                pointsInteret = ptsIntSalle3;
            }
            foreach (GameObject i in pointsInteret)
            {
                Debug.Log(i);
            }
        }
        foreach (GameObject a in listAgent)
        {
            foreach (GameObject b in listAgent)
            {
                if(a != b)
                {
                    foreach (GameObject p in pointsInteret)
                    {
                        if (p != b.GetComponent<IaPnj>().ptsInts)
                        {
                            a.GetComponent<NavMeshAgent>().destination = p.transform.position;
                            a.GetComponent<IaPnj>().ptsInts = p;
                        }
                    }
                }
            }
            if (!a.GetComponent<NavMeshAgent>().hasPath)
            {
                etat = Etat.SelectSalle;
            }
        }
    }

    private void SelectPtsIntSalle()
    {
        
    }

    private void Attente()
    {

    }

    private void SelectEtat()
    {
        if(etat == Etat.PointInteretSalle)
        {
            ChangementPtsInt();
        }
        if(etat == Etat.SelectSalle)
        {
            ChangementSalle();
        }
        if(etat == Etat.Attente)
        {
            Attente();
        }
    }
}
