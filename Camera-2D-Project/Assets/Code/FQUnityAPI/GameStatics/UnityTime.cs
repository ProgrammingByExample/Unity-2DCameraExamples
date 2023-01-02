namespace Code.FQUnityAPI.GameStatics
{
    /// <summary>
    /// Interface in front of Unity's time functions.
    /// <see href="https://docs.unity3d.com/ScriptReference/Time.html"/>
    /// </summary>
    public class UnityTime : IUnityTime
    {
        /// <summary>
        /// Slows your application’s playback time to allow Unity to save screenshots in between frames.
        /// <see href="https://docs.unity3d.com/ScriptReference/Time-captureDeltaTime.html"/>
        /// </summary>
        public float CaptureDeltaTime
        {
            get => UnityEngine.Time.captureDeltaTime; 
            set => UnityEngine.Time.captureDeltaTime = value;
        }
        
        /// <summary>
        /// <see cref="CaptureFramerate" /> is the equivalent of
        /// (1.0 / <see cref="CaptureDeltaTime" />) rounded to the nearest integer.
        /// <see href="https://docs.unity3d.com/ScriptReference/Time-captureFramerate.html"/>
        /// </summary>
        public int CaptureFramerate
        {
            get => UnityEngine.Time.captureFramerate; 
            set => UnityEngine.Time.captureFramerate = value;
        }
        
        /// <summary>
        /// The interval in seconds from the last frame to the current one (Read Only).
        /// <see href="https://docs.unity3d.com/ScriptReference/Time-deltaTime.html" />
        /// </summary>
        public float DeltaTime
        {
            get => UnityEngine.Time.deltaTime;
        }

        /// <summary>
        /// The interval in seconds at which physics and other fixed frame rate updates
        /// (like MonoBehaviour's fixed update) are performed.
        /// <see href="https://docs.unity3d.com/ScriptReference/Time-fixedDeltaTime.html" />
        /// </summary>
        public float FixedDeltaTime
        {
            get => UnityEngine.Time.fixedDeltaTime; 
            set => UnityEngine.Time.fixedDeltaTime = value;
        }
        
        /// <summary>
        /// The time since the last FixedUpdate started (Read Only).
        /// This is the time in seconds since the start of the game.
        /// This value is updated in fixed increments equal to <see cref="FixedDeltaTime"/>.
        /// <see href="https://docs.unity3d.com/ScriptReference/Time-fixedTime.html" />
        /// </summary>
        public float FixedTime
        {
            get => UnityEngine.Time.fixedTime;
        }
        
        /// <summary>
        /// The double precision time since the last FixedUpdate started (Read Only).
        /// This is the time in seconds since the start of the game.
        /// <see href="https://docs.unity3d.com/ScriptReference/Time-fixedTimeAsDouble.html" />
        /// </summary>
        public double FixedTimeAsDouble
        {
            get => UnityEngine.Time.fixedTimeAsDouble;
        }
        
        /// <summary>
        /// The timeScale-independent interval in seconds from the last
        /// MonoBehaviour.FixedUpdate phase to the current one (Read Only).
        /// Unlike <see cref="FixedDeltaTime"/> this value is not affected by <see cref="TimeScale"/>.
        /// <see href="https://docs.unity3d.com/ScriptReference/Time-fixedUnscaledDeltaTime.html" />
        /// </summary>
        public float FixedUnscaledDeltaTime
        {
            get => UnityEngine.Time.fixedUnscaledDeltaTime;
        }
        
        /// <summary>
        /// The timeScale-independent time at the beginning of the last MonoBehaviour.FixedUpdate phase (Read Only).
        /// This is the time in seconds since the start of the game.
        /// This value is updated in fixed increments equal to <see cref="FixedUnscaledDeltaTime"/>.
        /// Unlike <see cref="FixedTime"/> this value is not affected by <see cref="TimeScale"/>.
        /// <see href="https://docs.unity3d.com/ScriptReference/Time-fixedUnscaledTime.html"/>
        /// </summary>
        public float FixedUnscaledTime
        {
            get => UnityEngine.Time.fixedUnscaledTime;
        }
        
        /// <summary>
        /// The double precision timeScale-independent time at the beginning of the last FixedUpdate (Read Only).
        /// This is the time in seconds since the start of the game.
        /// Returns the same value if called multiple times in a single frame.
        /// Unlike <see cref="FixedTimeAsDouble"/> this value is not affected by <see cref="TimeScale"/>.
        /// <see href="https://docs.unity3d.com/ScriptReference/Time-fixedUnscaledTimeAsDouble.html" />
        /// </summary>
        public double FixedUnscaledTimeAsDouble
        {
            get => UnityEngine.Time.fixedUnscaledTimeAsDouble;
        }
        
        /// <summary>
        /// The total number of frames since the start of the game (Read Only).
        /// This value starts at 0 and increases by 1 on each Update phase.
        /// Internally, Unity uses a 64 bit integer which it downcasts to 32 bits when this is called,
        /// and discards the most significant (i.e. top) 32 bits.
        /// <see href="https://docs.unity3d.com/ScriptReference/Time-frameCount.html" />
        /// </summary>
        public int FrameCount
        {
            get => UnityEngine.Time.frameCount;
        }
        
        /// <summary>
        /// Returns true if called inside a fixed time step callback (like MonoBehaviour's FixedUpdate),
        /// otherwise returns false.
        /// <see href="https://docs.unity3d.com/ScriptReference/Time-inFixedTimeStep.html" />
        /// </summary>
        public bool InFixedTimeStep
        {
            get => UnityEngine.Time.inFixedTimeStep;
        }
        
        /// <summary>
        /// The maximum value of <see cref="DeltaTime"/> in any given frame.
        /// This is a time in seconds that limits the increase of <see cref="Time"/> between two frames.
        /// <see href="https://docs.unity3d.com/ScriptReference/Time-maximumDeltaTime.html" />
        /// </summary>
        public float MaximumDeltaTime
        {
            get => UnityEngine.Time.maximumDeltaTime; 
            set => UnityEngine.Time.maximumDeltaTime = value;
        }
        
        /// <summary>
        /// The maximum time a frame can spend on particle updates.
        /// If the frame takes longer than this, then updates are split into multiple smaller updates.
        /// <see href="https://docs.unity3d.com/ScriptReference/Time-maximumParticleDeltaTime.html" />
        /// </summary>
        public float MaximumParticleDeltaTime
        {
            get => UnityEngine.Time.maximumParticleDeltaTime; 
            set => UnityEngine.Time.maximumParticleDeltaTime = value;
        }
        
        /// <summary>
        /// The real time in seconds since the game started (Read Only).
        /// This is the time in seconds since the start of the application,
        /// and is not constant if called multiple times in a frame.
        /// <see cref="TimeScale"/> does not affect this property.
        /// In almost all cases you should use <see cref="Time"/> or <see cref="UnscaledTime"/> instead.
        /// </summary>
        public float RealtimeSinceStartup
        {
            get => UnityEngine.Time.realtimeSinceStartup;
        }
        
        /// <summary>
        /// The real time in seconds since the game started (Read Only).
        /// Double precision version of <see cref="RealtimeSinceStartup"/>.
        /// <see href="https://docs.unity3d.com/ScriptReference/Time-realtimeSinceStartupAsDouble.html" />
        /// </summary>
        public double RealtimeSinceStartupAsDouble
        {
            get => UnityEngine.Time.realtimeSinceStartupAsDouble;
        }
        
        /// <summary>
        /// A smoothed out <see cref="DeltaTime" /> (Read Only).
        /// <see href="https://docs.unity3d.com/ScriptReference/Time-smoothDeltaTime.html" />
        /// </summary>
        public float SmoothDeltaTime
        {
            get => UnityEngine.Time.smoothDeltaTime;
        }
        
        /// <summary>
        /// The time at the beginning of this frame (Read Only).
        /// <see href="https://docs.unity3d.com/ScriptReference/Time-time.html" />
        /// </summary>
        public float Time
        {
            get => UnityEngine.Time.time;
        }
        
        /// <summary>
        /// The double precision time at the beginning of this frame (Read Only).
        /// This is the time in seconds since the start of the game.
        /// <see href="https://docs.unity3d.com/ScriptReference/Time-timeAsDouble.html" />
        /// </summary>
        public double TimeAsDouble
        {
            get => UnityEngine.Time.timeAsDouble;
        }
        
        /// <summary>
        /// The scale at which time passes.
        /// This can be used for slow motion effects or to speed up your application.
        /// When <see cref="TimeScale"/> is 1.0, time passes as fast as real time.
        /// When <see cref="TimeScale"/> is 0.5 time passes 2x slower than realtime.
        /// <see href="https://docs.unity3d.com/ScriptReference/Time-timeScale.html" />
        /// </summary>
        public float TimeScale
        {
            get => UnityEngine.Time.timeScale; 
            set => UnityEngine.Time.timeScale = value;
        }
        
        /// <summary>
        /// The time since this frame started (Read Only).
        /// This is the time in seconds since the last non-additive scene has finished loading.
        /// This behaves in the same way as <see cref="Time"/> with a negative offset.
        /// <see href="https://docs.unity3d.com/ScriptReference/Time-timeSinceLevelLoad.html" />
        /// </summary>
        public float TimeSinceLevelLoad
        {
            get => UnityEngine.Time.timeSinceLevelLoad;
        }
        
        /// <summary>
        /// The double precision time since this frame started (Read Only).
        /// This is the time in seconds since the last non-additive scene has finished loading.
        /// <see href="https://docs.unity3d.com/ScriptReference/Time-timeSinceLevelLoadAsDouble.html" />
        /// </summary>
        public double TimeSinceLevelLoadAsDouble
        {
            get => UnityEngine.Time.timeSinceLevelLoadAsDouble;
        }
        
        /// <summary>
        /// The timeScale-independent interval in seconds from the last frame to the current one (Read Only).
        /// <see href="https://docs.unity3d.com/ScriptReference/Time-unscaledDeltaTime.html" />
        /// </summary>
        public float UnscaledDeltaTime
        {
            get => UnityEngine.Time.unscaledDeltaTime;
        }

        /// <summary>
        /// The timeScale-independent time for this frame (Read Only).
        /// This is the time in seconds since the start of the game.
        /// <see href="https://docs.unity3d.com/ScriptReference/Time-unscaledTime.html" />
        /// </summary>
        public float UnscaledTime 
        {
            get => UnityEngine.Time.unscaledTime;
        }
        
        /// <summary>
        /// The double precision timeScale-independent time for this frame (Read Only).
        /// This is the time in seconds since the start of the game.
        /// <see href="https://docs.unity3d.com/ScriptReference/Time-unscaledTimeAsDouble.html" />
        /// </summary>
        public double UnscaledTimeAsDouble
        {
            get => UnityEngine.Time.unscaledTimeAsDouble;
        }
    }
}