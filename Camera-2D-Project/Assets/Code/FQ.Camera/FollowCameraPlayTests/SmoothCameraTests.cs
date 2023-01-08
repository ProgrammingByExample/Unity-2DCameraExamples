using System.Collections;
using Code.FQ.Camera.FollowCamera;
using Code.FQUnityAPI.GameStatics;
using Moq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Code.FQ.Camera.FollowCameraPlayTests
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
        
        /// <summary>
        /// Setup must be run manually when using <see cref="IEnumerator"/> as running this as
        /// an actual setup may causes Start and Update to run before tests.
        /// </summary>
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
            mockTime.SetupGet(x => x.Time).Returns(() => givenTime);
            
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
            mockTime.SetupGet(x => x.Time).Returns(() => givenTime);
            
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
            var startingSubjectPosition = new Vector3(12, 34, 23);
            var startingCameraPosition = new Vector3(54, 76, 23);
            float givenTime = 1f;
            
            // Arrange
            SetUp();
            MakeStaticsAndTimeFactory();
            mockTime.SetupGet(x => x.Time).Returns(() => givenTime);
            
            subjectLocation.position = startingSubjectPosition;
            cameraLocation.position = startingCameraPosition;
            
            float distCovered = ((givenTime * 2) - givenTime) * SmoothCamera.MovementSpeed;
            float journeyLength = Vector3.Distance(startingCameraPosition, startingSubjectPosition);
            float fractionOfJourney = distCovered / journeyLength;
            
            Vector3 expectedLerp = Vector3.Lerp(startingCameraPosition, startingSubjectPosition, fractionOfJourney);

            // Act
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            ++givenTime;
            yield return new WaitForEndOfFrame();

            // Assert
            Assert.AreEqual(expectedLerp.x, cameraLocation.position.x);
            Assert.AreEqual(expectedLerp.y, cameraLocation.position.y);
        }
        
        [UnityTest]
        public IEnumerator FrameAdvance3Times_CameraLerpUsesOriginStartPosition_WhenSubjectIsBeyondPointOneDistanceTest()  
        {
            var startingSubjectPosition = new Vector3(12, 34, 23);
            var startingCameraPosition = new Vector3(54, 76, 23);
            float givenTime = 1f;
            
            // Arrange
            SetUp();
            MakeStaticsAndTimeFactory();
            mockTime.SetupGet(x => x.Time).Returns(() => givenTime);
            
            subjectLocation.position = startingSubjectPosition;
            cameraLocation.position = startingCameraPosition;

            float distCovered = ((givenTime * 3) - givenTime) * SmoothCamera.MovementSpeed;
            float journeyLength = Vector3.Distance(startingCameraPosition, startingSubjectPosition);
            float fractionOfJourney = distCovered / journeyLength;
            
            Vector3 expectedLerp = Vector3.Lerp(startingCameraPosition, startingSubjectPosition, fractionOfJourney);

            // Act
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            ++givenTime;
            yield return new WaitForEndOfFrame();
            ++givenTime;
            yield return new WaitForEndOfFrame();

            // Assert
            Assert.AreEqual(expectedLerp.x, cameraLocation.position.x);
            Assert.AreEqual(expectedLerp.y, cameraLocation.position.y);
        }

        [UnityTest]
        public IEnumerator FrameAdvance_CameraSnapsToExactPosition_WhenSubjectIsExactlyMarginAwayTest()  
        {
            var startingSubjectPosition = new Vector3(12.1f, 34, 56);
            var startingCameraPosition = new Vector3(12, 34, 56);
            float givenTime = 1f;
            
            // Arrange
            SetUp();
            MakeStaticsAndTimeFactory();
            mockTime.SetupGet(x => x.Time).Returns(() => givenTime);
            
            subjectLocation.position = startingSubjectPosition;
            cameraLocation.position = startingCameraPosition;

            // Act
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            ++givenTime;
            yield return new WaitForEndOfFrame();

            // Assert
            Assert.AreEqual(startingSubjectPosition.x, cameraLocation.position.x);
            Assert.AreEqual(startingSubjectPosition.y, cameraLocation.position.y);
        }
        
        [UnityTest]
        public IEnumerator FrameAdvanceTwice_CameraChangesSpeed_WhenSubjectMovesFarAwayTest()  
        {
            var startingSubjectPosition = new Vector3(12, 34, 23);
            var nextSubjectPosition = new Vector3(35, 34, 23);
            var startingCameraPosition = new Vector3(54, 76, 23);
            float givenTime = 1f;
            
            // Arrange
            SetUp();
            MakeStaticsAndTimeFactory();
            mockTime.SetupGet(x => x.Time).Returns(() => givenTime);
            
            cameraLocation.position = startingCameraPosition;
            
            float distCovered = ((givenTime * 2) - givenTime) * SmoothCamera.MovementSpeed;
            float journeyLength = Vector3.Distance(startingCameraPosition, nextSubjectPosition);
            float fractionOfJourney = distCovered / journeyLength;
            
            // The test is the fraction of the Journey, the Journey Length changes and this changes.
            Vector3 expectedLerp = Vector3.Lerp(startingCameraPosition, nextSubjectPosition, fractionOfJourney);
            
            // Run the first frame
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            ++givenTime;

            // Act
            subjectLocation.position = nextSubjectPosition;
            yield return new WaitForEndOfFrame();
            ++givenTime;
            yield return new WaitForEndOfFrame();
            ++givenTime;

            // Assert
            Vector3 camPosition = cameraLocation.position;
            Assert.AreEqual(expectedLerp.x, camPosition.x);
            Assert.AreEqual(expectedLerp.y, camPosition.y);
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