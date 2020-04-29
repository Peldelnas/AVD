using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prueba : MonoBehaviour
{
    public GameObject portalObject;
    public Transform dos;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(portalObject, dos.position, dos.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
