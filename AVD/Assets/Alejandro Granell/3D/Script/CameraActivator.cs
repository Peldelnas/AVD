using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraActivator : MonoBehaviour
{
    public GameObject cinematic;
    public CinemachineVirtualCamera gameplay;
    public GameObject character;
    // Start is called before the first frame update
    void Start()
    {
        cinematic.SetActive(false);
        gameplay.Priority = 100;        
        character.GetComponent<CreatorKitCodeInternal.CharacterControl>().exitCinematic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
