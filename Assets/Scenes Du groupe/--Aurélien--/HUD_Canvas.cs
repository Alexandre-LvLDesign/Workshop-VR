using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_Canvas : MonoBehaviour

{
    public int HUD_change = 1;
    public GameObject Current_obj;
    public GameObject Current_obj2;
    public GameObject Current_obj3;
    public GameObject Current_obj4;
    public GameObject Current_obj5;

    private bool obj1 = true;
    private bool obj2 = false;
    private bool obj3 = false;
    private bool obj4 = false;
    private bool obj5 = false;

    /*public void Update()
    {
        if(obj1 && "Récupérer câble")
        {
            obj1 = false;
            CogitatorHUD();
            obj2 = true;
        }

        if (obj2 && "Combiner tablette + câble")
        {
            obj2 = false;
            CogitatorHUD();
            obj3 = true;
        }

        if (obj3 && "Trouver casier")
        {
            obj3 = false;
            CogitatorHUD();
            obj4 = true;
        }

        if (obj4 && "Hacker casier")
        {
            obj4 = false;
            CogitatorHUD();
            obj5 = true;
        }

        if (obj5 && "Récupérer brochure")
        {
            obj5 = false;
            CogitatorHUD();
        }
    }*/

    public void CogitatorHUD()
    {
        HUD_change++;
        Debug.Log(HUD_change);

        switch (HUD_change)
        {
            //case 1 pas utile !! Jamais récupéré !!
            case 1:
                Current_obj.SetActive(true);
                break;

            case 2:
                Current_obj.SetActive(false);
                Current_obj2.SetActive(true);
                break;

            case 3:
                Current_obj2.SetActive(false);
                Current_obj3.SetActive(true);
                break;

            case 4:
                Current_obj3.SetActive(false);
                Current_obj4.SetActive(true);
                break;

            case 5:
                Current_obj4.SetActive(false);
                Current_obj5.SetActive(true);
                break;
        }
    }
}