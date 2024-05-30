using UnityEngine;

namespace Code.Scripts
{
    public class SurveyButtonHelper : MonoBehaviour
    {
        public void SurveyInput(string response)
        {
            SurveyManager.Instance.AddSurveyResponse(response);
        }
    }
}