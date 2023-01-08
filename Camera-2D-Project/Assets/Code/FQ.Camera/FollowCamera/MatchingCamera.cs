using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Code.FQ.Camera.FollowCamera
{
    /// <summary>
    /// Camera which moves to the exact location of the given subject.
    /// </summary>
    public class MatchingCamera : MovingCamera
    {
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