using System;
using System.Collections;
using UnityEngine;

namespace Assets.App.Script.Manager
{
    public class Timer2Controller : MonoBehaviour
    {
        public event Action Elapsed;

        [SerializeField] private bool _looped;
        [SerializeField] private float _elapsedTime;

        private bool _isStarted;
        
        private float _currentTime;
        public float CurrentTime
        {
            get => _currentTime;
        }
        void Update()
        {
            if (!_isStarted)
                return;
            UpdateTimer();
        }
        private void UpdateTimer()
        {
            _currentTime += Time.deltaTime;
            CheckTimer();
        }
        private void CheckTimer()
        {
            if (_currentTime < _elapsedTime)
                return;
            Elapsed?.Invoke();
            if (_looped)
                ResetTimer();
            else
                StopTimer();
        }
        public void SetElapsedTime(float elapsedTime)
        {
            _elapsedTime = elapsedTime;
        }
        public void ResetTimer()
        {
            _currentTime = 0;
        }
        public void StartTimer()
        {
            _isStarted = true;
        }
        public void StopTimer()
        {
            _isStarted = false;
        }
    }
}