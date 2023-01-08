using System;
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
        /// How fast to follow.
        /// </summary>
        public const float MovementSpeed = 2;
        
        /// <summary>
        /// How far away a subject needs to be before the speed is recalculated
        /// </summary>
        public const int DistanceToAlterSpeed = 5;
        
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
        /// The original position of the goal.
        /// </summary>
        private Vector3 goalPosition;
        
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
            this.unityStaticsFactory ??= new UnityStaticsFactory();
            this.unityTime = unityStaticsFactory.GetTime();
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

            SetupToMoveIfNotMovingAndFarEnough(goalPosition, cameraPosition);

            if (this.areFollowing)
            {
                RecalculateJourneyLengthIfFarEnough(goalPosition, cameraPosition);
            }
            
            MoveToGoal(goalPosition, this.startPosition, camera);
        }

        /// <summary>
        /// Moves to the goal if following the subject.
        /// </summary>
        /// <param name="goalPosition"> The location to aim for. </param>
        /// <param name="startCameraPosition"> The start position. </param>
        /// <param name="camera"> The current camera Transform. </param>
        private void MoveToGoal(Vector3 goalPosition, Vector3 startCameraPosition, Transform camera)
        {
            if (this.areFollowing)
            {
                float distCovered = (this.unityTime.Time - startTime) * MovementSpeed;
                float fractionOfJourney = distCovered / this.journeyLength;
                camera.position = Vector3.Lerp(startCameraPosition, goalPosition, fractionOfJourney);

                StopMovementIfCloseEnough(goalPosition, camera.position, camera);
            }
        }

        /// <summary>
        /// Will stop movement if the camera is now close enough.
        /// </summary>
        /// <param name="goalPosition"> The location to aim for. </param>
        /// <param name="cameraPosition"> Camera current position. </param>
        /// <param name="camera"> The current camera Transform. </param>
        private void StopMovementIfCloseEnough(Vector3 goalPosition, Vector3 cameraPosition, Transform camera)
        {
            if (AreCloseEnough(goalPosition, cameraPosition))
            {
                camera.position = goalPosition;
                this.areFollowing = false;
            }
        }

        /// <summary>
        /// Determines if the Camera is close enough to the goal.
        /// </summary>
        /// <param name="goalPosition"> The location to aim for. </param>
        /// <param name="cameraPosition"> Camera current position. </param>
        /// <returns> True means the camera has reached the goal. </returns>
        private bool AreCloseEnough(Vector3 goalPosition, Vector3 cameraPosition)
        {
            return Vector3.Distance(cameraPosition, goalPosition) <= 0.001f;
        }

        /// <summary>
        /// Sets up a moving start if far enough from the subject.
        /// </summary>
        /// <param name="goalPosition"> The location to aim for. </param>
        /// <param name="cameraPosition"> Camera current position. </param>
        private void SetupToMoveIfNotMovingAndFarEnough(Vector3 goalPosition, Vector3 cameraPosition)
        {
            if (!this.areFollowing)
            {
                SetupToMoveIfFarEnough(goalPosition, cameraPosition);
            }
        }

        /// <summary>
        /// Recalculates journey length if the target has moved far enough away.
        /// Uses <see cref="DistanceToAlterSpeed"/> to figure this out.
        /// </summary>
        /// <param name="currentSubjectPosition"> The current subject position. </param>
        /// <param name="cameraPosition"> Current Camera position. </param>
        private void RecalculateJourneyLengthIfFarEnough(Vector3 currentSubjectPosition, Vector3 cameraPosition)
        {
            var currentJourney = Vector3.Distance(this.goalPosition, currentSubjectPosition);
            if (currentJourney >= DistanceToAlterSpeed)
            {
                SetupToMoveIfFarEnough(currentSubjectPosition, cameraPosition);
            }
        }

        /// <summary>
        /// Will set up to move if the subject is far enough.
        /// </summary>
        /// <param name="goalPosition"> The location to aim for. </param>
        /// <param name="cameraPosition"> Camera current position. </param>
        private void SetupToMoveIfFarEnough(Vector3 goalPosition, Vector3 cameraPosition)
        {
            if (AreFarEnoughToMove(goalPosition, cameraPosition, out float distance))
            {
                this.journeyLength = distance;
                this.startPosition = new Vector3(cameraPosition.x, cameraPosition.y, cameraPosition.z);
                this.goalPosition = new Vector3(goalPosition.x, goalPosition.y, goalPosition.z);
                this.startTime = this.unityTime.Time;
                this.areFollowing = true;
            }
        }

        /// <summary>
        /// Determines if the subject is far enough away.
        /// </summary>
        /// <param name="goalPosition"> The location to aim for. </param>
        /// <param name="cameraPosition"> Camera current position. </param>
        /// <param name="distance"> Returns the actual distance it is away. </param>
        /// <returns> True means it is far enough to move to. </returns>
        private bool AreFarEnoughToMove(Vector3 goalPosition, Vector3 cameraPosition, out float distance)
        {
            distance = Vector3.Distance(cameraPosition, goalPosition);
            return distance > 0.001f;
        }
    }
}