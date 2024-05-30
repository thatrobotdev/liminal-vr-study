using UnityEngine;

namespace Code.Scripts
{
    public class StartExperimentHelper : MonoBehaviour
    {
        public void StartExperiment()
        {
            MainManager.Instance.StartExperiment();
        }
    }
}