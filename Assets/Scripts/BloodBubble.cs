using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodBubble : MonoBehaviour
{

    public float speed = 2.0f;

    void Start()
    {

    }

    void Update()
    {

        transform.Translate(Vector3.up * speed * Time.deltaTime);


    }


}
