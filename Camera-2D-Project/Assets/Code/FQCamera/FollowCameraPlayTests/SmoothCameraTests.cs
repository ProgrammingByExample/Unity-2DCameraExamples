using System.Collections;
using Code.FQCamera.FollowCamera;
using Code.FQUnityAPI.GameStatics;
using Moq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Vector2 = System.Numerics.Vector2;

namespace Code.FQCamera.FollowCameraPlayTests
{
    public class SmoothCameraTests
    {
        private SmoothCamera testSmoothCamera;
        private Transform cameraLocation;
        private Transform subjectLocation;

        private GameObject cameraObject;
        private GameObject subjectObject;
        private GameObject holderObject;

        private Mock<IUnityTime> mockTime;
        private Mock<IUnityStaticsFactory> mockStaticFactory;
        
        private void SetUp()
        {
            cameraObject = new GameObject();
            cameraLocation = cameraObject.GetComponent<Transform>();
            
            subjectObject = new GameObject();
            subjectLocation = subjectObject.GetComponent<Transform>();
            
            holderObject = new GameObject();
            testSmoothCamera = holderObject.AddComponent<SmoothCamera>();
            testSmoothCamera.Camera = cameraLocation;
            testSmoothCamera.Subject = subjectLocation;
        }

        [TearDown]
        public void TearDown()
        {
            Object.DestroyImmediate(cameraObject);
            Object.DestroyImmediate(subjectObject);
            Object.DestroyImmediate(holderObject);
        }
        
        [UnityTest]
        public IEnumerator FrameAdvance_CameraPositionUsesLerp_WhenDeltaTimeIsSetTest()  
        {
            var startingSubjectPosition = new Vector3(12, 34, 56);
            var startingCameraPosition = new Vector3(54, 76, 23);
            float givenTime = 1;
            
            // Arrange
            SetUp();
            MakeStaticsAndTimeFactory();
            mockTime.SetupGet(x => x.Time).Returns(givenTime);
            
            subjectLocation.position = startingSubjectPosition;
            cameraLocation.position = startingCameraPosition;

            Vector3 expectedLerp = Vector3.Lerp(startingCameraPosition, startingSubjectPosition, 0);

            // Act
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();

            // Assert
            Assert.AreEqual(expectedLerp.x, cameraLocation.position.x);
            Assert.AreEqual(expectedLerp.y, cameraLocation.position.y);
        }
        
        [UnityTest]
        public IEnumerator FrameAdvance_CameraPositionZDoesNotChange_WhenLerpIsSetupTest()  
        {
            var startingSubjectPosition = new Vector3(12, 34, 56);
            var startingCameraPosition = new Vector3(54, 76, 23);
            float givenTime = 1f;
            
            // Arrange
            SetUp();
            MakeStaticsAndTimeFactory();
            mockTime.SetupGet(x => x.Time).Returns(givenTime);
            
            subjectLocation.position = startingSubjectPosition;
            cameraLocation.position = startingCameraPosition;

            Vector3 expectedLerp = Vector3.Lerp(startingCameraPosition, startingSubjectPosition, givenTime);

            // Act
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();

            // Assert
            Assert.AreEqual(startingCameraPosition.z, cameraLocation.position.z);
        }
        
        [UnityTest]
        public IEnumerator FrameAdvanceTwice_CameraLerpUsesOriginStartPosition_WhenSubjectIsBeyondPointOneDistanceTest()  
        {
            var startingSubjectPosition = new Vector3(12, 34, 56);
            var startingCameraPosition = new Vector3(54, 76, 23);
            float givenTime = 1f;
            
            // Arrange
            SetUp();
            MakeStaticsAndTimeFactory();
            mockTime.SetupGet(x => x.Time).Returns(givenTime);
            
            subjectLocation.position = startingSubjectPosition;
            cameraLocation.position = startingCameraPosition;
            
            float distCovered = (givenTime - (givenTime * 2)) * 1f;
            float journeyLength = Vector3.Distance(startingCameraPosition, startingSubjectPosition);
            startingSubjectPosition.z = startingCameraPosition.z;
            float fractionOfJourney = distCovered / journeyLength;
            
            Vector3 expectedLerp = Vector3.Lerp(startingCameraPosition, startingSubjectPosition, fractionOfJourney);

            // Act
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();

            // Assert
            Assert.AreEqual(startingCameraPosition.x, cameraLocation.position.x);
            Assert.AreEqual(startingCameraPosition.y, cameraLocation.position.y);
        }
        
        [UnityTest]
        public IEnumerator FrameAdvance3Times_CameraLerpUsesOriginStartPosition_WhenSubjectIsBeyondPointOneDistanceTest()  
        {
            var startingSubjectPosition = new Vector3(12, 34, 56);
            var startingCameraPosition = new Vector3(54, 76, 23);
            float givenTime = 1f;
            
            // Arrange
            SetUp();
            MakeStaticsAndTimeFactory();
            mockTime.SetupGet(x => x.Time).Returns(givenTime);
            
            subjectLocation.position = startingSubjectPosition;
            cameraLocation.position = startingCameraPosition;
            
            float distCovered = (givenTime - (givenTime * 3)) * 1f;
            float journeyLength = Vector3.Distance(startingCameraPosition, startingSubjectPosition);
            startingSubjectPosition.z = startingCameraPosition.z;
            float fractionOfJourney = distCovered / journeyLength;
            
            Vector3 expectedLerp = Vector3.Lerp(startingCameraPosition, startingSubjectPosition, fractionOfJourney);

            // Act
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();

            // Assert
            Assert.AreEqual(startingCameraPosition.x, cameraLocation.position.x);
            Assert.AreEqual(startingCameraPosition.y, cameraLocation.position.y);
        }

        /// <summary>
        /// Creates a statics factory and time static within it
        /// </summary>
        private void MakeStaticsAndTimeFactory()
        {
            mockStaticFactory = new Mock<IUnityStaticsFactory>();
            mockTime = new Mock<IUnityTime>();
            mockStaticFactory.Setup(x => x.GetTime()).Returns(mockTime.Object);
            testSmoothCamera.unityStaticsFactory = mockStaticFactory.Object;
        }
    }
}