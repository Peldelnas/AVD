﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class en : MonoBehaviour
{
    public GameObject turret;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        turret.GetComponent<Turrets>()
    }
}
