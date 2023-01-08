using UnityEngine;

namespace Code.FQ.Camera.FollowCamera
{
    /// <summary>
    /// A game object with the aim to follow another camera object around.
    /// </summary>
    public interface IFollowCamera
    {
        /// <summary>
        /// Camera to move.
        /// </summary>
        Transform Camera { get; set; }
        
        /// <summary>
        /// Subject to move to.
        /// </summary>
        Transform Subject { get; set; }
    }
}