using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public float life = 3f;
    public float frecuenciaDisparo = 0.5f;
    public GameObject bullet;
    public Transform[] bulletPositions;
    public Animator turretAnim;
    private int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Die());
        StartCoroutine(ToShoot());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(life);

        //DIE TO DO
        yield return null;

    }

    public void selfDestruct()
    {
        //same as Die

    }

    IEnumerator ToShoot()
    {
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(Shoot());
        yield return null;
    }

    IEnumerator Shoot()
    {                       
            Instantiate(bullet, bulletPositions[i].position, bulletPositions[i].rotation);
            i++;
            if (i >= bulletPositions.Length) i = 0;
            yield return new WaitForSeconds(frecuenciaDisparo);
            StartCoroutine(Shoot());
    }


}
