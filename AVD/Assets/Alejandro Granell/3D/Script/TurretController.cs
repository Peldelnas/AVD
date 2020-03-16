﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public Transform target, aim, top;
    public float reloadTime = 1f, turnSpeed = 5f, firePauseTime = 0.25f, range = 3;
    public Transform[] cañonesPos;
    public GameObject[] lights;
    public bool canSee;

    private float nextFireTime, nextMoveTime;
    public int cañonDisparado;
    private Animator animT;
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (var light in lights)
            {
            light.SetActive(false);
            }
        animT = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AimFire()
    {
        if (target)
        {
            if(Time.time >= nextMoveTime)
            {
                aim.LookAt(target);
                aim.eulerAngles = new Vector3(0, aim.eulerAngles.y, 0);
                top.rotation = Quaternion.Lerp(top.rotation, aim.rotation, Time.deltaTime * turnSpeed);
            }
            if(Time.time >= nextFireTime && canSee == true)
            {
                Fire();
            }
        }
    }

    void Fire()
    {
        nextFireTime = Time.time + reloadTime;
        nextMoveTime = Time.time + firePauseTime;
        lights[cañonDisparado].SetActive(true);
        animT.SetBool("isFiring", true);
    }
}
