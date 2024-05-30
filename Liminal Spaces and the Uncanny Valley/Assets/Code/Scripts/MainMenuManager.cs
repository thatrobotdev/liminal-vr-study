using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

namespace Code.Scripts
{
    public class MainMenuManager : MonoBehaviour
    {
        public static MainMenuManager Instance;
        
        // GameObjects for initial pages
        public GameObject loadingPage;
        public GameObject mainMenuPage;
    
        // Loading menu status text
        [SerializeField] private TextMeshProUGUI loadingPageStatusText;
        [SerializeField] private TextMeshProUGUI loadingPageErrorText;
        
        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            // Start app by showing loading menu
            loadingPage.SetActive(true);
            loadingPageStatusText.text = "Attempting to connect to experiment server...";
            
            // Test connection by connecting to experiment server
            // TODO: Get experiment server to return a successful HTTP status code on a successful HEAD request.
            // TODO: StartCoroutine(TestConnection(MainManager.Instance.serverURI));
            StartCoroutine(TestConnection("example.com"));
        }

        private IEnumerator TestConnection(string uri)
        {
            using var webRequest = UnityWebRequest.Head(uri);
            
            // Request and wait for the page
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    loadingPageStatusText.text = "Unfortunately, could not connect to the experiment server. Please check your internet connection and try again.";
                    loadingPageErrorText.text = "Error: " + webRequest.error;
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    loadingPageStatusText.text = "Unfortunately, could not connect to the experiment server. Please check your internet connection and try again.";
                    loadingPageErrorText.text = "HTTP Error: " + webRequest.error;
                    break;
                case UnityWebRequest.Result.InProgress:
                    break;
                case UnityWebRequest.Result.Success:
                    // On a successful connection, load the main menu page
                    loadingPage.SetActive(false);
                    mainMenuPage.SetActive(true);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
