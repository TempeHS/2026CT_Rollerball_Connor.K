using UnityEngine;

public class turretPointScript : MonoBehaviour
{
    public float shootcd = 1.0f;
    public GameObject bulletObject;
    public Transform player;
    public float playerdist;
    public GameObject clone;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        playerdist = Vector3.Distance(transform.position, player.position);
        if(playerdist<5){
            shootcd -= Time.deltaTime;
            if(shootcd<=0.0f){
                GameObject clone = Instantiate(bulletObject, transform.position, transform.rotation);
                BulletMovement scriptReference = clone.AddComponent<BulletMovement>(); 
                shootcd = 1.0f;
            }
            transform.LookAt(player.position);
        }
        
        
        
    }
}
