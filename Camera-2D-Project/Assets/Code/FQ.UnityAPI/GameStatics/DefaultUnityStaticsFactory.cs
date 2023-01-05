namespace Code.FQUnityAPI.GameStatics
{
    /// <summary>
    /// Default implementations for Unity Statics, for the Unity API unmodified.
    /// </summary>
    public class UnityStaticsFactory : IUnityStaticsFactory
    {
        /// <summary>
        /// Returns a <see cref="IUnityTime"/> implementation.
        /// </summary>
        /// <returns> An implementation for <see cref="IUnityTime"/>. </returns>
        public IUnityTime GetTime()
        {
            return new UnityTime();
        }
    }
}