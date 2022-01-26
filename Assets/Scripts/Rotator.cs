using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float time = 0;

    private void FixedUpdate()
    {
        time += Time.deltaTime;
        transform.Rotate(new Vector3(0, 0, 5));
        if(time>60)
        {
            Destroy(this.gameObject);
        }
    }
}