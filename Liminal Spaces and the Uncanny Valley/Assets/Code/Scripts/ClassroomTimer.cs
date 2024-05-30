using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassroomTimer : MonoBehaviour
{
    public static ClassroomTimer Instance;

        public int GetClassroomTime()
        {
            return _classroomTime;
        }
        
        private void Awake()
        {
            Instance = this;
        }
        
        private int _classroomTime;
        
        // Start is called before the first frame update
        private void Start()
        {
            InvokeRepeating(nameof(UpdateTimer), 1.0f, 1.0f);
        }

        private void UpdateTimer()
        {
            _classroomTime++;
        }

}
