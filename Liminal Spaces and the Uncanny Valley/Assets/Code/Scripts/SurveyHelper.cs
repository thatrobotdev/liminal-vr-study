using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Scripts
{
    public class SurveyHelper : MonoBehaviour
    {
        public void AddSurveyResponse(string response)
        {
            MainManager.Instance.Form.AddField("Question " + response[..1], response.Substring(1,2));
            if (response[..1] == "3")
            {
                SceneManager.LoadScene("UploadData");
            }
        }
    }
}
