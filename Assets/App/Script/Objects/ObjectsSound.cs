using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class ObjectsSound : MonoBehaviour
{
    [SerializeField] private List<AudioSource> _objectSound;

    public void PlaySound(int value)
    {
        _objectSound[value].Play();
    }

    public void StopSound(int value)
    {
        _objectSound[value].Stop();
    }
}
