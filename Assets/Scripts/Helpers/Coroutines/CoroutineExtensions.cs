using UnityEngine;

namespace FVN.Helpers
{
    public static class CoroutineExtensions
    {
        public static void StopAndSetToNull(this Coroutine coroutine, MonoBehaviour obj)
        {
            if (coroutine != null)
            {
                obj.StopCoroutine(coroutine);
                coroutine = null;
            }
        }
    }
}
