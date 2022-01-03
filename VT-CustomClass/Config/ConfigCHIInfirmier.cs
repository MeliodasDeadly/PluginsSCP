﻿using Synapse.Config;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace VTCustomClass.Config
{
    public class ConfigCHIInfirmier : AbstractConfigSection
    {
        [Description("The Amount of Health the class have")]
        public int Health = 110;

        [Description("The Inventory of the class")]
        public SerializedPlayerInventory inventory = new SerializedPlayerInventory()
        {
            Ammo = new SerializedAmmo(100, 100, 100, 100, 100),
            Items = new List<SerializedPlayerItem>()
            {
                new SerializedPlayerItem((int)ItemType.KeycardChaosInsurgency, 1, 0, Vector3.one, 100, false),
                new SerializedPlayerItem((int)ItemType.GunCrossvec, 17, 0, Vector3.one, 100, true),
                new SerializedPlayerItem(55, 2, 0, Vector3.one, 100, false),
                new SerializedPlayerItem(55, 2, 0, Vector3.one, 100, false),
                new SerializedPlayerItem(55, 2, 0, Vector3.one, 100, false),
                new SerializedPlayerItem((int)ItemType.Adrenaline, 1, 0, Vector3.one, 100, false),
                new SerializedPlayerItem((int)ItemType.Radio, 100, 0, Vector3.one, 100, false),
                new SerializedPlayerItem((int)ItemType.ArmorLight, 1, 0, Vector3.one, 100, false)
            }
        };

        [Description("ArtificialHealthConfig of the class")]
        public int ArtificialHealth = 0;
        public int MaxArtificialHealth = 100;

        [Description("Shield of the class")]
        public int Shield = 20;
        public int MaxShield = 100;

        [Description("The Chance of which the class spawns")]
        public int SpawnChance = 16;

        [Description("Max alive at the same time")]
        public int MaxAlive = 100;

        [Description("max of this role which can spawn into a respawn")]
        public int MaxRespawn = 100;

        [Description("The number of players required in the same role to have the chance for the class to appear")]
        public int RequiredPlayers = 0;

        [Description("The name of the class")]
        public string RoleName = "Infirmier";

        [Description("The cooldown of the class Power")]
        public int Cooldown = 150;
    }
}