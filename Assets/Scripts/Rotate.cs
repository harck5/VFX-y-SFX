using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private int speed = 200;
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * speed);
    }
}
