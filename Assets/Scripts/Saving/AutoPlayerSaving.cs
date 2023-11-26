using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPlayerSaving : MonoBehaviour
{
    private void Start()
    {
        PlayerData playerData = PlayerJsonSave.Load();

        if (playerData != null)
        {
            transform.position = new Vector3(playerData.position[0],
                playerData.position[1],
                playerData.position[2]);
        }
    }
    
    private void OnApplicationQuit()
    {
        PlayerData playerData;
        playerData = new PlayerData("player", 10, transform.position);

        PlayerJsonSave.Save(playerData);
    }
}
