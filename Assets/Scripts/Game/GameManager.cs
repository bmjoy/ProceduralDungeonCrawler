﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public DungeonManager dungeonManager;
    public PartyManager partyManager;

    private void Awake()
    {
        dungeonManager.dungeonTiler.onComplete += PlaceParty;
    }

    private void Update()
    {
        //Debug Tool
        if (Input.GetKeyDown(KeyCode.F1))
        {
        }

        if (partyManager.partyLeader != null)
        {
            Vector3 newPos = Vector3.MoveTowards(Camera.main.transform.position, partyManager.partyLeader.transform.position, 50 * Time.deltaTime);
            Camera.main.transform.position = new Vector3(newPos.x, newPos.y, Camera.main.transform.position.z);
        }
    }


    void PlaceParty()
    {
        DungeonGenerator.Room room = dungeonManager.dungeonGenerator.Rooms[Random.Range(0, dungeonManager.dungeonGenerator.Rooms.Count)];

        partyManager.InitializeParty(dungeonManager.grid.GetCellCenterWorld(room.centerGridTile), dungeonManager.grid);
    }

}
