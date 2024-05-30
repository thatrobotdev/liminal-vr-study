using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Scripts
{
    public class EndClassroomHelper : MonoBehaviour
    {
        public void EndClassroom()
        {
            // pass on time to main manager
            MainManager.Instance.SetClassroomTime(ClassroomTimer.Instance.GetClassroomTime());
            
            // Load next scene based on whether or not in control group
            SceneManager.LoadScene(MainManager.Instance.IsControl() ? "ControlStore" : "ExperimentalStore");
        }
    }
}
