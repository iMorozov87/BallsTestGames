using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private int _damage;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray clickRay = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(clickRay.origin, clickRay.direction);

            if (hit  && hit.collider.TryGetComponent<Ball>(out Ball ball))
            {
                ball.ApplyDamage(_damage);
            }
        }
    }
}
