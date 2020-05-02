using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupController : MonoBehaviour
{
    public GameObject pressToPickup;    
    public GameObject turretController;
    private bool inside;

    // Start is called before the first frame update
    void Start()
    {
        pressToPickup = GameObject.Find("PressToPickup");
        turretController = GameObject.Find("TurretController");
        inside = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && inside)
        {
            pressToPickup.GetComponent<Image>().enabled = false;
            turretController.GetComponent<TriggerInputT>().SendMessage("CanUse");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Character")
        {
            pressToPickup.GetComponent<Image>().enabled = true;
            inside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Character")
        {
            pressToPickup.GetComponent<Image>().enabled = false;
            inside = false;
        }
    }
}
