using System.Collections;
using Code.FQCamera.FollowCamera;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

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
        
        [SetUp]
        public void Setup()
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
    }
}