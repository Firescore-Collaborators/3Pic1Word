using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    [SerializeField] bool star1 = false;
    [SerializeField] float rotateSpeed = 50f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!star1)
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);

        else
            transform.Rotate(0, 0, - rotateSpeed * Time.deltaTime);
    }
}
