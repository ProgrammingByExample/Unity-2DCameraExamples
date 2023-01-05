using System.Collections;
using Code.FQ.Camera.FollowCamera;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Code.FQ.Camera.FollowCameraPlayTests
{
    public class MovingCameraTests
    {
        private TestMovingCamera testMovingCamera;
        private Transform cameraLocation;
        private Transform subjectLocation;

        private GameObject cameraObject;
        private GameObject subjectObject;
        private GameObject holderObject;
        
        [SetUp]
        public void Setup()
        {
            cameraObject = new GameObject();
            cameraLocation = cameraObject.GetComponent<Transform>();
            
            subjectObject = new GameObject();
            subjectLocation = subjectObject.GetComponent<Transform>();
            
            holderObject = new GameObject();
            testMovingCamera = holderObject.AddComponent<TestMovingCamera>();
            testMovingCamera.Camera = cameraLocation;
            testMovingCamera.Subject = subjectLocation;
            
            // Simply stops the class from logging messages.
            testMovingCamera.haveLoggedCameraIsNull = true;
            testMovingCamera.haveLoggedSubjectIsNull = true;
        }

        [TearDown]
        public void TearDown()
        {
            Object.DestroyImmediate(cameraObject);
            Object.DestroyImmediate(subjectObject);
            Object.DestroyImmediate(holderObject);
        }
        
        [UnityTest]
        public IEnumerator FrameAdvance_NoErrorsThrown_WhenNoCameraGivenTest() 
        {
            // Arrange
            testMovingCamera.Camera = null;

            // Act
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();

            // Assert
            Assert.Pass();
        }
        
        [UnityTest]
        public IEnumerator FrameAdvance_NoErrorsThrown_WhenNoSubjectGivenTest() 
        {
            // Arrange
            testMovingCamera.Subject = null;

            // Act
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();

            // Assert
            Assert.Pass();
        }
        
        [UnityTest]
        public IEnumerator FrameAdvance_NoErrorsThrown_WhenSubjectDoesNotMoveTest() 
        {
            // Arrange

            // Act
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();

            // Assert
            Assert.Pass();
        }
    }

    /// <summary>
    /// Attempt to test the abstract behaviours.
    /// Only used in testing.
    /// </summary>
    public class TestMovingCamera : MovingCamera
    {
        protected override void MoveCameraToSubject(Transform subject, Transform camera)
        {
            
        }
    }
}
