using UnityEngine;

public class MoveByPosition : MonoBehaviour, IMoveable 
{
        [SerializeField]
        private float Speed = 1f;
        private Vector2 mCurMovement = Vector2.zero;
        private Animator mAnimationController;


        private void Start() 
        {
            mAnimationController = GetComponentInChildren<Animator>();
        }

        private void FixedUpdate()
        {
            Vector2 curPos = transform.position;
            Vector2 targetPos = new Vector2(curPos.x + mCurMovement.x,curPos.y + mCurMovement.y);
            transform.position = targetPos;
            mAnimationController.SetBool("Walking",mCurMovement != Vector2.zero);
        }
         
        public void Move(Vector2 direction)
        {
            mCurMovement = direction.normalized * Speed;
        }
}