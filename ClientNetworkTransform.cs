using Unity.Netcode.Components;
using UnityEngine;

namespace Unity.MultiPlayer.Sample.Utilities.ClientAutority
{
    [DisallowMultipleComponent]
    public class ClientNetworkTransform : NetworkTransform
    {
        protected override bool OnIsServerAuthoritative()
        {
            return false;
        }
    }
}
