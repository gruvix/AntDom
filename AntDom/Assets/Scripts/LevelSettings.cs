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
    public GameObject prefab;
    public int Cantidad;
}