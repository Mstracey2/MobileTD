using UnityEngine;

public class ResourceScript : MonoBehaviour
{
    public ResourceType resource;
    private Vector3 objectHome;

    private void Start()
    {
        objectHome = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("SafeHouse"))
        {
            collision.gameObject.GetComponent<SafeHouseManager>().AddResourceToPlayerResourceInv(resource);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            transform.position = objectHome;
        }
    }
}
