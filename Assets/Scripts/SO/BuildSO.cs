using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class BuildSO : ScriptableObject 
{
    public Transform prefab;
    public Transform prefabUp;
    public Sprite sprite;
    
    public float rangeAttack;
    public float speedAttack;
    public int cost;
}

