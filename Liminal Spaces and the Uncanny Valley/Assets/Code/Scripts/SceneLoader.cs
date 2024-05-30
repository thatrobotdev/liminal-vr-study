using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Scripts
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadScene(string scene)
        {
            SceneManager.LoadScene(scene);
        }
    }
}
