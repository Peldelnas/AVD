using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerInputT : MonoBehaviour
{
    public bool canUse;
    public bool TurretWorking = false;
    public bool useTbool;
    public GameObject BallTurretPrefab;
    public Transform PlayerTransform;
    public GameObject useT;
    // Start is called before the first frame update
    void Start()
    {
        canUse = false;
        useTbool = false;
        useT = GameObject.Find("UseT");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {

            if (canUse && !TurretWorking)
            {
                Instantiate(BallTurretPrefab, PlayerTransform.position, PlayerTransform.rotation, transform);
                TurretWorking = true;
                StartCoroutine(ResetTurret());
                if(useTbool)
                {
                    useT.GetComponent<Image>().enabled = false;
                }
            }                                   

        }
    }

    public void CanUse()
    {
        StartCoroutine(CanUseEnum());
    }

    IEnumerator CanUseEnum()
    {
        useT.GetComponent<Image>().enabled = true;
        yield return new WaitForSeconds(0.5f);
        canUse = true;
        useTbool = true;        
        yield return null;

    }

    IEnumerator ResetTurret()
    {
        yield return new WaitForSeconds(4.0f);
        TurretWorking = false;
        yield return null;
    }
}
