using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public float life = 4f;
    public float frecuenciaDisparo = 0.5f;
    public GameObject bullet;
    public Transform[] bulletPositions;
    public Animator turretAnim;
    private int i = 0;

    public float power = 10.0f;
    public float radius = 5.0f;
    public float upForce = 1.0f;
    public GameObject pos;
    public GameObject[] topBot;
    public AudioSource audioS;

    // Start is called before the first frame update
    void Start()
    {
        audioS = GetComponent<AudioSource>();
        StartCoroutine(PrepareDie());
        StartCoroutine(ToShoot());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PrepareDie()
    {
        yield return new WaitForSeconds(life);
        StopAllCoroutines();
        topBot[0].SetActive(false);
        topBot[1].SetActive(false);
        topBot[2].SetActive(true);
        topBot[3].SetActive(true);
        Vector3 explosionPosition = pos.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius);
        audioS.Play();
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddExplosionForce(power, explosionPosition, radius, upForce, ForceMode.Impulse);
            }
        }

        StartCoroutine(Delete());
    }
    
    IEnumerator Delete()
    {
        yield return new WaitForSeconds(6);
        Destroy(gameObject);
    }
    public void selfDestruct()
    {
        StopAllCoroutines();
        topBot[0].SetActive(false);
        topBot[1].SetActive(false);
        topBot[2].SetActive(true);
        topBot[3].SetActive(true);
        Vector3 explosionPosition = pos.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius);
        foreach (Collider hit in colliders)
        {
            if (hit.tag == "turret") { 
            Rigidbody rb = hit.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(power, explosionPosition, radius, upForce, ForceMode.Impulse);
                }
             }
        }
        StartCoroutine(Delete());

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
