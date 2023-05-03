using UnityEngine;

public class ResourceScript : MonoBehaviour
{
    public ResourceType resource;
    private Vector3 objectHome;

    private void Start()
    {
        objectHome = transform.position;
    }

    /// <summary>
    /// collision situations
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("SafeHouse"))   // adds resource to players inventory
        {
            collision.gameObject.GetComponent<SafeHouseManager>().AddResourceToPlayerResourceInv(resource);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Ground"))      //returns back to spawner
        {
            transform.position = objectHome;
        }
    }
}
