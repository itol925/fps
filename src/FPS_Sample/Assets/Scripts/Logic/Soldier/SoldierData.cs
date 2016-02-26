using System;
using UnityEngine;

public class SoldierData
{
    public string prefab = "cube"; //"soldier"; //"networkplayer";//cube
    public bool isMainHero = false;
    public float height = 1.8f;
    public float radius = 1.0f;
    public Vector3 center = new Vector3(0, 0.9f, 0);

    public Vector3 initPos = new Vector3(0, 1, 0);
}