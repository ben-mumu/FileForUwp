﻿#pragma checksum "C:\Users\lx835\Desktop\Import\Import\XamlPage\ShowPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0B55A5A8BA47B9EBC60B150CCBF4C538"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Import.XamlPage
{
    partial class ShowPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.TopWritePage = (global::Windows.UI.Xaml.Controls.RelativePanel)(target);
                }
                break;
            case 2:
                {
                    this.WriteBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    #line 40 "..\..\..\XamlPage\ShowPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.WriteBlock).Tapped += this.WriteBlock_Tapped;
                    #line default
                }
                break;
            case 3:
                {
                    this.SHPBack = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 24 "..\..\..\XamlPage\ShowPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.SHPBack).Click += this.SHPBack_Click;
                    #line default
                }
                break;
            case 4:
                {
                    this.ClearFile = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 32 "..\..\..\XamlPage\ShowPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.ClearFile).Click += this.ClearFile_Click;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

