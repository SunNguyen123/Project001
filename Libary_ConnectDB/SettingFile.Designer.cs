﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Libary_ConnectDB {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.10.0.0")]
    internal sealed partial class SettingFile : global::System.Configuration.ApplicationSettingsBase {
        
        private static SettingFile defaultInstance = ((SettingFile)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new SettingFile())));
        
        public static SettingFile Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=DESKTOP-9OR80U7\\SQLEXPRESS;Initial Catalog=DB_QLSV;Integrated Securit" +
            "y=True")]
        public string KeyDB {
            get {
                return ((string)(this["KeyDB"]));
            }
            set {
                this["KeyDB"] = value;
            }
        }
    }
}
