using UnityEngine;
using System.Collections;

[AddComponentMenu("BoneCracker Games/Realistic Car Controller Pro/Camera/RCCP Wheel Camera")]
public class RCCP_WheelCamera : RCCP_Component
{
    public void FixShake()
    {
        StartCoroutine(FixShakeDelayed());
    }

    private IEnumerator FixShakeDelayed()
    {
        if (!GetComponent<Rigidbody>())
            yield break;

        yield return new WaitForFixedUpdate();
        GetComponent<Rigidbody>().interpolation = RigidbodyInterpolation.None;
        yield return new WaitForFixedUpdate();
        GetComponent<Rigidbody>().interpolation = RigidbodyInterpolation.Interpolate;
    }
}