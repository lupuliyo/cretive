using UnityEngine;

public class GarlicController : WeaponController
{
    GameObject spawnedGarlic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
        spawnedGarlic = Instantiate(prefab);
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (spawnedGarlic != null)
        {
            spawnedGarlic.transform.position = transform.position; // Posicion del ajo en el jugador
            spawnedGarlic.transform.parent = transform; // Hijo del jugador
        }
       
        
    }
    protected override void Attack()
    {
        base.Attack();
        spawnedGarlic.GetComponent<GarlicBehaviour>();
        spawnedGarlic = Instantiate(prefab); // Crear un nuevo ajo para el siguiente ataque
    }
}


