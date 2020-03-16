using System.Collections;
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
        AimFire();
        Tracking();
    }

    void AimFire()
    {
        if (target != null)
        {
            
            
                Vector3 direction = target.position - transform.position;
                direction.y = 0.0f;
                Quaternion rotation = Quaternion.LookRotation(direction);
                
                top.rotation = Quaternion.Euler(rotation.eulerAngles.x, rotation.eulerAngles.y, rotation.eulerAngles.z);

            if (Time.time >= nextFireTime && canSee == true)
            {
                Fire();
            }
            //else
            //{
            //    foreach (var light in lights)
            //    {
            //        light.SetActive(false);
            //    }
            //    animT.SetBool("isFiring", false);
            //}
        }
        if (target == null)
        {
            foreach (var light in lights)
            {
                light.SetActive(false);
            }
        }
    }

    void Fire()
    {
        nextFireTime = Time.time + reloadTime;
        nextMoveTime = Time.time + firePauseTime;
        lights[cañonDisparado].SetActive(true);        
    }

    void Tracking()
    {
        Vector3 fwd = cañonesPos[cañonDisparado].TransformDirection(Vector3.forward);
    }

    void OnTriggerStay(Collider col)
    {
        if (!target)
        {
            if (col.CompareTag("Enemy"))
            {
                nextFireTime = Time.time + (reloadTime * 0.5f);
                target = col.gameObject.transform;
                //animT.SetBool("isFiring", true);
                gameObject.GetComponent<Animator>().enabled = false;
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.transform == target)
        {
            target = null;
            //animT.SetBool("isFiring", false);
            gameObject.GetComponent<Animator>().enabled = true;
        }
    }
}
