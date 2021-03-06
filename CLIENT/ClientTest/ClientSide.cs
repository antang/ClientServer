﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NetcomLibrary;// Using Library
using System.Net;

namespace ClientTest
{
    public partial class ClientSide : Form
    {
        AgentRelay m_chatProvider = new AgentRelay();
        //ServerRelay m_serverRelay = new ServerRelay(true); //This is method calling Server, needn't !

        // Get Client's host name
        String strHostName = Dns.GetHostName();


        private enum eTcpCommands                            // Contents.. (Parameters)
        {
            //Declare values
            InvalidCommand = 0,
            ChatMessage = 1,

            QueryNameRequest = 2,
            QueryNameResponse = 3,
        };

        public ClientSide()
        {
            InitializeComponent();
        }


        //LOAD FORM: CLIENT
        private void MyChatForm_Load(object sender, EventArgs e)
        {
            //Set default cursor position on IPAdress Text Box + Set TabIndex property = 0
            txtIPAddress.Focus();

            m_chatProvider.OnNewPacketReceived += chatProvider_OnNewPacketReceived;
        }
        //END LOAD FORM


        //CLOSING FORM: CLIENT
        private void MyChatForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Disconnect Client from Server
            m_chatProvider.Dispose();
        }
        //END CLOSING FORM


        //---NOTIFY NEW CONNECTION FORM SERVER---
        void m_serverRelay_OnServerFailedToAcceptConnection(Exception ex)
        {
            //this.Invoke(new MethodInvoker(() => { lblChatScreen.Items.Insert(0, "EXCEPTION in ServerRelay: " + ex.Message); }));
            this.Invoke(new MethodInvoker(() => { txtChatScreen.AppendText("EXCEPTION in ServerRelay: " + ex.Message+"\n"); }));
        }
        void m_serverRelay_OnNewAgentConnected(AgentRelay agentRelay)
        {
            agentRelay.OnNewPacketReceived += chatProvider_OnNewPacketReceived;
            m_chatProvider = agentRelay;
        }
        //END NOTIFY NEW CONNECTION FROM SERVER

       
        //SEND PACKAGE TO SERVER
        public bool SendChatMessage(string txt)
        {
            //Set scrollbar for Send Message TextBox
            txtMessage.ScrollBars = ScrollBars.Vertical;

            //Send package to Server
            return
            //Sent content message
            m_chatProvider.SendMessage(strHostName + ":  " + txt, (int)eTcpCommands.ChatMessage);

            /// <Change object position of method to change output, by changing in ServerRelay class (BroadcastMessage()) and AgentRelay class (SendMessage())>
            //m_chatProvider.SendMessage((int)eTcpCommands.ChatMessage, txt + ":  " + strHostName);
        }
        //END SEND PACKAGE TO SERVER


        //---RECEIVE PACKAGE FROM SERVER---
        private void chatProvider_OnNewPacketReceived(AgentRelay.Packet packet, AgentRelay agentRelay)
        {
            switch (packet.Command)
            {
                    //Receive package
                case (byte)eTcpCommands.ChatMessage:
                    //this.Invoke(new MethodInvoker(() => { lblChatScreen.Items.Insert(0, AgentRelay.MakeStringFromPacketContents(packet)); }));
                    this.Invoke(new MethodInvoker(() => { txtChatScreen.AppendText(AgentRelay.MakeStringFromPacketContents(packet)+"\n"); }));
                    break;

                case (byte)eTcpCommands.QueryNameRequest:
                    //agentRelay.SendMessage((int)eTcpCommands.QueryNameResponse, "TCP/IP Test");
                    agentRelay.SendMessage("TCP/IP Test", (int)eTcpCommands.QueryNameResponse);
                    break;

                case (byte)eTcpCommands.QueryNameResponse:
                    //this.Invoke(new MethodInvoker(() => { lblChatScreen.Items.Insert(0, "NAME:  " + AgentRelay.MakeStringFromPacketContents(packet)); }));
                    this.Invoke(new MethodInvoker(() => { txtChatScreen.AppendText("NAME:  " + AgentRelay.MakeStringFromPacketContents(packet)+"\n"); }));
                    break;

                default:
                    agentRelay.SendResponse(AgentRelay.eResponseTypes.InvalidCommand);
                    break;
            }
        }
        //END RECEIVE PACKAGE FROM SERVER
        int num;

        //---BTUTTON CONNECT---
        public void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(txtIPAddress.Text,out num))
                {
                    MessageBox.Show("IP Address is invalid or the other side is not accessable!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //Connect to Server
                    m_chatProvider.Connect(txtIPAddress.Text, 1234);

                    //Set Button status
                    btnConnect.Enabled = false;
                    btnDisconnect.Enabled = true;
                    btnSend.Enabled = true;

                    //Move cursor to Message Text Box after Click/Enter Connect Button
                    txtMessage.Focus();
                    txtMessage.TabIndex = 0;

                    ///<Using SendChatMessage>: use SendChatMessage method to send package (string,...)
                    //Send Client's host name to Server  to notify new agent connected
                    SendChatMessage("<New agent received...>");
                }
                
            }
            catch
            {
                MessageBox.Show("IP Address is invalid or the other side is not accessable!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //END BUTTON CONNECT


        //---BTUTTON DISCONNECT---
        public void btnDisconnect_Click(object sender, EventArgs e)
        {
            ///<Using SendChatMessage>: use SendChatMessage method to send package (string,...)
            //Send Client's host name to Server to notify agent disconnected
            SendChatMessage("<Agent disconnected !>");

            //Disconnect Client from Server
            m_chatProvider.Dispose();

            //Set Button status
            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
            btnSend.Enabled = false;

            //LOAD FORM
            m_chatProvider.OnNewPacketReceived += chatProvider_OnNewPacketReceived;
            //END LOAD FORM
        }
        //END BUTTON DISCONNECT
       

        //---BUTTON SEND---
        public void btnSend_Click(object sender, EventArgs e)
        {
           ///<Using SendChatMessage>: use SendChatMessage method to send package (string,...)
            if (txtMessage.Text.Trim() != "")
            {
                SendChatMessage(txtMessage.Text.Trim());
                //append text
                txtChatScreen.AppendText(strHostName + " : " + txtMessage.Text + "\n");

                //Clear text box after click/enter Send button
                txtMessage.Clear();
            }
            else
            {
                txtMessage.Clear();
            }
           
        }
        //END BUTTON SEND


        //Keydown = Enter
        public void btnConnect_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnConnect.PerformClick();
        }
        public void btnSend_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Shift && e.KeyCode == Keys.Enter)
            {
                txtMessage.AppendText("\n");
            }
            else
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSend.PerformClick();
                    //remove enter key
                    string trimText;
                    trimText = this.txtMessage.Text.Replace("\r\n", "").ToString();
                    this.txtMessage.Text = trimText;
                    txtMessage.Refresh();
                }
            }
            //if (e.KeyCode == Keys.Enter) btnSend.PerformClick();
        }
        //only input IP
        private void txtIPAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            if (e.KeyChar.ToString() == ".") e.Handled = false;
        }
        //END KEYDOWN

    }//End SendMessageDemo
}//End ClientTest
