using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Slider HitPointStatistic;
    [SerializeField] private int HitPoints;

    public void ApplyDamage(int damage)
    {
        HitPoints -= damage;
        HitPointStatistic.value = HitPoints;

        if (HitPoints <= 0)
        {
            Destroy(gameObject);
        }    
    }
}