using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapAudio : MonoBehaviour 
{
    private float AVolume1 = 1f;
    private float AVolume2 = 0;
    public AudioClip BarClip;
    public AudioClip ThermesClip;
    public AudioSource m_Bar;
    private void OnTriggerEnter(Collider other) 
    {

        if (m_Bar.clip = ThermesClip)
        {
            m_Bar.clip = BarClip;
            m_Bar.Play();
        }
        if (m_Bar.clip = BarClip)
        {
            m_Bar.clip = ThermesClip;
            m_Bar.Play();

        }
    }
    private void OnTriggerExit(Collider other) 
    {
        m_Bar.Stop();
        if (m_Bar.clip = ThermesClip) 
        {
            m_Bar.clip = BarClip;
            m_Bar.Play();
        }
    }

}
