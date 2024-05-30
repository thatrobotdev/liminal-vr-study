using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Scripts
{
    public class EndStoreHelper : MonoBehaviour
    {
        public void EndStore()
        {
            // pass on time to main manager
            MainManager.Instance.SetStoreTime(StoreTimer.Instance.GetStoreTime());
            
            // Load next scene based on whether or not in control group
            SceneManager.LoadScene(MainManager.Instance.IsControl() ? "ControlLibrary" : "ExperimentalLibrary");
        }
    }
}
