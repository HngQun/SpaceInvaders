using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public List<EnemyMovement> listEnemyMovement;

    [SerializeField]
    List<Vector3> listSquare = new List<Vector3>();

    [SerializeField]
    List<Vector3> listRhombus = new List<Vector3>();

    [SerializeField]
    List<Vector3> listTriangle = new List<Vector3>();

    [SerializeField]
    List<Vector3> listRetangle = new List<Vector3>();

    [ContextMenu("GetListVectorSquare")]
    void GetListVectorSquare()
    {
        var listSquares = GetComponentsInChildren<Transform>();
        foreach (Transform vec in listSquares)
        {
            listSquare.Add(vec.position);
        }
    }

    [ContextMenu("GetListVectorRhombus")]
    void GetListVectorRhombus()
    {
        var listRhombuss = GetComponentsInChildren<Transform>();
        foreach (Transform vec in listRhombuss)
        {
            listRhombus.Add(vec.position);
        }
    }

    [ContextMenu("GetListVectorTriangle")]
    void GetListVectorTriangle()
    {
        var listTriangles = GetComponentsInChildren<Transform>();
        foreach (Transform vec in listTriangles)
        {
            listTriangle.Add(vec.position);
        }


    }
    [ContextMenu("GetListVectorRetangle")]
    void GetListVectorRetangle()
    {
        var listRetangles = GetComponentsInChildren<Transform>();
        foreach (Transform vec in listRetangles)
        {
            listRetangle.Add(vec.position);
        }
    }

    void Spawn(List<Vector3> listShape)
    {
        for (int i = 0; i < listEnemyMovement.Count; i++)
        {
            listEnemyMovement[i].Move(listShape[i]);
        }
    }

    IEnumerator changeSpawn()
    {
        while (listEnemyMovement != null && listEnemyMovement.Count > 0)
        {
        respawn:
            Spawn(listSquare);
            yield return new WaitForSeconds(7f);
            Spawn(listTriangle);
            yield return new WaitForSeconds(5f);
            Spawn(listRhombus);
            yield return new WaitForSeconds(5f);
            Spawn(listRetangle);
            yield return new WaitForSeconds(5f);
            goto respawn;
        }
    }

    void Start()
    {
        StartCoroutine(changeSpawn());
    }


    private bool KiemTraMangFalse(List<EnemyMovement> listEnemyMovement)
    {
        foreach (EnemyMovement item in listEnemyMovement)
        {
            if (item.isMove == true && item != null)
            {
                return false;
            }
        }
        return true;
    }


    void Update()
    {
        if (KiemTraMangFalse(listEnemyMovement))
        {
            for (int i = 0; i < listEnemyMovement.Count; i++)
            {
                if (listEnemyMovement[i] != null)
                    listEnemyMovement[i].GetComponent<Collider2D>().enabled = true;
            }

        }
        if (!KiemTraMangFalse(listEnemyMovement))
        {
            for (int i = 0; i < listEnemyMovement.Count; i++)
            {
                if (listEnemyMovement[i] != null)
                    listEnemyMovement[i].GetComponent<Collider2D>().enabled = false;
            }
        }

    }
}