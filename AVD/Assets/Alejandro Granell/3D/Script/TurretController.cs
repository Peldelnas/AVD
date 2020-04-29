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

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Die());
        Shoot();
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

    public void Shoot()
    {
        int i = 0;
        while(true)
        {
            Instantiate(bullet, bulletPositions[i].position, bulletPositions[i].rotation);
            i++;
            if (i >= bulletPositions.Length) i = 0;
            WaitForShoot();
        }
    }

    IEnumerator WaitForShoot()
    {
        yield return new WaitForSeconds(frecuenciaDisparo);
        yield return null;
    }


}
