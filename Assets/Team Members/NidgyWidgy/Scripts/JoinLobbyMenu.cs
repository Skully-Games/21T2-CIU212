using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

namespace Nidgy
{
    public class JoinLobbyMenu : MonoBehaviour
    {
        [SerializeField] private NetworkManagerHnS networkManager = null;

        [Header("UI")] [SerializeField] private GameObject landingPagePanel = null;

        [SerializeField] private TMP_InputField ipAddressInputField = null;

        [SerializeField] private Button joinButton = null;


        void OnEnable()
        {
            NetworkManagerHnS.OnClientConnected += HandleClientConnected;
            NetworkManagerHnS.OnClientDisconnected += HandleClientDisconnected;
        }

        void OnDisable()
        {
            NetworkManagerHnS.OnClientConnected -= HandleClientConnected;
            NetworkManagerHnS.OnClientDisconnected -= HandleClientDisconnected;
        }

        public void JoinLobby()
        {
            string ipAddress = ipAddressInputField.text;

            networkManager.networkAddress = ipAddress;
            networkManager.StartClient();
            
            joinButton.SetEnabled(false);
        }
        
        
        void HandleClientConnected()
        {
            joinButton.SetEnabled(true);
            
            gameObject.SetActive(false);
            landingPagePanel.SetActive(false);
        }

        void HandleClientDisconnected()
        {
            joinButton.SetEnabled(true);
        }
    }
}