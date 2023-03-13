using System.Net.Sockets;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Server
{
    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Connect();
        }

        // Close connect
        private void Server_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            foreach (Socket item in clientList)
            {
                Send(item);
            }

            AddMessage("Me: " + txbMessage.Text);
            txbMessage.Clear();
        }

        IPEndPoint IP;
        Socket server;
        List<Socket> clientList;

        // Connect server
        void Connect()
        {
            clientList = new List<Socket>();
            IP = new IPEndPoint(IPAddress.Any, 9999);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            server.Bind(IP);

            Thread Listen = new Thread(() =>
            {
                try
                {
                    while (true)
                    {
                        server.Listen(100);

                        Socket client = server.Accept();

                        AddMessage("----------------New member from " + client.LocalEndPoint.ToString() + " joined----------------");

                        foreach (Socket item in clientList)
                        {
                            if (item != null)
                            {
                                item.Send(Serialize("----------------New member from " + item.LocalEndPoint.ToString() + " joined----------------"));
                            }
                        }

                        clientList.Add(client);

                        Thread receive = new Thread(Receive);
                        receive.IsBackground = true;
                        receive.Start(client);
                    }
                }
                catch
                {
                    IP = new IPEndPoint(IPAddress.Any, 9999);
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                }


            });

            Listen.IsBackground = true;
            Listen.Start();
        }

        // Close connect
        void Close()
        {
            server.Close();
        }

        // Send message
        void Send(Socket client)
        {
            if (txbMessage.Text != string.Empty && client != null)
            {
                client.Send(Serialize("Server: " + txbMessage.Text));
            }
        }

        // Receive messgae
        void Receive(object obj)
        {
            Socket client = obj as Socket;
            try
            {
                while (true)
                {
                    byte[] data = new Byte[1024 * 5000];
                    client.Receive(data);

                    string message = (string)Deserialize(data);
                    AddMessage("from " + client.LocalEndPoint.ToString() + ": " + message);

                    foreach (Socket item in clientList)
                    {
                        if (item != client && item != null)
                        {
                            item.Send(Serialize("from " + item.LocalEndPoint.ToString() + ": " + message));
                        }
                    }
                }
            }
            catch
            {
                clientList.Remove(client);
                client.Close();
            }
        }

        // Add message to list view
        void AddMessage(string s)
        {
            lsvMessage.Items.Add(new ListViewItem() { Text = s });
        }

        // Phan manh
        byte[] Serialize(object obj)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(stream, obj);

            return stream.ToArray();
        }

        // Gom phan manh
        object Deserialize(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();

            return formatter.Deserialize(stream);
        }

        // Close connect when close form
        private void server_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        private void txbMessage_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                foreach (Socket item in clientList)
                {
                    Send(item);
                }

                AddMessage("Me: " + txbMessage.Text);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                btnSend.Enabled = false;
            } else
            {
                btnSend.Enabled = true;
            }
        }
    }
}