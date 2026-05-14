using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// create Asset menu for EnemyMoveData
[CreateAssetMenu(fileName = "SimpleEnemyMoveData", menuName = "ScriptableObjects/SimpleEnemyMoveData", order = 1)]
public class SimpleEnemyMoveData : ScriptableObject
{
    public Vector2 StartPoint, EndPoint;

    private float NormalEnemySpeed = 5f;
    private float ModifiedEnemySpeed;



    public void OnEnable()
    {

        ModifiedEnemySpeed = NormalEnemySpeed * DifficultySettings.GetDifficultySpeedMultiplier(DaneGracza.difficulty);

    }

    // function to use in fixed update
    public virtual void Move(Rigidbody2D rb2d)
    {
        // default movement behavior
        rb2d.MovePosition(Vector2.MoveTowards(
            rb2d.position,
            EndPoint,
            ModifiedEnemySpeed * Time.fixedDeltaTime));
    }



}
