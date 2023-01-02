using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Code.FQUnityAPI.GameStatics;
using UnityEngine;

namespace Code.FQCamera.FollowCamera
{
    /// <summary>
    /// Moves the camera to the given subject.
    /// </summary>
    public class SmoothCamera : MovingCamera
    {
        /// <summary>
        /// Unity's time implementation.
        /// </summary>
        private IUnityTime unityTime;
        
        /// <summary>
        /// Methods for Unity Statics.
        /// Instead of using the actual Unity Statics, these are used.
        /// <c>Only testing sets this</c>
        /// </summary>
        internal IUnityStaticsFactory unityStaticsFactory;

        /// <summary>
        /// Called at the end of <see cref="Start"/>.
        /// </summary>
        protected override void Initialise()
        {
            unityStaticsFactory ??= new UnityStaticsFactory();
            unityTime = unityStaticsFactory.GetTime();
        }
        
        /// <summary>
        /// Moves the Camera to the given Subject if both are found.
        /// </summary>
        /// <param name="subject"> Subject to move to. </param>
        /// <param name="camera"> Camera to move. </param>
        protected override void MoveCameraToSubject(Transform subject, Transform camera)
        {
            Vector3 goalPosition = subject.position;
            Vector3 cameraPosition = camera.position;
            goalPosition.z = cameraPosition.z;
            
            float delta = unityTime.DeltaTime;
            
            camera.position = Vector3.Lerp(cameraPosition, goalPosition, delta);
        }
    }
}