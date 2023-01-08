namespace Code.FQUnityAPI.GameStatics
{
    /// <summary>
    /// Interface in front of Unity's time functions.
    /// </summary>
    public interface IUnityTime
    {
        /// <summary>
        /// Slows your application’s playback time to allow Unity to save screenshots in between frames.
        /// <see href="https://docs.unity3d.com/ScriptReference/Time-captureDeltaTime.html"/>
        /// </summary>
        float CaptureDeltaTime { get; set; }
        
        /// <summary>
        /// <see cref="CaptureFramerate" /> is the equivalent of
        /// (1.0 / <see cref="CaptureDeltaTime" />) rounded to the nearest integer.
        /// <see href="https://docs.unity3d.com/ScriptReference/Time-captureFramerate.html"/>
        /// </summary>
        int CaptureFramerate { get; set; }
        
        /// <summary>
        /// The interval in seconds from the last frame to the current one (Read Only).
        /// <see href="https://docs.unity3d.com/ScriptReference/Time-deltaTime.html" />
        /// </summary>
        float DeltaTime { get; }

        /// <summary>
        /// The interval in seconds at which physics and other fixed frame rate updates
        /// (like MonoBehaviour's fixed update) are performed.
        /// <see href="https://docs.unity3d.com/ScriptReference/Time-fixedDeltaTime.html" />
        /// </summary>
        float FixedDeltaTime { get; set; }
        
        /// <summary>
        /// The time since the last FixedUpdate started (Read Only).
        /// This is the time in seconds since the start of the game.
        /// This value is updated in fixed increments equal to <see cref="FixedDeltaTime"/>.
        /// <see href="https://docs.unity3d.com/ScriptReference/Time-fixedTime.html" />
        /// </summary>
        float FixedTime { get; }
        
        /// <summary>
        /// The double precision time since the last FixedUpdate started (Read Only).
        /// This is the time in seconds since the start of the game.
        /// <see href="https://docs.unity3d.com/ScriptReference/Time-fixedTimeAsDouble.html" />
        /// </summary>
        double FixedTimeAsDouble { get; }
        
        /// <summary>
        /// The timeScale-independent interval in seconds from the last
        /// MonoBehaviour.FixedUpdate phase to the current one (Read Only).
        /// Unlike <see cref="FixedDeltaTime"/> this value is not affected by <see cref="TimeScale"/>.
        /// <see href="https://docs.unity3d.com/ScriptReference/Time-fixedUnscaledDeltaTime.html" />
        /// </summary>
        float FixedUnscaledDeltaTime { get; }
        
        /// <summary>
        /// The timeScale-independent time at the beginning of the last MonoBehaviour.FixedUpdate phase (Read Only).
        /// This is the time in seconds since the start of the game.
        /// This value is updated in fixed increments equal to <see cref="FixedUnscaledDeltaTime"/>.
        /// Unlike <see cref="FixedTime"/> this value is not affected by <see cref="TimeScale"/>.
        /// <see href="https://docs.unity3d.com/ScriptReference/Time-fixedUnscaledTime.html"/>
        /// </summary>
        float FixedUnscaledTime { get; }
        
        /// <summary>
        /// The double precision timeScale-independent time at the beginning of the last FixedUpdate (Read Only).
        /// This is the time in seconds since the start of the game.
        /// Returns the same value if called multiple times in a single frame.
        /// Unlike <see cref="FixedTimeAsDouble"/> this value is not affected by <see cref="TimeScale"/>.
        /// <see href="https://docs.unity3d.com/ScriptReference/Time-fixedUnscaledTimeAsDouble.html" />
        /// </summary>
        double FixedUnscaledTimeAsDouble { get; }
        
        /// <summary>
        /// The total number of frames since the start of the game (Read Only).
        /// This value starts at 0 and increases by 1 on each Update phase.
        /// Internally, Unity uses a 64 bit integer which it downcasts to 32 bits when this is called,
        /// and discards the most significant (i.e. top) 32 bits.
        /// <see href="https://docs.unity3d.com/ScriptReference/Time-frameCount.html" />
        /// </summary>
        int FrameCount { get; }
        
        /// <summary>
        /// Returns true if called inside a fixed time step callback (like MonoBehaviour's FixedUpdate),
        /// otherwise returns false.
        /// <see href="https://docs.unity3d.com/ScriptReference/Time-inFixedTimeStep.html" />
        /// </summary>
        bool InFixedTimeStep { get; }
        
        /// <summary>
        /// The maximum value of <see cref="DeltaTime"/> in any given frame.
        /// This is a time in seconds that limits the increase of <see cref="Time"/> between two frames.
        /// <see href="https://docs.unity3d.com/ScriptReference/Time-maximumDeltaTime.html" />
        /// </summary>
        float MaximumDeltaTime { get; set; }
        
        /// <summary>
        /// The maximum time a frame can spend on particle updates.
        /// If the frame takes longer than this, then updates are split into multiple smaller updates.
        /// <see href="https://docs.unity3d.com/ScriptReference/Time-maximumParticleDeltaTime.html" />
        /// </summary>
        float MaximumParticleDeltaTime { get; set; }
        
        /// <summary>
        /// The real time in seconds since the game started (Read Only).
        /// This is the time in seconds since the start of the application,
        /// and is not constant if called multiple times in a frame.
        /// <see cref="TimeScale"/> does not affect this property.
        /// In almost all cases you should use <see cref="Time"/> or <see cref="UnscaledTime"/> instead.
        /// </summary>
        float RealtimeSinceStartup { get; }
        
        /// <summary>
        /// The real time in seconds since the game started (Read Only).
        /// Double precision version of <see cref="RealtimeSinceStartup"/>.
        /// <see href="https://docs.unity3d.com/ScriptReference/Time-realtimeSinceStartupAsDouble.html" />
        /// </summary>
        double RealtimeSinceStartupAsDouble { get; }
        
        /// <summary>
        /// A smoothed out <see cref="DeltaTime" /> (Read Only).
        /// <see href="https://docs.unity3d.com/ScriptReference/Time-smoothDeltaTime.html" />
        /// </summary>
        float SmoothDeltaTime { get; }
        
        /// <summary>
        /// The time at the beginning of this frame (Read Only).
        /// <see href="https://docs.unity3d.com/ScriptReference/Time-time.html" />
        /// </summary>
        float Time { get; }
        
        /// <summary>
        /// The double precision time at the beginning of this frame (Read Only).
        /// This is the time in seconds since the start of the game.
        /// <see href="https://docs.unity3d.com/ScriptReference/Time-timeAsDouble.html" />
        /// </summary>
        double TimeAsDouble { get; }
        
        /// <summary>
        /// The scale at which time passes.
        /// This can be used for slow motion effects or to speed up your application.
        /// When <see cref="TimeScale"/> is 1.0, time passes as fast as real time.
        /// When <see cref="TimeScale"/> is 0.5 time passes 2x slower than realtime.
        /// <see href="https://docs.unity3d.com/ScriptReference/Time-timeScale.html" />
        /// </summary>
        float TimeScale { get; set; }
        
        /// <summary>
        /// The time since this frame started (Read Only).
        /// This is the time in seconds since the last non-additive scene has finished loading.
        /// This behaves in the same way as <see cref="Time"/> with a negative offset.
        /// <see href="https://docs.unity3d.com/ScriptReference/Time-timeSinceLevelLoad.html" />
        /// </summary>
        float TimeSinceLevelLoad { get; }
        
        /// <summary>
        /// The double precision time since this frame started (Read Only).
        /// This is the time in seconds since the last non-additive scene has finished loading.
        /// <see href="https://docs.unity3d.com/ScriptReference/Time-timeSinceLevelLoadAsDouble.html" />
        /// </summary>
        double TimeSinceLevelLoadAsDouble { get; }
        
        /// <summary>
        /// The timeScale-independent interval in seconds from the last frame to the current one (Read Only).
        /// <see href="https://docs.unity3d.com/ScriptReference/Time-unscaledDeltaTime.html" />
        /// </summary>
        float UnscaledDeltaTime { get; }
        
        /// <summary>
        /// The timeScale-independent time for this frame (Read Only).
        /// This is the time in seconds since the start of the game.
        /// <see href="https://docs.unity3d.com/ScriptReference/Time-unscaledTime.html" />
        /// </summary>
        float UnscaledTime { get; }
        
        /// <summary>
        /// The double precision timeScale-independent time for this frame (Read Only).
        /// This is the time in seconds since the start of the game.
        /// <see href="https://docs.unity3d.com/ScriptReference/Time-unscaledTimeAsDouble.html" />
        /// </summary>
        double UnscaledTimeAsDouble { get; }
    }
}