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

    private void OnTriggerEnter(Collider coll)
    {
        Debug.Log(coll.tag);
        if (coll.tag.Equals("Enemy"))
        {
            Debug.Log("lol");
            CreatorKitCode.CharacterData target = coll.GetComponent<CreatorKitCode.CharacterData>();
            CreatorKitCode.Weapon.AttackData daño = new CreatorKitCode.Weapon.AttackData(target);
            daño.AddDamage(CreatorKitCode.StatSystem.DamageType.Electric, 2);
            target.Damage(daño);
            Destroy(gameObject);
        }
    }
}
