using UnityEngine;

namespace Code.Scripts
{
    public class StoreTimer : MonoBehaviour
    {
        public static StoreTimer Instance;

        public int GetStoreTime()
        {
            return _storeTime;
        }
        
        private void Awake()
        {
            Instance = this;
        }
        
        private int _storeTime;
        
        // Start is called before the first frame update
        private void Start()
        {
            InvokeRepeating(nameof(UpdateTimer), 1.0f, 1.0f);
        }

        private void UpdateTimer()
        {
            _storeTime++;
        }
    }
}
