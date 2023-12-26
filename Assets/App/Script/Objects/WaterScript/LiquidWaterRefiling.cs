using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidWaterRefiling : MonoBehaviour
{
    [SerializeField] private LiquidWater _liquidWater;

    private void OnParticleCollision(GameObject objectWater)
    {
        if (objectWater.CompareTag("RefillWater"))
        {
            {
                _liquidWater.RefillingWater();
                Debug.Log("Наполняйся");
            }
        }
    }
}
