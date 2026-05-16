using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private SimpleEnemyMoveData moveData;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void SetMoveData(SimpleEnemyMoveData moveData)
    {
        this.moveData = moveData;
        transform.position = moveData.GetStartPoint();
    }

    private void FixedUpdate()
    {
        if (moveData == null)
        {
            Debug.LogError("MoveData is not set for EnemyMovement.");
            return;
        }
        moveData.Move(GetComponent<Rigidbody2D>());

    }



}
