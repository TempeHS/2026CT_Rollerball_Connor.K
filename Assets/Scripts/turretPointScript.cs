using UnityEngine;

public class turretPointScript : MonoBehaviour
{
    public GameObject bulletObject;
    public Transform player;
    public float playerdist;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        playerdist = Vector3.Distance(transform.position, player.position);
        if(playerdist<3){
            if(Time.time%2 > 1){
                Instantiate(bulletObject, transform.position, transform.rotation);
            }
            transform.LookAt(player.position);
        }
        
        
        
    }
}
