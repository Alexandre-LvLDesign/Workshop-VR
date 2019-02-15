using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK;

public class HUD_Canvas : MonoBehaviour

{
    public Animator lockerAnimator;

    public int HUD_change = 1;
    //public GameObject Current_obj;
    //public GameObject Current_obj2;
    //public GameObject Current_obj3;
    //public GameObject Current_obj4;

    private bool obj1 = true;
    private bool obj2 = false;
    private bool obj3 = false;
    private bool obj4 = false;

    private bool onObj1 = false;
    private bool onObj2 = false;
    private bool onObj3 = false;
    private bool onObj4 = false;

    public void Update()
    {
        if(obj1 && onObj1)
        {
            obj1 = false;
            //CogitatorHUD();
            obj2 = true;
        }

        if (obj2 && onObj2)
        {
            obj2 = false;
            //CogitatorHUD();
            obj3 = true;
        }

        if (obj3 && onObj3)
        {
            obj3 = false;
            lockerAnimator.SetTrigger("Open");
            //CogitatorHUD();
            obj4 = true;
        }

        if (obj4 && onObj4)
        {
            obj4 = false;
            //CogitatorHUD();
        }
    }

    public void OnGetCable(object o, SnapDropZoneEventArgs e)
    {
        onObj1 = true;
    }

    public void OnCombineTabletCable(object o, SnapDropZoneEventArgs e)
    {
        onObj2 = true;
    }

    public void OnHackLocker(object o, SnapDropZoneEventArgs e)
    {
        onObj3 = true;
    }

    public void OnGetBrochure(object o, SnapDropZoneEventArgs e)
    {
        onObj4 = true;
    }

    //public void CogitatorHUD()
    //{
    //    HUD_change++;
    //    Debug.Log(HUD_change);

    //    switch (HUD_change)
    //    {
    //        //case 1 pas utile !! Jamais récupéré !!
    //        case 1:
    //            Current_obj.SetActive(true);
    //            break;

    //        case 2:
    //            Current_obj.SetActive(false);
    //            Current_obj2.SetActive(true);
    //            break;

    //        case 3:
    //            Current_obj2.SetActive(false);
    //            Current_obj3.SetActive(true);
    //            break;

    //        case 4:
    //            Current_obj3.SetActive(false);
    //            Current_obj4.SetActive(true);
    //            break;
    //    }
    //}
}