using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 100f;
    private Rigidbody rigidbodyy;
    // Start is called before the first frame update
    void Start()
    {
        rigidbodyy = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbodyy.AddForce(transform.forward * speed);
        Destroy(gameObject, 3.0f);
    }
}
