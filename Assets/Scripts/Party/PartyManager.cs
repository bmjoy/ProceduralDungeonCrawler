﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyManager : MonoBehaviour
{
    public List<PartyMember> partyMembers;

    public List<PartyMember> party;
    public PartyMember partyLeader;
    public DungeonManager dungeonManager;

    public void InitializeParty(Vector3 position, Grid grid)
    {
        party = new List<PartyMember>();

        for (int i = 0; i < partyMembers.Count; i++)
        {
            int index = i - 1;
            PartyMember partyMember = Instantiate(partyMembers[i], position, partyMembers[i].transform.rotation);
            partyMember.grid = grid;
            party.Add(partyMember);
        }

        for (int i = 1; i < party.Count; i++)
        {
            int index = i - 1;
            party[i].transform.position = new Vector3(party[index].transform.position.x + 1, party[index].transform.position.y, 0);
        }

        this.partyLeader = party[0];
    }

    

}
