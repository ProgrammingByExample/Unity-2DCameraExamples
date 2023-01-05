namespace Code.FQUnityAPI.GameStatics
{
    /// <summary>
    /// Provides implementations for Unity Statics so that control is taken back for testing.
    /// </summary>
    public interface IUnityStaticsFactory
    {
        /// <summary>
        /// Returns a <see cref="IUnityTime"/> implementation.
        /// </summary>
        /// <returns> An implementation for <see cref="IUnityTime"/>. </returns>
        IUnityTime GetTime();
    }
}