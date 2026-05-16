using UnityEngine;

// create Asset menu for EnemyMoveData
[CreateAssetMenu(fileName = "SimpleEnemyMoveData", menuName = "ScriptableObjects/SimpleEnemyMoveData", order = 1)]
public class SimpleEnemyMoveData : ScriptableObject
{
    public Vector2 StartPoint, EndPoint;

    private readonly float NormalEnemySpeed = 5f;
    private float ModifiedEnemySpeed;

    private readonly Vector2 offset = new Vector2(-4f, 0f); // Adjust as needed to position the enemy above the player

    public void OnEnable()
    {
        ModifiedEnemySpeed = NormalEnemySpeed * DifficultySettings.GetDifficultySpeedMultiplier(DaneGracza.difficulty);
        Debug.Log($"Enemy speed set to {ModifiedEnemySpeed} based on difficulty {DaneGracza.difficulty}");
    }
    public Vector2 GetStartPoint()
    {
        return StartPoint + offset; // Apply the offset to the start point
    }

    public Vector2 GetEndPoint()
    {
        return EndPoint + offset; // Apply the offset to the end point
    }

    // function to use in fixed update
    public virtual void Move(Rigidbody2D rb2d)
    {
        Vector2 adjustedEndPoint = EndPoint + offset;

        // default movement behavior
        rb2d.MovePosition(Vector2.MoveTowards(
            rb2d.position,
            adjustedEndPoint,
            ModifiedEnemySpeed * Time.fixedDeltaTime));
    }
}
