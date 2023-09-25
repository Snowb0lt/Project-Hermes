using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrusterFuel : MonoBehaviour
{
    public float fuelAmount;
    [SerializeField] private float fuelDrain;

    public void ThrusterFuelDraining()
    {
        //TODO: Drain the fuel overtime as it is used

        fuelAmount -= fuelDrain;
    }

    public void ReportThrusterFuel()
    {
        Debug.Log($"Fuel Amount is {fuelAmount}");
    }
}
