﻿using Synapse.Config;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace VTCustomClass.Config
{
    public class Config201 : AbstractConfigSection
    {
        [Description("The MapPoint where the class should Spawn")]
        public SerializedMapPoint SpawnPoint = new SerializedMapPoint("HCZ_Room3ar", -1.792f, 1.330017f, -0.004005589f);

        [Description("The Amount of Health the class have")]
        public int Health = 100;

        [Description("The Items the class spawns with")]
        public SerializedPlayerInventory inventory = new SerializedPlayerInventory()
        { 
            Ammo = new SerializedAmmo(0, 0, 0, 0, 0),
            Items = new List<SerializedPlayerItem>()
            {
                new SerializedPlayerItem((int)ItemType.Medkit, 35, 0, Vector3.one, 100, true)
            }
        };

        [Description("The number of players required in the same role to have the chance for the class to appear")]
        public int RequiredPlayers = 0;

        [Description("The name of the class")]
        public string RoleName = " 201";

        [Description("ArtificialHealthConfig of the class")]
        public int ArtificialHealth = 0;
    }
}