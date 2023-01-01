using System.Runtime.CompilerServices;
using UnityEngine;

[assembly: InternalsVisibleTo("FollowCameraPlayTests")]
namespace Code.FQCamera.FollowCamera
{
    /// <summary>
    /// Moves the camera to the given subject.
    /// </summary>
    public class SmoothCamera : MovingCamera
    {
        public int hello = 1;
        
        /// <summary>
        /// Called at the end of <see cref="Start"/>.
        /// </summary>
        protected override void Initialise()
        {
            
        }
        
        /// <summary>
        /// Moves the Camera to the given Subject if both are found.
        /// </summary>
        /// <param name="subject"> Subject to move to. </param>
        /// <param name="camera"> Camera to move. </param>
        protected override void MoveCameraToSubject(Transform subject, Transform camera)
        {
            Vector3 newPosition = subject.position;
            Vector3 cameraPosition = camera.position;
            camera.position = new Vector3(newPosition.x, newPosition.y, cameraPosition.z);
        }
    }
}