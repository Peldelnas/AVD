using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class TurretActivator : MonoBehaviour
{

    public LayerMask layermask;
    public float speed = 3f;
    public Rigidbody RB;
    public GameObject TurretPrefab;
    public VisualEffect portal;
    public Transform playerTransform;



    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.Find("Character").GetComponent<Transform>();
        RB.AddForce(transform.forward * speed, ForceMode.Impulse);
        Destroy(gameObject, 5f);

        portal = GetComponent<VisualEffect>();
        portal.SetFloat("Major", 0.1f);
        portal.SetFloat("Minor", 0.1f);
    }

    IEnumerator Die()
    {
         yield return new WaitForSeconds(4.0f);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {

        
        if (layermask == (layermask | (1 << collision.gameObject.layer)))
        {//if the ball collides with ground then the turret is created
         // INSTANTIATE IN THE POINT OF COLLISION!!that's why we need to check collisions and not just Triggers. We parent the gameobject to the parent of the ball in order to recieve broadcasted future messages
            Instantiate(TurretPrefab, collision.contacts[0].point, playerTransform.rotation, transform.parent);                 
            portal.SetFloat("Major", 3f);
            portal.SetFloat("Minor", 0.5f);
            RB.isKinematic = true;
            gameObject.GetComponent<Transform>().eulerAngles = new Vector3(90, 0, 0); 
            StartCoroutine(Die());

        }
        else
        { //the ball touches any other layer 
            Destroy(gameObject);
        }
        RB.Sleep();//avoid more interactions
    }
}
