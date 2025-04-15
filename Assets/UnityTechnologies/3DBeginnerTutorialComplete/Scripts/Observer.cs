using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Observer : MonoBehaviour
{
    public Transform player;
    public GameEnding gameEnding;

    bool m_IsPlayerInRange;

    float awareness = 0f;

    public float defaultAwareness = 0f;
    public float currentAwareness;

    public AwarenessBar awarenessBar;
    //float catchTime = 2f; 0.35 is long enough to walk through but any longer and you'll get caught

    void Start()
    {
        currentAwareness = defaultAwareness;
        awarenessBar.SetDefaultAwareness(defaultAwareness);
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.transform == player)
        {
            Debug.Log("WE HIT");
            m_IsPlayerInRange = true;
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = false;
            Debug.Log("WE OUT");
        }
    }

    void Update ()
    {
        if (m_IsPlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;
            
            if (Physics.Raycast (ray, out raycastHit))
            {
                if (raycastHit.collider.transform == player)
                {
                    awareness = Mathf.Lerp(awareness, 1f, Time.deltaTime / 0.5f);
                    Debug.Log("awareness = " + awareness.ToString());
                    currentAwareness = awareness;
                    awarenessBar.SetAwareness(currentAwareness);
                    if (awareness > 0.99f){
                        gameEnding.CaughtPlayer (); /*Its a class duh*/
                    }
                }
            }
        }
        else{
            awareness = Mathf.Lerp(awareness, 0f, Time.deltaTime / 1f);
            currentAwareness = awareness;
            awarenessBar.SetAwareness(currentAwareness);
        }
        /*if (!m_IsPlayerInRange){
            awareness = Mathf.Lerp(awareness, 0f, Time.deltaTime / 0.5f);
            Debug.Log("awareness = " + awareness.ToString());
            currentAwareness = awareness;
            awarenessBar.SetAwareness(currentAwareness);
        }*/

    }
}
