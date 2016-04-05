using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NetcomLibrary;// Using Library
using System.Net;
using System.Net.Sockets;

namespace ServerTest
{
    public partial class ServerSide : Form
    {
        //SERVER REMEMBER ALL OF AGENTS CONNECTED TO...
        List<AgentRelay> m_ListofAgent = new List<AgentRelay>(); 
 
        //AgentRelay m_chatProvider = new AgentRelay(); //Server only send package to newest agent connected to...

        ServerRelay m_serverRelay = new ServerRelay(true);

        // Get Server's host name
        String strHostName = Dns.GetHostName();

        private enum eTcpCommands                            // Contents.. (Parameters)
        {
            InvalidCommand = 0,
            ChatMessage = 1,

            QueryNameRequest = 2,
            QueryNameResponse = 3,
        };

        public ServerSide()
        {
            InitializeComponent();
        }


        //LOAD FORM: SERVER
        private void MyChatForm_Load(object sender, EventArgs e)
        {
            //m_chatProvider.OnNewPacketReceived += chatProvider_OnNewPacketReceived;
            m_serverRelay.OnNewAgentConnected += m_serverRelay_OnNewAgentConnected;
            m_serverRelay.OnServerFailedToAcceptConnection += m_serverRelay_OnServerFailedToAcceptConnection;
            m_serverRelay.StartServer(null, 1234);

            m_serverRelay.AcceptIncommingConnections = true;
            //Get IP Server
            IPAddress[] IP_Local = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress ip in IP_Local)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    txt_IPServer.Text = ip.ToString();
                }
            }
        }
        //END LOAD FORM


        //CLOSING FORM: SERVER
        private void MyChatForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Disconnect Server 
            m_serverRelay.Dispose();        // m_serverRelay.StopServer(true);
        }
        //END CLOSING FORM


        //---NOTIFY NEW CONNECTION FORM CLIENTS---
        void m_serverRelay_OnServerFailedToAcceptConnection(Exception ex)
        {
            //this.Invoke(new MethodInvoker(() => { lblChatScreen.Items.Insert(0, "EXCEPTION in ServerRelay: " + ex.Message); }));
            this.Invoke(new MethodInvoker(() => { txtChatScreen.AppendText("EXCEPTION in ServerRelay: " + ex.Message + "\n"); }));
        }
        void m_serverRelay_OnNewAgentConnected(AgentRelay agentRelay)
        {
            agentRelay.OnNewPacketReceived += chatProvider_OnNewPacketReceived;

            //m_chatProvider = agentRelay;
            m_ListofAgent.Add(agentRelay);    //Adding Agent into List of Agents after Agent connected to Server

            ///<Using SendChatMessage>: use SendChatMessage method to send package (string,...)
            //Server send message to Agent for connection
            SendChatMessage("<is connecting with you>");
 
            this.Invoke(new MethodInvoker(() =>
            {
                //Send message button Enable/Disable
                btnSend.Enabled = true;

                //Server show message for new connection 
                //lblChatScreen.Items.Insert(0, "<New agent received...>");
            }));
            
        }
        //END NOTIFY NEW CONNECTION FROM CLIENTS

       
        //SEND PACKAGE TO CLIENT
        public void SendChatMessage(string txt)
        {
            //Set scrollbar for Send Message TextBox
            txtMessage.ScrollBars = ScrollBars.Vertical;

            /*
            //Send package
            return
            m_chatProvider.SendMessage(strHostName + ":  " + txt, (int)eTcpCommands.ChatMessage);
             * */

            //Send package to all of Agents connected
            foreach (var agent in m_ListofAgent)
            {
                agent.SendMessage(strHostName + ":  " + txt, (int)eTcpCommands.ChatMessage);
            }

            //Can using <<BroadcastMessage>> in ServerRelay.cs to send package to all of Agents connected. 
            //If want to send message to all of agents by BroadcastMessage: edit BroadcastMessage method: change 1 agent into List of Agent
            //BroadcastMessage(string content, int cmdCode, AgentRelay excludedAgent);

            /// <Change object position of method to change output, by changing in ServerRelay class (BroadcastMessage()) and AgentRelay class (SendMessage())>
            //m_chatProvider.SendMessage((int)eTcpCommands.ChatMessage, txt + ":  " + strHostName);
        }
        //END SEND PACKAGE TO CLIENT


        //---RECEIVE PACKAGE FROM CLIENTS---
        private void chatProvider_OnNewPacketReceived(AgentRelay.Packet packet, AgentRelay agentRelay)
        {
            switch (packet.Command)
            {
                    //Receive package
                case (byte)eTcpCommands.ChatMessage:
                    //this.Invoke(new MethodInvoker(() => { lblChatScreen.Items.Insert(0, AgentRelay.MakeStringFromPacketContents(packet)); }));
                    this.Invoke(new MethodInvoker(() => { txtChatScreen.AppendText(AgentRelay.MakeStringFromPacketContents(packet) + "\n"); }));
                    break;

                case (byte)eTcpCommands.QueryNameRequest:
                    //agentRelay.SendMessage((int)eTcpCommands.QueryNameResponse, "TCP/IP Test");
                    agentRelay.SendMessage("TCP/IP Test", (int)eTcpCommands.QueryNameResponse);
                    break;

                case (byte)eTcpCommands.QueryNameResponse:
                    //this.Invoke(new MethodInvoker(() => { lblChatScreen.Items.Insert(0, "NAME:  " + AgentRelay.MakeStringFromPacketContents(packet)); }));
                    this.Invoke(new MethodInvoker(() => { txtChatScreen.AppendText("NAME:  " + AgentRelay.MakeStringFromPacketContents(packet) + "\n"); }));

                    break;

                default:
                    agentRelay.SendResponse(AgentRelay.eResponseTypes.InvalidCommand);
                    break;
            }
        }
        //END RECEIVE PACKAGE FROM CLIENTS
   

        //---BUTTON SEND---
        private void btnSend_Click(object sender, EventArgs e)
        {
           ///<Using SendChatMessage>: use SendChatMessage method to send package (string,...)
           SendChatMessage(txtMessage.Text.Trim());
            //append text
           txtChatScreen.AppendText(strHostName + " : " + txtMessage.Text + "\n");


           //Clear text box after click/enter Send button
           txtMessage.Clear();
        }
        //END BUTTON SEND


        //Keydown = Enter
        private void btnSend_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnSend.PerformClick();
        }
        //END KEYDOWN

    }//End SendMessageDemo
}//End ServerTest
