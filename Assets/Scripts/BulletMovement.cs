using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float bulletLifeTime = 1.0f;
    public float bulletSpeed = 7.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        bulletLifeTime -= Time.deltaTime;
        if(bulletLifeTime >0){
            transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);

        }else{
            Destroy(gameObject);
        }
        
        
    }
}
