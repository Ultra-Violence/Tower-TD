using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class BulletSO : ScriptableObject
{
    public Transform prefab;
    public Transform boomPrefab;
    public int damage;
    public float speed;
    public float boomRadius;

}
