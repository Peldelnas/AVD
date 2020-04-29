using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInputT : MonoBehaviour
{
    [SerializeField]
    public static bool TurretWorking = false;
    public GameObject BallTurretPrefab;
    public Transform PlayerTransform;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {

            if (!TurretWorking)
            {
                Instantiate(BallTurretPrefab, PlayerTransform.position, PlayerTransform.rotation, transform);

            }
            else
            {
                BroadcastMessage("KillTurret");
            }
            TurretWorking = !TurretWorking;
            Debug.Log(TurretWorking);

        }
    }
}
