﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace loadingStation.Base.Configuration.Config {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.6.0.0")]
    internal sealed partial class CoreLS : global::System.Configuration.ApplicationSettingsBase {
        
        private static CoreLS defaultInstance = ((CoreLS)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new CoreLS())));
        
        public static CoreLS Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("100")]
        public int ValueNumberTimeout {
            get {
                return ((int)(this["ValueNumberTimeout"]));
            }
            set {
                this["ValueNumberTimeout"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("3000")]
        public int PropelerCycleTime {
            get {
                return ((int)(this["PropelerCycleTime"]));
            }
            set {
                this["PropelerCycleTime"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("500")]
        public int EmergencyBtnCycleTime {
            get {
                return ((int)(this["EmergencyBtnCycleTime"]));
            }
            set {
                this["EmergencyBtnCycleTime"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("20000")]
        public int CounterFillingTimeout {
            get {
                return ((int)(this["CounterFillingTimeout"]));
            }
            set {
                this["CounterFillingTimeout"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("10000")]
        public int CounterWaterTimeout {
            get {
                return ((int)(this["CounterWaterTimeout"]));
            }
            set {
                this["CounterWaterTimeout"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("20000")]
        public int CounterCoolantTimeout {
            get {
                return ((int)(this["CounterCoolantTimeout"]));
            }
            set {
                this["CounterCoolantTimeout"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("10000")]
        public int CoolantFillingValue {
            get {
                return ((int)(this["CoolantFillingValue"]));
            }
            set {
                this["CoolantFillingValue"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("51")]
        public int WaterFillingValue {
            get {
                return ((int)(this["WaterFillingValue"]));
            }
            set {
                this["WaterFillingValue"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("03/11/2020 11:13:00")]
        public global::System.DateTime ChangeDaysStart {
            get {
                return ((global::System.DateTime)(this["ChangeDaysStart"]));
            }
            set {
                this["ChangeDaysStart"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("5")]
        public int ChangeDaysEnd {
            get {
                return ((int)(this["ChangeDaysEnd"]));
            }
            set {
                this["ChangeDaysEnd"] = value;
            }
        }
    }
}