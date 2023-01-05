using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Code.FQUnityAPI.GameStatics;
using UnityEngine;

namespace Code.FQ.Camera.FollowCamera
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
        /// True means we have recognised that moving is something to do and are now doing it.
        /// </summary>
        private bool areFollowing;

        /// <summary>
        /// Position at the start of movement.
        /// </summary>
        private Vector3 startPosition;
        
        /// <summary>
        /// How for to travel to the target
        /// </summary>
        private float journeyLength;
        
        /// <summary>
        /// Seconds in the application when we started moving.
        /// </summary>
        private float startTime;
        
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
            
            if (!this.areFollowing)
            {
                this.journeyLength = Vector3.Distance(cameraPosition, goalPosition);
                if (this.journeyLength > 0.001f)
                {
                    this.startPosition = new Vector3(cameraPosition.x,cameraPosition.y,cameraPosition.z);
                    this.startTime = this.unityTime.Time;
                    this.areFollowing = true;
                }
            }

            if (this.areFollowing)
            {
                float distCovered = (this.unityTime.Time - startTime) * 1f;
                float fractionOfJourney = distCovered / journeyLength;
                camera.position = Vector3.Lerp(startPosition, goalPosition, fractionOfJourney);

                if (Vector3.Distance(cameraPosition, goalPosition) <= 0.001f)
                {
                    camera.position = goalPosition;
                    this.areFollowing = false;
                }
            }
        }
    }
}