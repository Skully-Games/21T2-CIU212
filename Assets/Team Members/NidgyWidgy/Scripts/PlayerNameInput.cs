using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

namespace Nidgy
{
    public class PlayerNameInput : MonoBehaviour
    {
        [SerializeField] private TMP_InputField nameInputField = null;
        [SerializeField] private GameObject continueButton = null;

        public static string DisplayName { get; private set; }

        private const string PlayerPrefsNameKey = "PlayerName";

        private void Start() => SetUpInputField();

        void SetUpInputField()
        {
            if (!PlayerPrefs.HasKey(PlayerPrefsNameKey))
            {
                return;
            }

            string defaultName = PlayerPrefs.GetString(PlayerPrefsNameKey);

            nameInputField.text = defaultName;

            SetPlayerName(defaultName);
        }

        void SetPlayerName(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                continueButton.SetActive(true);
            }
        }

        public void SavePlayerName()
        {
            DisplayName = nameInputField.text;

            PlayerPrefs.SetString(PlayerPrefsNameKey, DisplayName);
        }
    }
}