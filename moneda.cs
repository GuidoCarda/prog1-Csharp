using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneda : MonoBehaviour
{
    private void Update() {
        transform.Rotate(0,0,100.0f * Time.deltaTime)
    }
}
