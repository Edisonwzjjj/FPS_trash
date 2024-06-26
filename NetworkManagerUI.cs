using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;


public class NetworkManagerUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Button hostBtn; 
    [SerializeField]
    private Button serverBtn;
    [SerializeField]
    private Button clientBtn;

    void Start()
    {
        hostBtn.onClick.AddListener(() => {
            NetworkManager.Singleton.StartHost();
        });
        serverBtn.onClick.AddListener(() => {
            NetworkManager.Singleton.StartServer();
        });
        clientBtn.onClick.AddListener(() => {
            NetworkManager.Singleton.StartClient();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
