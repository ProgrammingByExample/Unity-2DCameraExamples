using System.Runtime.CompilerServices;
using UnityEngine;

namespace Code.FQ.Camera.FollowCamera
{
    /// <summary>
    /// Moves the camera to the given subject.
    /// </summary>
    public abstract class MovingCamera : MonoBehaviour, IFollowCamera
    {
        /// <summary>
        /// Camera to move.
        /// </summary>
        public Transform Camera { get => camera; set => camera = value; }
        
        [SerializeField]
        private Transform camera;
        
        /// <summary>
        /// Subject to move to.
        /// </summary>
        public Transform Subject { get => subject; set => subject = value; }
        
        [SerializeField]
        private Transform subject;
        
        /// <summary>
        /// True means the Subject having a null state has already been logged.
        /// This is for performance and to avoid Logging 60 times a second.
        /// </summary>
        internal bool haveLoggedSubjectIsNull;
        
        /// <summary>
        /// True means the Camera being null has already been logged.
        /// This is for performance and to avoid Logging 60 times a second.
        /// </summary>
        internal bool haveLoggedCameraIsNull;

        /// <summary>
        /// Occurs at the start of the Objects life on the frame.
        /// </summary>
        private void Start()
        {
            this.haveLoggedSubjectIsNull = false;
            this.haveLoggedCameraIsNull = false;

            Initialise();
        }

        /// <summary>
        /// Called every frame the Behaviour is enabled.
        /// </summary>
        private void Update()
        {
            if (!VerifyGivenObjects())
            {
                return;
            }

            MoveCameraToSubject(Subject, Camera);
        }

        /// <summary>
        /// Verifies the Objects used for the <see cref="MatchingCamera"/> class.
        /// </summary>
        /// <returns> True means valid. </returns>
        private bool VerifyGivenObjects()
        {
            bool objectIsValid = true;
            if (Subject == null)
            {
                LogWarningWithinObject("There is no Subject to follow.", ref this.haveLoggedSubjectIsNull);
                objectIsValid = false;
            }
            
            if (Camera == null)
            {
                LogWarningWithinObject("There is no Camera to move.", ref this.haveLoggedCameraIsNull);
                objectIsValid = false;
            }

            return objectIsValid;
        }

        /// <summary>
        /// Logs a warning for the object with the given message.
        /// Does so once using the Toggle as indication of whether the message has been logged.
        /// </summary>
        /// <param name="logMessage"> Message to log. The class object is already mentioned. </param>
        /// <param name="singleLogToggle">
        /// A bool reference as to whether the log has been done yet.
        /// True means it has been logged and false it has not.
        /// </param>
        private void LogWarningWithinObject(string logMessage, ref bool singleLogToggle)
        {
            if (!singleLogToggle)
            {
                Debug.LogWarning($"{typeof(MatchingCamera)}: {logMessage}");
                singleLogToggle = true;
            }
        }
        
        /// <summary>
        /// Moves the Camera to the given Subject if both are found.
        /// </summary>
        /// <param name="subject"> Subject to move to. </param>
        /// <param name="camera"> Camera to move. </param>
        protected abstract void MoveCameraToSubject(Transform subject, Transform camera);
        
        /// <summary>
        /// Called at the end of <see cref="Start"/>.
        /// </summary>
        protected virtual void Initialise(){}
    }
}