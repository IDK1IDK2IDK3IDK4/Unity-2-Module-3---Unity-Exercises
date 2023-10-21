using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform rotateTarget;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, rotateTarget.eulerAngles.y + 90, 0);
    }
}
