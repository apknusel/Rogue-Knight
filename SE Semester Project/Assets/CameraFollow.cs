﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFollow : MonoBehaviour
{
    private GameObject player;
    private CinemachineVirtualCamera vcam;

    void Start()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
    }

    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
        vcam.LookAt = player.transform;
        vcam.Follow = player.transform;
    }
}
