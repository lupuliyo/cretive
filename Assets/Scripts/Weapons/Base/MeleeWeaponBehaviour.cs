using UnityEngine;


//Script para armas cuerpo a cuerpo,(dentro del prefab)
public class MeleeWeaponBehaviour : WeaponController
{

    public float destroyAfterSeconds;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
      Destroy(gameObject, destroyAfterSeconds);
    }

  
 
}
