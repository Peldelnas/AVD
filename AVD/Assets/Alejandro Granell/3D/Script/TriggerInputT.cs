using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInputT : MonoBehaviour
{
    [SerializeField]
    public bool TurretWorking = false;
    public GameObject BallTurretPrefab;
    public Transform PlayerTransform;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {

            if (!TurretWorking)
            {
                Instantiate(BallTurretPrefab, PlayerTransform.position, PlayerTransform.rotation, transform);

            }            
            TurretWorking = !TurretWorking;
            StartCoroutine(ResetTurret());

        }
    }

    IEnumerator ResetTurret()
    {
        yield return new WaitForSeconds(4.0f);
        TurretWorking = false;
        yield return null;
    }
}
