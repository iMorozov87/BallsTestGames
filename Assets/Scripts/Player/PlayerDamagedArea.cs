using UnityEngine;

public class PlayerDamagedArea : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _collider2D;
    [SerializeField] private CameraBordaries _bordaries; 

    private void Awake()
    {
        int sizeMultiplier = 2;       
        transform.position = new Vector2(0, _bordaries.LeftDownBorder.y);
        _collider2D.size = new Vector2(_bordaries.RightDownBorder.x * sizeMultiplier, _collider2D.size.y) ;        
    }
}
