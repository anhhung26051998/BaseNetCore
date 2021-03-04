using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XH.BaseProject.Common.Extentions
{
    public static class TaskExtension
    {
        public static TResult Await<TResult>(this Task<TResult> task)
        {
            return task.ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public static void Await(this Task task)
        {
            task.ConfigureAwait(false).GetAwaiter().GetResult();
        }
    }
}
