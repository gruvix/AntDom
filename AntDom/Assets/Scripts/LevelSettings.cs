using UnityEngine;

[System.Serializable]
public class LevelSettings
{
    public GameObject Brain;
    public Sibling[] Siblings;
}

[System.Serializable]
public class Sibling
{
    public GameObject Spawner;
    public int Cantidad;
}