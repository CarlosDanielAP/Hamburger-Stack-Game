﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    Transform tarjet;
    // Start is called before the first frame update
    void Start()
    {

        transform.position = new Vector3(transform.position.x,GameManager.sharedInstance.cameraMoveBlock, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.sharedInstance.tower.Count > 1)
        {

            transform.position = new Vector3(transform.position.x, GameManager.sharedInstance.tower[GameManager.sharedInstance.tower.Count - 1].transform.position.y - 3, transform.position.z);

        }
    }

}
