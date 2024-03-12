using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class MeteorPistol : MonoBehaviour
{
    public ParticleSystem particles;
    public LayerMask layerMask;
    public Transform shootSource;
    public float distance = 10;
    private bool rayActivate = false;

    void Start()
    {
        XRGrabInteractable grabInterActable = GetComponent<XRGrabInteractable>();
        grabInterActable.activated.AddListener(x => StartShooting());
        grabInterActable.deactivated.AddListener(x => StopShooting());
    }

    public void StartShooting()
    {
        particles.Play();
        rayActivate = true;
    }

    public void StopShooting()
    {
        particles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        rayActivate = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(rayActivate)
        {
            RaycastCheck();
        }
    }

    void RaycastCheck()
    {
        RaycastHit hit;
        bool hasHit = Physics.Raycast(shootSource.position, shootSource.forward, out hit, distance, layerMask);

        if(hasHit)
        {
            hit.transform.gameObject.SendMessage("Break", SendMessageOptions.DontRequireReceiver);
        }
    }
}
