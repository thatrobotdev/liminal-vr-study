using UnityEngine;

namespace Code.Scripts
{
    public class LibraryTimer : MonoBehaviour
    {
        public static LibraryTimer Instance;

        public int GetLibraryTime()
        {
            return _libraryTime;
        }
        
        private void Awake()
        {
            Instance = this;
        }
        
        private int _libraryTime;
        
        // Start is called before the first frame update
        private void Start()
        {
            InvokeRepeating(nameof(UpdateTimer), 1.0f, 1.0f);
        }

        private void UpdateTimer()
        {
            _libraryTime++;
        }
    }
}
