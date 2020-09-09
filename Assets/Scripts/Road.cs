using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Orientation
{
    North, East, South, West
}
[Serializable]
public class Road : MonoBehaviour
{
    private const int NO_ID = -1;

    public int _id;
    public GameObject _roadPrefab;
    public Orientation _orientation;

    public Road InitRoad(GameObject pRoadPrefab, Orientation pOrientation, int pId)
    {
        this._roadPrefab = pRoadPrefab;
        this._orientation = pOrientation;
        this._id = pId;
        return this;
    }
    public Road InitRoad(GameObject pRoadPrefab, int pId)
    {
        this._roadPrefab = pRoadPrefab;
        this._orientation = Orientation.North;
        this._id = pId;
        return this;
    }

    public Road InitRoad(GameObject pRoadPrefab)
    {
        this._roadPrefab = pRoadPrefab;
        this._orientation = Orientation.North;
        this._id = NO_ID;
        return this;
    }

    public GameObject ChangeOrientation(Orientation pOrientation) {

        this._orientation = pOrientation;
        float yRotation = 90.0f;
        switch (this._orientation)
        {
            case Orientation.North:
                this._roadPrefab.transform.eulerAngles = new Vector3(this._roadPrefab.transform.eulerAngles.x, 0, this._roadPrefab.transform.eulerAngles.z);
                break;
            case Orientation.East:
                this._roadPrefab.transform.eulerAngles = new Vector3(this._roadPrefab.transform.eulerAngles.x, yRotation, this._roadPrefab.transform.eulerAngles.z);
                break;
            case Orientation.South:
                this._roadPrefab.transform.eulerAngles = new Vector3(this._roadPrefab.transform.eulerAngles.x, yRotation * 2, this._roadPrefab.transform.eulerAngles.z);
                break;
            case Orientation.West:
                this._roadPrefab.transform.eulerAngles = new Vector3(this._roadPrefab.transform.eulerAngles.x, yRotation * 3, this._roadPrefab.transform.eulerAngles.z);
                break;
            default:
                break;
        }
        return this._roadPrefab.gameObject;
    }

    private void Update()
    {
        Debug.DrawRay(this._roadPrefab.transform.position, this._roadPrefab.transform.forward * 100, Color.blue);
    }
}
