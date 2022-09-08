//
// NewImplementation.cs
//
// Author:
//       melquiceded balbi villanueva <mbv@projects.com>
//
// Copyright (c) 2022 MIT
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.





/*
Copyright © 2017 Jesse Nicholson  
This Source Code Form is subject to the terms of the Mozilla Public
License, v. 2.0. If a copy of the MPL was not distributed with this
file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/


using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace MyRedactedNamespace
{
      /// <summary>
      /// Class responsible for exposing undocumented functionality making the host process unkillable.
      /// </summary>
      public static class ProcessProtection
      {
            [DllImport("ntdll.dll", SetLastError = true)]
            private static extern void RtlSetProcessIsCritical(UInt32 v1, UInt32 v2, UInt32 v3);

            /// <summary>
            /// Flag for maintaining the state of protection.
            /// </summary>
            private static volatile bool s_isProtected = false;

            /// <summary>
            /// For synchronizing our current state.
            /// </summary>
            private static ReaderWriterLockSlim s_isProtectedLock = new ReaderWriterLockSlim();

            /// <summary>
            /// Gets whether or not the host process is currently protected.
            /// </summary>
            public static bool IsProtected
            {
                  get
                  {
                        try
                        {
                              s_isProtectedLock.EnterReadLock();

                              return s_isProtected;
                        }
                        finally
                        {
                              s_isProtectedLock.ExitReadLock();
                        }
                  }
            }

            /// <summary>
            /// If not alreay protected, will make the host process a system-critical process so it
            /// cannot be terminated without causing a shutdown of the entire system.
            /// </summary>
            public static void Protect()
            {
                  try
                  {
                        s_isProtectedLock.EnterWriteLock();

                        if (!s_isProtected)
                        {
                              System.Diagnostics.Process.EnterDebugMode();
                              RtlSetProcessIsCritical(1, 0, 0);
                              s_isProtected = true;
                        }
                  }
                  finally
                  {
                        s_isProtectedLock.ExitWriteLock();
                  }
            }

            /// <summary>
            /// If already protected, will remove protection from the host process, so that it will no
            /// longer be a system-critical process and thus will be able to shut down safely.
            /// </summary>
            public static void Unprotect()
            {
                  try
                  {
                        s_isProtectedLock.EnterWriteLock();

                        if (s_isProtected)
                        {
                              RtlSetProcessIsCritical(0, 0, 0);
                              s_isProtected = false;
                        }
                  }
                  finally
                  {
                        s_isProtectedLock.ExitWriteLock();
                  }
            }
      }
}