using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapAudio : MonoBehaviour 
{

    public AudioClip BarClip;
    public AudioClip ThermesClip;
    public AudioSource m_Bar;
    public AudioSource m_Thermes;

    private void Update() 
    {
      


    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag  == "Player")
            
        {
            ToggleClip(true); 
        }
    }

        private void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.tag  == "Player")
            
        {
            ToggleClip(false); 
        }
    }
    private void ToggleClip (bool IsEnter)
    {
        if (IsEnter == false)
        {
            m_Bar.clip = BarClip;
            m_Bar.Play();
            m_Thermes.Stop();
        }
        else
        {
            m_Thermes.clip = ThermesClip;
            m_Bar.Stop();
            m_Thermes.Play();
            
        }
    
    }
}
