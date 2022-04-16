using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDisable : MonoBehaviour
{
    [SerializeField] float disableTime;
    float time;



    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= disableTime) gameObject.SetActive(false);
    }

    void OnDisable()
    {
        time = 0;
    }
}
