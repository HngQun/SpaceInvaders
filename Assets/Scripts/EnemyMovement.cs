using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public bool isMove;
    private Vector3 target;
    private float speed = 2f;
    public void Move(Vector3 target)
    {
        this.target = target;
        isMove = true;
    }

    void Update()
    {
        if (isMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            if (transform.position == target)
            {
                isMove = false;
            }
        }
    }
}
