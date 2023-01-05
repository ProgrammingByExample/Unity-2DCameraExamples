using System.Collections;
using Code.FQ.Camera.FollowCamera;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Code.FQ.Camera.FollowCameraPlayTests
{
    public class MatchingCameraTests
    {
        private MatchingCamera testMatchingCamera;
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
            testMatchingCamera = holderObject.AddComponent<MatchingCamera>();
            testMatchingCamera.Camera = cameraLocation;
            testMatchingCamera.Subject = subjectLocation;
        }

        [TearDown]
        public void TearDown()
        {
            Object.DestroyImmediate(cameraObject);
            Object.DestroyImmediate(subjectObject);
            Object.DestroyImmediate(holderObject);
        }

        [UnityTest]
        public IEnumerator FrameAdvance_CameraPositionMatchesX_WhenSubjectMovesTest() 
        {
            // Arrange
            subjectLocation.position = new Vector3(12, 34, 56);

            // Act
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();

            // Assert
            Assert.AreEqual(subjectLocation.position.x, cameraLocation.position.x);
        }
        
        [UnityTest]
        public IEnumerator FrameAdvance_CameraPositionMatchesY_WhenSubjectMovesTest() 
        {
            // Arrange
            subjectLocation.position = new Vector3(12, 34, 56);

            // Act
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();

            // Assert
            Assert.AreEqual(subjectLocation.position.y, cameraLocation.position.y);
        }
        
        [UnityTest]
        public IEnumerator FrameAdvance_CameraZDoesNotChange_WhenSubjectMovesTest()
        {
            int expectedZ = -4;
            
            // Arrange
            cameraLocation.position = new Vector3(3, 6, expectedZ);
            subjectLocation.position = new Vector3(12, 34, 56);

            // Act
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();

            // Assert
            Assert.AreEqual(expectedZ, cameraLocation.position.z);
        }
    }
}
