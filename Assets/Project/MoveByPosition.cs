using UnityEngine;

public class MoveByPosition : MonoBehaviour, IMoveable 
{
        [SerializeField]
        private float Speed = 1f;
        private Vector2 mCurMovement = Vector2.zero;

        private void FixedUpdate()
        {
            Vector2 curPos = transform.position;
            Vector2 targetPos = new Vector2(curPos.x + mCurMovement.x,curPos.y + mCurMovement.y);
            transform.position = targetPos;
        }
         
        public void Move(Vector2 direction)
        {
            mCurMovement = direction.normalized * Speed;
        }
}