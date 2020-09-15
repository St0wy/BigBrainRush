using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class BlockBehaviour : MonoBehaviour
{
    [SerializeField]
    private int x;
    [SerializeField]
    private int y;

    public int X { get => x; set => x = value; }
    public int Y { get => y; set => y = value; }

}
