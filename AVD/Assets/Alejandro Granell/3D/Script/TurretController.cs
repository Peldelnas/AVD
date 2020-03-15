using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public Transform target, aim, top;
    public float reloadTime = 1f, turnSpeed = 5f, firePauseTime = 0.25f, range = 3;
    public Transform[] cañonesPos;
    public GameObject[] Lights;

    private float nextFireTime, nextMoveTime;
    public int randomCañon;
    private Animator animT;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
