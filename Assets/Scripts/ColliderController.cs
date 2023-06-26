using UnityEngine;

public class ColliderController : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public BoxCollider2D boxCollider;
    public PlayerController playerController;

    public int spriteVal;

    private void Start()
    {
        //playerController = GetComponent<PlayerController>(); idk what this does 
    }

    private void Update()
    {
        Debug.Log(gameObject.name);
        if (playerController != null)
        {
            if (playerController.playVal != spriteVal)
            {
                boxCollider.enabled = true; 
            }
            else
            {
                boxCollider.enabled = false;
            }
        }
    }

}
