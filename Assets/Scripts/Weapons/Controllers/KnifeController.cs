using UnityEngine;

public class KnifeController : WeaponController
{
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject spawnedKnife = Instantiate(prefab);
        spawnedKnife.transform.position = transform.position;//Pongo la posicion en el jugador
        spawnedKnife.GetComponent<KnifeBehaviour>().directionChecker(pm.lastMovedVector);
    }
  
}
