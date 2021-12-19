// Copyright (c) 2021 Jim Atas. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for details.

namespace Developist.Core.Utilities
{
    public static class Ensure
    {
        public static readonly IEnsureArgument Argument = new EnsureArgument();

        private class EnsureArgument : IEnsureArgument
        {
        }
    }
}
