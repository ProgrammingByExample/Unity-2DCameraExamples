using System.Collections;
using Code.FQCamera.MatchCamera;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Code.FQCamera.MatchCameraTests
{
    public class MatchCamTests
    {
        private MatchCam testMatchCam;
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
            testMatchCam = holderObject.AddComponent<MatchCam>();
            testMatchCam.Camera = cameraLocation;
            testMatchCam.Subject = subjectLocation;
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
            testMatchCam.Camera = null;

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
            testMatchCam.Subject = null;

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

        [UnityTest]
        public IEnumerator FrameAdvance_CameraPositionEqualsSubjectTest() 
        {
            // Arrange
            subjectLocation.position = new Vector3(12, 34, 56);

            // Act
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();

            // Assert
            Assert.AreEqual(subjectLocation.position, cameraLocation.position);
        }
    }
}