﻿///////////////////////////////////////////////////////////////////////////////
//
// This file was automatically generated by RANOREX.
// DO NOT MODIFY THIS FILE! It is regenerated by the designer.
// All your modifications will be lost!
// http://www.ranorex.com
//
///////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;
using Ranorex.Core.Repository;

namespace Demo1
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The NotifyWrongIP recording.
    /// </summary>
    [TestModule("006ee940-e0ef-40ab-8f1e-610f33a90cc9", ModuleType.Recording, 1)]
    public partial class NotifyWrongIP : ITestModule
    {
        /// <summary>
        /// Holds an instance of the Demo1Repository repository.
        /// </summary>
        public static Demo1Repository repo = Demo1Repository.Instance;

        static NotifyWrongIP instance = new NotifyWrongIP();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public NotifyWrongIP()
        {
            var_LinkServer = "D:\\Topic_Research\\Git\\ClientServer\\SERVER\\ServerTest\\bin\\Debug\\ServerTest.exe";
            var_IPServer = "";
            var_LinkClient = "D:\\Topic_Research\\Git\\ClientServer\\CLIENT\\ClientTest\\bin\\Debug\\ClientTest.exe";
            var_ConnectSuccessful = "is connecting with you";
            var_Message = "IP Address is invalid or the other side is not accessable!";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static NotifyWrongIP Instance
        {
            get { return instance; }
        }

#region Variables

        string _var_LinkServer;

        /// <summary>
        /// Gets or sets the value of variable var_LinkServer.
        /// </summary>
        [TestVariable("e8d3fdb9-c206-40a6-bb1c-71004e1425d6")]
        public string var_LinkServer
        {
            get { return _var_LinkServer; }
            set { _var_LinkServer = value; }
        }

        string _var_IPServer;

        /// <summary>
        /// Gets or sets the value of variable var_IPServer.
        /// </summary>
        [TestVariable("14cb10be-71c1-4153-a2ee-c982d81a5918")]
        public string var_IPServer
        {
            get { return _var_IPServer; }
            set { _var_IPServer = value; }
        }

        string _var_LinkClient;

        /// <summary>
        /// Gets or sets the value of variable var_LinkClient.
        /// </summary>
        [TestVariable("39bdb3b3-11c7-419c-94ad-0e170af5d083")]
        public string var_LinkClient
        {
            get { return _var_LinkClient; }
            set { _var_LinkClient = value; }
        }

        string _var_ConnectSuccessful;

        /// <summary>
        /// Gets or sets the value of variable var_ConnectSuccessful.
        /// </summary>
        [TestVariable("8100a788-14b3-4584-910f-bc528d8e01fa")]
        public string var_ConnectSuccessful
        {
            get { return _var_ConnectSuccessful; }
            set { _var_ConnectSuccessful = value; }
        }

        string _var_Message;

        /// <summary>
        /// Gets or sets the value of variable var_Message.
        /// </summary>
        [TestVariable("e8e82fab-f5ee-4179-9d02-daa9d2cd33b6")]
        public string var_Message
        {
            get { return _var_Message; }
            set { _var_Message = value; }
        }

#endregion

        /// <summary>
        /// Starts the replay of the static recording <see cref="Instance"/>.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("Ranorex", "5.4.6")]
        public static void Start()
        {
            TestModuleRunner.Run(Instance);
        }

        /// <summary>
        /// Performs the playback of actions in this recording.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        [System.CodeDom.Compiler.GeneratedCode("Ranorex", "5.4.6")]
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 0;
            Delay.SpeedFactor = 1.0;

            Init();

            // Run Client
            Report.Log(ReportLevel.Info, "Application", "Run Client\r\nRun application with file name from variable $var_LinkClient with arguments '' in normal mode.", new RecordItemIndex(0));
            Host.Local.RunApplication(var_LinkClient, "", "D:\\Form KMS\\ClientServer-master\\ClientServer-master\\CLIENT\\ClientTest\\bin\\Debug", false);
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Keyboard", "Key sequence '' with focus on 'ClientSide.TxtIPAddress'.", repo.ClientSide.TxtIPAddressInfo, new RecordItemIndex(1));
            repo.ClientSide.TxtIPAddress.PressKeys("", 100);
            Delay.Milliseconds(100);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'ClientSide.BtnConnect' at Center.", repo.ClientSide.BtnConnectInfo, new RecordItemIndex(2));
            repo.ClientSide.BtnConnect.Click();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Validation", "Validating AttributeEqual (Text=$var_Message) on item 'Error.Text65535'.", repo.Error.Text65535Info, new RecordItemIndex(3));
            Validate.Attribute(repo.Error.Text65535Info, "Text", var_Message);
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'Error.ButtonOK' at Center.", repo.Error.ButtonOKInfo, new RecordItemIndex(4));
            repo.Error.ButtonOK.Click();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Application", "Killing application containing item 'ClientSide'.", repo.ClientSide.SelfInfo, new RecordItemIndex(5));
            Host.Local.KillApplication(repo.ClientSide.Self);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
