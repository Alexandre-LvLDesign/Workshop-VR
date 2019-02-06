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


    public void CogitatorHUD()
    {
        HUD_change++;
        Debug.Log(HUD_change);

        switch (HUD_change)
        {
            case 1:
                Current_obj.SetActive(true);
                Current_obj2.SetActive(false);
                Current_obj3.SetActive(false);
                break;

            case 2:
                Current_obj.SetActive(false);
                Current_obj2.SetActive(true);
                Current_obj3.SetActive(false);
                break;

            case 3:
                Current_obj.SetActive(false);
                Current_obj2.SetActive(false);
                Current_obj3.SetActive(true);
                break;


        }

    }



}