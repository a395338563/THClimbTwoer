using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyGUI;

namespace THClimbTower
{
    public static class FairyGUIHelper
    {
        public static Task PlayAsync(this Transition transition)
        {
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            transition.Play(() => tcs.TrySetResult(true));
            return tcs.Task;
        }
        public static Task PlayReverseAsync(this Transition transition)
        {
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            transition.PlayReverse(() => tcs.TrySetResult(true));
            return tcs.Task;
        }
    }
}
