using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.App.Script.Manager
{
    public delegate void TriggerHandler(Collider collision);
    public class TriggerZoneController : MonoBehaviour
    {
        [SerializeField] private List<string> _tags;
        public event TriggerHandler TriggerEntered;
        public event TriggerHandler TriggerExit;
        public event TriggerHandler TriggerStay;

        private void OnTriggerEnter(Collider collision)
        {
            if (_tags.Contains(collision.gameObject.tag))
            {
                TriggerEntered?.Invoke(collision);
            }
        }

        private void OnTriggerExit(Collider collision)
        {
            if (_tags.Contains(collision.gameObject.tag))
            {
                TriggerExit?.Invoke(collision);
            }
        }

        private void OnTriggerStay(Collider collision)
        {
            if (_tags.Contains(collision.gameObject.tag))
            {
                TriggerStay?.Invoke(collision);
            }
        }
    }
}
