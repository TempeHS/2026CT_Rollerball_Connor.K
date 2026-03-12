using UnityEngine;

public class ParticlePlayer : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleSystem;
    public Material particleMat;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Renderer>().material = particleMat;
                 
        
    }       
 
    
}
