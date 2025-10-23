using UnityEngine;


//Script para manejar proyectiles(va en el prefab del arma)
public class ProjectileWeaponBehaviour : MonoBehaviour
{

    protected Vector3 direction;
    public float destroyAfterSeconds;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

    public void directionChecker(Vector3 dir)
    {
        direction = dir;
        float dirx = dir.x;
        float diry = dir.y;
        
        Vector3 scale= transform.localScale;
        Vector3 rotation= transform.eulerAngles;

        if (dirx <= 0 && diry == 0) //left
        {
            scale.x = -1;
            scale.y = -1;
        }
        else if (dirx == 0 && diry < 0) //down
        {
            scale.y = -1;
        }
        else if (dirx == 0 && diry > 0) //up
        {
            scale.x = -1;
        }
        else if (dirx > 0 && diry > 0) //up-right
        { 
            rotation.z = 0;
        }
        
        
        else if (dirx > 0 && diry < 0) //down-right
        {
            rotation.z = -90;

        }
        else if (dirx < 0 && diry > 0) //left-up
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1; 
            rotation.z = -90;
        }
        else if (dirx < 0 && diry < 0) //left-down
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
            rotation.z = 0;
        }

            transform.localScale = scale;
        transform.rotation = Quaternion.Euler(rotation);
    }
}
