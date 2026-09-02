using UnityEngine;

namespace WebGLRescueArena
{
    public sealed class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform target;

        [SerializeField] private Vector3 offset = new Vector3(0f, 15f, -10f);

        [SerializeField] private float followSpeed = 8f;

        private void LateUpdate()
        {
            //smoothly follow, Lerp will never reach the target, so it will always be moving, but it will be smooth
            //not full correctly using Lerp
            transform.position = Vector3.Lerp(
                transform.position,
                target.position + offset,
                followSpeed * Time.deltaTime
            );
            //every frame?
            transform.rotation = Quaternion.Euler(55f, 0f, 0f);
        }
    }
}
