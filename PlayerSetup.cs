using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;


public class PlayerSetup : NetworkBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Behaviour[] componentsToDisable;

    [SerializeField]
    private Camera sceneCamera;

    void Start()
    {
        if (!IsLocalPlayer) {
            for (int i = 0; i < componentsToDisable.Length; i++) {
                componentsToDisable[i].enabled = false;
            }
        } else {
            sceneCamera = Camera.main;
            if (sceneCamera != null) {
                sceneCamera.gameObject.SetActive(false);
            }            
        }
    }

    private void OnDisable()
    {
        if (sceneCamera != null) {
            sceneCamera.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
