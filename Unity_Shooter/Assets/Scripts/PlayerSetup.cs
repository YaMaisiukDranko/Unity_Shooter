using System;
using Mirror;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour
{
    [SerializeField]
    Camera sceneCamera;
    Behaviour[] componentsToDisable;

    void Start()
    {
        if (!isLocalPlayer)
        {
            for (int i = 0; i < componentsToDisable.Length; i++)
            {
                componentsToDisable[i].enabled = false;
            }
        }
        
    }

    void OnDisable()
    {
        if (sceneCamera != null) ;
        {
            sceneCamera.gameObject.SetActive(false);
        }
    }
}

