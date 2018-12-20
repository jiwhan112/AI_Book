using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    public Vector3 Vec;
    public float ff;
    public float ff2;
    private void Update()
    {
        ff = Vec.magnitude; // 루트한거
        ff2 = Vec.sqrMagnitude; // 루트안한거
    }
}
