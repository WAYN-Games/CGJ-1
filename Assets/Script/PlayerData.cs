﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Player/Data")]
public class PlayerData : ScriptableObject
{
    public float Acceleration;
    public float MaxSpeed;
    public float JumpForce;
    public int JumpCount;
    public float Cooldown;

}
