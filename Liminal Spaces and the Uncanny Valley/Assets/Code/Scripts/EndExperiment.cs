using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

namespace Code.Scripts
{
    public class EndExperiment : MonoBehaviour
    {
        // the parent gameObject for the end experiment UI that will be deactivated at the end of the experiment.
        [SerializeField] private GameObject endExperimentUI;
    
        // status text on the end experiment UI that is a countdown to be taken back to the main menu
        [SerializeField] private TextMeshProUGUI statusText;

        // send data (disable for testing)
        [SerializeField] private bool sendData = true;
    
        private bool _countdownIsRunning;
        private static float _timeRemaining;
        private int _seconds;
    
        private void Start()
        {
            _timeRemaining = 15;
            _seconds = 0;

            if(sendData)
            {
                StartCoroutine(UploadData());
                statusText.text = "Uploading simulation data...";
            } else
            {
                _countdownIsRunning = true;
            }
        }
    
        // Update is called once per frame
        private void Update()
        {
            // Count down seconds on end experiment UI, then return to main menu
            if (!_countdownIsRunning) return;
            if (_timeRemaining > 0)
            {
                _seconds = (int) _timeRemaining;
                statusText.text = $"Returning to Main Menu in {_seconds} seconds.";
                _timeRemaining -= Time.deltaTime;
            }
            else
            {
                endExperimentUI.SetActive(false);
                Destroy(MainManager.Instance);
                _countdownIsRunning = false;

                SceneManager.LoadScene("MainMenu");
            }
        }

        private IEnumerator UploadData()
        {
            MainManager.Instance.Form.AddField("group", MainManager.Instance.GetGroup());
            MainManager.Instance.Form.AddField("q1", MainManager.Instance.GetQ1Response());
            MainManager.Instance.Form.AddField("q2", MainManager.Instance.GetQ2Response());
            MainManager.Instance.Form.AddField("q3", MainManager.Instance.GetQ3Response());
            MainManager.Instance.Form.AddField("classroom", MainManager.Instance.GetClassroomTime());
            MainManager.Instance.Form.AddField("store", MainManager.Instance.GetStoreTime());
            MainManager.Instance.Form.AddField("library", MainManager.Instance.GetLibraryTime());

            var www = UnityWebRequest.Post(MainManager.Instance.serverUri, MainManager.Instance.Form);
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                statusText.text = www.error;
            }
            else
            {
                // Start countdown once data is uploaded
                _countdownIsRunning = true;
            }
        }
    }
}
