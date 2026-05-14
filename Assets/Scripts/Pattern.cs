using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "SimplePattern", menuName = "ScriptableObjects/Patterns/SimplePattern")]
public class Pattern : ScriptableObject
{

    [SerializeField] GameObject bulletPrefab;
    public int amountOfBullets;

    public IEnumerator ShootPattern(Transform shootPoint)
    {
        for (int i = 0; i < amountOfBullets; i++)
        {
            Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
            yield return new WaitForSeconds(0.5f);
        }
    }
}