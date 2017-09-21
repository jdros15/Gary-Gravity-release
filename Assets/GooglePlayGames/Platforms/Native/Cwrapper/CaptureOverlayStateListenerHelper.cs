﻿// <copyright file="CaptureOverlayStateListenerHelper.cs" company="Google Inc.">
// Copyright (C) 2016 Google Inc.
//
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//
//  http://www.apache.org/licenses/LICENSE-2.0
//
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>

#if UNITY_ANDROID


namespace GooglePlayGames.Native.Cwrapper
{
    using System;
    using System.Runtime.InteropServices;
    using System.Text;

    internal static class CaptureOverlayStateListenerHelper
    {
        internal delegate void OnCaptureOverlayStateChangedCallback(
            /* from(VideoCaptureOverlayState_t) */ Types.VideoCaptureOverlayState arg0,
            /* from(void *) */ IntPtr arg1);

        [DllImport(SymbolLocation.NativeSymbolLocation)]
        internal static extern void CaptureOverlayStateListenerHelper_SetOnCaptureOverlayStateChangedCallback(
            HandleRef self,
            /* from(RealTimeEventListenerHelper_OnCaptureOverlayStateChangedCallback_t) */OnCaptureOverlayStateChangedCallback callback,
            /* from(void *) */IntPtr callback_arg);

        [DllImport(SymbolLocation.NativeSymbolLocation)]
        internal static extern /* from(CaptureOverlayStateListenerHelper_t) */ IntPtr CaptureOverlayStateListenerHelper_Construct();

        [DllImport(SymbolLocation.NativeSymbolLocation)]
        internal static extern void CaptureOverlayStateListenerHelper_Dispose(
            HandleRef self);
    }
}
#endif // (UNITY_ANDROID || UNITY_IPHONE)
