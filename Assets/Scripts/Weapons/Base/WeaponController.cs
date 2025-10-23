using UnityEngine;

//Script general para todas las armas
public class WeaponController : MonoBehaviour
{
    [Header("Weapon Stats")]
    public GameObject prefab;
    public float damage;
    public float speed;
    public float cooldownDuration;
    float currentCooldown;
    public int pierce;

    protected PlayerMovement pm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        pm = FindFirstObjectByType<PlayerMovement>();
        //Inicializamos el cooldown
        currentCooldown = cooldownDuration;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        currentCooldown -= Time.deltaTime;//Reducimos el cooldown cada frame
        //Cuando llega a cero atacamos
        if (currentCooldown<=0f) { 
            Attack();
        }
    }

    protected virtual void Attack()
    {
        currentCooldown = cooldownDuration;//Reiniciamos el cooldown
    }
}
