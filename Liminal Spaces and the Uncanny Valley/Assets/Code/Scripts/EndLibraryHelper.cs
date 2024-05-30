using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Scripts
{
    public class EndLibraryHelper : MonoBehaviour
    {
        public void EndLibrary()
        {
            // pass on time to main manager
            MainManager.Instance.SetLibraryTime(LibraryTimer.Instance.GetLibraryTime());
            
            SceneManager.LoadScene("Survey");
        }
    }
}
