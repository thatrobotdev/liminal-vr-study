using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Scripts
{
    public class SurveyManager : MonoBehaviour
    {
        public static SurveyManager Instance;
        
        [SerializeField] private TextMeshProUGUI questionTitle;
        [SerializeField] private TextMeshProUGUI questionText;
        private int _currentQuestion = 1;
        private string _q1Response;
        private string _q2Response;
        private string _q3Response;
        
        private void Awake()
        {
            Instance = this;
        }

        public void Start()
        {
            questionTitle.text = "Question #" + _currentQuestion.ToString();
        }
        public void AddSurveyResponse(string response)
        {
            if (_currentQuestion == 1)
            {
                questionText.text = "I felt at ease in the environment most similar to a classroom.";
                MainManager.Instance.SetQ1Response(response);
                _currentQuestion++;
            } else if (_currentQuestion == 2)
            {
                questionText.text = "I felt at ease in the environment most similar to a library.";
                MainManager.Instance.SetQ2Response(response);
                _currentQuestion++;
            } else
            {
                MainManager.Instance.SetQ3Response(response);
                SceneManager.LoadScene("UploadData");
            }
            
            questionTitle.text = "Question #" + _currentQuestion.ToString();
            
        }
    }
}
