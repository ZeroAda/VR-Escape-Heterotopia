using UnityEngine;

public class SmoothCameraFollow3 : MonoBehaviour
{
    #region Variables

    private Vector3 _offset3;
    private Quaternion _rotationOffset;
    [SerializeField] private Transform target3;
    [SerializeField] private float smoothTime3;
    [SerializeField] private float rotationLerpFactor = 0.1f; // 控制旋转跟随幅度的因子
    private Vector3 _currentVelocity3 = Vector3.zero;
    private float _currentAngularVelocity3 = 0.0f; // 用于SmoothDampAngle的当前角速度
    [SerializeField] private LayerMask collisionLayerMask;
    [SerializeField] private float collisionOffset = 0.2f;

    #endregion

    #region Unity callbacks

    private void Awake()
    {
        _offset3 = transform.position - target3.position;
        _rotationOffset = Quaternion.Euler(0, transform.eulerAngles.y - target3.eulerAngles.y, 0);
    }

    private void LateUpdate()
    {

        float wantedRotationAngle = target3.eulerAngles.y;
        float currentRotationAngle = transform.eulerAngles.y;

        // Smoothly interpolate the rotation angle
        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationLerpFactor * Time.deltaTime);

        // Convert the angle into a rotation
        Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

        // Set the position of the camera on the x-z plane to:
        // distance meters behind the target
 
        Vector3 targetPosition = target3.position - currentRotation * _offset3;
        //Vector3 targetPosition = target3.position + _offset3;

        // transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity3, smoothTime3);
        Vector3 newPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity3, smoothTime3);
        if (Physics.Linecast(target3.position, newPosition, out RaycastHit hit, collisionLayerMask))
        {
            transform.position = hit.point + hit.normal * collisionOffset;
        }
        else
        {
            transform.position = newPosition;
        }

        /// -- ///

        // Calculate the desired rotation
        float targetYRotation = target3.eulerAngles.y + _rotationOffset.eulerAngles.y;

        // If you want to smooth the rotation as well, you can use SmoothDampAngle for the y rotation
        float smoothedYRotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetYRotation, ref _currentAngularVelocity3, smoothTime3);

        // Determine the rotation amount based on the lerp factor
        float limitedYRotation = Mathf.LerpAngle(transform.eulerAngles.y, smoothedYRotation, rotationLerpFactor);

        // Apply the limited rotation while maintaining original x and z rotation
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, limitedYRotation, transform.eulerAngles.z);
        

        // // Look at the target
        // transform.LookAt(target3);
    }

    #endregion
}
