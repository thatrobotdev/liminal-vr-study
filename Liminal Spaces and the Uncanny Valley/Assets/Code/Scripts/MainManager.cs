using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Scripts
{
    public class MainManager : MonoBehaviour
    {
        public static MainManager Instance;
        public WWWForm Form;
    
        // The URI for the experiment server accepting a POST of experiment data
        public string serverUri = "https://www.server.com/public/script.php";
        private bool _control;
        private int _classroomTime;
        private int _storeTime;
        private int _libraryTime;
        private string _q1Response;
        private string _q2Response;
        private string _q3Response;

        private void Awake()
        {
            // Make sure that there's only one MainManager at all times
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
        
            Instance = this;
        
            // Make MainManager persistent across scene changes
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            // create form to store experiment data
            Form = new WWWForm();
        
            // Randomly sort participant into control or experimental group
            if (Random.value < 0.5)
            {
                _control = true;
            }
        }
    
        public void StartExperiment()
        {
            // Start in control classroom if in control group, otherwise experimental classroom
            SceneManager.LoadScene(_control ? "ControlClassroom" : "ExperimentalClassroom");
        }

        public void SetClassroomTime(int time)
        {
            _classroomTime = time;
        }
        
        public int GetClassroomTime()
        {
            return _classroomTime;
        }
        
        public void SetLibraryTime(int time)
        {
            _libraryTime = time;
        }
        
        public int GetLibraryTime()
        {
            return _libraryTime;
        }
        
        public void SetStoreTime(int time)
        {
            _storeTime = time;
        }
        
        public int GetStoreTime()
        {
            return _storeTime;
        }
        
        public void SetQ1Response(string response)
        {
            _q1Response = response;
        }
        
        public string GetQ1Response()
        {
            return _q1Response;
        }
        
        public void SetQ2Response(string response)
        {
            _q2Response = response;
        }
        
        public string GetQ2Response()
        {
            return _q2Response;
        }
        
        public void SetQ3Response(string response)
        {
            _q3Response = response;
        }
        
        public string GetQ3Response()
        {
            return _q3Response;
        }

        public bool IsControl()
        {
            return _control;
        }
        
        public string GetGroup()
        {
            return _control ? "control" : "experimental";
        }
    }
}
